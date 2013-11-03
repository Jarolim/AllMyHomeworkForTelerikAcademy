/// <reference path="class.js" />
/// <reference path="dataProvider.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />
/// <reference path="helpers.js" />
/// <reference path="notify.js" />

var controllers = (function () {
	var rootUrl = "http://localhost:40643/api/";
	var Controller = Class.create({
		init: function () {
		    this.provider = providers.get(rootUrl);
		    
			if (this.provider.isUserLoggedIn()) {
			    this.loadGame("#panelbar");
			}
			else {
			    this.loadLogin("#kwindow");
			}
		},
		loadLogin: function (selector) {
		    this.attachLoginEventHandlers(selector);
		    createKendoWindow("Login / Register", "Login").open();
		},
		loadGame: function () {
		    this.attachGameEventHandlers("#kwindow");
		    $("#organizer").show();

		    this.loadOpenGames();

		    this.provider.game.active().then(function (result) {
		        for (var i = 0; i < result.length; i++) {
		            games.push(result[i]);
		            if (result[i].status === "full") {
		                panelBar.select(getItemByIndex(1));
		                panelBar.append('<li id="' + result[i].id + '" class="k-link">' + result[i].title + '</li>', panelBar.select());
		            } else {
		                panelBar.select(getItemByIndex(2));
		                panelBar.append('<li id="' + result[i].id + '" class="k-link">' + result[i].title + '</li>', panelBar.select());
		            }
		        }
		    }).then(function () {
		        var item = getItemByIndex(0);
		        panelBar.select(item);
		        panelBar.expand(item);
		    });

		    this.loadMessages();
		},
		loadOpenGames:function() {
		    this.provider.game.open().then(function (result) {
		        for (var i = 0; i < result.length; i++) {
		            var item = findById(games, result[i].id);
		            if (item === undefined) {
		                games.push(result[i]);
		                panelBar.select(getItemByIndex(0));
		                panelBar.append('<li id="' + result[i].id + '" class="k-link">' + result[i].title + '</li>', panelBar.select());
		            }
		        }
		        panelBar.expand(panelBar.select(getItemByIndex(0)));
		    });
		},
		loadMessages: function () {
		    var self = this;
		    //load messages

		    setInterval(function () {
		        console.log('message');
		        self.provider.message.unread().then(function (result) {
		            for (var i = 0; i < result.length; i++) {
		                var content = 'text: ' + result[i].text +
		                    '<br />gameId: ' + result[i].gameId +
		                    '<br />type: ' + result[i].type +
		                    '<br />state: ' + result[i].state;
		                var nofyType = 'alert';
		                if (result[i].type === "guess-made") {
		                    var game = findById(games, result[i].gameId);
		                    console.log(game);
		                    if (game !== undefined && game.button !== undefined) {
		                        game.button.removeAttr("disabled");
		                        game.button.css('background', '#61FF73');
		                    }
		                    nofyType = 'information';
		                } else {
		                    content += '<br />Click OK if you are ready to play';
		                }
		                
		                notify.create(content, result[i].gameId, result[i].type, result[i].state, null, nofyType);
		            }
		        });
		    }, 2000);
		},
		attachLoginEventHandlers: function (selector) {
		    var self = this;
		    var kwindow = $(selector);
		    kwindow.on('click', '#btnLogin', function () {
		        var username = $('#txtLoginUsername').val();
		        var password = $('#txtLoginPassword').val();
		        self.provider.user.login(username, password).then(function () {
		            kwindow.data("kendoWindow").close();
		            self.loadGame("#panelbar");
		        });
		    });

		    kwindow.on('click', '#btnRegister', function () {
		        var username = $('#txtRegisterUsername').val();
		        var nickname = $('#txtRegisterNickname').val();
		        var password = $('#txtRegisterPassword').val();
		        self.provider.user.register(username, nickname, password).then(function () {
		            kwindow.data("kendoWindow").close();
		            self.loadGame("#panelbar");
		        });
		    });
		},
		attachGameEventHandlers: function (selector) {
		    var self = this;
		    var kwindow = $(selector);
		    kwindow.on('click', '#btnJoinGame', function () {
		        var password = $('#txtJoinGamePassword').val();
		        var number = $('#txtJoinGameNumber').val();
		        self.provider.game.join(selectedGameId, password, number).then(function (result) {
		            kwindow.data("kendoWindow").close();
		            var item = panelBar.getItemById(selectedGameId);
		        }, function (error) {
		            alert(error.responseText);
		        });
		    });

		    kwindow.on('click', '#btnCreateGame', function () {
		        var title = $('#txtCreateGameName').val();
		        var password = $('#txtCreateGamePassword').val();
		        var number = $('#txtCreateGameNumber').val();
		        self.provider.game.create(title, password, number).then(function (result) {
		            kwindow.data("kendoWindow").close();
		            var data = {
		                message: "new-game",
		                user: self.provider.nickname()
		            };
		            pubnubPublish(data);
		        }, function (error) {
		            alert(error.responseText);
		        });
		    });

		    $('#organizer').on('click', '#btnCreateNewGame', function () {
		        createKendoWindow("Create New Game", "CreateGame").center().open();
		    });
		    
		    $('#organizer').on('click', '#btnReadAllMessages', function () {
		        self.provider.message.all().then(function (result) {
		            for (var i = 0; i < result.length; i++) {
		                var content = 'text: ' + result[i].text +
                            '<br />gameId: ' + result[i].gameId +
                            '<br />type: ' + result[i].type +
                            '<br />state: ' + result[i].state;
		                notify.create(content, result[i].gameId, result[i].type, result[i].state);
		            }
		        });
		    });
		}
	});
    return {
        get: function() {
            return new Controller();
        }
    };
}());