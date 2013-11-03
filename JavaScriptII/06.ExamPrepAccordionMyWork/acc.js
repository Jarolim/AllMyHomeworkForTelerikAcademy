var controls = (function () {
    //44444444444444444444444start
    function hidePrev(item) {
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
    //44444444444444444444444end

    function Accordion(selector) {

        var items = [];
        var accItem = document.querySelector(selector);

        //333333333333333333333333333333333333333333333start
        accItem.addEventListener("click", 
            function (ev) {
                if (!ev) {
                    ev = window.event;
                }
                ev.stopPropagation();
                ev.preventDefault();

                //<a>
                var clickedItem = ev.target;
                if (!(clickedItem instanceof HTMLAnchorElement)) { //fix bug next sibling making it to work with a
                    return;
                }

                //44444444444444444444444444start
                var liItem = clickedItem.parentNode;

                hidePrev(liItem);
                hideNext(liItem);
                //44444444444444444444444444end

                var sublist = clickedItem.nextElementSibling;
                if (!sublist) { //shtoto kato kliknem na desktop dava greshka
                    return;
                }
                if (sublist.style.display==="none") {
                    sublist.style.display = "";
                } else {
                    sublist.style.display = "none";
                }               

        }, false);
        //333333333333333333333333333333333333333333333end

        var itemsList = document.createElement("ul"); //1111 za ul 
        //accItem.appendChild(itemsList); //1111 za ul
        
        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem; //2222222222novo
        }

        this.render = function () {
            //var accFragment = document.createDocumentFragment(); 1111 za ul
            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            } //zachistwane za povtoren render
            while (itemsList.firstChild) {
                itemsList.removeChild(itemsList.firstChild);
            } //zachistwane za povtoren render

            //var thisList = itemsList.cloneNode(true); moje i taka zachistwane

            for (var i = 0; i < items.length; i++) {
                var domItem = items[i].render();
                itemsList.appendChild(domItem); // 1111 ne ni trqbwa fragment
            }          
            accItem.appendChild(itemsList); //1111 za ul
        }


    }

    function Item(title) {

        //222222222222222start
        var items = [];

        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem; //novoto ot gore zashtoto iskame da go izpolzvame
        }
        //222222222222222end

        this.render = function () {
            var itemNode = document.createElement("li"); //1111 li
            itemNode.innerHTML = "<a href='#'>" + title+ "</a>";
            //2222222222222start
            if (items.length > 0) {
                var sublist = document.createElement("ul");
                sublist.style.display = "none"; //333333333333333333
                for (var i = 0; i < items.length; i++) {
                    var subItem = items[i].render();
                    sublist.appendChild(subItem);
                }
                itemNode.appendChild(sublist);
            }
            //2222222222222end
            return itemNode;
        }

    }

    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        }
    }




}());