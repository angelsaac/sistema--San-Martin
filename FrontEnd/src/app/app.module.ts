import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { HttpClientModule } from '@angular/common/http'; // Importa HttpClientModule
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductosComponent } from './productos/productos.component';
import { HeaderComponent } from './header/header.component';
import { TimerComponent } from './header/timer/timer.component';
import { AgregarProductoComponent } from './productos/agregar-producto/agregar-producto.component';
import { ListarProductoComponent } from './productos/listar-producto/listar-producto.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ActualizarProductosComponent } from './productos/actualizar-productos/actualizar-productos.component';
import { TipoProductosComponent } from './productos/tipo-productos/tipo-productos.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductosComponent,
    HeaderComponent,
    TimerComponent,
    AgregarProductoComponent,
    ListarProductoComponent,
    ActualizarProductosComponent,
    TipoProductosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatDialogModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
