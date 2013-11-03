var notify = (function () {

    var create = function (title, gameId, type, state, panelItem, nofyType) {
        //$.noty.returns = 'id'; // BC for old api

        var buttons;

        if (nofyType === undefined) {
            nofyType = 'alert';
            buttons = [
                {
                    type: 'btn btn-primary',
                    text: 'Ok',
                    click: function($noty) {
                        var item = findById(games, gameId);
                        if (type === "game-joined" || item.status === "full") {
                            if (item === undefined) {
                                item = {
                                    id: gameId,
                                    title: title.substring(title.indexOf('joined your game ') + 17, title.indexOf('<br />')),
                                    creatorNickname: controller.provider.nickname,
                                    status: "in-progress"
                                };
                                games.push(item);
                            }
                            controller.provider.game.start(gameId).then(function() {
                                noty({ force: true, text: 'Have fun :)', type: 'success', layout: 'topRight', timeout: 1000 });
                                createGameWindow("Active Game: " + item.title, item.id).center().open();
                                var panelGroup = getItemByIndex(2);
                                if (panelItem !== undefined && panelItem !== null) {
                                    panelBar.remove(panelItem, panelBar.select());
                                    panelBar.select(panelGroup);
                                    panelBar.append(panelItem, panelBar.select());
                                } else {
                                    panelBar.select(getItemByIndex(2));
                                    panelBar.append('<li id="' + item.id + '" class="k-link">' + item.title + '</li>', panelBar.select());
                                }
                                panelBar.expand(panelGroup);
                            });
                        } else if (item.status == "in-progress") {
                            noty({ force: true, text: 'Have fun :)', type: 'success', layout: 'topRight', timeout: 1000 });
                            createGameWindow("Active Game: " + item.title, item.id).center().open();
                        } else if (type === "guess-made") {

                        }
                        // this = button element
                        // $noty = $noty element
                        $noty.close();
                        //noty({ force: true, text: 'You clicked "Ok" button', type: 'success', layout: 'topRight' });
                    }
                },
                {
                    type: 'btn btn-danger',
                    text: 'Cancel',
                    click: function($noty) {
                        $noty.close();
                        noty({ force: true, text: 'You clicked "Cancel" button', type: 'error', layout: 'topRight', timeout: 1000 });
                    }
                }
            ];
        }

        var n = noty({
            layout: 'topRight',
            theme: 'noty_theme_default',
            animateOpen: { height: 'toggle' },
            animateClose: { height: 'toggle' },
            easing: 'swing',
            text: title,
            type: nofyType,
            speed: 500,
            timeout: 5000,
            closeButton: false,
            closeOnSelfClick: true,
            closeOnSelfOver: false,
            force: false,
            onShow: false,
            onShown: false,
            onClose: false,
            onClosed: false,
            buttons: buttons,
            modal: false,
            template: '<div class="noty_message"><span class="noty_text"></span><div class="noty_close"></div></div>',
            cssPrefix: 'noty_',
            custom: {
                container: null
            }
        });

        //console.log('html: ' + n);
    };

    return {
        create: create,
    };

}());