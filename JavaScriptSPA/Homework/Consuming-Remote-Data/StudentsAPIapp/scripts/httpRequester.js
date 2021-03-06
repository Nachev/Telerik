// Generated by CoffeeScript 1.7.1
(function() {
  define(['jquery', 'Q'], function($, Q) {
    var createAjax, delAjax, getAjax, postAjax;
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
    postAjax = function(url, data) {
      return createAjax(url, "POST", data);
    };
    getAjax = function(url) {
      return createAjax(url, "GET");
    };
    delAjax = function(url) {
      var deferred;
      deferred = Q.defer();
      return $.ajax({
        url: url,
        type: "POST",
        data: {
          _method: 'delete'
        },
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
    return {
      postAjax: postAjax,
      getAjax: getAjax,
      delAjax: delAjax
    };
  });

}).call(this);

//# sourceMappingURL=httpRequester.map
