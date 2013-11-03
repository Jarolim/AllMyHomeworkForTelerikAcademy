function getItemByIndex(index) {
    rootItem = panelBar.element.children("li").eq(index);
    return rootItem;
}

function getItemById(id) {
    rootItem = panelBar.element.find('li[id=' + id + ']')[0];
    return rootItem;
}

function createKendoWindow(title, content) {
    var kwindow = $("#kwindow").kendoWindow({
        modal: true,
        title: title,
        content: '../UserControls/' + content + '.html',
        refresh: function () { this.center(); }
    });
    return kwindow.data('kendoWindow');
}

function createGameWindow(title, gameId) {
    var kwindow = $('<div id=' + gameId + '>').attr('tag', 5).kendoWindow({
        title: title,
        width: '520px',
        height: '400px',
        content: '../UserControls/ActiveGame.html',
    });
    return kwindow;//.data('kendoWindow');
    //http://jsfiddle.net/dimodi/8tzgc/
}

function findById(source, id) {
    return source.filter(function (obj) {
        // coerce both obj.id and id to numbers 
        // for val & type comparison
        return +obj.id === +id;
    })[0];
}

// SEND
function pubnubPublish(message) {
    pubnub.publish({
        channel: "saykor_bulls_cows",
        message: message
    });
}