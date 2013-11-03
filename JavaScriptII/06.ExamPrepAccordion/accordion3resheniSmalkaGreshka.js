var controls = (function () {


    //---------------------------------------------------------------------
    function Accordion(selector) {
        var title;
        var items = [];
        var accItem = document.querySelector(selector);

        //Treta zada4a
        accItem.addEventListener("click", function (ev) {

            if (!ev) {
                ev = window.event;
            }

            ev.stopPropagation(); //ne e nujno
            ev.preventDefault(); //ne e nujno

            //anchor element
            var clickedItem = ev.target;
            var sublist = clickedItem.nextElementSibling;

            if (sublist.style.display === "none") {
                sublist.style.display = "";
            }
            else {
                sublist.style.display = "none";
            }

        }, false)
        //end of Treta zada4a

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
                sublist.style.display = "none"; // 3ta zada4a

                for (var i = 0; i < items.length; i++) {
                    var subItem = items[i].render();
                    sublist.appendChild(subItem);
                }
                itemNode.appendChild(sublist);
                //itemNode.onclick = ... // 3ta zada4a
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