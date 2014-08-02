define(['lib/q'], function (Q) {
    var httpRequest;

    httpRequest = (function () {
        var getHttpRequest, getJSON, makeRequest, postJSON;

        getHttpRequest = (function () {
            var xmlHttpFactories, result;

            xmlHttpFactories = [
                function () {
                    return new XMLHttpRequest();
                }, function () {
                    return new ActiveXObject("Msxml3.XMLHTTP");
                }, function () {
                    return new ActiveXObject("Msxml2.XMLHTTP.6.0");
                }, function () {
                    return new ActiveXObject("Msxml2.XMLHTTP.3.0");
                }, function () {
                    return new ActiveXObject("Msxml2.XMLHTTP");
                }, function () {
                    return new ActiveXObject("Microsoft.XMLHTTP");
                }
            ];

            result = function () {
                var xmlFactory, i, len;

                for (i = 0, len = xmlHttpFactories.length; i < len; i += 1) {
                    xmlFactory = xmlHttpFactories[i];
                    try {
                        return xmlFactory();
                    } catch (err) {

                    }
                }

                return null;
            };

            return result;
        })();

        makeRequest = function (options, deferred, customHeader) {
            var _httpRequest, requestUrl;

            if(!options){
                throw new Error("No options are send to make request.");
            }

            if(!options.url) {
                throw  new Error("URL is mandatory for the request.");
            }

            requestUrl = options.url;
            _httpRequest = getHttpRequest();
            options.contentType = options.contentType || '';
            options.accept = options.accept || '';
            options.data = options.data || null;
            /*
            _httpRequest.addEventListener("load", transferComplete, false);
            _httpRequest.addEventListener("error", transferFailed, false);
            _httpRequest.addEventListener("abort", transferCanceled, false);
            */
            _httpRequest.onreadystatechange = function () {
                if (_httpRequest.readyState === 4) {
                    if (Math.floor(_httpRequest.status / 100) === 2) {
                        return deferred.resolve(_httpRequest.responseText);
                    } else {
                        return deferred.reject(_httpRequest.responseText);
                    }
                }
            };

            _httpRequest.open((options.type ? options.type : 'GET'), requestUrl, true);
            _httpRequest.setRequestHeader('Content-Type', options.contentType);
            _httpRequest.setRequestHeader('Accept', options.accept);
            if(customHeader){
                if(customHeader.type && customHeader.value) {
                    _httpRequest.setRequestHeader(customHeader.type, customHeader.value);
                }
            }
            _httpRequest.send(options.data);
        };

        getJSON = function (url, commonHeaders, customHeader) {
            var deferred = Q.defer();

            commonHeaders = commonHeaders || {};

            makeRequest({
                url: url,
                type: 'GET',
                contentType: commonHeaders.contentType || 'application/json',
                accept: commonHeaders.accept || 'application/json'
            }, deferred, customHeader);

            return deferred.promise;
        };

        postJSON = function (url, data, commonHeaders, customHeader) {
            var deferred = Q.defer();

            commonHeaders = commonHeaders || {};

            makeRequest({
                url: url,
                type: 'POST',
                contentType: commonHeaders.contentType || 'application/json',
                accept: commonHeaders.accept || 'application/json',
                data: JSON.stringify(data)
            }, deferred, customHeader);

            return deferred.promise;
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON
        };
    })();

    return httpRequest;
});
