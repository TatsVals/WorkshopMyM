"use strict";
var PermisosEdit;
(function (PermisosEdit) {
    function OnclickGuardar() {
        Toast.fire({ title: "El registro se elimino correctamente", icon: "success" }).
            then(function () { return window.location.reload(); });
    }
    PermisosEdit.OnclickGuardar = OnclickGuardar;
    /*Datable*/
    $("#GridView").DataTable();
})(PermisosEdit || (PermisosEdit = {}));
//# sourceMappingURL=Edit.js.map