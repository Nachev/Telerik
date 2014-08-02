require(['modules/http-request'], function main(httpRequest) {

    httpRequest.getJSON('http://localhost:3000/students')
        .then(function () {
            alert('Promise');
        })
        .fail(function () {
            alert('Fail')
        });
    
    httpRequest.postJSON('http://localhost:3000/students', {
        'name': 'Pesho',
        'sex': 'undefined'
    })
        .then(function () {
             alert('Pesho is sent.');
        });

    httpRequest.getJSON('http://localhost:3000/students')
        .then(function (data) {
            alert('Received ' + data);
        })
        .fail(function () {
            alert('Fail')
        });
});
