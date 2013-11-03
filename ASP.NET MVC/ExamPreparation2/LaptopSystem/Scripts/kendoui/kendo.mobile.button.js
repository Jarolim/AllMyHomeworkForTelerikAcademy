/*
* Kendo UI Complete v2013.2.918 (http://kendoui.com)
* Copyright 2013 Telerik AD. All rights reserved.
*
* Kendo UI Complete commercial licenses may be obtained at
* https://www.kendoui.com/purchase/license-agreement/kendo-ui-complete-commercial.aspx
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
kendo_module({
    id: "mobile.button",
    name: "Button",
    category: "mobile",
    description: "The Button widget navigates between mobile Application views when pressed.",
    depends: [ "mobile.application", "userevents" ]
});

(function($, undefined) {
    var kendo = window.kendo,
        mobile = kendo.mobile,
        ui = mobile.ui,
        Widget = ui.Widget,
        support = kendo.support,
        os = support.mobileOS,
        ANDROID3UP = os.android && os.flatVersion >= 300,
        CLICK = "click";

    function highlightButton(widget, event, highlight) {
        $(event.target).closest(".km-button,.km-detail").toggleClass("km-state-active", highlight);

        if (ANDROID3UP && widget.deactivateTimeoutID) {
            clearTimeout(widget.deactivateTimeoutID);
            widget.deactivateTimeoutID = 0;
        }
    }

    function createBadge(value) {
        return $('<span class="km-badge">' + value + '</span>');
    }

    var Button = Widget.extend({
        init: function(element, options) {
            var that = this;

            Widget.fn.init.call(that, element, options);

            that._wrap();
            that._style();

            that._userEvents = new kendo.UserEvents(that.element, {
                press: function(e) { that._activate(e); },
                tap: function(e) { that._release(e); },
                release: function(e) { highlightButton(that, e, false); },
                // Prevent the navigation when scrolled in this case
                // in THEORY this should not break anything in the other mode, too - but let's not take any chances
                end: function(e) {
                    if (kendo.mobile.application.options.useNativeScrolling) {
                        e.preventDefault();
                    }
                }
            });

            if (ANDROID3UP) {
                that.element.on("move", function(e) { that._timeoutDeactivate(e); });
            }
        },

        destroy: function() {
            Widget.fn.destroy.call(this);
            this._userEvents.destroy();
        },

        events: [
            CLICK
        ],

        options: {
            name: "Button",
            icon: "",
            style: "",
            badge: ""
        },

        badge: function (value) {
            var badge = this.badgeElement = this.badgeElement || createBadge(value).appendTo(this.element);

            if (value) {
                badge.html(value);
                return this;
            }

            if (value === false) {
                badge.empty().remove();
                this.badgeElement = false;
                return this;
            }

            return badge.html();
        },

        _timeoutDeactivate: function(e) {
            if (!this.deactivateTimeoutID) {
                this.deactivateTimeoutID = setTimeout(highlightButton, 500, this, e, false);
            }
        },

        _activate: function(e) {
            var activeElement = document.activeElement,
                nodeName = activeElement ? activeElement.nodeName : "";

            highlightButton(this, e, true);

            if (nodeName == "INPUT" || nodeName == "TEXTAREA") {
                activeElement.blur(); // Hide device keyboard
            }
        },

        _release: function(e) {
            var that = this;

            if (e.which > 1) {
                return;
            }

            if (that.trigger(CLICK, {target: $(e.target), button: that.element})) {
                e.preventDefault();
            }
        },

        _style: function() {
            var style = this.options.style,
                element = this.element,
                styles;

            if (style) {
                styles = style.split(" ");
                $.each(styles, function() {
                    element.addClass("km-" + this);
                });
            }
        },

        _wrap: function() {
            var that = this,
                icon = that.options.icon,
                badge = that.options.badge,
                iconSpan = '<span class="km-icon km-' + icon,
                element = that.element.addClass("km-button"),
                span = element.children("span:not(.km-icon)").addClass("km-text"),
                image = element.find("img").addClass("km-image");

            if (!span[0] && element.html()) {
                span = element.wrapInner('<span class="km-text" />').children("span.km-text");
            }

            if (!image[0] && icon) {
                if (!span[0]) {
                    iconSpan += " km-notext";
                }
                that.iconElement = element.prepend($(iconSpan + '" />'));
            }

            if (badge) {
                that.badgeElement = createBadge(badge).appendTo(element);
            }
        }
    });

    var BackButton = Button.extend({
        options: {
            name: "BackButton",
            style: "back"
        },

        init: function(element, options) {
            var that = this;
            Button.fn.init.call(that, element, options);

            if (typeof that.element.attr("href") === "undefined") {
                that.element.attr("href", "#:back");
            }
        }
    });

    var DetailButton = Button.extend({
        options: {
            name: "DetailButton",
            style: ""
        },

        init: function(element, options) {
            Button.fn.init.call(this, element, options);
        },

        _style: function() {
            var style = this.options.style + " detail",
                element = this.element;

            if (style) {
                var styles = style.split(" ");
                $.each(styles, function() {
                    element.addClass("km-" + this);
                });
            }
        },

        _wrap: function() {
            var that = this,
                icon = that.options.icon,
                iconSpan = '<span class="km-icon km-' + icon,
                element = that.element,
                span = element.children("span"),
                image = element.find("img").addClass("km-image");

            if (!image[0] && icon) {
                if (!span[0]) {
                    iconSpan += " km-notext";
                }
                element.prepend($(iconSpan + '" />'));
            }
        }

    });

    ui.plugin(Button);
    ui.plugin(BackButton);
    ui.plugin(DetailButton);
})(window.kendo.jQuery);
