/*
* Kendo UI Complete v2013.2.918 (http://kendoui.com)
* Copyright 2013 Telerik AD. All rights reserved.
*
* Kendo UI Complete commercial licenses may be obtained at
* https://www.kendoui.com/purchase/license-agreement/kendo-ui-complete-commercial.aspx
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
kendo_module({
    id: "mobile.modalview",
    name: "ModalView",
    category: "mobile",
    description: "The Kendo ModalView is used to present self-contained functionality in the context of the current task.",
    depends: [ "mobile.shim", "mobile.application" ]
});

(function($, undefined) {
    var kendo = window.kendo,
        ui = kendo.mobile.ui,
        Shim = ui.Shim,
        Widget = ui.Widget,
        OPEN = "open",
        CLOSE = "close",
        INIT = "init",
        WRAP = '<div class="km-modalview-wrapper" />';

    var ModalView = ui.View.extend({
        init: function(element, options) {
            var that = this, width, height;

            Widget.fn.init.call(that, element, options);

            element = that.element;
            options = that.options;

            width = element[0].style.width || element.css("width");
            height = element[0].style.height || element.css("height");

            element.addClass("km-modalview").wrap(WRAP);

            that.wrapper = element.parent().css({
                width: options.width || width || 300,
                height: options.height || height || 300
            });

            element.css({ width: "", height: "" });

            that.shim = new Shim(that.wrapper, {
                modal: options.modal,
                position: "center center",
                align: "center center",
                effect: "fade:in"
            });

            that._layout();
            that._scroller();
            that._model();
            that.element.css("display", "");

            that.trigger(INIT);
            kendo.onResize(function() {
                var positionedElement = that.wrapper.parent(),
                    viewPort = positionedElement.parent();

                positionedElement.css({
                    top: (viewPort.height() - positionedElement.height()) / 2 + "px",
                    left: (viewPort.width() - positionedElement.width()) / 2 + "px"
                });
            });
        },

        events: [
            INIT,
            OPEN,
            CLOSE
        ],

        options: {
            name: "ModalView",
            modal: true,
            width: null,
            height: null
        },

        destroy: function() {
            Widget.fn.destroy.call(this);
            this.shim.destroy();
        },

        open: function(target) {
            var that = this;
            that.target = $(target);
            that.shim.show();
            that.trigger("show", { view: that });
        },

        // Interface implementation, called from the pane click handlers
        openFor: function(target) {
            this.open(target);
            this.trigger(OPEN, { target: target });
        },

        close: function() {
            this.shim.hide();
            this.trigger(CLOSE);
        }
    });

    ui.plugin(ModalView);
})(window.kendo.jQuery);
