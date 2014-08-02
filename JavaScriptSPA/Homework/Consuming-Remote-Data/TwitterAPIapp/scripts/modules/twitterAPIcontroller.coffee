define ['jquery'], ($) ->
  controller = do ->
    getPosts = (properties) ->
      requestJson =
        consumerKey: properties.consumerKey
        consumerSecret: properties.consumerSecret
        accessToken: properties.accessToken
        accessTokenSecret: properties.accessTokenSecret
        username : properties.username
        count : properties.numberOfPosts

      $.ajax
        url: 'http://localhost:3000/tweets'
        type: 'POST'
        data: JSON.stringify requestJson
        contentType: 'application/json'
        success: (data) ->
          data

    getPosts: getPosts

  controller