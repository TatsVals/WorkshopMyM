"use strict";
var RolesEdit;
(function (RolesEdit) {
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
                    App.AxiosProvider.SaveRoles(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El registro se guardó correctamente", icon: "success" }).then(function () { return window.location.href = "Roles/Grid"; });
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
})(RolesEdit || (RolesEdit = {}));
//# sourceMappingURL=Edit.js.map