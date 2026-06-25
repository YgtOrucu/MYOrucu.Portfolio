using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Context;
using MuhsinYigitOrucu.DataAccessLayer.Repository;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(MYOrucuPortfolioContext context) : base(context)
        {
        }
    }
}
