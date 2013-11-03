var controls = (function () {


    //---------------------------------------------------------------------
    function Accordion(selector) {
        var title;
        var items = [];
        var accItem = document.querySelector(selector);
        var itemsList = document.createElement("ul");

        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem;
        }

        this.render = function () {
            //var accordionFragment = document.createDocumentFragment();

            //while (itemsList.firstChild) {
            //    itemsList.removeChild(itemsList.firstChild);
            //}//Зачистваме

            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            }//Зачистваме

            var thisList = itemsList.cloneNode(true);

            for (var i = 0; i < items.length; i++) {
                var domItem = items[i].render();
                //accordionFragment.appendChild(domItem);
                thisList.appendChild(domItem);
            }
            //accItem.appendChild(itemsList);
            accItem.appendChild(thisList);

            return this;
        }
    }
    //---------------------------------------------------------------------


    //---------------------------------------------------------------------
    function Item(title) {

        var items = [];

        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem;
        };

        this.render = function () {
            var itemNode = document.createElement("li");

            itemNode.innerHTML = "<a href '#' >" + title + "</a>";
            if (items.length > 0) {

                var sublist = document.createElement("ul");

                for (var i = 0; i < items.length; i++) {
                    var subItem = items[i].render();
                    sublist.appendChild(subItem);
                }
                itemNode.appendChild(sublist);
            }

            return itemNode;
        }

    }
    //---------------------------------------------------------------------


    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        }
    }

}());