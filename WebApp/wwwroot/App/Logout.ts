namespace LogOut {


    export function OnclickSalir() {

        ComfirmAlert("¿Desea Cerrar Sesion?", "Salir", "warning", '#3085d6', '#d33')
            .then(result => {
                if (result.isConfirmed) {
                    Loading.fire("Saliendo");
                    window.location.href = "Login/?handler=Salir";
                }
            });
        

    }
}