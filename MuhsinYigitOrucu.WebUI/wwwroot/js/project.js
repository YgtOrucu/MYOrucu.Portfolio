//PROJECT CREATE PAGE JAVASCRIPT

(function () {
    'use strict';

    var list = document.getElementById('techList');
    var addBtn = document.getElementById('addTech');

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;').replace(/"/g, '&quot;')
            .replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    function reindex() {
        list.querySelectorAll('input[type="text"]').forEach(function (inp, i) {
            inp.name = 'UseTechnology[' + i + ']';
        });
    }
    function addRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="pc-input"' +
            '       placeholder=".NET 8 / React / PostgreSQL ..."' +
            '       value="' + escHtml(value || '') + '" />' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır">' +
            '    <i class="bi bi-trash3"></i>' +
            '</button>';

        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove();
            reindex();
        });

        list.appendChild(row);
        reindex();
    }

    addBtn.addEventListener('click', function () { addRow(''); });

}());


//PROJECT UPDATE PAGE JAVASCRIPT

(function () {
    'use strict';

    var list = document.getElementById('techList');
    var addBtn = document.getElementById('addTech');

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;').replace(/"/g, '&quot;')
            .replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    /* Tüm satırların name index'lerini baştan sona yeniden yaz */
    function reindex() {
        list.querySelectorAll('input[type="text"]').forEach(function (inp, i) {
            inp.name = 'UseTechnology[' + i + ']';
        });
    }

    /* SSR ile gelen mevcut satırlara sil butonunu bağla */
    function bindExistingRows() {
        list.querySelectorAll('.btn-dyn-remove').forEach(function (btn) {
            if (btn._bound) return;
            btn._bound = true;
            btn.addEventListener('click', function () {
                btn.closest('.dyn-row').remove();
                reindex();
            });
        });
    }

    /* Yeni satır oluştur */
    function addRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="pu-input"' +
            '       placeholder=".NET 8 / React / PostgreSQL ..."' +
            '       value="' + escHtml(value || '') + '" />' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır">' +
            '    <i class="bi bi-trash3"></i>' +
            '</button>';

        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove();
            reindex();
        });

        list.appendChild(row);
        reindex();
    }

    /* Başlangıç */
    bindExistingRows();
    reindex();

    addBtn.addEventListener('click', function () { addRow(''); });

}());