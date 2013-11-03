﻿var controls = (function () {

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
            albumNode.appendChild(imageAlbumNode);

            albumNode.innerHTML = "<a href='#'>" + albumTitle + "</a>" + "<br />"; //33333333333333333333333333333333333333

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