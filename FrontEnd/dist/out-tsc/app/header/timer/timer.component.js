"use strict";
exports.__esModule = true;
exports.TimerComponent = void 0;
var tslib_1 = require("tslib");
var core_1 = require("@angular/core");
var TimerComponent = /** @class */ (function () {
    function TimerComponent() {
    }
    TimerComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.actualizarFecha(); // Llamar a la función al iniciar el componente
        setInterval(function () {
            _this.actualizarFecha();
        }, 1000);
    };
    TimerComponent.prototype.actualizarFecha = function () {
        var date = new Date();
        this.fecha = date.toLocaleString('es-MX');
    };
    TimerComponent = tslib_1.__decorate([
        core_1.Component({
            selector: 'app-timer',
            templateUrl: './timer.component.html',
            styleUrls: ['./timer.component.css']
        })
    ], TimerComponent);
    return TimerComponent;
}());
exports.TimerComponent = TimerComponent;
//# sourceMappingURL=timer.component.js.map