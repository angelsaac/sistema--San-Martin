"use strict";
exports.__esModule = true;
exports.ProductosComponent = void 0;
var tslib_1 = require("tslib");
var core_1 = require("@angular/core");
var ProductosComponent = /** @class */ (function () {
    function ProductosComponent(productoService) {
        this.productoService = productoService;
    }
    ProductosComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.productoService.obtenerProductos().subscribe(function (data) {
            _this.productos = data;
        });
    };
    ProductosComponent = tslib_1.__decorate([
        core_1.Component({
            selector: 'app-productos',
            templateUrl: './productos.component.html',
            styleUrls: ['./productos.component.css']
        })
    ], ProductosComponent);
    return ProductosComponent;
}());
exports.ProductosComponent = ProductosComponent;
//# sourceMappingURL=productos.component.js.map