/*jslint browser: true*/
/**************************************************
 * Create a tag cloud:
 * - Visualize a string of tags (strings) in a given container
 * - By given minFontSize and maxFontSize, generate the
 * tags with different font-size, depending on the number
 * of occurrences
 **************************************************/
window.onload = function() {
    'use strict';
    var container = document.getElementById('container'),
        tags = ["cms", "javascript", "js",
            "ASP.NET MVC", ".net", ".net", "css",
            "wordpress", "xaml", "js", "http", "web",
            "asp.net", "asp.net MVC", "ASP.NET MVC",
            "wp", "javascript", "js", "cms", "html",
            "javascript", "http", "http", "CMS"
        ],
        tagCloud = null,
        MAX_FONT_SIZE = 42,
        MIN_FONT_SIZE = 17;

    function countEquals(tags) {
        var mainCount = 0,
            innerCount = 0,
            countedTags = {};

        countedTags.length = 0;

        for (mainCount = tags.length - 1; mainCount >= 0; mainCount--) {
            tags[mainCount] = tags[mainCount].trim().toLowerCase();

            if (countedTags.hasOwnProperty(tags[mainCount])) {
                continue;
            }

            countedTags[tags[mainCount]] = 1;
            countedTags.length += 1;
            for (innerCount = mainCount; innerCount >= 0; innerCount--) {
                if (tags[mainCount] === tags[innerCount].trim().toLowerCase()) {
                    countedTags[tags[mainCount]] += 1;
                }
            }
        }

        return countedTags;
    }

    function findMax(countedTags, calcFontSizes) {
        var tag = null,
            maxTag = null,
            maxValue = 0;

        for (tag in countedTags) {
            if (tag !== 'length' && countedTags.hasOwnProperty(tag)) {
                if (calcFontSizes.hasOwnProperty(tag)) {
                    continue;
                }

                if (countedTags[tag] > maxValue) {
                    maxValue = countedTags[tag];
                    maxTag = tag;
                }
            }
        }

        return maxTag;
    }

    function setFontSizes(countedTags, minFontSize, maxFontSize) {
        var calcFontSizes = {},
            currentFontSize = maxFontSize,
            count = countedTags.length,
            tag = null;

        while (count >= 0) {
            tag = findMax(countedTags, calcFontSizes);
            calcFontSizes[tag] = currentFontSize + 'px';
            if (currentFontSize >= minFontSize) {
                currentFontSize -= 1;
            }

            count -= 1;
        }

        return calcFontSizes;
    }

    function generateTagCloud(tags, minFontSize, maxFontSize) {
        var newSpan = null,
            tag = null,
            countedTags = null,
            calcFontSizes = null,
            cloudBag = null;

        countedTags = countEquals(tags);
        calcFontSizes = setFontSizes(countedTags, minFontSize, maxFontSize);
        cloudBag = document.createElement('div');

        for (tag in countedTags) {
            if (tag !== 'length' && countedTags.hasOwnProperty(tag)) {
                newSpan = document.createElement('span');
                newSpan.innerHTML = tag;
                newSpan.style.fontSize = calcFontSizes[tag];
                newSpan.style.margin = '5px';
                cloudBag.appendChild(newSpan);
            }
        }

        return cloudBag;
    }

    tagCloud = generateTagCloud(tags, MIN_FONT_SIZE, MAX_FONT_SIZE);
    container.appendChild(tagCloud);
};