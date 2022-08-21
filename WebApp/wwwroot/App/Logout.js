"use strict";
var LogOut;
(function (LogOut) {
    function OnclickSalir() {
        ComfirmAlert("¿Desea Cerrar Sesion?", "Salir", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Saliendo");
                window.location.href = "Login/?handler=Salir";
            }
        });
    }
    LogOut.OnclickSalir = OnclickSalir;
})(LogOut || (LogOut = {}));
//# sourceMappingURL=LogOut.js.map