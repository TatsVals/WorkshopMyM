"use strict";
var UsersEdit;
(function (UsersEdit) {
    function OnclickGuardar() {
        Toast.fire({ title: "El registro se elimino correctamente", icon: "success" }).
            then(function () { return window.location.reload(); });
    }
    UsersEdit.OnclickGuardar = OnclickGuardar;
    /*Datable*/
    $("#GridView").DataTable();
})(UsersEdit || (UsersEdit = {}));
//# sourceMappingURL=Edit.js.map