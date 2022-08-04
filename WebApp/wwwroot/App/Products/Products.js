"use strict";
var ProductsProducts;
(function (ProductsProducts) {
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
                    App.AxiosProvider.SaveProduct(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El registro se inserto correctamente", icon: "success" }).then(function () { return window.location.href = "Contacto/Grid"; });
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
})(ProductsProducts || (ProductsProducts = {}));
//# sourceMappingURL=Products.js.map