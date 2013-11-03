(function(){
    function Accordion(selector) {

        var items = [];

        this.add = function(title){
            var newItem = new Item(title);
            items.push(newItem);

        }

        this.render = function(){
            var accordionFragment = document.createDocumentFragment;
            for (var i = 0; i < items.length; i++) {
                var domItem = items[i].render();
                accordionFragment.appendChild(domItem);
            }

            var accorItem = document.querySelector(selector);
            accorItem.appendChild(accordionFragment);
        }
    }

    function item(title) {
        this.render = function () {
            var itemNode = document.createElement("div");
            itemNode.innerHTML = title;

        }
    }


    return {
        getAccordion = functon(){

    }
    
}());