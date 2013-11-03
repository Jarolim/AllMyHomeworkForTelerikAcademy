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
            albumNode.innerHTML = albumTitle;
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
                    var subItem = images[i].render();
                    albumNode.appendChild(subItem);
                }
                albumNode.appendChild(subItem);
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