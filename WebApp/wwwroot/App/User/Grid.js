"use strict";
var UserGrid;
(function (UserGrid) {
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro seleccionado?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Users/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    UserGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(UserGrid || (UserGrid = {}));
//# sourceMappingURL=Grid.js.map