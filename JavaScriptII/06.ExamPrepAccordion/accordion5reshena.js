var controls = (function () {

    //444444444444444444444444444444start
    function hidePrev(item){
        var prev = item.previousElementSibling;
        while (prev) {
            var sublist = prev.querySelector("ul");
            if (sublist) {
                sublist.style.display = "none";
            }

            prev = prev.previousElementSibling;
        }
    }
    function hideNext(item) {
        var next = item.nextElementSibling;
        while (next) {
            var sublist = next.querySelector("ul");
            if (sublist) {
                sublist.style.display = "none";
            }
            next = next.nextElementSibling;
        }
    }
    //444444444444444444444444444444end
    //---------------------------------------------------------------------
    function Accordion(selector) {
        var title;
        var items = [];
        var accItem = document.querySelector(selector);

        //33333333333333333333333333333start
        accItem.addEventListener("click", function (ev) {

            if (!ev) {
                ev = window.event;
            }

            ev.stopPropagation(); //ne e nujno
            ev.preventDefault(); //ne e nujno

            //anchor element
            var clickedItem = ev.target;
            if (!(clickedItem instanceof HTMLAnchorElement)) { //fixed a bug kato se klikne blizo do anchor
                return;
            }

            hidePrev(clickedItem.parentNode); //4444444444444444
            hideNext(clickedItem.parentNode); //4444444444444444

            var sublist = clickedItem.nextElementSibling;

            if (!sublist) { //ako nqma siblings dava greshka
                return;
            }
            if (sublist.style.display === "none") {
                sublist.style.display = "";
            }
            else {
                sublist.style.display = "none";          
            }

            //44444444444444444444444444start
            var liItem = clickedItem.parentNode;
            var list = liItem.parentNode;
            var node = list.firstChild;
            while (node) {
                node.getElementByTagName("ul")[0].style.display = "none";
                node = node.nextElementSibling;
            }

            //44444444444444444444444444end
           
        }, false)
        //33333333333333333333333end

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
        //5555555555555555555555555start2
        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i++) {
                serializedItems.push(items[i].serialize());
            }
            return serializedItems;
        }
        //5555555555555555555555555end2
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
        //555555555555555555555555555555555start

        this.serialize = function (selector) {
        var thisItem = {
            title:title
        };
        if (items.length > 0) {
            var serializedItems = [];
            for (var i = 0; i < items.length; i++) {
                var serItem = items[i].serialize();
                serializedItems.push(serItem);
            }
            thisItem.items = serializedItems;
        }
        return thisItem;
    }

    //555555555555555555555555555555555end

    }
    //---------------------------------------------------------------------
    


    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        }
    }

}());