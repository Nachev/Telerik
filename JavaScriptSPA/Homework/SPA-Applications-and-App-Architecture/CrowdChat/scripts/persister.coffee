define ['jquery', 'httpRequester'], ($, httpRequester) ->
  resourceUrl = 'http://crowd-chat.herokuapp.com/posts'

  validateData = (input) ->
    isCorrectInput = $.type(input) is "string" and input.length > 0
    if not isCorrectInput
      throw new Error "Value for #{input} must be string with length greater than 0"
    null

  sendMessage = (userName, messageText) ->
    validateData userName
    validateData messageText
    newPost =
      user: userName
      text: messageText
    httpRequester.postJsonData resourceUrl, newPost
      .then (data) ->
        alert "Post successful"
      .fail (err) ->
        alert "Error: #{err}"

  getMessages = () ->
    httpRequester.getJsonData resourceUrl

  sendMessage: sendMessage
  getMessages: getMessages