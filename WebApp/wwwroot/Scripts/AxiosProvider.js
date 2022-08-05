"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        AxiosProvider.SaveProducts = function (entity) { return axios.post("Products/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.DeleteProducts = function (id) { return axios.delete("Products/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map