(function () {
    var MainControler = function (param) {
        this.param = param;
    }

    MainControler.prototype = {
        init: function () {
            this.initTodoList();
        },
        initTodoList: function () {
            this.todoList = new TodoList({
                todoListContainer: this.param.todoListContainer,
                txtItemName: this.param.txtItemName,
                btnAddItem: this.param.btnAddItem,
                btnRemoveItem: this.param.btnRemoveItem,
                btnHideItem: this.param.btnHideItem,
                btnShowAllItem: this.param.btnShowAllItem
            });
            this.todoList.init();
        }
    }
    
    attachEventHandler(window,"load", function () {
        var mainControler = new MainControler({
            // add parameters in MainControler
            todoListContainer: "todoListContainer",
            txtItemName: "txtItemName",
            btnAddItem: "btnAddItem",
            btnRemoveItem: "btnRemoveItem",
            btnHideItem: "btnHideItem",
            btnShowAllItem: "btnShowAllItem"
        });
        mainControler.init();
    });

    
    function attachEventHandler(element, eventType, eventHandler) {
        if (document.addEventListener) {
            element.addEventListener(eventType, eventHandler, false); 
        }
        else if (document.attachEvent) {
            element.attachEvent("on" + eventType, eventHandler);
        }
        else {
            element["on" + eventType] = eventHandler;
        }
    }

})();