"use strict";
var ProductsEdit;
(function (ProductsEdit) {
    function OnclickGuardar() {
        Toast.fire({ title: "El registro se elimino correctamente", icon: "success" }).
            then(function () { return window.location.reload(); });
    }
    ProductsEdit.OnclickGuardar = OnclickGuardar;
    /*Datable*/
    $("#GridView").DataTable();
})(ProductsEdit || (ProductsEdit = {}));
//# sourceMappingURL=Edit.js.map