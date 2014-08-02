define ['jquery', 'sammy', 'mustache'], ($, Sammy, Mustache) ->
  $chatForm = $ '#chat'
  $crowdDisplay = $ '#app'

  $nameInput = $chatForm.find '#name'
  $messageInput = $chatForm.find '#message'
  $sendButton = $chatForm.find '#btn-send'
  $getPostsButton = $chatForm.find '#btn-get-posts'

  escapeInput = (s) ->
    s.replace /[-\/\\^$*+?.()|[\]{}]/g, '\\$&'

  getSubmitButton = ->
    $sendButton

  getGetPostsButton = ->
    $getPostsButton

  getNewPost = ->
    user = escapeInput $nameInput.val()
    text = escapeInput $messageInput.val()

    user: user
    text: text

  showMessages = (data) ->
    template = """
      Messages:<ul>{{#.}}
        <dl>
          <dt>name: {{by}}</dt>
            <dd>message: {{{text}}}</dd>
        </dl>
      {{/.}}</ul>
    """
    posts = Mustache.to_html template, data
    $crowdDisplay.html posts

  getSubmitButton: getSubmitButton
  getGetPostsButton: getGetPostsButton
  getNewPost: getNewPost
  showMessages: showMessages