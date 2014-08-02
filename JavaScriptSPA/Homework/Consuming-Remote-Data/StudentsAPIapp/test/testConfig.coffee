require.config
  paths:
    Q: '../bower_components/q/q',
    jquery: '../bower_components/jquery/dist/jquery',
    httpRequester: '../scripts/httpRequester',
    mustache: '../bower_components/mustache/mustache',
    persister: '../scripts/persister',
    ui: '../scripts/ui'
    mocha: '../bower_components/mocha/mocha'
    chai: '../bower_components/chai/chai'

  require ['require', 'chai', 'mocha', 'jquery'], (reqiure, chai, mocha) ->
    # Chai
    should = chai.should()

    # globals mocha
    mocha.setup 'bdd'


