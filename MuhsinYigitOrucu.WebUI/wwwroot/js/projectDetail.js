/*PROJECT CREATE*/

(function () {
    'use strict';

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;').replace(/"/g, '&quot;')
            .replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    function makeList(listId, btnId, namePrefix, placeholder, useTextarea) {
        var list = document.getElementById(listId);
        var addBtn = document.getElementById(btnId);

        function reindex() {
            var tag = useTextarea ? 'textarea' : 'input';
            list.querySelectorAll(tag).forEach(function (el, i) {
                el.name = namePrefix + '[' + i + ']';
            });
        }

        function addRow(value) {
            var row = document.createElement('div');
            row.className = 'dyn-row';
            var field = useTextarea
                ? '<textarea class="pdc-input pdc-textarea" rows="2" placeholder="' + placeholder + '">' + escHtml(value || '') + '</textarea>'
                : '<input type="text" class="pdc-input" placeholder="' + placeholder + '" value="' + escHtml(value || '') + '" />';
            row.innerHTML = field +
                '<button type="button" class="btn-dyn-remove" title="Kaldır">' +
                '<i class="bi bi-trash3"></i></button>';
            row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
                row.remove(); reindex();
            });
            list.appendChild(row);
            reindex();
        }

        addBtn.addEventListener('click', function () { addRow(''); });
    }

    makeList('techList', 'addTech', 'UseTechnology', '.NET 8 / React / PostgreSQL ...', false);
    makeList('featureList', 'addFeature', 'Features', 'JWT tabanlı kimlik doğrulama sistemi...', true);
    makeList('challengeList', 'addChallenge', 'Challenges', 'N+1 sorgu problemi → eager loading ile çözüldü...', true);
    (function initFilePreview() {
        var pairs = [
            {
                inputName: 'CoverImageFile',
                infoId: 'coverFileInfo',
                nameId: 'coverFileName',
                countId: null
            },
            {
                inputName: 'GalleryImageFile',
                infoId: 'galleryFileInfo',
                nameId: 'galleryFileName',
                countId: 'galleryFileCount'
            }
        ];

        pairs.forEach(function (pair) {
            var input = document.querySelector('input[name="' + pair.inputName + '"]');
            var infoBox = document.getElementById(pair.infoId);
            var nameEl = document.getElementById(pair.nameId);
            var countEl = pair.countId ? document.getElementById(pair.countId) : null;

            if (!input || !infoBox || !nameEl) return;

            input.addEventListener('change', function () {
                var files = Array.from(this.files || []);
                if (!files.length) {
                    infoBox.classList.remove('visible');
                    nameEl.textContent = '—';
                    if (countEl) countEl.textContent = '';
                    return;
                }

                if (files.length === 1) {
                    /* Uzun ismi kırp */
                    var name = files[0].name;
                    nameEl.textContent = name.length > 40
                        ? name.substring(0, 38) + '…'
                        : name;
                    if (countEl) countEl.textContent = '';
                } else {
                    nameEl.textContent = files[0].name.length > 28
                        ? files[0].name.substring(0, 26) + '…'
                        : files[0].name;
                    if (countEl) countEl.textContent = '+' + (files.length - 1) + ' daha';
                }

                infoBox.classList.add('visible');
            });
        });
    }());
}());

/*PROJECT CREATE*/




/*PROJECT UPDATE*/

