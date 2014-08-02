require.config
  paths:
    Q: 'bower_components/q/q'
    jquery: 'bower_components/jquery/dist/jquery'
    httpRequester: 'scripts/httpRequester'
    mustache: 'bower_components/mustache/mustache'
    persister: 'scripts/persister'
    ui: 'scripts/ui'

require ['scripts/controller'], (mainApp) ->
  mainApp.run()
  null