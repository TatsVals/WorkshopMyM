"use strict";
var ProductsGrid;
(function (ProductsGrid) {
    /*Muestra modal de mensaje*/
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }
    /*Mostrar el modal de confirmación*/
    function OnclickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Proveedor/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    ProductsGrid.OnclickEliminar = OnclickEliminar;
    /*Datable*/
    $("#GridView").DataTable();
})(ProductsGrid || (ProductsGrid = {}));
//# sourceMappingURL=Grid.js.map