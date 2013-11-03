/*
* Kendo UI Complete v2013.2.918 (http://kendoui.com)
* Copyright 2013 Telerik AD. All rights reserved.
*
* Kendo UI Complete commercial licenses may be obtained at
* https://www.kendoui.com/purchase/license-agreement/kendo-ui-complete-commercial.aspx
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
kendo_module({
    id: "mobile.actionsheet",
    name: "ActionSheet",
    category: "mobile",
    description: "The mobile ActionSheet widget displays a set of choices related to a task the user initiates.",
    depends: [ "mobile.popover", "mobile.shim" ]
});

(function($, undefined) {
    var kendo = window.kendo,
        support = kendo.support,
        ui = kendo.mobile.ui,
        Shim = ui.Shim,
        Popup = ui.Popup,
        Widget = ui.Widget,
        OPEN = "open",
        BUTTONS = "li>a",
        CONTEXT_DATA = "actionsheetContext",
        WRAP = '<div class="km-actionsheet-wrapper" />',
        cancelTemplate = kendo.template('<li class="km-actionsheet-cancel"><a href="\\#">#:cancel#</a></li>');

    var ActionSheet = Widget.extend({
        init: function(element, options) {
            var that = this,
                os = support.mobileOS,
                ShimClass = os.tablet ? Popup : Shim;

            Widget.fn.init.call(that, element, options);

            element = that.element;

            element
                .addClass("km-actionsheet")
                .append(cancelTemplate({cancel: that.options.cancel}))
                .wrap(WRAP)
                .on("up", BUTTONS, "_click")
                .on("click", BUTTONS, kendo.preventDefault);

            that.wrapper = element.parent();
            that.shim = new ShimClass(that.wrapper, $.extend({modal: os.ios && os.majorVersion < 7}, that.options.popup) );

            kendo.notify(that, ui);

            kendo.onResize($.proxy(this, "_resize"));
        },

        events: [
            OPEN
        ],

        options: {
            name: "ActionSheet",
            cancel: "Cancel",
            popup: { height: "auto" }
        },

        open: function(target, context) {
            var that = this;
            that.target = $(target);
            that.context = context;
            that.shim.show(target);
        },

        close: function() {
            this.context = this.target = null;
            this.shim.hide();
        },

        openFor: function(target) {
            var that = this,
                context = target.data(CONTEXT_DATA);

            that.open(target, context);
            that.trigger(OPEN, { target: target, context: context });
        },

        destroy: function() {
            Widget.fn.destroy.call(this);
            this.shim.destroy();
        },

        _click: function(e) {
            if (e.isDefaultPrevented()) {
                return;
            }

            var action = $(e.currentTarget).data("action");

            if (action) {
                kendo.getter(action)(window)({
                    target: this.target,
                    context: this.context
                });
            }

            e.preventDefault();
            this.close();
        },

        _resize: function() {
            if (support.mobileOS.tablet) {
                this.shim.hide();
            } else { // phone
                if (this.element.is(":visible")) {
                    var positionedElement = this.wrapper.parent(),
                        viewPort = positionedElement.parent();

                    positionedElement.css({
                        top: (viewPort.height() - positionedElement.height()) + "px",
                        width: viewPort.width() + "px"
                    });
                }
            }
        }
    });

    ui.plugin(ActionSheet);
})(window.kendo.jQuery);
