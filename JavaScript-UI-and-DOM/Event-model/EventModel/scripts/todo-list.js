(function () {
    var todo = document.getElementById('todo'),
        addButton = document.getElementById('add'),
        deleteButton = document.createElement('button'),
        showButton = document.getElementById('show'),
        hideButton = document.getElementById('hide'),
        todoList = document.getElementById('todo-list');

    deleteButton.type = 'button';
    deleteButton.innerHTML = 'delete';
    deleteButton.className = 'delete';

    var onHideButtonClick = function () {
        todoList.style.display = 'none';
    };

    var onShowButtonClick = function () {
        todoList.style.display = '';
    };

    var onDeleteButtonClick = function (ev) {
        var li = ev.target.parentNode;
        todoList.removeChild(li);
    };

    var onAddButtonClick = function () {
        var span = document.createElement('span'),
            li = document.createElement('li'),
            button = deleteButton.cloneNode(true);

        if (!todo.value) {
            return;
        }

        span.innerHTML = todo.value;
        todo.value = '';
        button.addEventListener('click', onDeleteButtonClick);
        li.appendChild(button);
        li.appendChild(span);
        todoList.appendChild(li);
    };

    addButton.addEventListener('click', onAddButtonClick);
    hideButton.addEventListener('click', onHideButtonClick);
    showButton.addEventListener('click', onShowButtonClick);
}());