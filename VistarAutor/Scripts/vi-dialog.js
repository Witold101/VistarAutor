function close_dialog() {
        $("#clientModal").modal("hide");
}

function close_di() {
    $("#clientModal").modal("hide");
}
function close_dell() {
    $("#dellPerson").modal("hide");
}


function clear_client() {
    $("#cl_name").val("");
    $("#cl_betday").val("");
    $("#cl_department").val("");
    $("#cl_position").val("");
    $("#cl_note").val("");
    close_di();
}

function dell_person(id_person, name_person) {
    $("#hidenDellPersonId").val(id_person)
    $("#hidenNamePerson").val(name_person)
}

$("#dellPersonOk").on("click", function () {
    $("#dellPerson").modal("hide");
});