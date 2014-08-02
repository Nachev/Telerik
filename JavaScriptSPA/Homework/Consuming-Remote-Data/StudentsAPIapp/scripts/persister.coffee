define = require('amdefine')(module) unless typeof define is 'function'

define ['jquery', 'httpRequester'], ($, httpRequester) ->
  resourceUrl = 'http://localhost:3000/students'
  MIN_GRADE = 2
  MAX_GRADE = 6

  addStudent = (name, grade) ->
    isCorrectName = $.type(name) is "string" and name.length > 0
    if not isCorrectName
      throw new Error "Name value must be string with length greater than 0"
      return

    isCorrectGrade = $.type(grade) is "number" and MIN_GRADE <= grade <= MAX_GRADE
    if not isCorrectGrade
      throw new Error "Grade must be number in range " + MIN_GRADE + ' to ' + MAX_GRADE
      return

    newStudent =
      name: name
      grade: grade
    httpRequester.postAjax resourceUrl, newStudent

  getStudents = () ->
    httpRequester.getAjax resourceUrl

  delStudent = (idToDelete) ->
    httpRequester.delAjax resourceUrl + "/#{idToDelete}/"

  addStudent: addStudent
  getStudents: getStudents
  delStudent: delStudent