define ['jquery', 'persister', 'ui'], ($,  persister, ui) ->
  run = () ->
    $addForm = $ '#student-input'
    $getDelForm = $ '#get-del-student'
    $nameInput = $addForm.find '#tb-st-name'
    $gradeInput = $addForm.find '#tb-st-grade'
    $addButton = $addForm.find '#btn-add'

    $delInput = $getDelForm.find '#tb-del-id'
    $getButton = $getDelForm.find '#btn-get'
    $delButton = $getDelForm.find '#btn-del'

    addStudent = (ev) ->
      ev.preventDefault()
      name = $nameInput.val()
      grade = parseInt $gradeInput.val()
      persister.addStudent name, grade
        .then (data) ->
          ui.showMessage "Addition successful"
        .fail (err) ->
          ui.showMessage "Error: #{err}"

    getStudents = (ev) ->
      ev.preventDefault()
      persister.getStudents()
        .then (data) ->
          ui.displayStudents data
        .fail (err) ->
          ui.showMessage "Error: #{err}"

    delStudent = (ev) ->
      ev.preventDefault()
      idToDelete = $delInput.val()
      persister.delStudent(idToDelete)
        .then (data) ->
          ui.showMessage "Student #{idToDelete} was deleted successfully"
          getStudents ev
        .fail (err) ->
          ui.showMessage "Error: #{err}"


    #Atach events
    $addButton.on 'click', addStudent
    $getButton.on 'click', getStudents
    $delButton.on 'click', delStudent

  run: run