var controls = (function () {

    function Accordion(selector) {

        var items = [];
        var accItem = document.querySelector(selector);
        var itemsList = document.createElement("ul"); //1111 za ul 
        //accItem.appendChild(itemsList); //1111 za ul
        
        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
        }

        this.render = function () {
            //var accFragment = document.createDocumentFragment(); 1111 za ul
            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            } //zachistwane za povtoren render
            while (itemsList.firstChild) {
                itemsList.removeChild(itemsList.firstChild);
            } //zachistwane za povtoren render

            for (var i = 0; i < items.length; i++) {
                var domItem = items[i].render();
                itemsList.appendChild(domItem); // 1111 ne ni trqbwa fragment
            }          
            accItem.appendChild(itemsList); //1111 za ul
        }


    }

    function Item(title) {

        this.render = function () {
            var itemNode = document.createElement("li"); //1111 li
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