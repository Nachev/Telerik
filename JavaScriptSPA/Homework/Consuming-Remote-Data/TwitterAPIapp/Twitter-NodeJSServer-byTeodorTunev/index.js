var express = require('express'),
    http = require('http'),
    bodyParser = require('body-parser'),
    tweets = require('./tweets'),
    app = express();

app.use(bodyParser.json());
app.all('*', function(req, res, next) {
    res.header('Access-Control-Allow-Origin', '*');
    res.header('Access-Control-Allow-Headers', 'X-Requested-With,Content-type');
    res.header('Access-Control-Allow-Methods', "GET, POST, OPTIONS, DELETE");
    next();
});
app.post('/tweets', tweets.getUserTimeline);

http.createServer(app).listen(3000, function() {
    console.log("Server running on port 3000");
});