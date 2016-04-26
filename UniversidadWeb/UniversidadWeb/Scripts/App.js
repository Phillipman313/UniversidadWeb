(function () {
    console.log('the awesome is coming...');
})()

var state = {
    currentCourse: undefined
}

function setCurrentCourse(id) {
    state.currentCourse = id;
}

function verify() {

    if ($('#cedula_input').val() === "") {
        alert("Snaap!, Bad input");
        return;
    }

    var id = $('#cedula_input').val();

    $.get("http://localhost:62609/Estudiantes/Details/" + id, function () {
        console.log('Usuario encontrado!');
        verifyEnrollment(id);
    })
    .done(function () {
        //alert("second success");
    })
    .fail(function (e) {
        alert("Mensaje => Usuario no encontrado");
        console.log(e);
    })
    .always(function () {
        //alert("finished");
    });

}

function verifyEnrollment(id) {

    $.get("http://localhost:62609/Matriculas/Details/" + id, function () {
        //alert('success...');
    })
    .done(function (response) {
        //alert("second success");
        console.log(response[0].Content);
        console.log("El usuario " + id + " ya tiene un registro de matricula, id => " + response[0].Content);
        //enrollCourse(response[0].Content, state.currentCourse);
        createCursoEstudiante(state.currentCourse, id);
    })
    .fail(function (e) {
        alert("Error al verificar la matricula del estudiante");
        console.log(e);
    })
    .always(function () {
        //alert("finished");
    });
}

function createCursoEstudiante(idCursoLectivo, idEstudiante) {

    $.post("http://localhost:62609/MatriculaCursoes/Create/", {
        Id_CursoLectivo: idCursoLectivo,
        Id_Estudiante: idEstudiante,
        Estado: 'Activo',
        Nota: 0
    })
    .done(function (response) {
        //alert("second success");
        //console.log(response);
    })
    .fail(function (e) {
        alert("Error mientras se matriculaba el curso");
        console.log(e);
    })
    .always(function () {
        //alert("finished");
    });
}

function enrollCourse(idMatricula, idCursoLectivo) {

    console.log("Enroll params " + idMatricula + " => " + idCursoLectivo);

    $.post("http://localhost:62609/MatriculaCursoes/Create/" , {
        Id_Matricula: idMatricula,
        Id_CursoLectivo:  idCursoLectivo
    })
    .done(function (response) {
        //alert("second success");
        //console.log(response);
    })
    .fail(function (e) {
        alert("Error mientras se matriculaba el curso");
        console.log(e);
    })
    .always(function () {
        //alert("finished");
    });
}