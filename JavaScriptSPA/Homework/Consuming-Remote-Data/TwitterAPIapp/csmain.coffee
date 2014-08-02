require.config
  paths:
    'jquery': 'bower_components/jquery/dist/jquery'
    'controller': 'scripts/modules/twitterAPIcontroller'

require ['jquery', 'controller'], ($, controller) ->
  $form = $ '#requestForm'

  showPosts = (posts) ->
    $('#target-display').html = posts

  $form.on 'click', '#submit', (ev) ->
    ev.preventDefault()
    $properties = $ '.properties'
    values = []
    for prop in $properties
      do ->
        if prop?
          values.push prop.value
        else
          alert "All fields are mandatory"
          throw new Error "All fields are mandatory"
    properties =
      'consumerKey': values[0]
      'consumerSecret': values[1]
      'accessToken': values[2]
      'accessTokenSecret': values[3]
      'username' : values[4]
      'numberOfPosts' : Number.parseInt values[5]

    posts = controller.getPosts properties
    showPosts posts