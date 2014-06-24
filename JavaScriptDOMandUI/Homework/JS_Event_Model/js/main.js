/*jslint browser: true*/
window.onload = function() {
    var inputForm = document.getElementById('input-text'),
        addButton = document.getElementById('add-items'),
        deleteButton = document.getElementById('delete-items'),
        visibilityButton = document.getElementById('toggle-visibility'),
        noteContainer = document.getElementById('note-container');

    function createNote(ev) {
        var note = null;

        ev.preventDefault();

        note = document.createElement('div');
        note.className += 'note';
        note.innerHTML = inputForm.value;
        noteContainer.appendChild(note);
    }

    function deleteNote(ev) {
        var i = 0,
            selectedNotes = noteContainer.getElementsByClassName('selected');

        ev.preventDefault();

        for (i = selectedNotes.length - 1; i >= 0; i--) {
            noteContainer.removeChild(selectedNotes[i]);
        }
    }

    function markSelected(ev) {
        var className = ev.target.className;

        ev.preventDefault();

        if (className.indexOf('selected') >= 0) {
            className = className.replace('selected', '');
        } else {
            className += ' selected';
        }

        ev.target.className = className;
    }

    function toggleVisibility(ev) {
        var i = 0,
            display = null,
            selectedNotes = noteContainer.getElementsByClassName('selected');

        ev.preventDefault();

        for (i = selectedNotes.length - 1; i >= 0; i--) {
            display = selectedNotes[i].style.display;
            if (display === 'none') {
                display = '';
            } else {
                display = 'none';
            }

            selectedNotes[i].style.display = display;
        }
    }

    function dragAndDrop(ev) {
        ev.preventDefault();
        self = ev.target;
        self.style.position = 'absolute';
        self.addEventListener('mousemove', function(event) {
            self.style.top = ev.pageY + 'px';
            self.style.left = ev.pageX + 'px';
        });
    }

    noteContainer.addEventListener('click', markSelected);
    noteContainer.addEventListener('mousedown', dragAndDrop);
    addButton.addEventListener('click', createNote);
    deleteButton.addEventListener('click', deleteNote);
    visibilityButton.addEventListener('click', toggleVisibility);
};