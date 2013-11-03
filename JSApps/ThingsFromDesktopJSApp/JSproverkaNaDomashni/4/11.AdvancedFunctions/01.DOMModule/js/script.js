window.onload = function() {
	var domModule = (function() {

		var buffer = new Object();
		var bufferSize = 100;

		//Add DOM element to parent element given by selector
		function appendChild(child, selector) {
			var parent = document.querySelectorAll(selector);
			for (var i = 0; i < parent.length; i++) {
				var addedChild = parent[i].appendChild(child);
				addedChild.style.width = "100px";
				addedChild.style.background = "black";
				addedChild.innerHTML = "my teeessttt";
			}

		}

		//Remove element from the DOM  by given selector
		function removeChild(selector) {
			var element = document.querySelectorAll(selector);
			for (var i = 0; i < element.length; i++) {
				element[i].parentNode.removeChild(element[i]);
			};
		}

		//Attach event to given selector by given event type and event hander
		function addHandler(selector, eventType, eventHandler) {
			var element = document.querySelectorAll(selector);
			for (var i = 0; i < element.length; i++) {
				element[i].addEventListener(eventType, eventHandler, false);
			}
		}

		//Add elements to buffer, which appends them to the DOM when their count for some selector becomes 10
		function appendToBuffer(selector, element) {

			var parent = document.querySelector(selector);
			if (parent) {
				if (!buffer[parent]) {
					buffer[parent] = [];
				}

				buffer[parent].push(element);

				if (buffer[parent].length >= bufferSize) {
					for (var i = 0; i < buffer[parent].length; i++) {
						var bufferChild = parent.appendChild(buffer[parent][i]);
					}
					buffer[parent] = [];
				}
			}
		}

		//Get elements by CSS selector
		function getElementsByCSS(selector)  {
			var elements = document.querySelectorAll(selector);
			return elements;
		}
		
		return {
			appendChild: appendChild,
			removeChild: removeChild,
			addHandler: addHandler,
			appendToBuffer: appendToBuffer,
			getElementsByCSS: getElementsByCSS
		};
	})();
	document.getElementById("generate").onclick = function() {
		var div = document.createElement("div");
		domModule.appendChild(div, "#area");
		domModule.removeChild("li:first-child");
		domModule.addHandler("a.button", 'click', function() {
			alert("Clicked")
		});

		for (var j = 0; j < 9; j++) {
			var h1 = document.createElement("h2");
			h1.style.background = "red";
			h1.style.width = "200px";
			h1.innerHTML = j;
			domModule.appendToBuffer("#buffer", h1);
		}

	}
}