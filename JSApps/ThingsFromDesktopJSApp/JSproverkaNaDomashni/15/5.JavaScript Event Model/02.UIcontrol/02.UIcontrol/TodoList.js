(function () {
    var elementList = [];
    TodoList = function (param) {
        this.todoListContainer = document.getElementById(param.todoListContainer);
        this.txtItemName = document.getElementById(param.txtItemName);
        this.btnAddItem = document.getElementById(param.btnAddItem);
        this.btnRemoveItem = document.getElementById(param.btnRemoveItem);
        this.btnHideItem = document.getElementById(param.btnHideItem);
        this.btnShowAllItem = document.getElementById(param.btnShowAllItem);
    }

    TodoList.prototype = {
        init: function (){
            this.initEvents();
        },
        initEvents: function () {
            var that = this;
            attachEventHandler(this.btnAddItem, "click", function (ev) {
                ev.preventDefault();
                var li = document.createElement("li");
                li.className = "visible";
                var element = document.createElement("input");
                element.type = "radio";
                element.name = "items";
                var id = generateRandomNumber(1, 100000);
                element.id = id;
                li.appendChild(element);
                var label = document.createElement("label");
                label.innerHTML = that.txtItemName.value;
                label.setAttribute("for", id);
                li.appendChild(label);
                that.todoListContainer.appendChild(li);
                that.txtItemName.value = "";
                elementList.push(li);
            });
            attachEventHandler(this.btnRemoveItem, "click", function (ev) {
                ev.preventDefault();
                for (var i = 0; i < elementList.length; i++) {
                    var element = elementList[i];
                    if (element.firstChild.checked) {
                        that.todoListContainer.removeChild(element);
                        elementList.splice(i, 1);
                        i--;
                    }
                }
            });
            attachEventHandler(this.btnHideItem, "click", function (ev) {
                ev.preventDefault();
                for (var i = 0; i < elementList.length; i++) {
                    var element = elementList[i];
                    if (element.firstChild.checked) {
                        element.className = "hidden";
                    }
                }
                changeVisibility(elementList);
            });
            attachEventHandler(this.btnShowAllItem, "click", function (ev) {
                ev.preventDefault();
                for (var i = 0; i < elementList.length; i++) {
                    var element = elementList[i];
                    element.className = "visible";
                    element.firstChild.checked = false;
                }
                changeVisibility(elementList);
            });
            
        }
    }

    function changeVisibility(elementList) {
        for (var i = 0; i < elementList.length; i++) {
            if (elementList[i].className == "hidden") {
                elementList[i].style.display = "none";
            }
            else if (elementList[i].className == "visible") {
                elementList[i].style.display = "";
            }
        }
    }

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

    function generateRandomNumber(start, end) {
        var number = Math.floor(Math.random() * (end - start)) + start;
        return number;
    }
})();