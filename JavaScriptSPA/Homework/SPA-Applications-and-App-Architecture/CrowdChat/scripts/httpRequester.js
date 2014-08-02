// Generated by CoffeeScript 1.7.1
(function() {
  define(['jquery', 'Q'], function($, Q) {
    var createAjax, getJson, postJson;
    createAjax = function(url, type, data) {
      var deferred;
      deferred = Q.defer();
      return $.ajax({
        url: url,
        type: type,
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function(data) {
          deferred.resolve(data);
          return null;
        },
        error: function(err) {
          deferred.reject(err);
          return null;
        }
      });
    };
    postJson = function(url, data) {
      return createAjax(url, "POST", data);
    };
    getJson = function(url) {
      return createAjax(url, "GET");
    };
    return {
      postJsonData: postJson,
      getJsonData: getJson
    };
  });

}).call(this);

//# sourceMappingURL=httpRequester.map
