// Generated by CoffeeScript 1.7.1
(function() {
  define(['jquery', 'persister', 'view'], function($, persister, view) {
    var run;
    run = function() {
      var $getPostsBtn, $sendButton, getPosts;
      $sendButton = view.getSubmitButton();
      $getPostsBtn = view.getGetPostsButton();
      getPosts = function() {
        return persister.getMessages().then(function(data) {
          return view.showMessages(data.reverse());
        }).fail(function(err) {
          return alert("Error: " + err);
        });
      };
      $sendButton.on('click', function(ev) {
        var newPost;
        ev.preventDefault();
        newPost = view.getNewPost();
        return persister.sendMessage(newPost.user, newPost.text);
      });
      $getPostsBtn.on('click', function(ev) {
        ev.preventDefault();
        return getPosts();
      });
      setTimeout(getPosts, 10000);
      return null;
    };
    return {
      run: run
    };
  });

}).call(this);

//# sourceMappingURL=controller.map