var controls = (function () {

    function Accordion(selector) {

        var items = [];
        var accItem = document.querySelector(selector);
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
            itemNode.innerHTML = title;
            //2222222222222start
            if (items.length > 0) {
                var sublist = document.createElement("ul");
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