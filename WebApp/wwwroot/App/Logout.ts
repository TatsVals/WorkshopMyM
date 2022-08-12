namespace Logout {
   
    declare var MensajeApp;

    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }

    export function OnClickLogout() {

        ComfirmAlert("¿Desea Cerrar Sesion?", "Salir", "warning", '#3085d6', '#d33')
            .then(result => {
                if (result.isConfirmed) {
                    window.location.href = "Login?handler=Logout=";

                }

                
            });
    }

    

}