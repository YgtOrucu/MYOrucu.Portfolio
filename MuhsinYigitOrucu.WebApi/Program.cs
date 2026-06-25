using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MuhsinYigitOrucu.BusinessLayer.DependencyInjection;
using MuhsinYigitOrucu.DataAccessLayer.DependencyInjection;
using MuhsinYigitOrucu.BusinessLayer.Validations.ValidationMarker;
using MuhsinYigitOrucu.DataAccessLayer.Context;
using MuhsinYigitOrucu.EntityLayer.Entities;
using MuhsinYigitOrucu.WebApi.ErrorDescriberIdendity;
using MuhsinYigitOrucu.BusinessLayer.MailConfigs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MYOrucuPortfolioContext>(opt =>
{
    var Address = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseSqlServer(Address);
});

builder.Services.AddHttpClient("OpenAIClient", client =>
{
    var baseUrl = builder.Configuration.GetSection("OpenAIAddress")["DefaultAdress"];
    if (baseUrl == null)
        throw new InvalidOperationException("OpenAI API adresi yapılandırma dosyasında bulunamadı.");
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 5;
    opt.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<MYOrucuPortfolioContext>()
.AddErrorDescriber<TurkishIdentityErrorDescriber>();

builder.Services.AddValidatorsFromAssemblyContaining<MarkerValidator>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddAutoMapper(opt => opt.AddMaps(typeof(Program)));
builder.Services.AddBusinessLayerServices();
builder.Services.AddDataAccessLayerServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
async Task SeedRolesAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "User", "Admin Yardımcısı" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

await SeedRolesAsync(app);


using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var email = builder.Configuration.GetSection("AdminSeed")["Email"];
    var password = builder.Configuration.GetSection("AdminSeed")["Password"];
    var nameSurname = builder.Configuration.GetSection("AdminSeed")["NameSurname"];
    var userName = builder.Configuration.GetSection("AdminSeed")["UserName"];

    if (!await roleManager.RoleExistsAsync("Admin"))
        await roleManager.CreateAsync(new IdentityRole("Admin"));

    if (!await roleManager.RoleExistsAsync("User"))
        await roleManager.CreateAsync(new IdentityRole("User"));

    if (!await roleManager.RoleExistsAsync("Admin Yardımcısı"))
        await roleManager.CreateAsync(new IdentityRole("Admin Yardımcısı"));


    var user = await userManager.FindByEmailAsync(email ?? "");

    if (user == null)
    {
        user = new AppUser
        {
            NameSurname = nameSurname,
            Email = email,
            UserName = userName
        };

        var createResult = await userManager.CreateAsync(user, password);

        if (!createResult.Succeeded)
            throw new Exception("Admin user oluşturulamadı: " +
                string.Join(", ", createResult.Errors.Select(e => e.Description)));


        var roles = await userManager.GetRolesAsync(user);

        if (roles.Any())
            await userManager.RemoveFromRolesAsync(user, roles);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
