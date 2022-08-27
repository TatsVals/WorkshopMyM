namespace LogOut {


    export function OnclickTemporal() {

        alert("¿Si su direccion de E-Mail y Usuario son correctos se le enviará una clave temporal?" )
            
               
                    Loading.fire("Saliendo");
        window.location.href = "Login/?handler=ClaveTemporal";
             


    }
}