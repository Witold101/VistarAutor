function close_dialog() {
        $("#clientModal").modal("hide");
}

function close_di() {
    $("#clientModal").modal("hide");
}
function close_dell() {
    $("#dellPerson").modal("hide");
}

function close_mess() {
    $("#message-text").val("");
    $("#messModal").modal("hide");
}


function clear_client() {
    $("#cl_name").val("");
    $("#cl_betday").val("");
    $("#cl_department").val("");
    $("#cl_position").val("");
    $("#cl_note").val("");
    close_di();
}

function dell_person(idPerson, namePerson) {
    $("#hidenDellPersonId").val(idPerson);
    $("#HdellPerson").html(namePerson);
}

$("#dellPersonOk").on("click", function () {
    $("#dellPerson").modal("hide");
});