var tags = ["cms", "js", "html", "html",
            "ASP.NET MVC", ".net", ".net", "css",
            "wordpress", "xaml", "http", "web",
            "asp.net", "asp.net MVC", "ASP.NET MVC",
            "wp", "javascript", "js", "cms", "html",
            "javascript", "http", "http", "CMS", "web"];

var tagCloud = generateTagCloud(tags, 17, 42);
document.body.appendChild(tagCloud);

function generateTagCloud(tags, minFont, maxFont) {
    var tagsCount = countSameTags(tags);
    var div = document.createElement("div");

    div.style.width = "250px";
    div.style.height = "250px";
    div.style.border = "1px solid black";

    function countSameTags(tags) {
        var tagsCount = {};
        var tag = {};
        for (var i in tags) {
            tag = tags[i].toLowerCase();
            if (tagsCount[tag]) {
                tagsCount[tag]++;
            }
            else {
                tagsCount[tag] = 1;
            }
        }

        return tagsCount;
    }

    var min = Number.MAX_VALUE;
    var max = 0;

    for (var tag in tagsCount) {
        if (tagsCount[tag] > max) {
            max = tagsCount[tag];
        }
        if (tagsCount[tag] < min) {
            min = tagsCount[tag];
        }
    }

    for (var tag in tagsCount) {
        var span = document.createElement("span");

        if (min == tagsCount[tag]) {
            span.style.fontSize = minFont + "px";
        }
        else if (max == tagsCount[tag]) {
            span.style.fontSize = maxFont + "px";
        }
        else {
            span.style.fontSize = minFont + ((maxFont - minFont) / ((max - tagsCount[tag]) + 1)) + "px";
        }
        span.innerText = tag + " ";
        div.appendChild(span);
    }

    return div;
}
