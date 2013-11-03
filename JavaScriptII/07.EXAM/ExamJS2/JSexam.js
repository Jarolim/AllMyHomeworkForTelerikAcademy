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


        //Task 7 ------------------------------------ start

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
                var newThing = document.createElement("img");

                if (!sublist) { //bug fix
                    return;
                }
                if (clickedItem) {
                    sublist.style.width = "200px";
                    sublist.style.height = "200px";
                    sublist.style.float = "right";
                }
                

            }, false);

        //Task 7 ------------------------------------ end



        //Task 3 ------------------------------------ start

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

                var sublist = clickedItem.nextElementSibling;
                var subAlbum = sublist.nextElementSibling;

                if (!sublist) { //bug fix if clicked on something else
                    return;
                }
                if (sublist.style.display === "") {
                    sublist.style.display = "none";
                    clickedItem.style.display = "";
                    subAlbum.style.display = "none";
                } else {
                    sublist.style.display = "";
                    subAlbum.style.display = "";
                }

            }, false);

        //Task 3 ------------------------------------ end

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

            while (galleryItem.firstChild) {
                galleryItem.removeChild(galleryItem.firstChild);
            }

            while (imagesList.firstChild) {
                imagesList.removeChild(imagesList.firstChild);
            }
            while (albumsList.firstChild) {
                albumsList.removeChild(albumsList.firstChild);
            }

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
        //Task 4 ------------------------------------ start2
        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < albums.length; i++) {
                serializedItems.push(albums[i].serialize());
            }
            return serializedItems;
        }
        //Task 4 ------------------------------------ end2

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

        var images = [];

        this.addImage = function (title, src) {
            var newImage = new Image(title, src);
            images.push(newImage);
            return newImage;
        }

        //Task 2 ------------------------------------ start1
        var albums = [];

        this.addAlbum = function (albumTitle) {
            var newAlbum = new Album(albumTitle);
            albums.push(newAlbum);
            return newAlbum;
        }
        //Task 2 ------------------------------------ end1


        this.render = function () {

            var albumNode = document.createElement("div");
            var imageAlbumNode = document.createElement("div");
            imageAlbumNode.className = "bla"; //test
            albumNode.appendChild(imageAlbumNode);

            albumNode.innerHTML = "<a href='#'>" + albumTitle + "</a>"; //for task 3 - updated

            if (images.length > 0) {
                for (var i = 0; i < images.length; i++) {
                    var subItemImage = images[i].render();
                    imageAlbumNode.appendChild(subItemImage);
                }
                imageAlbumNode.appendChild(subItemImage);
                albumNode.appendChild(imageAlbumNode);
            }

            //Task 2 ------------------------------------ start2
            if (albums.length > 0) {
                for (var i = 0; i < albums.length; i++) {
                    var subItemAlbum = albums[i].render();
                    albumNode.appendChild(subItemAlbum);
                }
                albumNode.appendChild(subItemAlbum);
            }
            //Task 2 ------------------------------------ end2
            return albumNode;
        }
        //Task 4 ------------------------------------ start1

        this.serialize = function (selector) {
            var thisItem = {
                albumTitle: albumTitle
            };
            if (albums.length > 0) {
                var serializedItems = [];
                for (var i = 0; i < albums.length; i++) {
                    var serItem = albums[i].serialize();
                    serializedItems.push(serItem);
                }
                thisItem.albums = serializedItems;
            }
            return thisItem;
        }

        //Task 4 ------------------------------------ end1

    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        }
    }


}());