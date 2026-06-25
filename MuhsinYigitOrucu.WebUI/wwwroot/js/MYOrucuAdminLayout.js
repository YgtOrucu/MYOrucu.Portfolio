(function () {
    'use strict';

    var sidebar = document.getElementById('adminSidebar');
    var backdrop = document.getElementById('sidebarBackdrop');
    var toggle = document.getElementById('sidebarToggle');
    var BREAKPOINT = 992;

    function openSidebar() {
        sidebar.classList.add('open');
        backdrop.classList.add('visible');
        toggle.setAttribute('aria-expanded', 'true');
        document.body.style.overflow = 'hidden';
    }

    function closeSidebar() {
        sidebar.classList.remove('open');
        backdrop.classList.remove('visible');
        toggle.setAttribute('aria-expanded', 'false');
        document.body.style.overflow = '';
    }

    function isMobile() { return window.innerWidth < BREAKPOINT; }

    toggle.addEventListener('click', function () {
        sidebar.classList.contains('open') ? closeSidebar() : openSidebar();
    });

    backdrop.addEventListener('click', closeSidebar);

    sidebar.querySelectorAll('.sidebar-link').forEach(function (link) {
        link.addEventListener('click', function () {
            if (isMobile()) closeSidebar();
        });
    });

    window.addEventListener('resize', function () {
        if (!isMobile()) {
            closeSidebar();
            document.body.style.overflow = '';
        }
    }, { passive: true });

    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape' && sidebar.classList.contains('open')) {
            closeSidebar();
            toggle.focus();
        }
    });

    document.querySelectorAll('.alert.alert-success, .alert.alert-danger').forEach(function (el) {
        setTimeout(function () {
            var bsAlert = bootstrap.Alert.getOrCreateInstance(el);
            if (bsAlert) bsAlert.close();
        }, 5000);
    });

})();