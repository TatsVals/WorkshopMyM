namespace UsersEdit {


    export function OnclickGuardar() {
        Toast.fire({ title: "El registro se elimino correctamente", icon: "success" }).
            then(() => window.location.reload());

    }


    /*Datable*/
    $("#GridView").DataTable();




}