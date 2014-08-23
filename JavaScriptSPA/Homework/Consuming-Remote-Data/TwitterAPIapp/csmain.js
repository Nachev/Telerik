// Generated by CoffeeScript 1.7.1
(function() {
  require.config({
    paths: {
      'jquery': 'bower_components/jquery/dist/jquery',
      'controller': 'scripts/modules/twitterAPIcontroller'
    }
  });

  require(['jquery', 'controller'], function($, controller) {
    var $form, showPosts;
    $form = $('#requestForm');
    showPosts = function(posts) {
      return $('#target-display').html = posts;
    };
    return $form.on('click', '#submit', function(ev) {
      var $properties, posts, prop, properties, values, _fn, _i, _len;
      ev.preventDefault();
      $properties = $('.properties');
      values = [];
      _fn = function() {
        if (prop != null) {
          return values.push(prop.value);
        } else {
          alert("All fields are mandatory");
          throw new Error("All fields are mandatory");
        }
      };
      for (_i = 0, _len = $properties.length; _i < _len; _i++) {
        prop = $properties[_i];
        _fn();
      }
      properties = {
        'consumerKey': values[0],
        'consumerSecret': values[1],
        'accessToken': values[2],
        'accessTokenSecret': values[3],
        'username': values[4],
        'numberOfPosts': Number.parseInt(values[5])
      };
      posts = controller.getPosts(properties);
      return showPosts(posts);
    });
  });

}).call(this);

//# sourceMappingURL=persister.map