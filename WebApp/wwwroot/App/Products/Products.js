"use strict";
var Products;
(function (Products) {
    /*Muestra modal de mensaje*/
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }
    /*Mostrar el modal de confirmación*/
    function OnclickEliminar2(id) {
        ComfirmAlert("¿Desea eliminar el registro?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Proveedor/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    Products.OnclickEliminar2 = OnclickEliminar2;
    /*Datable*/
    $("#GridView").DataTable();
})(Products || (Products = {}));
//# sourceMappingURL=Products.js.map