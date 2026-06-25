(function () {
    'use strict';

    /* ── Lightbox ── */
    var lb = document.getElementById('pd-lightbox');
    var lbImg = document.getElementById('pd-lightbox-img');
    var lbClose = document.getElementById('pd-lightbox-close');

    function openLightbox(src, alt) {
        lbImg.src = src;
        lbImg.alt = alt || '';
        lb.classList.add('open');
        document.body.style.overflow = 'hidden';
    }
    function closeLightbox() {
        lb.classList.remove('open');
        lbImg.src = '';
        document.body.style.overflow = '';
    }

    document.querySelectorAll('.pd-gallery-item').forEach(function (item) {
        function trigger() {
            var src = item.getAttribute('data-src') || item.querySelector('img')?.src;
            var alt = item.querySelector('img')?.alt || '';
            if (src) openLightbox(src, alt);
        }
        item.addEventListener('click', trigger);
        item.addEventListener('keydown', function (e) {
            if (e.key === 'Enter' || e.key === ' ') { e.preventDefault(); trigger(); }
        });
    });

    lbClose.addEventListener('click', closeLightbox);
    lb.addEventListener('click', function (e) {
        if (e.target === lb) closeLightbox();
    });
    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') closeLightbox();
    });

    /* ── Back to top ── */
    var btt = document.getElementById('pd-back-top');
    window.addEventListener('scroll', function () {
        btt.classList.toggle('show', window.scrollY > 300);
    }, { passive: true });
    btt.addEventListener('click', function (e) {
        e.preventDefault();
        window.scrollTo({ top: 0, behavior: 'smooth' });
    });

})();