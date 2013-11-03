var controls = (function () {


//---------------------------------------------------------------------
    function Accordion(selector) {
        var title;
        var items = [];
        var accItem = document.querySelector(selector);
        var itemsList = document.createElement("ul");

        this.add = function(title) {
            var newItem = new Item(title);
            items.push(newItem);
        };

        this.render = function() {
            //var accordionFragment = document.createDocumentFragment();

            while (itemsList.firstChild) {
                itemsList.removeChild(itemsList.firstChild);
            }//Зачистваме

            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            }//Зачистваме

            for (var i = 0; i < items.length; i++) {
                var domItem = items[i].render();
                //accordionFragment.appendChild(domItem);
                itemsList.appendChild(domItem);
            }      
            //accItem.appendChild(itemsList);
            accItem.appendChild(itemsList);
        };
    }
//---------------------------------------------------------------------


//---------------------------------------------------------------------
    function Item(title) {

        this.render = function () {
            var itemNode = document.createElement("li");
            itemNode.innerHTML = title;
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