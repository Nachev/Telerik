// Generated by CoffeeScript 1.7.1
(function() {
  var define;

  if (typeof define !== 'function') {
    define = require('amdefine')(module);
  }

  define(['jquery', 'httpRequester'], function($, httpRequester) {
    var MAX_GRADE, MIN_GRADE, addStudent, delStudent, getStudents, resourceUrl;
    resourceUrl = 'http://localhost:3000/students';
    MIN_GRADE = 2;
    MAX_GRADE = 6;
    addStudent = function(name, grade) {
      var isCorrectGrade, isCorrectName, newStudent;
      isCorrectName = $.type(name) === "string" && name.length > 0;
      if (!isCorrectName) {
        throw new Error("Name value must be string with length greater than 0");
        return;
      }
      isCorrectGrade = $.type(grade) === "number" && (MIN_GRADE <= grade && grade <= MAX_GRADE);
      if (!isCorrectGrade) {
        throw new Error("Grade must be number in range " + MIN_GRADE + ' to ' + MAX_GRADE);
        return;
      }
      newStudent = {
        name: name,
        grade: grade
      };
      return httpRequester.postAjax(resourceUrl, newStudent);
    };
    getStudents = function() {
      return httpRequester.getAjax(resourceUrl);
    };
    delStudent = function(idToDelete) {
      return httpRequester.delAjax(resourceUrl + ("/" + idToDelete + "/"));
    };
    return {
      addStudent: addStudent,
      getStudents: getStudents,
      delStudent: delStudent
    };
  });

}).call(this);

//# sourceMappingURL=persister.map
