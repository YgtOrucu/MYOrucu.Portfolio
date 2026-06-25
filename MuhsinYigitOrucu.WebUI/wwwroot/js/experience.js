(function () {
    'use strict';

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;').replace(/"/g, '&quot;')
            .replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    var descList = document.getElementById('descriptionList');
    var descBtn = document.getElementById('addDescription');

    function reindexDesc() {
        descList.querySelectorAll('textarea').forEach(function (ta, i) {
            ta.name = 'Description[' + i + ']';
        });
    }

    function addDescRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<textarea class="ec-input ec-textarea" rows="2"' +
            ' placeholder="Mikroservis altyapısını .NET 8 ile sıfırdan tasarladım...">' +
            escHtml(value || '') + '</textarea>' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır">' +
            '<i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove(); reindexDesc();
        });
        descList.appendChild(row);
        reindexDesc();
    }

    descBtn.addEventListener('click', function () { addDescRow(''); });

    var techList = document.getElementById('techList');
    var techBtn = document.getElementById('addTech');

    function reindexTech() {
        techList.querySelectorAll('input').forEach(function (inp, i) {
            inp.name = 'UseTechnology[' + i + ']';
        });
    }

    function addTechRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="ec-input"' +
            ' placeholder=".NET 8 / Azure / Redis ..."' +
            ' value="' + escHtml(value || '') + '" />' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır">' +
            '<i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove(); reindexTech();
        });
        techList.appendChild(row);
        reindexTech();
    }

    techBtn.addEventListener('click', function () { addTechRow(''); });

}());


(function () {
    'use strict';

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;').replace(/"/g, '&quot;')
            .replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    function bindRemove(list, reindexFn) {
        list.querySelectorAll('.btn-dyn-remove').forEach(function (btn) {
            if (btn._bound) return;
            btn._bound = true;
            btn.addEventListener('click', function () {
                btn.closest('.dyn-row').remove(); reindexFn();
            });
        });
    }

    var descList = document.getElementById('descriptionList');
    var descBtn = document.getElementById('addDescription');

    function reindexDesc() {
        descList.querySelectorAll('textarea').forEach(function (ta, i) {
            ta.name = 'Description[' + i + ']';
        });
    }

    function addDescRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<textarea class="eu-input eu-textarea" rows="2"' +
            ' placeholder="Başarı veya sorumluluk...">' +
            escHtml(value || '') + '</textarea>' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır">' +
            '<i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove(); reindexDesc();
        });
        descList.appendChild(row);
        reindexDesc();
    }

    bindRemove(descList, reindexDesc);
    reindexDesc();
    descBtn.addEventListener('click', function () { addDescRow(''); });

    var techList = document.getElementById('techList');
    var techBtn = document.getElementById('addTech');

    function reindexTech() {
        techList.querySelectorAll('input').forEach(function (inp, i) {
            inp.name = 'UseTechnology[' + i + ']';
        });
    }

    function addTechRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="eu-input"' +
            ' placeholder=".NET 8 / Azure / Redis ..."' +
            ' value="' + escHtml(value || '') + '" />' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır">' +
            '<i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove(); reindexTech();
        });
        techList.appendChild(row);
        reindexTech();
    }

    bindRemove(techList, reindexTech);
    reindexTech();
    techBtn.addEventListener('click', function () { addTechRow(''); });

}());