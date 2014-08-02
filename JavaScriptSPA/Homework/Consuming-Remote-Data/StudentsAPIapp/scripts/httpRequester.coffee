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

  postAjax = (url, data) ->
    createAjax url, "POST", data
  getAjax = (url) ->
    createAjax url, "GET"
  delAjax = (url) ->
    deferred = Q.defer()
    $.ajax
      url: url
      type: "POST"
      data: {_method: 'delete'}
      success: (data) ->
        deferred.resolve data
        null
      error: (err) ->
        deferred.reject err
        null

  postAjax: postAjax
  getAjax: getAjax
  delAjax: delAjax