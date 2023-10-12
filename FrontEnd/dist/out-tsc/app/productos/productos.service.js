"use strict";
exports.__esModule = true;
exports.ProductoService = void 0;
var tslib_1 = require("tslib");
var core_1 = require("@angular/core");
var ProductoService = /** @class */ (function () {
    function ProductoService(http) {
        this.http = http;
    }
    ProductoService.prototype.obtenerProductos = function () {
        return this.http.get('URL_DEL_API_O_DATOS'); // Reemplaza 'URL_DEL_API_O_DATOS' con la URL real de tu API o datos.
    };
    ProductoService = tslib_1.__decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], ProductoService);
    return ProductoService;
}());
exports.ProductoService = ProductoService;
//# sourceMappingURL=productos.service.js.map