define ['jquery', 'mustache'], ($, Mustache) ->
  $studentsDisplay = $ '#target-display'
  templateStd = """
    <ul class="students-list">{{#students}}
      <li>
        <span>ID: {{id}}</span>
        <strong>name: {{name}}</strong>
        <span>grade: {{grade}}</span>
      </li>{{/students}}
    </ul>
    """
  templateMsg = "<div class='message-box'>{{.}}</div>"

  displayStudents = (data) ->
    studentsHTML = Mustache.to_html templateStd, data
    $studentsDisplay.html studentsHTML

  showMessage = (message) ->
    $msgHtml = $ Mustache.to_html templateMsg, message
    $('body').append $msgHtml
    $msgHtml.fadeIn()
    $msgHtml.fadeOut 800

  displayStudents: displayStudents
  showMessage: showMessage