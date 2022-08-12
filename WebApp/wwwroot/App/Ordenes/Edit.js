"use strict";
var Entity = $("#AppEdit").data("entity");
var Formulario = new Vue({
    data: {
        Formulario: "#FormEdit",
        Entity: Entity
    },
    methods: {
        Save: function () {
            if (BValidateData(this.Formulario)) {
                Loading.fire("Guardando..");
                App.AxiosProvider.SaveOrdenes(this.Entity).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "El registro se guardó correctamente", icon: "success" }).then(function () { return window.location.href = "Ordenes/Grid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
            else {
                Toast.fire({ title: "Por favor complete los campos requeridos" });
            }
        }
    },
    mounted: function () {
        CreateValidator(this.Formulario);
    }
});
Formulario.$mount("#AppEdit");
//# sourceMappingURL=Edit.js.map