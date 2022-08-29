"use strict";
var CambioClave;
(function (CambioClave) {
    var Entity = $("#AppCambioClave").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormCambioClave",
            Entity: Entity
        },
        methods: {
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando..");
                    App.AxiosProvider.CambioClave(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El registro se guardó correctamente", icon: "success" }).then(function () { return window.location.href = "Users/Grid"; });
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
    Formulario.$mount("#AppCambioClave");
})(CambioClave || (CambioClave = {}));
//# sourceMappingURL=CambioClave.js.map