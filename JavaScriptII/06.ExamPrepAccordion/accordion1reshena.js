var controls = (function () {


//---------------------------------------------------------------------
    function Accordion(selector) {

        var items = [];
        var accItem = document.querySelector(selector);

        this.add = function(title) {
            var newItem = new Item(title);
            items.push(newItem);
        };

        this.render = function() {
            var accordionFragment = document.createDocumentFragment();

            for (var i = 0; i < items.length; i++) {
                var domItem = items[i].render();
                accordionFragment.appendChild(domItem);
            }      
            accItem.appendChild(accordionFragment);
        };
    }
//---------------------------------------------------------------------


//---------------------------------------------------------------------
    function Item(title) {

        this.render = function () {
            var itemNode = document.createElement("div");
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