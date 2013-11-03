var controls = (function () {

    function Accordion(selector) {

        var items = [];
        
        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
        }

        this.render = function () {
            var accFragment = document.createDocumentFragment();
            for (var i = 0; i < items.length; i++) {
                var domItem = items[i].render();
                accFragment.appendChild(domItem);
            }

            var accItem = document.querySelector(selector);
            accItem.appendChild(accFragment);
        }


    }

    function Item(title) {

        this.render = function () {
            var itemNode = document.createElement("div");
            itemNode.innerHTML = title;
            return itemNode;
        }

    }

    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        }
    }




}());