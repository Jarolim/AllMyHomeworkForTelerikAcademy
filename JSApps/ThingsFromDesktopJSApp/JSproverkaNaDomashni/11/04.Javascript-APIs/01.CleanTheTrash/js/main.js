(function () {
  'use strict';

  document.addEventListener('dragstart', function (event) {
    event.dataTransfer.effectAllowed = 'move';
    event.dataTransfer.setData('text/plain', '#' + event.target.id);
  }, false);

  var binEl = document.querySelector('#bin');

  binEl.addEventListener('dragenter', function (event) {
    event.target.classList.add('opened');
    event.dropEffect = 'move';
  }, false);

  binEl.addEventListener('dragover', function (event) {
    event.preventDefault();
  }, false);

  binEl.addEventListener('dragleave', function (event) {
    event.target.classList.remove('opened');
  }, false);

  binEl.addEventListener('drop', function (event) {
    event.preventDefault();
    var draggedEl = document.querySelector(event.dataTransfer.getData('text/plain'));
    draggedEl.parentElement.removeChild(draggedEl);
    event.target.classList.remove('opened');

    if (document.querySelectorAll('[draggable]').length === 0) {
      showSuccess();
    }
  }, false);

  function showSuccess() {
    document.querySelector('#success').classList.add('visible');
  }
})();