(function () {
    'use strict';

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;').replace(/"/g, '&quot;')
            .replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    function makeList(listId, btnId, namePrefix, placeholder, useTextarea) {
        var list = document.getElementById(listId);
        var addBtn = document.getElementById(btnId);

        function reindex() {
            var tag = useTextarea ? 'textarea' : 'input';
            list.querySelectorAll(tag).forEach(function (el, i) {
                el.name = namePrefix + '[' + i + ']';
            });
        }

        function bindExisting() {
            list.querySelectorAll('.btn-dyn-remove').forEach(function (btn) {
                if (btn._bound) return;
                btn._bound = true;
                btn.addEventListener('click', function () { btn.closest('.dyn-row').remove(); reindex(); });
            });
        }

        function addRow(value) {
            var row = document.createElement('div');
            row.className = 'dyn-row';
            var field = useTextarea
                ? '<textarea class="pdu-input pdu-textarea" rows="2" placeholder="' + placeholder + '">' + escHtml(value || '') + '</textarea>'
                : '<input type="text" class="pdu-input" placeholder="' + placeholder + '" value="' + escHtml(value || '') + '" />';
            row.innerHTML = field +
                '<button type="button" class="btn-dyn-remove" title="Kaldır">' +
                '<i class="bi bi-trash3"></i></button>';
            row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
                row.remove(); reindex();
            });
            list.appendChild(row);
            reindex();
        }

        bindExisting();
        reindex();
        addBtn.addEventListener('click', function () { addRow(''); });
    }

    makeList('techList', 'addTech', 'UseTechnology', '.NET 8 / React ...', false);
    makeList('featureList', 'addFeature', 'Features', 'Özellik açıklaması...', true);
    makeList('challengeList', 'addChallenge', 'Challenges', 'N+1 sorgu problemi → eager loading ile çözüldü...', true);



    (function initGalleryImageDelete() {
        var galleryGrid = document.querySelector('.img-preview-grid');
        if (!galleryGrid) return;

        function reindexGalleryInputs() {
            var cards = galleryGrid.querySelectorAll('.gallery-thumb');
            cards.forEach(function (card, newIndex) {
                card.setAttribute('data-index', newIndex);
                var hiddenInput = card.querySelector('.gallery-hidden-input');
                if (hiddenInput) {
                    hiddenInput.name = 'GalleryImages[' + newIndex + ']';
                }
            });
        }

        galleryGrid.addEventListener('click', function (e) {
            var deleteBtn = e.target.closest('.btn-img-delete');
            if (!deleteBtn) return;

            var card = deleteBtn.closest('.gallery-thumb');
            if (card) {
                card.remove();
                reindexGalleryInputs();
            }
        });
    }());

    (function initFilePreview() {
        var pairs = [
            {
                inputName: 'CoverImageFile',
                infoId: 'coverFileInfo',
                nameId: 'coverFileName',
                countId: null
            },
            {
                inputName: 'GalleryImageFile',
                infoId: 'galleryFileInfo',
                nameId: 'galleryFileName',
                countId: 'galleryFileCount'
            }
        ];

        pairs.forEach(function (pair) {
            var input = document.querySelector('input[name="' + pair.inputName + '"]');
            var infoBox = document.getElementById(pair.infoId);
            var nameEl = document.getElementById(pair.nameId);
            var countEl = pair.countId ? document.getElementById(pair.countId) : null;

            if (!input || !infoBox || !nameEl) return;

            input.addEventListener('change', function () {
                var files = Array.from(this.files || []);
                if (!files.length) {
                    infoBox.classList.remove('visible');
                    nameEl.textContent = '—';
                    if (countEl) countEl.textContent = '';
                    return;
                }

                if (files.length === 1) {
                    var name = files[0].name;
                    nameEl.textContent = name.length > 40
                        ? name.substring(0, 38) + '…'
                        : name;
                    if (countEl) countEl.textContent = '';
                } else {
                    nameEl.textContent = files[0].name.length > 28
                        ? files[0].name.substring(0, 26) + '…'
                        : files[0].name;
                    if (countEl) countEl.textContent = '+' + (files.length - 1) + ' daha';
                }

                infoBox.classList.add('visible');
            });
        });
    }());

    (function initGalleryDelete() {
        var grid = document.querySelector('.img-preview-grid');
        var deletedContainer = document.querySelector('#deletedImagesContainer');
        if (!grid || !deletedContainer) return;

        function reindexKeep() {
            var index = 0;
            grid.querySelectorAll('.gallery-thumb').forEach(function (thumb) {
                var keepInput = thumb.querySelector('.gallery-keep-input');
                if (keepInput && !keepInput.disabled) {
                    keepInput.name = 'GalleryImages[' + index + ']';
                    index++;
                }
            });
        }

        function bindThumb(thumb) {
            var deleteBtn = thumb.querySelector('.btn-img-delete');
            var keepInput = thumb.querySelector('.gallery-keep-input');
            var imgUrl = thumb.getAttribute('data-url');

            var restoreBtn = document.createElement('button');
            restoreBtn.type = 'button';
            restoreBtn.className = 'btn-img-restore';
            restoreBtn.title = 'Geri Al';
            restoreBtn.innerHTML = '<i class="bi bi-arrow-counterclockwise"></i>';
            thumb.appendChild(restoreBtn);

            deleteBtn.addEventListener('click', function () {
                thumb.classList.add('marked-delete');

                if (keepInput) {
                    keepInput.disabled = true;
                }

                var delInput = document.createElement('input');
                delInput.type = 'hidden';
                delInput.name = 'DeleteGalleryImages';
                delInput.value = imgUrl;
                delInput.className = 'deleted-img-input';
                delInput.setAttribute('data-target-url', imgUrl);

                deletedContainer.appendChild(delInput);

                reindexKeep();
            });

            restoreBtn.addEventListener('click', function () {
                thumb.classList.remove('marked-delete');

                if (keepInput) {
                    keepInput.disabled = false;
                }

                var delInput = deletedContainer.querySelector('.deleted-img-input[data-target-url="' + imgUrl + '"]');
                if (delInput) {
                    delInput.remove();
                }

                reindexKeep();
            });
        }

        grid.querySelectorAll('.gallery-thumb').forEach(bindThumb);
        reindexKeep();
    }());
}());

/*PROJECT UPDATE*/