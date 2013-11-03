var controls = (function () {

    function Gallery(selector) {

        var albums = [];
        var images = [];

        var galleryItem = document.querySelector(selector);
        var imagesList = document.createElement("div");
        var albumsList = document.createElement("div");
       
        imagesList.style.background = "red";
        imagesList.style.margin = "auto";
        //imagesList.style.position = "relative";
        albumsList.style.background = "green";
        //albumsList.style.position = "relative";
        //imagesList.style.float = "right";


        //77777777777777777777777777777777777start

        imagesList.addEventListener("click",
            function (ev) {
                if (!ev) {
                    ev = window.event;
                }
                ev.stopPropagation();
                ev.preventDefault();

                //<img>
                var clickedItem = ev.target;
                if (!(clickedItem instanceof HTMLImageElement)) { //fix bug next sibling making it to work with <a>
                    return;
                }

                // //44444444444444444444444444start
                // var liItem = clickedItem.parentNode;
                // var list = liItem.parentNode;
                // hidePrev(liItem);
                // hideNext(liItem);
                // //44444444444444444444444444end

                var sublist = clickedItem;
                if (!sublist) { //shtoto kato kliknem na desktop dava greshka
                    return;
                }
                if (sublist.style.display === "") {
                    clickedItem.style.width = "200px";
                    clickedItem.style.height = "200px";
                } else {
                    sublist.style.display = "";
                }

            }, false);

        //77777777777777777777777777777777777end



        //333333333333333333333333333333333333333start

        albumsList.addEventListener("click",
            function (ev) {
                if (!ev) {
                    ev = window.event;
                }
                ev.stopPropagation();
                ev.preventDefault();

                //<a>
                var clickedItem = ev.target;
                if (!(clickedItem instanceof HTMLAnchorElement)) { //fix bug next sibling making it to work with <a>
                    return;
                }

               // //44444444444444444444444444start
               // var liItem = clickedItem.parentNode;
               // var list = liItem.parentNode;
               // hidePrev(liItem);
               // hideNext(liItem);
               // //44444444444444444444444444end

                var sublist = clickedItem.parentNode;
                if (!sublist) { //shtoto kato kliknem na desktop dava greshka
                    return;
                }
                if (sublist.style.display === "") {
                    sublist.style.display = "none";
                    clickedItem.style.display = "";
                } else {
                    sublist.style.display = "";
                }

            }, false);

        //333333333333333333333333333333333333333end
        this.addImage = function (title, src) {
            var newImage = new Image(title , src);
            images.push(newImage);
            return newImage;
        }

        this.addAlbum = function (albumTitle) {
            var newAlbum = new Album(albumTitle);
            albums.push(newAlbum);
            return newAlbum;
        }

        
        this.render = function () {
            for (var i = 0; i < images.length; i++) {
                var domImage = images[i].render();
                imagesList.appendChild(domImage);
            }
            galleryItem.appendChild(imagesList);


            for (var i = 0; i < albums.length; i++) {
                var domAlbum = albums[i].render();
                albumsList.appendChild(domAlbum);
            }
            galleryItem.appendChild(albumsList);

            
        }

    }

    function Image(title, src) {

        this.render = function () {

            var imageNode = document.createElement("img");
            imageNode.setAttribute("src", src);
            imageNode.setAttribute("title", title);
            return imageNode;
        }
    }

    function Album(albumTitle) {
        //1111111111111111111111111111111start1
        var images = [];

        this.addImage = function (title, src) {
            var newImage = new Image(title, src);
            images.push(newImage);
            return newImage;
        }
        //11111111111111111111111111111111end1

        //1111111111111111111111111111111start1
        //22222222222222222222222222222222start1
        var albums = [];

        this.addAlbum = function (albumTitle) {
            var newAlbum = new Album(albumTitle);
            albums.push(newAlbum);
            return newAlbum;
        }
        //22222222222222222222222222222222end1
        //11111111111111111111111111111111end1

        this.render = function () {

            var albumNode = document.createElement("div");
            albumNode.innerHTML = "<a href='#'>" + albumTitle + "</a>" + "<br />"; //33333333333333333333333333333333333333
            //11111111111111111111111111111start2
            if (images.length > 0) {
                for (var i = 0; i < images.length; i++) {
                    var subItemImage = images[i].render();
                    albumNode.appendChild(subItemImage);
                }
                albumNode.appendChild(subItemImage);
            }
            //111111111111111111111111111111end2
            //222222222222222222222222222222start2
            if (albums.length > 0) {
                for (var i = 0; i < albums.length; i++) {
                    var subItemAlbum = albums[i].render();
                    albumNode.appendChild(subItemAlbum);
                }
                albumNode.appendChild(subItemAlbum);
            }
            //222222222222222222222222222222222end2
            return albumNode;
        }

    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        }
    }


}());