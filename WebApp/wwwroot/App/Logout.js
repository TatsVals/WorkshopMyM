"use strict";
var Logout;
(function (Logout) {
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }
    function OnClickLogout() {
        ComfirmAlert("¿Desea Cerrar Sesion?", "Salir", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Index?handler=Logout=";
            }
        });
    }
    Logout.OnClickLogout = OnClickLogout;
    $("#GridView").DataTable();
})(Logout || (Logout = {}));
//# sourceMappingURL=Logout.js.map