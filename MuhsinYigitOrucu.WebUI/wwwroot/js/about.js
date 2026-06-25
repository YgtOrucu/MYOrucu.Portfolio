(function () {
    'use strict';

    var twList = document.getElementById('typewriterList');
    var twBtn = document.getElementById('addTypewriter');

    function addTypewriterRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="ac-input" placeholder="Senior .NET Developer" value="' + escHtml(value || '') + '" />' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır"><i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove();
            reindexTypewriter();
        });
        twList.appendChild(row);
        reindexTypewriter();
    }

    function reindexTypewriter() {
        twList.querySelectorAll('input').forEach(function (inp, i) {
            inp.name = 'TypewriterTitles[' + i + ']';
        });
    }

    twBtn.addEventListener('click', function () { addTypewriterRow(''); });

    var bioList = document.getElementById('bioParagraphList');
    var bioBtn = document.getElementById('addBioParagraph');

    function addBioParagraphRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<textarea class="ac-input ac-textarea" rows="3" placeholder="Biyografi paragrafı...">' + escHtml(value || '') + '</textarea>' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır"><i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove();
            reindexBio();
        });
        bioList.appendChild(row);
        reindexBio();
    }

    function reindexBio() {
        bioList.querySelectorAll('textarea').forEach(function (ta, i) {
            ta.name = 'BioParagraphs[' + i + ']';
        });
    }

    bioBtn.addEventListener('click', function () { addBioParagraphRow(''); });

    var qiList = document.getElementById('quickInfoList');
    var qiBtn = document.getElementById('addQuickInfo');

    function addQuickInfoRow(key, value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="ac-input key-input" placeholder="Anahtar (örn: Deneyim)" value="' + escHtml(key || '') + '" />' +
            '<input type="text" class="ac-input" placeholder="Değer (örn: 5+ Yıl)" value="' + escHtml(value || '') + '" />' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır"><i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove();
            reindexQuickInfo();
        });
        qiList.appendChild(row);
        reindexQuickInfo();
    }

    function reindexQuickInfo() {
        qiList.querySelectorAll('.dyn-row').forEach(function (row, i) {
            var inputs = row.querySelectorAll('input');
            inputs[0].name = 'QuickInfo[' + i + '].Key';
            inputs[1].name = 'QuickInfo[' + i + '].Value';
        });
    }

    qiBtn.addEventListener('click', function () { addQuickInfoRow('', ''); });

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');
    }

}());



(function () {
    'use strict';

    function escHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');
    }

    function bindRemoveButtons(list, reindexFn) {
        list.querySelectorAll('.btn-dyn-remove').forEach(function (btn) {
            if (btn._bound) return;
            btn._bound = true;
            btn.addEventListener('click', function () {
                btn.closest('.dyn-row').remove();
                reindexFn();
            });
        });
    }

    var twList = document.getElementById('typewriterList');
    var twBtn = document.getElementById('addTypewriter');

    function reindexTypewriter() {
        twList.querySelectorAll('input').forEach(function (inp, i) {
            inp.name = 'TypewriterTitles[' + i + ']';
        });
    }

    function addTypewriterRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="au-input" name="" placeholder="Senior .NET Developer" value="' + escHtml(value || '') + '" />' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır"><i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove(); reindexTypewriter();
        });
        twList.appendChild(row);
        reindexTypewriter();
    }

    bindRemoveButtons(twList, reindexTypewriter);
    reindexTypewriter();
    twBtn.addEventListener('click', function () { addTypewriterRow(''); });

    var bioList = document.getElementById('bioParagraphList');
    var bioBtn = document.getElementById('addBioParagraph');

    function reindexBio() {
        bioList.querySelectorAll('textarea').forEach(function (ta, i) {
            ta.name = 'BioParagraphs[' + i + ']';
        });
    }

    function addBioParagraphRow(value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<textarea class="au-textarea" name="" rows="3" placeholder="Biyografi paragrafı...">' + escHtml(value || '') + '</textarea>' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır"><i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove(); reindexBio();
        });
        bioList.appendChild(row);
        reindexBio();
    }

    bindRemoveButtons(bioList, reindexBio);
    reindexBio();
    bioBtn.addEventListener('click', function () { addBioParagraphRow(''); });

    var qiList = document.getElementById('quickInfoList');
    var qiBtn = document.getElementById('addQuickInfo');

    function reindexQuickInfo() {
        qiList.querySelectorAll('.dyn-row').forEach(function (row, i) {
            var inputs = row.querySelectorAll('input');
            inputs[0].name = 'QuickInfo[' + i + '].Key';
            inputs[1].name = 'QuickInfo[' + i + '].Value';
        });
    }

    function addQuickInfoRow(key, value) {
        var row = document.createElement('div');
        row.className = 'dyn-row';
        row.innerHTML =
            '<input type="text" class="au-input key-input" name="" placeholder="Anahtar (örn: Deneyim)" value="' + escHtml(key || '') + '" />' +
            '<input type="text" class="au-input" name="" placeholder="Değer (örn: 5+ Yıl)" value="' + escHtml(value || '') + '" />' +
            '<button type="button" class="btn-dyn-remove" title="Kaldır"><i class="bi bi-trash3"></i></button>';
        row.querySelector('.btn-dyn-remove').addEventListener('click', function () {
            row.remove(); reindexQuickInfo();
        });
        qiList.appendChild(row);
        reindexQuickInfo();
    }

    bindRemoveButtons(qiList, reindexQuickInfo);
    reindexQuickInfo();
    qiBtn.addEventListener('click', function () { addQuickInfoRow('', ''); });

}());