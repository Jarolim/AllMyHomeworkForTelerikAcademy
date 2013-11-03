/*
* Kendo UI Complete v2013.2.918 (http://kendoui.com)
* Copyright 2013 Telerik AD. All rights reserved.
*
* Kendo UI Complete commercial licenses may be obtained at
* https://www.kendoui.com/purchase/license-agreement/kendo-ui-complete-commercial.aspx
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
kendo_module({
    id: "dataviz.core",
    name: "Core",
    description: "The DataViz core functions",
    category: "dataviz",
    depends: [ "core" ],
    hidden: true
});

(function ($, undefined) {

    // Imports ================================================================
    var doc = document,
        kendo = window.kendo,
        dataviz = kendo.dataviz = {},
        Class = kendo.Class,
        template = kendo.template,
        map = $.map,
        noop = $.noop,
        indexOf = $.inArray,
        math = Math,
        deepExtend = kendo.deepExtend;

    var renderTemplate = function(definition) {
        return template(definition, { useWithBlock: false, paramName: "d" });
    };

    var CSS_PREFIX = "k-";

    // Constants ==============================================================
    var ANIMATION_STEP = 10,
        AXIS_LABEL_CLICK = "axisLabelClick",
        BASELINE_MARKER_SIZE = 1,
        BLACK = "#000",
        BOTTOM = "bottom",
        CENTER = "center",
        COORD_PRECISION = 3,
        CLIP = "clip",
        CIRCLE = "circle",
        DEFAULT_FONT = "12px sans-serif",
        DEFAULT_HEIGHT = 400,
        DEFAULT_PRECISION = 6,
        DEFAULT_WIDTH = 600,
        DEG_TO_RAD = math.PI / 180,
        FADEIN = "fadeIn",
        FORMAT_REGEX = /\{\d+:?/,
        HEIGHT = "height",
        ID_PREFIX = "k",
        ID_POOL_SIZE = 1000,
        ID_START = 10000,
        INITIAL_ANIMATION_DURATION = 600,
        INSIDE = "inside",
        LEFT = "left",
        LINEAR = "linear",
        MAX_VALUE = Number.MAX_VALUE,
        MIN_VALUE = -Number.MAX_VALUE,
        NONE = "none",
        NOTE_CLICK = "noteClick",
        NOTE_HOVER = "noteHover",
        OUTSIDE = "outside",
        RADIAL = "radial",
        RIGHT = "right",
        SWING = "swing",
        TOP = "top",
        TRIANGLE = "triangle",
        UNDEFINED = "undefined",
        UPPERCASE_REGEX = /([A-Z])/g,
        WIDTH = "width",
        WHITE = "#fff",
        X = "x",
        Y = "y",
        ZERO_THRESHOLD = 0.2;

    function getSpacing(value, defaultSpacing) {
        var spacing = { top: 0, right: 0, bottom: 0, left: 0 };

        defaultSpacing = defaultSpacing || 0;

        if (typeof(value) === "number") {
            spacing[TOP] = spacing[RIGHT] = spacing[BOTTOM] = spacing[LEFT] = value;
        } else {
            spacing[TOP] = value[TOP] || defaultSpacing;
            spacing[RIGHT] = value[RIGHT] || defaultSpacing;
            spacing[BOTTOM] = value[BOTTOM] || defaultSpacing;
            spacing[LEFT] = value[LEFT] || defaultSpacing;
        }

        return spacing;
    }

    // Geometric primitives ===================================================

    // TODO: Rename to Point?
    var Point2D = function(x, y) {
        var point = this;
        if (!(point instanceof Point2D)) {
            return new Point2D(x, y);
        }

        point.x = round(x || 0, COORD_PRECISION);
        point.y = round(y || 0, COORD_PRECISION);
    };

    Point2D.fn = Point2D.prototype = {
        clone: function() {
            var point = this;

            return new Point2D(point.x, point.y);
        },

        equals: function(point) {
            return point && point.x === this.x && point.y === this.y;
        },

        rotate: function(center, degrees) {
            var point = this,
                theta = degrees * DEG_TO_RAD,
                cosT = math.cos(theta),
                sinT = math.sin(theta),
                cx = center.x,
                cy = center.y,
                x = point.x,
                y = point.y;

            point.x = round(
                cx + (x - cx) * cosT + (y - cy) * sinT,
                COORD_PRECISION
            );

            point.y = round(
                cy + (y - cy) * cosT - (x - cx) * sinT,
                COORD_PRECISION
            );

            return point;
        },

        distanceTo: function(point) {
            var dx = this.x - point.x,
                dy = this.y - point.y;

            return math.sqrt(dx * dx + dy * dy);
        }
    };

    // Clock-wise, 0 points left
    Point2D.onCircle = function(c, a, r) {
        a *= DEG_TO_RAD;

        return new Point2D(
            c.x - r * math.cos(a),
            c.y - r * math.sin(a)
        );
    };

    var Box2D = function(x1, y1, x2, y2) {
        var box = this;

        if (!(box instanceof Box2D)) {
            return new Box2D(x1, y1, x2, y2);
        }

        box.x1 = x1 || 0;
        box.x2 = x2 || 0;
        box.y1 = y1 || 0;
        box.y2 = y2 || 0;
    };

    Box2D.fn = Box2D.prototype = {
        width: function() {
            return this.x2 - this.x1;
        },

        height: function() {
            return this.y2 - this.y1;
        },

        translate: function(dx, dy) {
            var box = this;

            box.x1 += dx;
            box.x2 += dx;
            box.y1 += dy;
            box.y2 += dy;

            return box;
        },

        // TODO: Accept point!
        move: function(x, y) {
            var box = this,
                height = box.height(),
                width = box.width();

            box.x1 = x;
            box.y1 = y;
            box.x2 = box.x1 + width;
            box.y2 = box.y1 + height;

            return box;
        },

        wrap: function(targetBox) {
            var box = this;

            box.x1 = math.min(box.x1, targetBox.x1);
            box.y1 = math.min(box.y1, targetBox.y1);
            box.x2 = math.max(box.x2, targetBox.x2);
            box.y2 = math.max(box.y2, targetBox.y2);

            return box;
        },

        wrapPoint: function(point) {
            this.wrap(new Box2D(point.x, point.y, point.x, point.y));

            return this;
        },

        snapTo: function(targetBox, axis) {
            var box = this;

            if (axis == X || !axis) {
                box.x1 = targetBox.x1;
                box.x2 = targetBox.x2;
            }

            if (axis == Y || !axis) {
                box.y1 = targetBox.y1;
                box.y2 = targetBox.y2;
            }

            return box;
        },

        alignTo: function(targetBox, anchor) {
            var box = this,
                height = box.height(),
                width = box.width(),
                axis = anchor == TOP || anchor == BOTTOM ? Y : X,
                offset = axis == Y ? height : width;

            if (anchor === CENTER) {
                var targetCenter = targetBox.center();
                var center = box.center();

                box.x1 += targetCenter.x - center.x;
                box.y1 += targetCenter.y - center.y;
            } else if (anchor === TOP || anchor === LEFT) {
                box[axis + 1] = targetBox[axis + 1] - offset;
            } else {
                box[axis + 1] = targetBox[axis + 2];
            }

            box.x2 = box.x1 + width;
            box.y2 = box.y1 + height;

            return box;
        },

        shrink: function(dw, dh) {
            var box = this;

            box.x2 -= dw;
            box.y2 -= dh;

            return box;
        },

        expand: function(dw, dh) {
            this.shrink(-dw, -dh);
            return this;
        },

        pad: function(padding) {
            var box = this,
                spacing = getSpacing(padding);

            box.x1 -= spacing.left;
            box.x2 += spacing.right;
            box.y1 -= spacing.top;
            box.y2 += spacing.bottom;

            return box;
        },

        unpad: function(padding) {
            var box = this,
                spacing = getSpacing(padding);

            spacing.left = -spacing.left;
            spacing.top = -spacing.top;
            spacing.right = -spacing.right;
            spacing.bottom = -spacing.bottom;

            return box.pad(spacing);
        },

        clone: function() {
            var box = this;

            return new Box2D(box.x1, box.y1, box.x2, box.y2);
        },

        center: function() {
            var box = this;

            return new Point2D(
                box.x1 + box.width() / 2,
                box.y1 + box.height() / 2
            );
        },

        containsPoint: function(point) {
            var box = this;

            return point.x >= box.x1 && point.x <= box.x2 &&
                   point.y >= box.y1 && point.y <= box.y2;
        },

        points: function() {
            var box = this;

            return [
                new Point2D(box.x1, box.y1),
                new Point2D(box.x2, box.y1),
                new Point2D(box.x2, box.y2),
                new Point2D(box.x1, box.y2)
            ];
        },

        getHash: function() {
            var box = this;

            return [box.x1, box.y1, box.x2, box.y2].join(",");
        }
    };

    var Ring = Class.extend({
        init: function(center, innerRadius, radius, startAngle, angle) {
            var ring = this;

            ring.c = center;
            ring.ir = innerRadius;
            ring.r = radius;
            ring.startAngle = startAngle;
            ring.angle = angle;
        },

        clone: function() {
            var r = this;
            return new Ring(r.c, r.ir, r.r, r.startAngle, r.angle);
        },

        // TODO: Rename to midAngle
        middle: function() {
            return this.startAngle + this.angle / 2;
        },

        // TODO: Sounds like a getter
        radius: function(newRadius, innerRadius) {
            var that = this;

            if (innerRadius) {
                that.ir = newRadius;
            } else {
                that.r = newRadius;
            }

            return that;
        },

        // TODO: Remove and replace with Point2D.onCircle
        point: function(angle, innerRadius) {
            var ring = this,
                radianAngle = angle * DEG_TO_RAD,
                ax = math.cos(radianAngle),
                ay = math.sin(radianAngle),
                radius = innerRadius ? ring.ir : ring.r,
                x = ring.c.x - (ax * radius),
                y = ring.c.y - (ay * radius);

            return new Point2D(x, y);
        },

        adjacentBox: function(distance, width, height) {
            var sector = this.clone().expand(distance),
                midAndle = sector.middle(),
                midPoint = sector.point(midAndle),
                hw = width / 2,
                hh = height / 2,
                x = midPoint.x - hw,
                y = midPoint.y - hh,
                sa = math.sin(midAndle * DEG_TO_RAD),
                ca = math.cos(midAndle * DEG_TO_RAD);

            if (math.abs(sa) < 0.9) {
                x += hw * -ca / math.abs(ca);
            }

            if (math.abs(ca) < 0.9) {
                y += hh * -sa / math.abs(sa);
            }

            return new Box2D(x, y, x + width, y + height);
        },

        containsPoint: function(p) {
            var ring = this,
                c = ring.c,
                ir = ring.ir,
                r = ring.r,
                startAngle = ring.startAngle,
                endAngle = ring.startAngle + ring.angle,
                dx = p.x - c.x,
                dy = p.y - c.y,
                vector = new Point2D(dx, dy),
                startPoint = ring.point(startAngle),
                startVector = new Point2D(startPoint.x - c.x, startPoint.y - c.y),
                endPoint = ring.point(endAngle),
                endVector = new Point2D(endPoint.x - c.x, endPoint.y - c.y),
                dist = dx * dx + dy *dy;

            return (startVector.equals(vector) || clockwise(startVector, vector)) &&
                   !clockwise(endVector, vector) &&
                   dist >= ir * ir && dist <= r * r;
        },

        getBBox: function() {
            var ring = this,
                box = new Box2D(MAX_VALUE, MAX_VALUE, MIN_VALUE, MIN_VALUE),
                sa = round(ring.startAngle % 360),
                ea = round((sa + ring.angle) % 360),
                innerRadius = ring.ir,
                allAngles = [0, 90, 180, 270, sa, ea].sort(numericComparer),
                saIndex = indexOf(sa, allAngles),
                eaIndex = indexOf(ea, allAngles),
                angles,
                i,
                point;

            if (sa == ea) {
                angles = allAngles;
            } else {
                if (saIndex < eaIndex) {
                    angles = allAngles.slice(saIndex, eaIndex + 1);
                } else {
                    angles = [].concat(
                        allAngles.slice(0, eaIndex + 1),
                        allAngles.slice(saIndex, allAngles.length)
                    );
                }
            }

            for (i = 0; i < angles.length; i++) {
                point = ring.point(angles[i]);
                box.wrapPoint(point);
                box.wrapPoint(point, innerRadius);
            }

            if (!innerRadius) {
                box.wrapPoint(ring.c);
            }

            return box;
        },

        expand: function(value) {
            this.r += value;
            return this;
        }
    });

    // TODO: Remove, looks like an alias
    var Sector = Ring.extend({
        init: function(center, radius, startAngle, angle) {
            Ring.fn.init.call(this, center, 0, radius, startAngle, angle);
        },

        expand: function(value) {
            return Ring.fn.expand.call(this, value);
        },

        clone: function() {
            var sector = this;
            return new Sector(sector.c, sector.r, sector.startAngle, sector.angle);
        },

        radius: function(newRadius) {
            return Ring.fn.radius.call(this, newRadius);
        },

        point: function(angle) {
            return Ring.fn.point.call(this, angle);
        }
    });

    var Pin = Class.extend({
        init: function(options) {
            deepExtend(this, {
                height: 40,
                rotation: 90,
                radius: 10,
                arcAngle: 10
            }, options);
        }
    });

    // View-Model primitives ==================================================
    var ChartElement = Class.extend({
        init: function(options) {
            var element = this;
            element.children = [];

            element.options = deepExtend({}, element.options, options);
        },

        reflow: function(targetBox) {
            var element = this,
                children = element.children,
                box,
                i,
                currentChild;

            for (i = 0; i < children.length; i++) {
                currentChild = children[i];

                currentChild.reflow(targetBox);
                box = box ? box.wrap(currentChild.box) : currentChild.box.clone();
            }

            element.box = box || targetBox;
        },

        getViewElements: function(view) {
            var element = this,
                options = element.options,
                modelId = options.modelId,
                viewElements = [],
                root,
                children = element.children,
                i,
                child,
                childrenCount = children.length;

            for (i = 0; i < childrenCount; i++) {
                child = children[i];

                if (!child.discoverable) {
                    child.options = child.options || {};
                    child.options.modelId = modelId;
                }

                viewElements.push.apply(
                    viewElements, child.getViewElements(view));
            }

            if (element.discoverable) {
                root = element.getRoot();
                if (root) {
                    root.modelMap[modelId] = element;
                }
            }

            return viewElements;
        },

        enableDiscovery: function() {
            var element = this,
                options = element.options;

            options.modelId = IDPool.current.alloc();
            element.discoverable = true;
        },

        destroy: function() {
            var element = this,
                children = element.children,
                root = element.getRoot(),
                modelId = element.options.modelId,
                id = element.options.id,
                pool = IDPool.current,
                i;

            if (id) {
                pool.free(id);
            }

            if (modelId) {
                pool.free(modelId);

                if (root && root.modelMap[modelId]) {
                    root.modelMap[modelId] = undefined;
                }
            }

            for (i = 0; i < children.length; i++) {
                children[i].destroy();
            }
        },

        getRoot: function() {
            var parent = this.parent;

            return parent ? parent.getRoot() : null;
        },

        translateChildren: function(dx, dy) {
            var element = this,
                children = element.children,
                childrenCount = children.length,
                i;

            for (i = 0; i < childrenCount; i++) {
                children[i].box.translate(dx, dy);
            }
        },

        append: function() {
            var element = this,
                i,
                length = arguments.length;

            append(element.children, arguments);

            for (i = 0; i < length; i++) {
                arguments[i].parent = element;
            }
        }
    });

    var RootElement = ChartElement.extend({
        init: function(options) {
            var root = this;

            // Logical tree ID to element map
            root.modelMap = {};

            ChartElement.fn.init.call(root, options);
        },

        options: {
            width: DEFAULT_WIDTH,
            height: DEFAULT_HEIGHT,
            background: WHITE,
            border: {
                color: BLACK,
                width: 0
            },
            margin: getSpacing(5),
            zIndex: -2
        },

        reflow: function() {
            var root = this,
                options = root.options,
                children = root.children,
                currentBox = new Box2D(0, 0, options.width, options.height);

            root.box = currentBox.unpad(options.margin);

            for (var i = 0; i < children.length; i++) {
                children[i].reflow(currentBox);
                currentBox = boxDiff(currentBox, children[i].box);
            }
        },

        getViewElements: function(view) {
            var root = this,
                options = root.options,
                border = options.border || {},
                box = root.box.clone().pad(options.margin).unpad(border.width),
                elements = [
                        view.createRect(box, {
                            stroke: border.width ? border.color : "",
                            strokeWidth: border.width,
                            dashType: border.dashType,
                            fill: options.background,
                            fillOpacity: options.opacity,
                            zIndex: options.zIndex })
                    ];

            return elements.concat(
                ChartElement.fn.getViewElements.call(root, view)
            );
        },

        getRoot: function() {
            return this;
        }
    });

    var BoxElement = ChartElement.extend({
        init: function(options) {
            ChartElement.fn.init.call(this, options);
        },

        options: {
            align: LEFT,
            vAlign: TOP,
            margin: {},
            padding: {},
            border: {
                color: BLACK,
                width: 0
            },
            background: "",
            shrinkToFit: false,
            width: 0,
            height: 0,
            visible: true
        },

        reflow: function(targetBox) {
            var element = this,
                box,
                contentBox,
                options = element.options,
                margin = getSpacing(options.margin),
                padding = getSpacing(options.padding),
                borderWidth = options.border.width,
                children = element.children,
                i, item;

            function reflowPaddingBox() {
                element.align(targetBox, X, options.align);
                element.align(targetBox, Y, options.vAlign);
                element.paddingBox = box.clone().unpad(margin).unpad(borderWidth);
            }

            ChartElement.fn.reflow.call(element, targetBox);

            if (options.width && options.height) {
                box = element.box = new Box2D(0, 0, options.width, options.height);
            } else {
                box = element.box;
            }

            if (options.shrinkToFit) {
                reflowPaddingBox();
                contentBox = element.contentBox = element.paddingBox.clone().unpad(padding);
            } else {
                contentBox = element.contentBox = box.clone();
                box.pad(padding).pad(borderWidth).pad(margin);
                reflowPaddingBox();
            }

            element.translateChildren(
                box.x1 - contentBox.x1 + margin.left + borderWidth + padding.left,
                box.y1 - contentBox.y1 + margin.top + borderWidth + padding.top);

            for (i = 0; i < children.length; i++) {
                item = children[i];
                item.reflow(item.box);
            }
        },

        align: function(targetBox, axis, alignment) {
            var element = this,
                box = element.box,
                c1 = axis + 1,
                c2 = axis + 2,
                sizeFunc = axis === X ? WIDTH : HEIGHT,
                size = box[sizeFunc]();

            if (inArray(alignment, [LEFT, TOP])) {
                box[c1] = targetBox[c1];
                box[c2] = box[c1] + size;
            } else if (inArray(alignment, [RIGHT, BOTTOM])) {
                box[c2] = targetBox[c2];
                box[c1] = box[c2] - size;
            } else if (alignment == CENTER) {
                box[c1] = targetBox[c1] + (targetBox[sizeFunc]() - size) / 2;
                box[c2] = box[c1] + size;
            }
        },

        hasBox: function() {
            var options = this.options;
            return options.border.width || options.background;
        },

        getViewElements: function(view, renderOptions) {
            var boxElement = this,
                options = boxElement.options,
                elements = [];

            if (!options.visible) {
                return [];
            }


            if (boxElement.hasBox()) {
                elements.push(
                    view.createRect(
                        boxElement.paddingBox,
                        deepExtend(boxElement.elementStyle(), renderOptions)
                    )
                );
            }

            return elements.concat(
                ChartElement.fn.getViewElements.call(boxElement, view)
            );
        },

        elementStyle: function() {
            var boxElement = this,
                options = boxElement.options,
                border = options.border || {};

            return {
                id: options.id,
                stroke: border.width ? border.color : "",
                strokeWidth: border.width,
                dashType: border.dashType,
                strokeOpacity: options.opacity,
                fill: options.background,
                fillOpacity: options.opacity,
                animation: options.animation,
                zIndex: options.zIndex,
                data: { modelId: options.modelId }
            };
        }
    });

    var Text = ChartElement.extend({
        init: function(content, options) {
            var text = this;

            ChartElement.fn.init.call(text, options);

            text.content = decodeEntities(content);

            // Calculate size
            text.reflow(Box2D());
        },

        options: {
            font: DEFAULT_FONT,
            color: BLACK,
            align: LEFT,
            vAlign: ""
        },

        reflow: function(targetBox) {
            var text = this,
                options = text.options,
                size,
                margin;

            size = options.size =
                measureText(text.content, { font: options.font }, options.rotation);

            text.baseline = size.baseline;

            if (options.align == LEFT) {
                text.box = new Box2D(
                    targetBox.x1, targetBox.y1,
                    targetBox.x1 + size.width, targetBox.y1 + size.height);
            } else if (options.align == RIGHT) {
                text.box = new Box2D(
                    targetBox.x2 - size.width, targetBox.y1,
                    targetBox.x2, targetBox.y1 + size.height);
            } else if (options.align == CENTER) {
                margin = (targetBox.width() - size.width) / 2;
                text.box = new Box2D(
                    round(targetBox.x1 + margin, COORD_PRECISION), targetBox.y1,
                    round(targetBox.x2 - margin, COORD_PRECISION), targetBox.y1 + size.height);
            }

            if (options.vAlign == CENTER) {
                margin = (targetBox.height() - size.height) /2;
                text.box = new Box2D(
                    text.box.x1, targetBox.y1 + margin,
                    text.box.x2, targetBox.y2 - margin);
            } else if (options.vAlign == BOTTOM) {
                text.box = new Box2D(
                    text.box.x1, targetBox.y2 - size.height,
                    text.box.x2, targetBox.y2);
            } else if (options.vAlign == TOP) {
                text.box = new Box2D(
                    text.box.x1, targetBox.y1,
                    text.box.x2, targetBox.y1 + size.height);
            }
        },

        getViewElements: function(view) {
            var text = this,
                options = text.options;

            ChartElement.fn.getViewElements.call(this, view);

            return [
                view.createText(text.content,
                    deepExtend({}, options, {
                        x: text.box.x1, y: text.box.y1,
                        baseline: text.baseline,
                        data: { modelId: options.modelId }
                    })
                )
            ];
        }
    });

    var TextBox = BoxElement.extend({
        init: function(content, options) {
            var textBox = this,
                text;

            BoxElement.fn.init.call(textBox, options);
            options = textBox.options;

            text = new Text(content, deepExtend({ }, options, { align: LEFT, vAlign: TOP }));
            textBox.append(text);

            if (textBox.hasBox()) {
                text.options.id = uniqueId();
            }

            // Calculate size
            textBox.reflow(new Box2D());
        }
    });

    var Title = ChartElement.extend({
        init: function(options) {
            var title = this;
            ChartElement.fn.init.call(title, options);

            options = title.options;
            title.append(
                new TextBox(options.text, deepExtend({}, options, {
                    vAlign: options.position
                }))
            );
        },

        options: {
            color: BLACK,
            position: TOP,
            align: CENTER,
            margin: getSpacing(5),
            padding: getSpacing(5)
        },

        reflow: function(targetBox) {
            var title = this;

            ChartElement.fn.reflow.call(title, targetBox);
            title.box.snapTo(targetBox, X);
        }
    });

    Title.buildTitle = function(options, parent, defaultOptions) {
        var title;

        if (typeof options === "string") {
            options = { text: options };
        }

        options = deepExtend({ visible: true }, defaultOptions, options);

        if (options && options.visible && options.text) {
            title = new Title(options);
            parent.append(title);
        }

        return title;
    };

    var AxisLabel = TextBox.extend({
        init: function(value, index, dataItem, options) {
            var label = this,
                text = value;

            if (options.template) {
                label.template = template(options.template);
                text = label.template({ value: value, dataItem: dataItem });
            } else if (options.format) {
                text = label.formatValue(value, options);
            }

            label.text = text;
            label.value = value;
            label.index = index;
            label.dataItem = dataItem;

            TextBox.fn.init.call(label, text,
                deepExtend({ id: uniqueId() }, options)
            );

            label.enableDiscovery();
        },

        formatValue: function(value, options) {
            return autoFormat(options.format, value);
        },

        click: function(widget, e) {
            var label = this;

            widget.trigger(AXIS_LABEL_CLICK, {
                element: $(e.target),
                value: label.value,
                text: label.text,
                index: label.index,
                dataItem: label.dataItem,
                axis: label.parent.options
            });
        }
    });

    var Axis = ChartElement.extend({
        init: function(options) {
            var axis = this;

            ChartElement.fn.init.call(axis, options);

            if (!axis.options.visible) {
                axis.options = deepExtend({}, axis.options, {
                    labels: {
                        visible: false
                    },
                    line: {
                        visible: false
                    },
                    margin: 0,
                    majorTickSize: 0,
                    minorTickSize: 0
                });
            }

            axis.options.minorTicks = deepExtend({}, {
                color: axis.options.line.color,
                width: axis.options.line.width,
                visible: axis.options.minorTickType != NONE
            }, axis.options.minorTicks, {
                size: axis.options.minorTickSize,
                align: axis.options.minorTickType
            });

            axis.options.majorTicks = deepExtend({}, {
                color: axis.options.line.color,
                width: axis.options.line.width,
                visible: axis.options.majorTickType != NONE
            }, axis.options.majorTicks, {
                size: axis.options.majorTickSize,
                align: axis.options.majorTickType
            });

            axis.createLabels();
            axis.createTitle();
            axis.createNotes();
        },

        options: {
            labels: {
                visible: true,
                rotation: 0,
                mirror: false,
                step: 1,
                skip: 0
            },
            line: {
                width: 1,
                color: BLACK,
                visible: true
            },
            title: {
                visible: true,
                position: CENTER
            },
            majorTicks: {
                align: OUTSIDE,
                size: 4,
                skip: 0,
                step: 1
            },
            minorTicks: {
                align: OUTSIDE,
                size: 3,
                skip: 0,
                step: 1
            },
            axisCrossingValue: 0,
            majorTickType: OUTSIDE,
            minorTickType: NONE,
            majorGridLines: {
                skip: 0,
                step: 1
            },
            minorGridLines: {
                visible: false,
                width: 1,
                color: BLACK,
                skip: 0,
                step: 1
            },
            // TODO: Move to line or labels options
            margin: 5,
            visible: true,
            reverse: false,
            justified: true,
            notes: {},

            _alignLines: true
        },

        // abstract labelsCount(): Number
        // abstract createAxisLabel(index, options): AxisLabel

        createLabels: function() {
            var axis = this,
                options = axis.options,
                align = options.vertical ? RIGHT : CENTER,
                labelOptions = deepExtend({ }, options.labels, {
                    align: align, zIndex: options.zIndex,
                    modelId: options.modelId
                }),
                step = labelOptions.step;

            axis.labels = [];

            if (labelOptions.visible) {
                var labelsCount = axis.labelsCount(),
                    label,
                    i;

                for (i = labelOptions.skip; i < labelsCount; i += step) {
                    label = axis.createAxisLabel(i, labelOptions);
                    axis.append(label);
                    axis.labels.push(label);
                }
            }
        },

        // TODO: Redundant - labels are child elements
        destroy: function() {
            var axis = this,
                labels = axis.labels,
                i;

            for (i = 0; i < labels.length; i++) {
                labels[i].destroy();
            }

            ChartElement.fn.destroy.call(axis);
        },

        lineBox: function() {
            var axis = this,
                options = axis.options,
                box = axis.box,
                vertical = options.vertical,
                labels = axis.labels,
                labelSize = vertical ? HEIGHT : WIDTH,
                justified = options.justified,
                mirror = options.labels.mirror,
                axisX = mirror ? box.x1 : box.x2,
                axisY = mirror ? box.y2 : box.y1,
                startMargin = 0,
                endMargin = options.line.width;

            if (justified && labels.length > 1) {
                startMargin = labels[0].box[labelSize]() / 2;
                endMargin = last(labels).box[labelSize]() / 2;
            }

            return vertical ?
                Box2D(axisX, box.y1 + startMargin, axisX, box.y2 - endMargin) :
                Box2D(box.x1 + startMargin, axisY, box.x2 - endMargin, axisY);
        },

        createTitle: function() {
            var axis = this,
                options = axis.options,
                titleOptions = deepExtend({
                    rotation: options.vertical ? -90 : 0,
                    text: "",
                    zIndex: 1
                }, options.title),
                title;

            if (titleOptions.visible && titleOptions.text) {
                title = new TextBox(titleOptions.text, titleOptions);
                axis.append(title);
                axis.title = title;
            }
        },

        createNotes: function() {
            var axis = this,
                options = axis.options,
                notes = options.notes,
                items = notes.data || [],
                noteTemplate, i, text, item, note;

            axis.notes = [];

            for (i = 0; i < items.length; i++) {
                item = deepExtend({}, notes, items[i]);
                item.value = axis.parseNoteValue(item.value);
                text = item.label.text || item.value;
                if (item.label.template) {
                    noteTemplate = template(item.label.template);
                    text = noteTemplate({
                        value: text
                    });
                } else if (item.label.format) {
                    text = autoFormat(item.label.format, text);
                }

                note = new Note(deepExtend({}, item, { label: { text: text }}));

                if (note.options.visible) {
                    if (defined(note.options.position)) {
                        if (options.vertical && !inArray(note.options.position, [LEFT, RIGHT])) {
                            note.options.position = options.reverse ? LEFT : RIGHT;
                        } else if (!options.vertical && !inArray(note.options.position, [TOP, BOTTOM])) {
                            note.options.position = options.reverse ? BOTTOM : TOP;
                        }
                    } else {
                        if (options.vertical) {
                            note.options.position = options.reverse ? LEFT : RIGHT;
                        } else {
                            note.options.position = options.reverse ? BOTTOM : TOP;
                        }
                    }
                    axis.append(note);
                    axis.notes.push(note);
                }
            }
        },

        parseNoteValue: function(value) {
            return value;
        },

        renderTicks: function(view) {
            var axis = this,
                ticks = [],
                options = axis.options,
                lineBox = axis.lineBox(),
                mirror = options.labels.mirror,
                majorUnit = options.majorTicks.visible ? options.majorUnit : 0,
                tickX, tickY, pos,
                start, end;

            function render(tickPositions, tickOptions) {
                var i, count = tickPositions.length;

                if (tickOptions.visible) {
                    for (i = tickOptions.skip; i < count; i += tickOptions.step) {
                        if (i % tickOptions.skipUnit === 0) {
                            continue;
                        }

                        tickX = mirror ? lineBox.x2 : lineBox.x2 - tickOptions.size;
                        tickY = mirror ? lineBox.y1 - tickOptions.size : lineBox.y1;
                        pos = tickPositions[i];

                        if (options.vertical) {
                            start = Point2D(tickX, pos);
                            end = Point2D(tickX + tickOptions.size, pos);
                        } else {
                            start = Point2D(pos, tickY);
                            end = Point2D(pos, tickY + tickOptions.size);
                        }

                        ticks.push(view.createLine(
                            start.x, start.y,
                            end.x, end.y, {
                                strokeWidth: tickOptions.width,
                                stroke: tickOptions.color,
                                align: options._alignLines
                            }));
                    }
                }
            }

            render(axis.getMajorTickPositions(), options.majorTicks);
            render(axis.getMinorTickPositions(), deepExtend({}, {
                    skipUnit: majorUnit / options.minorUnit
                }, options.minorTicks));

            return ticks;
        },

        renderLine: function(view) {
            var axis = this,
                options = axis.options,
                line = options.line,
                lineBox = axis.lineBox(),
                lineOptions,
                elements = [];

            if (line.width > 0 && line.visible) {
                lineOptions = {
                    strokeWidth: line.width,
                    stroke: line.color,
                    dashType: line.dashType,
                    zIndex: line.zIndex,
                    align: options._alignLines
                };

                elements.push(view.createLine(
                    lineBox.x1, lineBox.y1, lineBox.x2, lineBox.y2,
                    lineOptions));

                append(elements, axis.renderTicks(view));
            }

            return elements;
        },

        getViewElements: function(view) {
            var axis = this,
                elements = ChartElement.fn.getViewElements.call(axis, view);

            append(elements, axis.renderLine(view));
            append(elements, axis.renderPlotBands(view));

            return elements;
        },

        getActualTickSize: function () {
            var axis = this,
                options = axis.options,
                tickSize = 0;

            if (options.majorTicks.visible && options.minorTicks.visible) {
                tickSize = math.max(options.majorTicks.size, options.minorTicks.size);
            } else if (options.majorTicks.visible) {
                tickSize = options.majorTicks.size;
            } else if (options.minorTicks.visible) {
                tickSize = options.minorTicks.size;
            }

            return tickSize;
        },

        renderPlotBands: function(view) {
            var axis = this,
                options = axis.options,
                plotBands = options.plotBands || [],
                vertical = options.vertical,
                result = [],
                plotArea = axis.plotArea,
                slotX, slotY, from, to;

            if (plotBands.length) {
                result = map(plotBands, function(item) {
                    from = valueOrDefault(item.from, MIN_VALUE);
                    to = valueOrDefault(item.to, MAX_VALUE);

                    if (vertical) {
                        slotX = plotArea.axisX.lineBox();
                        slotY = axis.getSlot(item.from, item.to);
                    } else {
                        slotX = axis.getSlot(item.from, item.to);
                        slotY = plotArea.axisY.lineBox();
                    }

                    return view.createRect(
                            Box2D(slotX.x1, slotY.y1, slotX.x2, slotY.y2),
                            { fill: item.color, fillOpacity: item.opacity, zIndex: -1 });
                });
            }

            return result;
        },

        renderGridLines: function(view, altAxis) {
            var axis = this,
                items = [],
                options = axis.options,
                modelId = axis.plotArea.options.modelId,
                axisLineVisible = altAxis.options.line.visible,
                majorGridLines = options.majorGridLines,
                majorUnit = majorGridLines.visible ? options.majorUnit : 0,
                vertical = options.vertical,
                lineBox = altAxis.lineBox(),
                lineStart = lineBox[vertical ? "x1" : "y1"],
                lineEnd = lineBox[vertical ? "x2" : "y2"],
                linePos = lineBox[vertical ? "y1" : "x1"],
                pos, majorTicks = [], start, end;

            function render(tickPositions, gridLine) {
                var count = tickPositions.length,
                    i;

                if (gridLine.visible) {
                    for (i = gridLine.skip; i < count; i += gridLine.step) {
                        pos = round(tickPositions[i]);
                        if (!inArray(pos, majorTicks)) {
                            if (i % gridLine.skipUnit !== 0 && (!axisLineVisible || linePos !== pos)) {
                                if (options.vertical) {
                                    start = Point2D(lineStart, pos);
                                    end = Point2D(lineEnd, pos);
                                } else {
                                    start = Point2D(pos, lineStart);
                                    end = Point2D(pos, lineEnd);
                                }

                                if (start && end) {
                                    items.push(view.createLine(
                                        start.x, start.y,
                                        end.x, end.y, {
                                            data: { modelId: modelId },
                                            strokeWidth: gridLine.width,
                                            stroke: gridLine.color,
                                            dashType: gridLine.dashType,
                                            zIndex: -1
                                        }));

                                    majorTicks.push(pos);
                                }
                            }
                        }
                    }
                }
            }

            render(axis.getMajorTickPositions(), options.majorGridLines);
            render(axis.getMinorTickPositions(), deepExtend({}, {
                    skipUnit: majorUnit / options.minorUnit
                }, options.minorGridLines));

            return items;
        },

        reflow: function(box) {
            var axis = this,
                options = axis.options,
                vertical = options.vertical,
                labels = axis.labels,
                count = labels.length,
                space = axis.getActualTickSize() + options.margin,
                maxLabelHeight = 0,
                maxLabelWidth = 0,
                title = axis.title,
                label, i;

            for (i = 0; i < count; i++) {
                label = labels[i];
                maxLabelHeight = math.max(maxLabelHeight, label.box.height());
                maxLabelWidth = math.max(maxLabelWidth, label.box.width());
            }

            if (title) {
                if (vertical) {
                    maxLabelWidth += title.box.width();
                } else {
                    maxLabelHeight += title.box.height();
                }
            }

            if (vertical) {
                axis.box = Box2D(
                    box.x1, box.y1,
                    box.x1 + maxLabelWidth + space, box.y2
                );
            } else {
                axis.box = Box2D(
                    box.x1, box.y1,
                    box.x2, box.y1 + maxLabelHeight + space
                );
            }

            axis.arrangeTitle();
            axis.arrangeLabels();
            axis.arrangeNotes();
        },

        arrangeLabels: function() {
            var axis = this,
                options = axis.options,
                labelOptions = options.labels,
                labels = axis.labels,
                labelsBetweenTicks = !options.justified,
                vertical = options.vertical,
                lineBox = axis.lineBox(),
                mirror = options.labels.mirror,
                tickPositions = axis.getMajorTickPositions(),
                labelOffset = axis.getActualTickSize()  + options.margin,
                labelBox, labelY, i;

            for (i = 0; i < labels.length; i++) {
                var label = labels[i],
                    tickIx = labelOptions.skip + labelOptions.step * i,
                    labelSize = vertical ? label.box.height() : label.box.width(),
                    labelPos = tickPositions[tickIx] - (labelSize / 2),
                    firstTickPosition, nextTickPosition, middle, labelX;

                if (vertical) {
                    if (labelsBetweenTicks) {
                        firstTickPosition = tickPositions[tickIx];
                        nextTickPosition = tickPositions[tickIx + 1];

                        middle = firstTickPosition + (nextTickPosition - firstTickPosition) / 2;
                        labelPos = middle - (labelSize / 2);
                    }

                    labelX = lineBox.x2;

                    if (mirror) {
                        labelX += labelOffset;
                    } else {
                        labelX -= labelOffset + label.box.width();
                    }

                    labelBox = label.box.move(labelX, labelPos);
                } else {
                    if (labelsBetweenTicks) {
                        firstTickPosition = tickPositions[tickIx];
                        nextTickPosition = tickPositions[tickIx + 1];
                    } else {
                        firstTickPosition = labelPos;
                        nextTickPosition = labelPos + labelSize;
                    }

                    labelY = lineBox.y1;

                    if (mirror) {
                        labelY -= labelOffset + label.box.height();
                    } else {
                        labelY += labelOffset;
                    }

                    labelBox = Box2D(firstTickPosition, labelY,
                                    nextTickPosition, labelY + label.box.height());
                }

                label.reflow(labelBox);
            }
        },

        arrangeTitle: function() {
            var axis = this,
                options = axis.options,
                mirror = options.labels.mirror,
                vertical = options.vertical,
                title = axis.title;

            if (title) {
                if (vertical) {
                    title.options.align = mirror ? RIGHT : LEFT;
                    title.options.vAlign = title.options.position;
                } else {
                    title.options.align = title.options.position;
                    title.options.vAlign = mirror ? TOP : BOTTOM;
                }

                title.reflow(axis.box);
            }
        },

        arrangeNotes: function() {
            var axis = this,
                i, item, slot, value;

            for (i = 0; i < axis.notes.length; i++) {
                item = axis.notes[i];
                value = item.options.value;
                if (defined(value)) {
                    if (axis.shouldRenderNote(value)) {
                        item.show();
                    } else {
                        item.hide();
                    }

                    slot = axis.getSlot(value);
                } else {
                    item.hide();
                }

                item.reflow(slot || axis.lineBox());
            }
        },

        alignTo: function(secondAxis) {
            var axis = this,
                lineBox = secondAxis.lineBox(),
                vertical = axis.options.vertical,
                pos = vertical ? Y : X;

            axis.box.snapTo(lineBox, pos);
            if (vertical) {
                axis.box.shrink(0, axis.lineBox().height() - lineBox.height());
            } else {
                axis.box.shrink(axis.lineBox().width() - lineBox.width(), 0);
            }
            axis.box[pos + 1] -= axis.lineBox()[pos + 1] - lineBox[pos + 1];
            axis.box[pos + 2] -= axis.lineBox()[pos + 2] - lineBox[pos + 2];
        }
    });

    var Note = BoxElement.extend({
        init: function(options) {
            var note = this;

            BoxElement.fn.init.call(note, options);
            note.enableDiscovery();

            note.render();
        },

        options: {
            icon: {
                zIndex: 1,
                visible: true,
                type: CIRCLE
            },
            label: {
                zIndex: 2,
                position: INSIDE,
                visible: true,
                align: CENTER,
                vAlign: CENTER
            },
            line: {
                visible: true,
                zIndex: 2
            },
            visible: true,
            position: TOP
        },

        hide: function() {
            this.options.visible = false;
        },

        show: function() {
            this.options.visible = true;
        },

        render: function() {
            var note = this,
                options = note.options,
                label = options.label,
                icon = options.icon,
                size = icon.size,
                dataModelId = { data: { modelId: options.modelId } },
                box = Box2D(),
                marker, width, height;

            if (options.visible) {
                if (defined(label) && label.visible) {
                    note.label = new TextBox(label.text || options.value, deepExtend({}, label, dataModelId));
                    note.append(note.label);

                    if (label.position === INSIDE) {
                        if (icon.type === CIRCLE) {
                            size = math.max(note.label.box.width(), note.label.box.height());
                        } else {
                            width = note.label.box.width();
                            height = note.label.box.height();
                        }
                        box.wrap(note.label.box);
                    }
                }

                icon.width = width || size;
                icon.height = height || size;

                marker = new ShapeElement(deepExtend({}, icon, dataModelId));

                note.marker = marker;
                note.append(marker);
                marker.reflow(Box2D());
                note.wrapperBox = box.wrap(marker.box);
            }
        },

        reflow: function(targetBox) {
            var note = this,
                options = note.options,
                center = targetBox.center(),
                wrapperBox = note.wrapperBox,
                length = options.line.length,
                position = options.position,
                label = note.label,
                marker = note.marker,
                lineStart, box, contentBox;

            if (options.visible) {
                if (inArray(position, [LEFT, RIGHT])) {
                    if (position === LEFT) {
                        contentBox = wrapperBox.alignTo(targetBox, position).translate(-length, targetBox.center().y - wrapperBox.center().y);

                        if (options.line.visible) {
                            lineStart = Point2D(math.floor(targetBox.x1), center.y);
                            note.linePoints = [
                                lineStart,
                                Point2D(math.floor(contentBox.x2), center.y)
                            ];
                            box = contentBox.clone().wrapPoint(lineStart);
                        }
                    } else {
                        contentBox = wrapperBox.alignTo(targetBox, position).translate(length, targetBox.center().y - wrapperBox.center().y);

                        if (options.line.visible) {
                            lineStart = Point2D(math.floor(targetBox.x2), center.y);
                            note.linePoints = [
                                lineStart,
                                Point2D(math.floor(contentBox.x1), center.y)
                            ];
                            box = contentBox.clone().wrapPoint(lineStart);
                        }
                    }
                } else {
                    if (position === BOTTOM) {
                        contentBox = wrapperBox.alignTo(targetBox, position).translate(targetBox.center().x - wrapperBox.center().x, length);

                        if (options.line.visible) {
                            lineStart = Point2D(math.floor(center.x), math.floor(targetBox.y2));
                            note.linePoints = [
                                lineStart,
                                Point2D(math.floor(center.x), math.floor(contentBox.y1))
                            ];
                            box = contentBox.clone().wrapPoint(lineStart);
                        }
                    } else {
                        contentBox = wrapperBox.alignTo(targetBox, position).translate(targetBox.center().x - wrapperBox.center().x, -length);

                        if (options.line.visible) {
                            lineStart = Point2D(math.floor(center.x), math.floor(targetBox.y1));
                            note.linePoints = [
                                lineStart,
                                Point2D(math.floor(center.x), math.floor(contentBox.y2))
                            ];
                            box = contentBox.clone().wrapPoint(lineStart);
                        }
                    }
                }

                if (marker) {
                    marker.reflow(contentBox);
                }

                if (label) {
                    label.reflow(contentBox);
                    if (marker) {
                        if (options.label.position === OUTSIDE) {
                            label.box.alignTo(marker.box, position);
                        }
                        label.reflow(label.box);
                    }
                }
                note.contentBox = contentBox;
                note.box = box || contentBox;
            }
        },

        getViewElements: function(view) {
            var note = this,
                elements = BoxElement.fn.getViewElements.call(note, view),
                group = view.createGroup({
                    data: { modelId: note.options.modelId },
                    zIndex: 1
                });

            if (note.options.visible) {
                append(elements, note.createLine(view));
            }

            group.children = elements;

            return [ group ];
        },

        createLine: function(view) {
            var note = this,
                line = note.options.line;

            return [
                view.createPolyline(note.linePoints, false, {
                    stroke: line.color,
                    strokeWidth: line.width,
                    dashType: line.dashType,
                    zIndex: line.zIndex
                })
            ];
        },

        click: function(widget, e) {
            var args = this.eventArgs(e);

            if (!widget.trigger(NOTE_CLICK, args)) {
                e.preventDefault();
            }
        },

        hover: function(widget, e) {
            var args = this.eventArgs(e);

            if (!widget.trigger(NOTE_HOVER, args)) {
                e.preventDefault();
            }
        },

        leave: function(widget) {
            widget._unsetActivePoint();
        },

        eventArgs: function(e) {
            var note = this.parent,
                options = note.options;

            return {
                element: $(e.target),
                text: defined(options.label) ? options.label.text : ""
            };
        }
    });

    var ShapeElement = BoxElement.extend({
        options: {
            type: CIRCLE,
            align: CENTER,
            vAlign: CENTER
        },

        getViewElements: function(view, renderOptions) {
            var marker = this,
                options = marker.options,
                type = options.type,
                rotation = options.rotation,
                box = marker.paddingBox,
                element,
                elementOptions,
                center = box.center(),
                halfWidth = box.width() / 2,
                points,
                i;

            // Make sure that this element will be added in the model map.
            ChartElement.fn.getViewElements.call(this, view);

            if ((renderOptions || {}).visible !== true) {
                if (!options.visible || !marker.hasBox())  {
                    return [];
                }
            }

            elementOptions = deepExtend(marker.elementStyle(), renderOptions);

            if (type === CIRCLE) {
                element = view.createCircle(new Point2D(
                    round(box.x1 + halfWidth, COORD_PRECISION),
                    round(box.y1 + box.height() / 2, COORD_PRECISION)
                ), halfWidth, elementOptions);
            } else if (type === TRIANGLE) {
                points = [
                    new Point2D(box.x1 + halfWidth, box.y1),
                    new Point2D(box.x1, box.y2),
                    new Point2D(box.x2, box.y2)
                ];
            } else {
                points = box.points();
            }

            if (points) {
                if (rotation) {
                    for (i = 0; i < points.length; i++) {
                        points[i].rotate(center, rotation);
                    }
                }

                element = view.createPolyline(
                    points, true, elementOptions
                );
            }

            return [ element ];
        }
    });

    var PinElement = BoxElement.extend({
        init: function(options) {
            var pin = this;

            BoxElement.fn.init.call(pin, options);

            pin.createTextBox();
        },

        options: {
            arcAngle: 300,
            border: {
                width: 1,
                color: "red"
            },
            label: {
                zIndex: 2,
                margin: getSpacing(2),
                border: {
                    width: 1,
                    color: "green"
                }
            }
        },

        createTextBox: function() {
            var pin = this,
                options = pin.options,
                textBox = new TextBox(options.code, options.label);

            pin.append(textBox);
            pin.textBox = textBox;
        },

        reflow: function(targetBox) {
            var pin = this,
                textBox = pin.textBox;

            pin.box = Box2D(0, 0, textBox.box.height(), textBox.box.height() * 1.5);

            BoxElement.fn.reflow.call(pin, targetBox);
        },

        getViewElements: function(view) {
            var pin = this,
                options = pin.options,
                center = pin.box.center(),
                element = view.createPin(new Pin({
                    origin: new Point2D(center.x, center.y),
                    radius: pin.textBox.box.height() / 2,
                    height: pin.textBox.box.height() * 1.5,
                    rotation: 0,
                    arcAngle: options.arcAngle
                }), deepExtend({}, {
                    fill: "red",
                    zIndex: 1,
                    kur: 1,
                    id: "111"
                }, options)),
                elements = [ element ];


            append(elements, BoxElement.fn.getViewElements.call(pin, view));

            return elements;
        }
    });

    var NumericAxis = Axis.extend({
        init: function(seriesMin, seriesMax, options) {
            var axis = this,
                defaultOptions = axis.initDefaults(seriesMin, seriesMax, options);

            Axis.fn.init.call(axis, defaultOptions);
        },

        options: {
            type: "numeric",
            min: 0,
            max: 1,
            vertical: true,
            majorGridLines: {
                visible: true,
                width: 1,
                color: BLACK
            },
            zIndex: 1
        },

        initDefaults: function(seriesMin, seriesMax, options) {
            var axis = this,
                narrowRange = options.narrowRange,
                autoMin = axis.autoAxisMin(seriesMin, seriesMax, narrowRange),
                autoMax = axis.autoAxisMax(seriesMin, seriesMax, narrowRange),
                majorUnit = autoMajorUnit(autoMin, autoMax),
                autoOptions = {
                    majorUnit: majorUnit
                },
                userSetLimits;

            if (options.roundToMajorUnit !== false) {
                if (autoMin < 0 && remainderClose(autoMin, majorUnit, 1/3)) {
                    autoMin -= majorUnit;
                }

                if (autoMax > 0 && remainderClose(autoMax, majorUnit, 1/3)) {
                    autoMax += majorUnit;
                }
            }

            autoOptions.min = floor(autoMin, majorUnit);
            autoOptions.max = ceil(autoMax, majorUnit);

            if (options) {
                userSetLimits = defined(options.min) || defined(options.max);
                if (userSetLimits) {
                    if (options.min === options.max) {
                        if (options.min > 0) {
                            options.min = 0;
                        } else {
                            options.max = 1;
                        }
                    }
                }

                if (options.majorUnit) {
                    autoOptions.min = floor(autoOptions.min, options.majorUnit);
                    autoOptions.max = ceil(autoOptions.max, options.majorUnit);
                } else if (userSetLimits) {
                    options = deepExtend(autoOptions, options);

                    // Determine an auto major unit after min/max have been set
                    autoOptions.majorUnit = autoMajorUnit(options.min, options.max);
                }
            }

            autoOptions.minorUnit = (options.majorUnit || autoOptions.majorUnit) / 5;

            return deepExtend(autoOptions, options);
        },

        range: function() {
            var options = this.options;
            return { min: options.min, max: options.max };
        },

        autoAxisMax: function(min, max, narrow) {
            var axisMax,
                diff;

            if (!min && !max) {
                return 1;
            }

            if (min <= 0 && max <= 0) {
                max = min == max ? 0 : max;

                diff = math.abs((max - min) / max);
                if(!narrow && diff > ZERO_THRESHOLD) {
                    return 0;
                }

                axisMax = math.min(0, max - ((min - max) / 2));
            } else {
                min = min == max ? 0 : min;
                axisMax = max;
            }

            return axisMax;
        },

        autoAxisMin: function(min, max, narrow) {
            var axisMin,
                diff;

            if (!min && !max) {
                return 0;
            }

            if (min >= 0 && max >= 0) {
                min = min == max ? 0 : min;

                diff = (max - min) / max;
                if(!narrow && diff > ZERO_THRESHOLD) {
                    return 0;
                }

                axisMin = math.max(0, min - ((max - min) / 2));
            } else {
                max = min == max ? 0 : max;
                axisMin = min;
            }

            return axisMin;
        },

        getDivisions: function(stepValue) {
            var options = this.options,
                range = options.max - options.min;

            return math.floor(round(range / stepValue, COORD_PRECISION)) + 1;
        },

        getTickPositions: function(unit, skipUnit) {
            var axis = this,
                options = axis.options,
                vertical = options.vertical,
                reverse = options.reverse,
                lineBox = axis.lineBox(),
                lineSize = vertical ? lineBox.height() : lineBox.width(),
                range = options.max - options.min,
                scale = lineSize / range,
                step = unit * scale,
                skipStep = 0,
                divisions = axis.getDivisions(unit),
                dir = (vertical ? -1 : 1) * (reverse ? -1 : 1),
                startEdge = dir === 1 ? 1 : 2,
                pos = lineBox[(vertical ? Y : X) + startEdge],
                positions = [],
                i;

            if (skipUnit) {
                skipStep = skipUnit / unit;
            }

            for (i = 0; i < divisions; i++) {
                if (i % skipStep !== 0) {
                    positions.push(round(pos, COORD_PRECISION));
                }

                pos = pos + step * dir;
            }

            return positions;
        },

        getMajorTickPositions: function() {
            var axis = this;

            return axis.getTickPositions(axis.options.majorUnit);
        },

        getMinorTickPositions: function() {
            var axis = this;

            return axis.getTickPositions(axis.options.minorUnit);
        },

        getSlot: function(a, b) {
            var axis = this,
                options = axis.options,
                reverse = options.reverse,
                vertical = options.vertical,
                valueAxis = vertical ? Y : X,
                lineBox = axis.lineBox(),
                lineStart = lineBox[valueAxis + (reverse ? 2 : 1)],
                lineSize = vertical ? lineBox.height() : lineBox.width(),
                dir = reverse ? -1 : 1,
                step = dir * (lineSize / (options.max - options.min)),
                p1,
                p2,
                slotBox = new Box2D(lineBox.x1, lineBox.y1, lineBox.x1, lineBox.y1);

            if (!defined(a)) {
                a = b || 0;
            }

            if (!defined(b)) {
                b = a || 0;
            }

            a = math.max(math.min(a, options.max), options.min);
            b = math.max(math.min(b, options.max), options.min);

            if (vertical) {
                p1 = options.max - math.max(a, b);
                p2 = options.max - math.min(a, b);
            } else {
                p1 = math.min(a, b) - options.min;
                p2 = math.max(a, b) - options.min;
            }

            slotBox[valueAxis + 1] = lineStart + step * (reverse ? p2 : p1);
            slotBox[valueAxis + 2] = lineStart + step * (reverse ? p1 : p2);

            return slotBox;
        },

        getValue: function(point) {
            var axis = this,
                options = axis.options,
                reverse = options.reverse,
                vertical = options.vertical,
                max = options.max * 1,
                min = options.min * 1,
                valueAxis = vertical ? Y : X,
                lineBox = axis.lineBox(),
                lineStart = lineBox[valueAxis + (reverse ? 2 : 1)],
                lineSize = vertical ? lineBox.height() : lineBox.width(),
                dir = reverse ? -1 : 1,
                offset = dir * (point[valueAxis] - lineStart),
                step = (max - min) / lineSize,
                valueOffset = offset * step,
                value;

            if (offset < 0 || offset > lineSize) {
                return null;
            }

            value = vertical ?
                    max - valueOffset :
                    min + valueOffset;

            return round(value, DEFAULT_PRECISION);
        },

        translateRange: function(delta) {
            var axis = this,
                options = axis.options,
                lineBox = axis.lineBox(),
                vertical = options.vertical,
                reverse = options.reverse,
                size = vertical ? lineBox.height() : lineBox.width(),
                range = options.max - options.min,
                scale = size / range,
                offset = round(delta / scale, DEFAULT_PRECISION);

            if ((vertical || reverse) && !(vertical && reverse )) {
                offset = -offset;
            }

            return {
                min: options.min + offset,
                max: options.max + offset
            };
        },

        scaleRange: function(delta) {
            var axis = this,
                options = axis.options,
                offset = -delta * options.majorUnit;

            return {
                min: options.min - offset,
                max: options.max + offset
            };
        },

        labelsCount: function() {
            return this.getDivisions(this.options.majorUnit);
        },

        createAxisLabel: function(index, labelOptions) {
            var axis = this,
                options = axis.options,
                value = round(options.min + (index * options.majorUnit), DEFAULT_PRECISION);

            return new AxisLabel(value, index, null, labelOptions);
        },

        shouldRenderNote: function(value) {
            var range = this.range();
            return range.min <= value && value <= range.max;
        }
    });

    // View base classes ======================================================
    var ViewElement = Class.extend({
        init: function(options) {
            var element = this;
            element.children = [];
            element.options = deepExtend({}, element.options, options);
        },

        render: function() {
            return this.template(this);
        },

        renderContent: function() {
            var element = this,
                output = "",
                sortedChildren = element.sortChildren(),
                childrenCount = sortedChildren.length,
                i;

            for (i = 0; i < childrenCount; i++) {
                output += sortedChildren[i].render();
            }

            return output;
        },

        sortChildren: function() {
            var element = this,
                children = element.children,
                length,
                i;

            for (i = 0, length = children.length; i < length; i++) {
                children[i]._childIndex = i;
            }

            return children.slice(0).sort(element.compareChildren);
        },

        refresh: $.noop,

        destroy: function() {
            var element = this,
                id = element.options.id,
                children = element.children,
                length,
                i;

            if (id) {
                IDPool.current.free(id);
            }

            for (i = 0, length = children.length; i < length; i++) {
                children[i].destroy();
            }
        },

        compareChildren: function(a, b) {
            var aValue = a.options.zIndex || 0,
                bValue = b.options.zIndex || 0;

            if (aValue !== bValue) {
                return aValue - bValue;
            }

            return a._childIndex - b._childIndex;
        },

        renderId: function() {
            var element = this,
                result = "";

            if (element.options.id) {
                result = element.renderAttr("id", element.options.id);
            }

            return result;
        },

        renderAttr: function (name, value) {
            return defined(value) ? " " + name + "='" + value + "' " : "";
        },

        renderDataAttributes: function() {
            var element = this,
                data = element.options.data,
                key, attr, output = "";

            for (key in data) {
                attr = "data-" + key.replace(UPPERCASE_REGEX, "-$1").toLowerCase();
                output += element.renderAttr(attr, data[key]);
            }

            return output;
        },

        renderCursor: function() {
            var options = this.options,
                result = "";

            if (defined(options.cursor) && options.cursor.style) {
                result += "cursor: " + options.cursor.style + ";";
            }

            return result;
        }
    });

    var ViewBase = ViewElement.extend({
        init: function(options) {
            var view = this;

            ViewElement.fn.init.call(view, options);

            view.definitions = {};
            view.decorators = [];
            view.animations = [];
        },

        destroy: function() {
            var view = this,
                animations = view.animations,
                viewElement = view._viewElement;

            ViewElement.fn.destroy.call(this);

            while (animations.length > 0) {
                animations.shift().destroy();
            }

            if (viewElement) {
                view._freeIds(viewElement);
                view._viewElement = null;
            }
        },

        _freeIds: function(domElement) {
            $("[id]", domElement).each(function() {
                IDPool.current.free($(this).attr("id"));
            });
        },

        replace: function(model) {
            var view = this,
                element = getElement(model.options.id);

            if (element) {
                view._freeIds(element);

                element.parentNode.replaceChild(
                    view.renderElement(model.getViewElements(view)[0]),
                    element
                );
            }
        },

        load: function(model) {
            var view = this;
            view.children = model.getViewElements(view);
        },

        renderDefinitions: function() {
            var definitions = this.definitions,
                definitionId,
                output = "";

            for (definitionId in definitions) {
                if (definitions.hasOwnProperty(definitionId)) {
                    output += definitions[definitionId].render();
                }
            }

            return output;
        },

        decorate: function(element) {
            var decorators = this.decorators,
                i,
                length = decorators.length,
                currentDecorator;

            for (i = 0; i < length; i++) {
                currentDecorator = decorators[i];
                this._decorateChildren(currentDecorator, element);
                element = currentDecorator.decorate.call(currentDecorator, element);
            }

            return element;
        },

        _decorateChildren: function(decorator, element) {
            var view = this,
                children = element.children,
                i,
                length = children.length;

            for (i = 0; i < length; i++) {
                view._decorateChildren(decorator, children[i]);
                children[i] = decorator.decorate.call(decorator, children[i]);
            }
        },

        setupAnimations: function() {
            for (var i = 0; i < this.animations.length; i++) {
                this.animations[i].setup();
            }
        },

        playAnimations: function() {
            for (var i = 0; i < this.animations.length; i++) {
                this.animations[i].play();
            }
        },

        buildGradient: function(options) {
            var view = this,
                cache = view._gradientCache,
                hashCode,
                overlay,
                definition;

            if (!cache) {
                cache = view._gradientCache = [];
            }

            if (options) {
                hashCode = getHash(options);
                overlay = cache[hashCode];
                definition = dataviz.Gradients[options.gradient];
                if (!overlay && definition) {
                    overlay = deepExtend({ id: uniqueId() }, definition, options);
                    cache[hashCode] = overlay;
                }
            }

            return overlay;
        },

        setDefaults: function(options) {
            var viewOptions = this.options;

            options = options || {};

            if (!defined(options.inline)) {
                options.inline = viewOptions.inline;
            }

            if (!defined(options.align)) {
                options.align = viewOptions.align;
            }

            return options;
        }
    });

    dataviz.Gradients = {
        glass: {
            type: LINEAR,
            rotation: 0,
            stops: [{
                offset: 0,
                color: WHITE,
                opacity: 0
            }, {
                offset: 0.25,
                color: WHITE,
                opacity: 0.3
            }, {
                offset: 1,
                color: WHITE,
                opacity: 0
            }]
        },
        sharpBevel: {
            type: RADIAL,
            stops: [{
                offset: 0,
                color: WHITE,
                opacity: 0.55
            }, {
                offset: 0.65,
                color: WHITE,
                opacity: 0
            }, {
                offset: 0.95,
                color: WHITE,
                opacity: 0.25
            }]
        },
        roundedBevel: {
            type: RADIAL,
            stops: [{
                offset: 0.33,
                color: WHITE,
                opacity: 0.06
            }, {
                offset: 0.83,
                color: WHITE,
                opacity: 0.2
            }, {
                offset: 0.95,
                color: WHITE,
                opacity: 0
            }]
        },
        roundedGlass: {
            type: RADIAL,
            supportVML: false,
            stops: [{
                offset: 0,
                color: WHITE,
                opacity: 0
            }, {
                offset: 0.5,
                color: WHITE,
                opacity: 0.3
            }, {
                offset: 0.99,
                color: WHITE,
                opacity: 0
            }]
        },
        sharpGlass: {
            type: RADIAL,
            supportVML: false,
            stops: [{
                offset: 0,
                color: WHITE,
                opacity: 0.2
            }, {
                offset: 0.15,
                color: WHITE,
                opacity: 0.15
            }, {
                offset: 0.17,
                color: WHITE,
                opacity: 0.35
            }, {
                offset: 0.85,
                color: WHITE,
                opacity: 0.05
            }, {
                offset: 0.87,
                color: WHITE,
                opacity: 0.15
            }, {
                offset: 0.99,
                color: WHITE,
                opacity: 0
            }]
        }
    };

    // Animations =============================================================
    var ElementAnimation = Class.extend({
        init: function(element, options) {
            var anim = this;

            anim.options = deepExtend({}, anim.options, options);
            anim.element = element;
        },

        options: {
            duration: INITIAL_ANIMATION_DURATION,
            easing: SWING
        },

        play: function() {
            var anim = this,
                options = anim.options,
                element = anim.element,
                elementId = element.options.id,
                domElement,
                delay = options.delay || 0,
                start = +new Date() + delay,
                duration = options.duration,
                finish = start + duration,
                easing = $.easing[options.easing],
                wallTime,
                time,
                pos,
                easingPos;

            setTimeout(function() {
                var loop = function() {
                    if (anim._stopped) {
                        return;
                    }

                    wallTime = +new Date();
                    time = math.min(wallTime - start, duration);
                    pos = time / duration;
                    easingPos = easing(pos, time, 0, 1, duration);

                    anim.step(easingPos);

                    if (!domElement || detached(domElement)) {
                        domElement = getElement(elementId);
                    }

                    element.refresh(domElement);

                    if (wallTime < finish) {
                        dataviz.requestFrame(loop);
                    } else {
                        anim.destroy();
                    }
                };

                loop();
            }, delay);
        },

        abort: function() {
            this._stopped = true;
        },

        destroy: function() {
            this.abort();
        },

        setup: noop,

        step: noop
    });

    var FadeAnimation = ElementAnimation.extend({
        options: {
            duration: 200,
            easing: LINEAR
        },

        setup: function() {
            var anim = this,
                options = anim.element.options;

            anim.targetFillOpacity = options.fillOpacity;
            anim.targetStrokeOpacity = options.strokeOpacity;
            options.fillOpacity = options.strokeOpacity = 0;
        },

        step: function(pos) {
            var anim = this,
                options = anim.element.options;

            options.fillOpacity = pos * anim.targetFillOpacity;
            options.strokeOpacity = pos * anim.targetStrokeOpacity;
        }
    });

    var ExpandAnimation = ElementAnimation.extend({
        options: {
            size: 0,
            easing: LINEAR
        },

        setup: function() {
            var points = this.element.points;

            points[1].x = points[2].x = points[0].x;
        },

        step: function(pos) {
            var options = this.options,
                size = interpolateValue(0, options.size, pos),
                points = this.element.points;

            // Expands rectangle to the right
            points[1].x = points[2].x = points[0].x + size;
        },

        destroy: function() {
            ElementAnimation.fn.destroy.call(this);

            // Unwrap all child elements
            this.element.destroy();
        }
    });

    var RotationAnimation = ElementAnimation.extend({
        options: {
            easing: LINEAR,
            duration: 900
        },

        setup: function() {
            var anim = this,
                element = anim.element,
                elementOptions = element.options,
                options = anim.options,
                center = options.center,
                start, end;

            if (elementOptions.rotation) {
                start = options.startAngle;
                end = elementOptions.rotation[0];

                options.duration = math.max((math.abs(start - end) / options.speed) * 1000, 1);

                anim.endState = end;
                elementOptions.rotation = [
                    start,
                    center.x,
                    center.y
                ];
            }
        },

        step: function(pos) {
            var anim = this,
                element = anim.element;

            if (element.options.rotation) {
                element.options.rotation[0] = interpolateValue(anim.options.startAngle, anim.endState, pos);
            }
        }
    });

    var BarAnimation = ElementAnimation.extend({
        options: {
            easing: SWING
        },

        setup: function() {
            var anim = this,
                element = anim.element,
                points = element.points,
                options = element.options,
                axis = options.vertical ? Y : X,
                stackBase = options.stackBase,
                aboveAxis = options.aboveAxis,
                startPosition,
                endState = anim.endState = {
                    top: points[0].y,
                    right: points[1].x,
                    bottom: points[3].y,
                    left: points[0].x
                };

            if (axis === Y) {
                startPosition = valueOrDefault(stackBase,
                    endState[aboveAxis ? BOTTOM : TOP]);
            } else {
                startPosition = valueOrDefault(stackBase,
                    endState[aboveAxis ? LEFT : RIGHT]);
            }

            anim.startPosition = startPosition;

            updateArray(points, axis, startPosition);
        },

        step: function(pos) {
            var anim = this,
                startPosition = anim.startPosition,
                endState = anim.endState,
                element = anim.element,
                points = element.points;

            if (element.options.vertical) {
                points[0].y = points[1].y =
                    interpolateValue(startPosition, endState.top, pos);

                points[2].y = points[3].y =
                    interpolateValue(startPosition, endState.bottom, pos);
            } else {
                points[0].x = points[3].x =
                    interpolateValue(startPosition, endState.left, pos);

                points[1].x = points[2].x =
                    interpolateValue(startPosition, endState.right, pos);
            }
        }
    });

    var BarIndicatorAnimatin = ElementAnimation.extend({
        options: {
            easing: SWING,
            duration: 1000
        },

        setup: function() {
            var anim = this,
                element = anim.element,
                points = element.points,
                options = element.options.animation,
                vertical = options.vertical,
                reverse = options.reverse,
                axis = anim.axis = vertical ? "y" : "x",
                start, end, pos,
                endPosition = anim.options.endPosition,
                initialState = anim.initialState = {
                    top: points[0].y,
                    right: points[1].x,
                    bottom: points[3].y,
                    left: points[0].x
                },
                initial = !defined(anim.options.endPosition);

            if (vertical) {
                pos = reverse ? "y2" : "y1";
                start = initialState[initial && !reverse ? BOTTOM : TOP];
                end = initial ? initialState[reverse ? BOTTOM : TOP] : endPosition[pos];
            } else {
                pos = reverse ? "x1" : "x2";
                start = initialState[initial && !reverse ? LEFT : RIGHT];
                end = initial ? initialState[reverse ? LEFT : RIGHT] : endPosition[pos];
            }

            anim.start = start;
            anim.end = end;

            if (initial) {
                updateArray(points, axis, anim.start);
            } else if (options.speed) {
                anim.options.duration = math.max((math.abs(anim.start - anim.end) / options.speed) * 1000, 1);
            }
        },

        step: function(pos) {
            var anim = this,
                start = anim.start,
                end = anim.end,
                element = anim.element,
                points = element.points,
                axis = anim.axis;

            if (element.options.animation.vertical) {
                points[0][axis] = points[1][axis] =
                    interpolateValue(start, end, pos);
            } else {
                points[1][axis] = points[2][axis] =
                    interpolateValue(start, end, pos);
            }
        }
    });

    var ArrowAnimation = ElementAnimation.extend({
        options: {
            easing: SWING,
            duration: 1000
        },

        setup: function() {
            var anim = this,
                element = anim.element,
                points = element.points,
                options = element.options.animation,
                vertical = options.vertical,
                reverse = options.reverse,
                axis = vertical ? "y" : "x",
                startPos = axis + (reverse ? "1" : "2"),
                endPos = axis + (reverse ? "2" : "1"),
                startPosition = options.startPosition[vertical ? startPos : endPos],
                halfSize = options.size / 2,
                count = points.length,
                initial = !defined(anim.options.endPosition),
                padding = halfSize,
                point,
                end,
                i;

            anim.axis = axis;
            anim.endPositions = [];
            anim.startPositions = [];

            if (!initial) {
                startPosition = points[1][axis];
                end = anim.options.endPosition[vertical ? endPos : startPos];
                if (options.speed) {
                    anim.options.duration = math.max((math.abs(startPosition - end) / options.speed) * 1000, 1);
                }
            }

            for (i = 0; i < count; i++) {
                point = deepExtend({}, points[i]);
                if (initial) {
                    anim.endPositions[i] = point[axis];
                    points[i][axis] = startPosition - padding;
                } else {
                    anim.endPositions[i] = end - padding;
                }
                anim.startPositions[i] = points[i][axis];
                padding -= halfSize;
            }
        },

        step: function(pos) {
            var anim = this,
                startPositions = anim.startPositions,
                endPositions = anim.endPositions,
                element = anim.element,
                points = element.points,
                axis = anim.axis,
                count = points.length,
                i;

            for (i = 0; i < count; i++) {
                points[i][axis] = interpolateValue(startPositions[i], endPositions[i], pos);
            }
        }
    });

    function animationDecorator(animationName, animationType) {
        return Class.extend({
            init: function(view) {
                this.view = view;
            },

            decorate: function(element) {
                var decorator = this,
                    view = decorator.view,
                    animation = element.options.animation,
                    animationObject;

                if (animation && animation.type === animationName && view.options.transitions) {
                    animationObject = element._animation = new animationType(element, animation);
                    view.animations.push(animationObject);
                }

                return element;
            }
        });
    }

    var FadeAnimationDecorator = animationDecorator(FADEIN, FadeAnimation);

    // Helper functions========================================================
    var Color = function(value) {
        var color = this,
            formats = Color.formats,
            re,
            processor,
            parts,
            i,
            channels;

        if (arguments.length === 1) {
            value = color.resolveColor(value);

            for (i = 0; i < formats.length; i++) {
                re = formats[i].re;
                processor = formats[i].process;
                parts = re.exec(value);

                if (parts) {
                    channels = processor(parts);
                    color.r = channels[0];
                    color.g = channels[1];
                    color.b = channels[2];
                }
            }
        } else {
            color.r = arguments[0];
            color.g = arguments[1];
            color.b = arguments[2];
        }

        color.r = color.normalizeByte(color.r);
        color.g = color.normalizeByte(color.g);
        color.b = color.normalizeByte(color.b);
    };

    Color.prototype = {
        toHex: function() {
            var color = this,
                pad = color.padDigit,
                r = color.r.toString(16),
                g = color.g.toString(16),
                b = color.b.toString(16);

            return "#" + pad(r) + pad(g) + pad(b);
        },

        resolveColor: function(value) {
            value = value || BLACK;

            if (value.charAt(0) == "#") {
                value = value.substr(1, 6);
            }

            value = value.replace(/ /g, "");
            value = value.toLowerCase();
            value = Color.namedColors[value] || value;

            return value;
        },

        normalizeByte: function(value) {
            return (value < 0 || isNaN(value)) ? 0 : ((value > 255) ? 255 : value);
        },

        padDigit: function(value) {
            return (value.length === 1) ? "0" + value : value;
        },

        brightness: function(value) {
            var color = this,
                round = math.round;

            color.r = round(color.normalizeByte(color.r * value));
            color.g = round(color.normalizeByte(color.g * value));
            color.b = round(color.normalizeByte(color.b * value));

            return color;
        },

        percBrightness: function() {
            var color = this;

            return math.sqrt(0.241 * color.r * color.r + 0.691 * color.g * color.g + 0.068 * color.b * color.b);
        }
    };

    Color.formats = [{
            re: /^rgb\((\d{1,3}),\s*(\d{1,3}),\s*(\d{1,3})\)$/,
            process: function(parts) {
                return [
                    parseInt(parts[1], 10), parseInt(parts[2], 10), parseInt(parts[3], 10)
                ];
            }
        }, {
            re: /^(\w{2})(\w{2})(\w{2})$/,
            process: function(parts) {
                return [
                    parseInt(parts[1], 16), parseInt(parts[2], 16), parseInt(parts[3], 16)
                ];
            }
        }, {
            re: /^(\w{1})(\w{1})(\w{1})$/,
            process: function(parts) {
                return [
                    parseInt(parts[1] + parts[1], 16),
                    parseInt(parts[2] + parts[2], 16),
                    parseInt(parts[3] + parts[3], 16)
                ];
            }
        }
    ];

    Color.namedColors = {
        aqua: "00ffff", azure: "f0ffff", beige: "f5f5dc",
        black: "000000", blue: "0000ff", brown: "a52a2a",
        coral: "ff7f50", cyan: "00ffff", darkblue: "00008b",
        darkcyan: "008b8b", darkgray: "a9a9a9", darkgreen: "006400",
        darkorange: "ff8c00", darkred: "8b0000", dimgray: "696969",
        fuchsia: "ff00ff", gold: "ffd700", goldenrod: "daa520",
        gray: "808080", green: "008000", greenyellow: "adff2f",
        indigo: "4b0082", ivory: "fffff0", khaki: "f0e68c",
        lightblue: "add8e6", lightgrey: "d3d3d3", lightgreen: "90ee90",
        lightpink: "ffb6c1", lightyellow: "ffffe0", lime: "00ff00",
        limegreen: "32cd32", linen: "faf0e6", magenta: "ff00ff",
        maroon: "800000", mediumblue: "0000cd", navy: "000080",
        olive: "808000", orange: "ffa500", orangered: "ff4500",
        orchid: "da70d6", pink: "ffc0cb", plum: "dda0dd",
        purple: "800080", red: "ff0000", royalblue: "4169e1",
        salmon: "fa8072", silver: "c0c0c0", skyblue: "87ceeb",
        slateblue: "6a5acd", slategray: "708090", snow: "fffafa",
        steelblue: "4682b4", tan: "d2b48c", teal: "008080",
        tomato: "ff6347", turquoise: "40e0d0", violet: "ee82ee",
        wheat: "f5deb3", white: "ffffff", whitesmoke: "f5f5f5",
        yellow: "ffff00", yellowgreen: "9acd32"
    };

    var IDPool = Class.extend({
        init: function(size, prefix, start) {
            this._pool = [];
            this._freed = {};
            this._size = size;
            this._id = start;
            this._prefix = prefix;
        },

        alloc: function() {
            var that = this,
                pool = that._pool,
                id;

            if (pool.length > 0) {
                id = pool.pop();
                that._freed[id] = false;
            } else {
                id = that._prefix + that._id++;
            }

            return id;
        },

        free: function(id) {
            var that = this,
                pool = that._pool,
                freed = that._freed;

            if (pool.length < that._size && !freed[id]) {
                pool.push(id);

                freed[id] = true;
            }
        }
    });
    IDPool.current = new IDPool(ID_POOL_SIZE, ID_PREFIX, ID_START);

    var LRUCache = Class.extend({
        init: function(size) {
            this._size = size;
            this._length = 0;
            this._map = {};
        },

        put: function(key, value) {
            var lru = this,
                map = lru._map,
                entry = { key: key, value: value };

            map[key] = entry;

            if (!lru._head) {
                lru._head = lru._tail = entry;
            } else {
                lru._tail.newer = entry;
                entry.older = lru._tail;
                lru._tail = entry;
            }

            if (lru._length >= lru._size) {
                map[lru._head.key] = null;
                lru._head = lru._head.newer;
                lru._head.older = null;
            } else {
                lru._length++;
            }
        },

        get: function(key) {
            var lru = this,
                entry = lru._map[key];

            if (entry) {
                if (entry === lru._head && entry !== lru._tail) {
                    lru._head = entry.newer;
                    lru._head.older = null;
                }

                if (entry !== lru._tail) {
                    if (entry.older) {
                        entry.older.newer = entry.newer;
                        entry.newer.older = entry.older;
                    }

                    entry.older = lru._tail;
                    entry.newer = null;

                    lru._tail.newer = entry;
                    lru._tail = entry;
                }

                return entry.value;
            }
        }
    });

    var ViewFactory = function() {
        this._views = [];
    };

    ViewFactory.prototype = {
        register: function(name, type, order) {
            var views = this._views,
                defaultView = views[0],
                entry = {
                    name: name,
                    type: type,
                    order: order
                };

            if (!defaultView || order < defaultView.order) {
                views.unshift(entry);
            } else {
                views.push(entry);
            }
        },

        create: function(options, preferred) {
            var views = this._views,
                match = views[0];

            if (preferred) {
                preferred = preferred.toLowerCase();
                for (var i = 0; i < views.length; i++) {
                    if (views[i].name === preferred) {
                        match = views[i];
                        break;
                    }
                }
            }

            if (match) {
                return new match.type(options);
            }

            kendo.logToConsole(
                "Warning: KendoUI DataViz cannot render. Possible causes:\n" +
                "- The browser does not support SVG, VML and Canvas. User agent: " + navigator.userAgent + "\n" +
                "- The kendo.dataviz.(svg|vml|canvas).js scripts are not loaded");
        }
    };

    ViewFactory.current = new ViewFactory();

    var ExportMixin = {
        svg: function() {
            if (dataviz.SVGView) {
                var model = this._getModel(),
                    view = new dataviz.SVGView(model.options);

                view.load(model);

                return view.render();
            } else {
                throw new Error("Unable to create SVGView. Check that kendo.dataviz.svg.js is loaded.");
            }
        },

        imageDataURL: function() {
            if (dataviz.CanvasView) {
                if (dataviz.supportsCanvas()) {
                    var model = this._getModel(),
                        container = document.createElement("div"),
                        view = new dataviz.CanvasView(model.options);

                    view.load(model);

                    return view.renderTo(container).toDataURL();
                } else {
                    kendo.logToConsole(
                        "Warning: Unable to generate image. The browser does not support Canvas.\n" +
                        "User agent: " + navigator.userAgent);

                    return null;
                }
            } else {
                throw new Error("Unable to create CanvasView. Check that kendo.dataviz.canvas.js is loaded.");
            }
        }
    };

    function measureText(text, style, rotation) {
        var styleHash = getHash(style),
            cacheKey = text + styleHash + rotation,
            cachedResult = measureText.cache.get(cacheKey),
            size = {
                width: 0,
                height: 0,
                baseline: 0
            };

        if (cachedResult) {
            return cachedResult;
        }

        var measureBox = measureText.measureBox,
            baselineMarker = measureText.baselineMarker.cloneNode(false);

        if (!measureBox || !measureBox.parentNode) {
            measureBox = measureText.measureBox =
                $("<div style='position: absolute; top: -4000px;" +
                              "line-height: normal; visibility: hidden;' />")
                .appendTo(doc.body)[0];
        }

        for (var styleKey in style) {
            measureBox.style[styleKey] = style[styleKey];
        }
        measureBox.innerHTML = text;
        measureBox.appendChild(baselineMarker);

        if ((text + "").length) {
            size = {
                width: measureBox.offsetWidth - BASELINE_MARKER_SIZE,
                height: measureBox.offsetHeight,
                baseline: baselineMarker.offsetTop + BASELINE_MARKER_SIZE
            };
        }

        if (rotation) {
            var width = size.width,
                height = size.height,
                cx = width / 2,
                cy = height / 2,
                r1 = rotatePoint(0, 0, cx, cy, rotation),
                r2 = rotatePoint(width, 0, cx, cy, rotation),
                r3 = rotatePoint(width, height, cx, cy, rotation),
                r4 = rotatePoint(0, height, cx, cy, rotation);

            size.normalWidth = width;
            size.normalHeight = height;
            size.width = math.max(r1.x, r2.x, r3.x, r4.x) - math.min(r1.x, r2.x, r3.x, r4.x);
            size.height = math.max(r1.y, r2.y, r3.y, r4.y) - math.min(r1.y, r2.y, r3.y, r4.y);
        }

        measureText.cache.put(cacheKey, size);

        return size;
    }

    measureText.cache = new LRUCache(1000);
    measureText.baselineMarker =
        $("<div class='" + CSS_PREFIX + "baseline-marker' " +
            "style='display: inline-block; vertical-align: baseline;" +
            "width: " + BASELINE_MARKER_SIZE + "px; height: " + BASELINE_MARKER_SIZE + "px;" +
            "overflow: hidden;' />")[0];

    function autoMajorUnit(min, max) {
        var diff = max - min;

        if (diff === 0) {
            if (max === 0) {
                return 0.1;
            }

            diff = math.abs(max);
        }

        var scale = math.pow(10, math.floor(math.log(diff) / math.log(10))),
            relativeValue = round((diff / scale), DEFAULT_PRECISION),
            scaleMultiplier = 1;

        if (relativeValue < 1.904762) {
            scaleMultiplier = 0.2;
        } else if (relativeValue < 4.761904) {
            scaleMultiplier = 0.5;
        } else if (relativeValue < 9.523809) {
            scaleMultiplier = 1;
        } else {
            scaleMultiplier = 2;
        }

        return round(scale * scaleMultiplier, DEFAULT_PRECISION);
    }

    function getHash(object) {
        var hash = [];
        for (var key in object) {
            hash.push(key + object[key]);
        }

        return hash.sort().join(" ");
    }

    function uniqueId() {
        return IDPool.current.alloc();
    }

    // TODO: Replace with Point2D.rotate
    function rotatePoint(x, y, cx, cy, angle) {
        var theta = angle * DEG_TO_RAD;

        return new Point2D(
            cx + (x - cx) * math.cos(theta) + (y - cy) * math.sin(theta),
            cy - (x - cx) * math.sin(theta) + (y - cy) * math.cos(theta)
        );
    }

    function boxDiff(r, s) {
        if (r.x1 == s.x1 && r.y1 == s.y1 && r.x2 == s.x2 && r.y2 == s.y2) {
            return s;
        }

        var a = math.min(r.x1, s.x1),
            b = math.max(r.x1, s.x1),
            c = math.min(r.x2, s.x2),
            d = math.max(r.x2, s.x2),
            e = math.min(r.y1, s.y1),
            f = math.max(r.y1, s.y1),
            g = math.min(r.y2, s.y2),
            h = math.max(r.y2, s.y2),
            result = [];

        // X = intersection, 0-7 = possible difference areas
        // h +-+-+-+
        // . |5|6|7|
        // g +-+-+-+
        // . |3|X|4|
        // f +-+-+-+
        // . |0|1|2|
        // e +-+-+-+
        // . a b c d

        // we'll always have rectangles 1, 3, 4 and 6
        result[0] = Box2D(b, e, c, f);
        result[1] = Box2D(a, f, b, g);
        result[2] = Box2D(c, f, d, g);
        result[3] = Box2D(b, g, c, h);

        // decide which corners
        if ( r.x1 == a && r.y1 == e || s.x1 == a && s.y1 == e )
        { // corners 0 and 7
            result[4] = Box2D(a, e, b, f);
            result[5] = Box2D(c, g, d, h);
        }
        else
        { // corners 2 and 5
            result[4] = Box2D(c, e, d, f);
            result[5] = Box2D(a, g, b, h);
        }

        return $.grep(result, function(box) {
            return box.height() > 0 && box.width() > 0;
        })[0];
    }

    function supportsSVG() {
        return doc.implementation.hasFeature(
            "http://www.w3.org/TR/SVG11/feature#BasicStructure", "1.1");
    }

    function supportsCanvas() {
        return !!doc.createElement("canvas").getContext;
    }

    var requestFrameFn =
        window.requestAnimationFrame       ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame    ||
        window.oRequestAnimationFrame      ||
        window.msRequestAnimationFrame     ||
        function(callback) {
            setTimeout(callback, ANIMATION_STEP);
        };

    dataviz.requestFrame = function(callback, delay) {
        return requestFrameFn(callback, delay);
    };

    function inArray(value, array) {
        return indexOf(value, array) != -1;
    }

    function last(array) {
        return array[array.length - 1];
    }

    function append(first, second) {
        [].push.apply(first, second);
    }

    function ceil(value, step) {
        return round(math.ceil(value / step) * step, DEFAULT_PRECISION);
    }

    function floor(value, step) {
        return round(math.floor(value / step) * step, DEFAULT_PRECISION);
    }

    function round(value, precision) {
        var power = math.pow(10, precision || 0);
        return math.round(value * power) / power;
    }

    function remainderClose(value, divisor, ratio) {
        var remainder = round(math.abs(value % divisor), DEFAULT_PRECISION),
            threshold = divisor * (1 - ratio);

        return remainder === 0 || remainder > threshold;
    }

    function interpolateValue(start, end, progress) {
        return round(start + (end - start) * progress, COORD_PRECISION);
    }

    function defined(value) {
        return typeof value !== UNDEFINED;
    }

    function valueOrDefault(value, defaultValue) {
        return defined(value) ? value : defaultValue;
    }

    function numericComparer(a, b) {
        return a - b;
    }

    function updateArray(arr, prop, value) {
        var i,
            length = arr.length;

        for(i = 0; i < length; i++) {
            arr[i][prop] = value;
        }
    }

    function autoFormat(format, value) {
        if (format.match(FORMAT_REGEX)) {
            return kendo.format.apply(this, arguments);
        }

        return kendo.toString(value, format);
    }

    function getElement(modelId) {
        return doc.getElementById(modelId);
    }

    function detached(element) {
        var parent = element.parentNode;

        while(parent && parent.parentNode) {
            parent = parent.parentNode;
        }

        return parent !== doc;
    }

    function clockwise(v1, v2) {
        // True if v2 is clockwise of v1
        // assuming angles grow in clock-wise direction
        // (as in the pie and radar charts)
        return -v1.x * v2.y + v1.y * v2.x < 0;
    }

    function decodeEntities(text) {
        if (!text || !text.indexOf || text.indexOf("&") < 0) {
            return text;
        } else {
            var element = decodeEntities._element;
            element.innerHTML = text;
            return element.textContent || element.innerText;
        }
    }
    decodeEntities._element = doc.createElement("span");

    function dateComparer(a, b) {
         if (a && b) {
             return a.getTime() - b.getTime();
         }

         return 0;
    }

    // Exports ================================================================
    deepExtend(kendo.dataviz, {
        init: function(element) {
            kendo.init(element, kendo.dataviz.ui);
        },
        ui: {
            roles: {},
            themes: {},
            views: [],
            plugin: function(widget) {
                kendo.ui.plugin(widget, dataviz.ui);
            }
        },

        AXIS_LABEL_CLICK: AXIS_LABEL_CLICK,
        COORD_PRECISION: COORD_PRECISION,
        DEFAULT_PRECISION: DEFAULT_PRECISION,
        DEFAULT_WIDTH: DEFAULT_WIDTH,
        DEFAULT_HEIGHT: DEFAULT_HEIGHT,
        DEFAULT_FONT: DEFAULT_FONT,
        INITIAL_ANIMATION_DURATION: INITIAL_ANIMATION_DURATION,
        NOTE_CLICK: NOTE_CLICK,
        NOTE_HOVER: NOTE_HOVER,
        CLIP: CLIP,
        DASH_ARRAYS: {
            dot: [1.5, 3.5],
            dash: [4, 3.5],
            longdash: [8, 3.5],
            dashdot: [3.5, 3.5, 1.5, 3.5],
            longdashdot: [8, 3.5, 1.5, 3.5],
            longdashdotdot: [8, 3.5, 1.5, 3.5, 1.5, 3.5]
        },

        Axis: Axis,
        AxisLabel: AxisLabel,
        Box2D: Box2D,
        BoxElement: BoxElement,
        ChartElement: ChartElement,
        Color: Color,
        ElementAnimation:ElementAnimation,
        ExpandAnimation: ExpandAnimation,
        ExportMixin: ExportMixin,
        ArrowAnimation: ArrowAnimation,
        BarAnimation: BarAnimation,
        BarIndicatorAnimatin: BarIndicatorAnimatin,
        FadeAnimation: FadeAnimation,
        FadeAnimationDecorator: FadeAnimationDecorator,
        IDPool: IDPool,
        LRUCache: LRUCache,
        Note: Note,
        NumericAxis: NumericAxis,
        Point2D: Point2D,
        PinElement: PinElement,
        Ring: Ring,
        Pin: Pin,
        RootElement: RootElement,
        RotationAnimation: RotationAnimation,
        Sector: Sector,
        ShapeElement: ShapeElement,
        Text: Text,
        TextBox: TextBox,
        Title: Title,
        ViewBase: ViewBase,
        ViewElement: ViewElement,
        ViewFactory: ViewFactory,

        animationDecorator: animationDecorator,
        append: append,
        autoFormat: autoFormat,
        autoMajorUnit: autoMajorUnit,
        boxDiff: boxDiff,
        defined: defined,
        decodeEntities: decodeEntities,
        dateComparer: dateComparer,
        getElement: getElement,
        getSpacing: getSpacing,
        inArray: inArray,
        interpolateValue: interpolateValue,
        last: last,
        measureText: measureText,
        rotatePoint: rotatePoint,
        round: round,
        ceil: ceil,
        floor: floor,
        supportsCanvas: supportsCanvas,
        supportsSVG: supportsSVG,
        renderTemplate: renderTemplate,
        uniqueId: uniqueId,
        valueOrDefault: valueOrDefault
    });

})(window.kendo.jQuery);
