var controls = (function () {

    function Gallery(selector) {

        var albums = [];
        var images = [];

        var galleryItem = document.querySelector(selector);
        var albumsList = document.createElement("div");
        var imagesList = document.createElement("div");

        this.addAlbum = function (albumTitle) {
            var newAlbum = new Album(albumTitle);
            albums.push(newAlbum);
            return newAlbum;
        }

        this.addImage = function (title, src) {
            var newImage = new Image(title , src);
            images.push(newImage);
            return newImage;
        }

        this.render = function () {

            for (var i = 0; i < albums.length; i++) {
                var domAlbum = albums[i].render();
                albumsList.appendChild(domAlbum);
            }
            galleryItem.appendChild(albumsList);

            for (var i = 0; i < images.length; i++) {
                var domImage = images[i].render();
                imagesList.appendChild(domImage);
            }
            galleryItem.appendChild(imagesList);
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

        this.render = function () {

            var albumNode = document.createElement("div");
            albumNode.innerHTML = albumTitle;
            return albumNode;
        }

    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        }
    }


}());