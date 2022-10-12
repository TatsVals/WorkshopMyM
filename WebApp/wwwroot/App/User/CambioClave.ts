﻿namespace CambioClave {


    var Entity = $("#AppCambioClave").data("entity")

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormCambioClave",  // nombre del id que se le dio al form en el Edit
                Entity: Entity
            },

            methods: {

                Save() {
                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando..");

                        App.AxiosProvider.CambioClave(this.Entity).then(data => {
                            Loading.close();

                            if (data.CodeError == 0) {

                                Toast.fire({ title: "El registro se guardó correctamente", icon: "success" }).then
                                    (() => window.location.href = "Users/Grid")
                            } else {
                                Toast.fire({ title: data.MsgError, icon: "error" })

                            }
                        });


                    } else {
                        Toast.fire({ title: "Por favor complete los campos requeridos" })
                    }


                }


            },

            mounted() {
                CreateValidator(this.Formulario);

            }

        });

    Formulario.$mount("#AppCambioClave");



}