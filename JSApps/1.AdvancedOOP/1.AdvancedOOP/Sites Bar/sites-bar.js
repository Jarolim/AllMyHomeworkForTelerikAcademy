var SitesBar = Class.create({
	init: function(folders, urls) {
		this.folders = folders;
		this.urls = urls;
	},
	getFolders: function() {
		return "Folders: " + this.folders;
	},
	displayUrls: function(urls) {
		var fragment = document.createDocumentFragment();
		for(var i = 0; i < urls.length; i++) {
			var item = document.createElement("li");
			var anchor = document.createElement("a");
			anchor.innerText = urls[i].getTitle();
			anchor.title = urls[i].getTitle();
			anchor.target = "_blank";
			anchor.href = urls[i].getUrl();
			item.appendChild(anchor);
			fragment.appendChild(item);
		}
		return fragment;
	},
	display: function(selector) {
		var container = document.getElementById(selector);
		var list = document.createElement("ul");
		var items = document.createDocumentFragment();
		for(var i = 0; i < this.folders.length; i++) {
			var item = document.createElement("li");
			item.innerText = this.folders[i].getTitle();
			var subList = document.createElement("ul");
			subList.appendChild(this.folders[i].displayUrls(this.urls));
			item.appendChild(subList);
			items.appendChild(item);
		}
		list.appendChild(this.displayUrls(this.urls));
		list.appendChild(items);
		container.appendChild(list);
	}
});

var Folder = Class.create({
	init: function(title, urls) {
		this.urls = urls;
		this.title = title;
	},
	getTitle: function() {
		return this.title;
	},
	displayUrls: function() {
		return this._super.displayUrls(this.urls);
	}
});

var Url = Class.create({
	init: function(title, url) {
		this.title = title;
		this.url = url;
	},
	getTitle: function() {
		return this.title;
	},
	getUrl: function() {
		return this.url;
	}
});

Folder.inherit(SitesBar);

var stumble = new Url("Stumble Upon", "http://www.stumbleupon.com/");
var lifehack = new Url("Lifehack", "http://www.lifehack.bg/");
var gag = new Url("9gag", "https://9gag.com/");
var traffic = new Url("Sofia Traffic", "http://www.sofiatraffic.bg/bg/transport/virtual-tables");
var sport = new Url("Sports Direct", "http://www.sportsdirect.com/");
var cinema = new Url("Cinema", "http://kino.gbg.bg/");
var theCodePlayer = new Url("The Code Player", "http://thecodeplayer.com/");
var codeAcademy = new Url("Code Academy", "http://www.codecademy.com/");

var fun = new Folder("Fun", [gag, cinema]);
var knowledge = new Folder("Knowledge", [stumble, lifehack]);
var needs = new Folder("Needs", [traffic, sport]);

var favBar = new SitesBar([fun, knowledge, needs], [theCodePlayer, codeAcademy]);

favBar.display("sites-bar");