namespace ProductsEdit {

    /*Mostrar el modal de confirmación*/
    export function OnclickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(result => {
                if (result.isConfirmed) {
                    Loading.fire("Borrando");


                    App.AxiosProvider.DeletePermisos(id).then(data => {
                        Loading.close();

                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El registro se elimino correctamente", icon: "success" }).
                                then(() => window.location.reload());
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" })
                        }



                    })

                }

            });

    }

   





}