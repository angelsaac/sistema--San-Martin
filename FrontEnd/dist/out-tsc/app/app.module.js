"use strict";
exports.__esModule = true;
exports.AppModule = void 0;
var tslib_1 = require("tslib");
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/common/http"); // Importa HttpClientModule
var app_routing_module_1 = require("./app-routing.module");
var app_component_1 = require("./app.component");
var productos_component_1 = require("./productos/productos.component");
var header_component_1 = require("./header/header.component");
var timer_component_1 = require("./header/timer/timer.component");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib_1.__decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                productos_component_1.ProductosComponent,
                header_component_1.HeaderComponent,
                timer_component_1.TimerComponent
            ],
            imports: [
                platform_browser_1.BrowserModule,
                app_routing_module_1.AppRoutingModule,
                http_1.HttpClientModule
            ],
            providers: [],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map