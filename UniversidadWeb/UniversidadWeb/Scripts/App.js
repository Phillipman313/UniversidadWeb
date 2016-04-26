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

    var idEstudiante = $('#cedula_input').val();

    $.get("http://localhost:62609/Estudiantes/Details/" + idEstudiante, function () {
        console.log('Usuario encontrado!');
        verifyEnrollment(idEstudiante);
    })
    .done(function () {

    })
    .fail(function (e) {
        alert("Mensaje => Usuario no encontrado");
        console.log(e);
    })
    .always(function () {

    });

}

function verifyEnrollment(idEstudiante) {

    $.get("http://localhost:62609/Matriculas/getMatriculaID/" + idEstudiante, function () {

    })
    .done(function (response) {
        console.log("El usuario " + idEstudiante + " ya tiene un registro de matricula, id => " + response[0].Content);
        //createCursoEstudiante(state.currentCourse, idEstudiante, response[0].Content);
        getCursoEstudiante(idEstudiante, state.currentCourse, response[0].Content);
    })
    .fail(function (e) {
        //alert("Error al verificar la matricula del estudiante");
        console.log(e);

        if(e.status === 404){
            createMatricula(idEstudiante);
        }
    })
    .always(function () {

    });
}

// param idMatricula
function getCursoEstudiante(idEstudiante, idCursoLectivo, idMatricula) {

    $.get("http://localhost:62609/Curso_Estudiante/getCursoEstudianteID/" + idEstudiante, function () {

    })
    .done(function (response) {
        console.log("El usuario " + idEstudiante + " ya tiene un registro de de curso estudiante, id => " + response[0].Content);
        enrollCourse(idMatricula, response[0].Content);
    })
    .fail(function (e) {
        //alert("Error en get de CursoEstudiante");
        console.log(e);

        if (e.status === 404) {
            createCursoEstudiante(idCursoLectivo, idEstudiante, idMatricula);
        }
    })
    .always(function () {

    });
}

function createCursoEstudiante(idCursoLectivo, idEstudiante, idMatricula) {

    $.post("http://localhost:62609/Curso_Estudiante/Create/" , {
        Id_CursoLectivo: idCursoLectivo,
        Id_Estudiante: idEstudiante,
        Estado: 'Activo',
        Nota: 0
    })
    .done(function (response) {
        console.log("CursoEstudiante creado.");
        getCursoEstudiante(idEstudiante, idCursoLectivo, idMatricula);
  
    })
    .fail(function (e) {
        alert("Error mientras se creaba CursoEstudiante.");
        console.log(e);
    })
    .always(function () {

    });
}

function enrollCourse(idMatricula, idCursoLectivo) {

    console.log("Enroll params, => " + idMatricula + " => " + idCursoLectivo);

    $.post("http://localhost:62609/MatriculaCursoes/Create/" , {
        Id_Matricula: idMatricula,
        Id_CursoLectivo:  idCursoLectivo
    })
    .done(function (response) { 
        console.log("CursoMatricula creado satisfactoriamente.");
        $('#matricula_modal').modal('hide');
        //window.location.href = "http://localhost:62609/Matriculas/Details/" + idMatricula;
        increaseEnrollmentAmount(idMatricula);
    })
    .fail(function (e) {
        alert("Error mientras se matriculaba el curso");
        console.log(e);
    })
    .always(function () {
        //alert("finished");
    });
}


function createMatricula(idEstudiante) {

    $.post("http://localhost:62609/Matriculas/Create", {
        CodMatricula: 'MM',
        Id_Periodo: 1,
        Id_Estudiante: idEstudiante,
        Estado: 'Pendiente de pago',
        Monto: 0
    })
    .done(function (response) {
        console.log("Matricula creada satisfactoriamente, vloviendo a verificar...");
        verifyEnrollment(idEstudiante);
    })
    .fail(function (e) {
        alert("Error mientras se creaba la matricula.");
        console.log(e);
    })
    .always(function () {
        //alert("finished");
    });
}



function increaseEnrollmentAmount(idMatricula) {
    $.post("http://localhost:62609/Matriculas/increaseEnrollmentAmount", {
        id: idMatricula
    })
    .done(function (response) {
        console.log("Monto de matricula incrementado satisfactoriamente.");
        window.location.href = "http://localhost:62609/Matriculas/Details/" + idMatricula;
    })
    .fail(function (e) {
        alert("Error mientras se aumentaba el monto de la matricula.");
        console.log(e);
    })
    .always(function () {
        //alert("finished");
    });
}