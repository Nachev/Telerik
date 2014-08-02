define ['jquery', 'Q'], ($, Q) ->
  createAjax = (url, type, data) ->
    deferred = Q.defer()
    $.ajax
        url: url
        type: type
        data: JSON.stringify data
        contentType: 'application/json'
        success: (data) ->
          deferred.resolve data
          null
        error: (err) ->
          deferred.reject err
          null

  postJson = (url, data) ->
    createAjax url, "POST", data
  getJson = (url) ->
    createAjax url, "GET"

  postJsonData: postJson
  getJsonData: getJson