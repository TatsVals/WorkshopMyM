"use strict";
var Products;
(function (Products) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(Products || (Products = {}));
//# sourceMappingURL=Products.js.map