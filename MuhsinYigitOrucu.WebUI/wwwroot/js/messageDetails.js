document.addEventListener('DOMContentLoaded', function () {
    'use strict';

    var aiBtn = document.getElementById('aiBtn');
    var sendBtn = document.getElementById('sendBtn');
    var replyBody = document.getElementById('ReplyBody');
    var aiThinking = document.getElementById('aiThinking');

    if (!aiBtn) return;

    var messageId = document.querySelector('[name="MessageId"]').value;

    aiBtn.addEventListener('click', function () {

        aiBtn.classList.add('loading');
        aiBtn.disabled = true;
        sendBtn.disabled = true;
        aiThinking.classList.add('visible');
        replyBody.style.opacity = '.4';

        fetch('/AdminMessage/GenerateAiReply?messageId=' + messageId, {
            method: 'GET'
        })
            .then(function (response) {
                if (!response.ok) throw new Error('Sunucu hatası: ' + response.status);
                return response.text();
            })
            .then(function (aiText) {
                replyBody.value = aiText;
                resetAiState();
            })
            .catch(function (err) {
                console.error('AI yanıt hatası:', err);
                resetAiState();
            });
    });

    function resetAiState() {
        aiBtn.classList.remove('loading');
        aiBtn.disabled = false;
        sendBtn.disabled = false;
        aiThinking.classList.remove('visible');
        replyBody.style.opacity = '1';
    }
});