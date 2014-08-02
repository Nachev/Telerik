define ['jquery', 'persister', 'view'], ($, persister, view) ->

  run = () ->
    $sendButton = view.getSubmitButton()
    $getPostsBtn = view.getGetPostsButton()

    getPosts = ->
      persister.getMessages()
      .then (data) ->
        view.showMessages data.reverse()
      .fail (err) ->
        alert "Error: #{err}"

    $sendButton.on 'click', (ev) ->
      ev.preventDefault()
      newPost = view.getNewPost()
      persister.sendMessage newPost.user, newPost.text

    $getPostsBtn.on 'click', (ev) ->
      ev.preventDefault()
      getPosts()

    setTimeout getPosts, 10000

    null
  run: run