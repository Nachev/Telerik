require.config
  paths:
    Q: 'bower_components/q/q'
    jquery: 'bower_components/jquery/dist/jquery'
    mustache: 'bower_components/mustache/mustache'
    sammy: 'bower_components/sammy/lib/sammy'
    persister: 'scripts/persister'
    httpRequester: 'scripts/httpRequester'
    view: 'scripts/view'

require ['scripts/controller'], (controller) ->
  controller.run()
  null