(function () {
    'use strict';

    var list = document.getElementById('skillItemList');
    var addBtn = document.getElementById('addSkillItem');

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;').replace(/"/g, '&quot;')
            .replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    function reindex() {
        list.querySelectorAll('.dyn-row').forEach(function (row, i) {
            var inputs = row.querySelectorAll('input');
            inputs[0].name = 'SkillItem[' + i + '].Key';
            inputs[1].name = 'SkillItem[' + i + '].Value';
        });
    }

    function addRow(keyVal, valueVal) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="sc-input"' +
            '       placeholder="C# / .NET / React ..."' +
            '       value="' + escHtml(keyVal || '') + '" />' +
            '<input type="text" class="sc-input"' +
            '       placeholder="bi bi-code-slash"' +
            '       value="' + escHtml(valueVal || '') + '" />' +
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

    addBtn.addEventListener('click', function () { addRow('', ''); });

}());


(function () {
    'use strict';

    var list = document.getElementById('skillItemList');
    var addBtn = document.getElementById('addSkillItem');

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;').replace(/"/g, '&quot;')
            .replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    function reindex() {
        list.querySelectorAll('.dyn-row').forEach(function (row, i) {
            var inputs = row.querySelectorAll('input');
            inputs[0].name = 'SkillItem[' + i + '].Key';
            inputs[1].name = 'SkillItem[' + i + '].Value';
        });
    }
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

    function addRow(keyVal, valueVal) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="su-input"' +
            '       placeholder="C# / .NET / React ..."' +
            '       value="' + escHtml(keyVal || '') + '" />' +
            '<input type="text" class="su-input"' +
            '       placeholder="bi bi-code-slash"' +
            '       value="' + escHtml(valueVal || '') + '" />' +
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

    bindExistingRows();
    reindex();

    addBtn.addEventListener('click', function () { addRow('', ''); });

}());