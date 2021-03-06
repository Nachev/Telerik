// Generated by CoffeeScript 1.7.1
(function() {
  define(['jquery', 'mustache'], function($, Mustache) {
    var $studentsDisplay, displayStudents, showMessage, templateMsg, templateStd;
    $studentsDisplay = $('#target-display');
    templateStd = "<ul class=\"students-list\">{{#students}}\n  <li>\n    <span>ID: {{id}}</span>\n    <strong>name: {{name}}</strong>\n    <span>grade: {{grade}}</span>\n  </li>{{/students}}\n</ul>";
    templateMsg = "<div class='message-box'>{{.}}</div>";
    displayStudents = function(data) {
      var studentsHTML;
      studentsHTML = Mustache.to_html(templateStd, data);
      return $studentsDisplay.html(studentsHTML);
    };
    showMessage = function(message) {
      var $msgHtml;
      $msgHtml = $(Mustache.to_html(templateMsg, message));
      $('body').append($msgHtml);
      $msgHtml.fadeIn();
      return $msgHtml.fadeOut(800);
    };
    return {
      displayStudents: displayStudents,
      showMessage: showMessage
    };
  });

}).call(this);

//# sourceMappingURL=ui.map
