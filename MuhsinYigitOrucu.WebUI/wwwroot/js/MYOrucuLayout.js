(function () {
    'use strict';
    var loader = document.getElementById('page-loader');
    var mainContent = document.getElementById('main-content');

    setTimeout(function () {
        loader.classList.add('hidden');
        mainContent.classList.add('visible');
    }, 500);

    var typewriterEl = document.getElementById('typewriter-text');
    var titles = window.appSettings?.typewriterTitles || ["Full-Stack Developer", "Web Developer"];
    var tIdx = 0, cIdx = 0, deleting = false;

    function typeLoop() {
        var current = titles[tIdx];
        if (!deleting) {
            typewriterEl.textContent = current.slice(0, ++cIdx);
            if (cIdx === current.length) {
                deleting = true;
                setTimeout(typeLoop, 1800);
                return;
            }
            setTimeout(typeLoop, 85);
        } else {
            typewriterEl.textContent = current.slice(0, --cIdx);
            if (cIdx === 0) {
                deleting = false;
                tIdx = (tIdx + 1) % titles.length;
                setTimeout(typeLoop, 400);
                return;
            }
            setTimeout(typeLoop, 45);
        }
    }
    typeLoop();
    var navbar = document.getElementById('mainNavbar');
    window.addEventListener('scroll', function () {
        navbar.classList.toggle('scrolled', window.scrollY > 20);
    }, { passive: true });
    var sections = document.querySelectorAll('section[id]');
    var navLinks = document.querySelectorAll('.navbar-nav .nav-link');

    function updateActiveLink() {
        var scrollY = window.scrollY + 120;
        sections.forEach(function (sec) {
            if (scrollY >= sec.offsetTop && scrollY < sec.offsetTop + sec.offsetHeight) {
                navLinks.forEach(function (link) {
                    link.classList.toggle('active', link.getAttribute('href') === '#' + sec.id);
                });
            }
        });
    }
    window.addEventListener('scroll', updateActiveLink, { passive: true });
    updateActiveLink();
    var backTop = document.getElementById('backToTop');
    window.addEventListener('scroll', function () {
        backTop.classList.toggle('show', window.scrollY > 300);
    }, { passive: true });

    backTop.addEventListener('click', function (e) {
        e.preventDefault();
        window.scrollTo({ top: 0, behavior: 'smooth' });
    });
    (function initAdminModal() {
        var modal = document.getElementById('adminLoginModal');
        if (!modal) return;

        var panelLogin = document.getElementById('panelLogin');
        var panelReg = document.getElementById('panelRegister');
        var tabLogin = document.getElementById('tabLogin');
        var tabReg = document.getElementById('tabRegister');
        var goToRegister = document.getElementById('goToRegister');
        var goToLogin = document.getElementById('goToLogin');
        var headingText = document.getElementById('modalHeadingText');
        var subText = document.getElementById('modalSubText');
        var loginEmailInput = document.getElementById('loginEmail');

        function showPanel(which) {
            if (which === 'login') {
                panelLogin.classList.remove('admin-panel-hidden');
                panelReg.classList.add('admin-panel-hidden');
                tabLogin.classList.add('active');
                tabReg.classList.remove('active');
                headingText.textContent = 'Yönetici Girişi';
                subText.textContent = 'Panele erişmek için giriş yapın';
            } else {
                panelReg.classList.remove('admin-panel-hidden');
                panelLogin.classList.add('admin-panel-hidden');
                tabReg.classList.add('active');
                tabLogin.classList.remove('active');
                headingText.textContent = 'Yeni Hesap Oluştur';
                subText.textContent = 'Yönetici hesabı oluşturun';
            }
        }

        tabLogin.addEventListener('click', function () { showPanel('login'); });
        tabReg.addEventListener('click', function () { showPanel('register'); });
        goToRegister.addEventListener('click', function () { showPanel('register'); });
        goToLogin.addEventListener('click', function () { showPanel('login'); });


        modal.addEventListener('show.bs.modal', function () {
            var hasRegisterErrors = window.authBackendData?.hasRegisterErrors || "false";

            if (hasRegisterErrors === "true") {
                showPanel('register');
            } else {
                showPanel('login');
            }
        });

        modal.querySelectorAll('.admin-eye-btn').forEach(function (btn) {
            btn.addEventListener('click', function () {
                var targetId = this.getAttribute('data-target');
                var input = document.getElementById(targetId);
                var icon = this.querySelector('i');
                if (!input) return;

                if (input.type === 'password') {
                    input.type = 'text';
                    icon.classList.replace('bi-eye', 'bi-eye-slash');
                } else {
                    input.type = 'password';
                    icon.classList.replace('bi-eye-slash', 'bi-eye');
                }
            });
        });

        var showLoginFromBackend = window.authBackendData?.showLogin || "false";
        var registeredEmail = window.authBackendData?.registeredEmail || "";
        var hasRegisterErrors = window.authBackendData?.hasRegisterErrors || "false";
        var hasLoginErrors = window.authBackendData?.hasLoginErrors || "false";

        if (showLoginFromBackend === "true") {
            showPanel('login');

            if (loginEmailInput && registeredEmail !== "") {
                loginEmailInput.value = registeredEmail;
            }
            var bsModal = bootstrap.Modal.getOrCreateInstance(modal);
            bsModal.show();
        }

        if (hasRegisterErrors === "true") {
            showPanel('register');
            var bsModal = bootstrap.Modal.getOrCreateInstance(modal);
            bsModal.show();
        }

        if (hasLoginErrors === "true") {
            showPanel('login');
            var bsModal = bootstrap.Modal.getOrCreateInstance(modal);
            bsModal.show();
        }

    }());
})();
