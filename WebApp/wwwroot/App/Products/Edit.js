"use strict";
var ProductsEdit;
(function (ProductsEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(ProductsEdit || (ProductsEdit = {}));
//# sourceMappingURL=Edit.js.map