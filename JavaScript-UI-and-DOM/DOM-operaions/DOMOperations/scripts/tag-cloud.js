(function () {
    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"],
        tagCloud;

    function indexOfTag(tags, tag) {
        var i;

        for (i = 0; i < tags.length; i += 1) {
            if (tags[i].innerHTML === tag.innerHTML) {
                return i;
            }
        }

        return -1;
    }

    function generateTagCloud(tags, minFontSize, maxFontSize) {
        var i,
            tagCloud = [],
            currentTag,
            index,
            documentFragment = document.createDocumentFragment(),
            font;

        for (i = 0; i < tags.length; i += 1) {
            currentTag = document.createElement('span');
            currentTag.innerHTML = tags[i].toLowerCase();
            index = indexOfTag(tagCloud, currentTag);

            if (index !== -1) {
                if (parseInt(tagCloud[index].style.fontSize, 10) < maxFontSize) {
                    font = parseInt(tagCloud[index].style.fontSize, 10);
                    tagCloud[index].style.fontSize = font + 10 + 'px';
                }
            } else {
                currentTag.style.fontSize = minFontSize + 'px';
                tagCloud.push(currentTag);
            }
        }

        for (i = 0; i < tagCloud.length; i += 1) {
            console.log(tagCloud[i].style.fontSize);
            documentFragment.appendChild(tagCloud[i]);
            documentFragment.appendChild(document.createTextNode(" "));
        }

        return documentFragment;
    }

    tagCloud = generateTagCloud(tags, 10, 50);
    document.getElementById('tag-cloud').appendChild(tagCloud);
}());