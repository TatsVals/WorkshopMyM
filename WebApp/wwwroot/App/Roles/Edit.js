"use strict";
var RolesEdit;
(function (RolesEdit) {
    function OnclickGuardar() {
        Toast.fire({ title: "El registro se elimino correctamente", icon: "success" }).
            then(function () { return window.location.reload(); });
    }
    RolesEdit.OnclickGuardar = OnclickGuardar;
    /*Datable*/
    $("#GridView").DataTable();
})(RolesEdit || (RolesEdit = {}));
//# sourceMappingURL=Edit.js.map