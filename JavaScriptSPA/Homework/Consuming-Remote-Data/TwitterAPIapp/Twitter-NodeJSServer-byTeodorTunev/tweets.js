(function () {
    var Twitter = new require('./libs/Twitter').Twitter;

    var error = function (err, response, body) {
        console.log('ERROR [%s]', err);
    };
    var getUserTimeline = function (req, res) {
        var twitter = new Twitter({
            "consumerKey": req.body.consumerKey,
            "consumerSecret": req.body.consumerSecret,
            "accessToken": req.body.accessToken,
            "accessTokenSecret": req.body.accessTokenSecret
        });
        var countOfTweets = req.body.count || 10;
        twitter.getUserTimeline({ screen_name: req.body.username, count: countOfTweets}, function (error) {
            return res.status(400).json(error);
        }, function (data) {
            return res.status(202).json(data);
        });
    };

    module.exports = {
        getUserTimeline: getUserTimeline
    }
}());