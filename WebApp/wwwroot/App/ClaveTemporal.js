"use strict";
var ClaveTemporal;
(function (ClaveTemporal) {
    var Entity = $("#AppClaveTemporal").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#RecuperarForm",
            Entity: Entity,
        },
        methods: {
            Recuperar: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Enviando...");
                    App.AxiosProvider.Recuperar(this.Entity).then(function (data) {
                        Loading.close();
                        console.log(data);
                        if (data.CodeError == 0) {
                            alert("Si su direccion de E-Mail y Usuario son correctos se le enviará una clave temporal");
                            window.location.href = "Login";
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    }).catch(function (c) { return console.log(c); });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos!", icon: "error" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#RecuperarForm");
})(ClaveTemporal || (ClaveTemporal = {}));
//# sourceMappingURL=ClaveTemporal.js.map