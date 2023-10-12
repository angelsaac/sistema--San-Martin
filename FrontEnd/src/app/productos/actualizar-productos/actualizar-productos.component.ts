import { Component, EventEmitter, Output } from '@angular/core';
import { ProductoService } from '../productos.service';

@Component({
  selector: 'app-actualizar-productos',
  templateUrl: './actualizar-productos.component.html',
  styleUrls: ['./actualizar-productos.component.css']
})
export class ActualizarProductosComponent {
  public Id! :number;
  public nombre? :string;
  public descripcion? :string;
  public precio? :number | null;
  public existencia? :number | null;
  public tipoProducto? :number | null;
  @Output() toggle = new EventEmitter<void>();
  @Output() botonClickeado = new EventEmitter<number>();

  onBotonClick(boton: number) {
    this.botonClickeado.emit(boton);
  }

  constructor(private productoService: ProductoService) { }
  onSubmit() {
    const producto = {
      id : this.Id,
      nombreProducto: this.nombre,
      descripcionProducto: this.descripcion,
      precio: this.precio,
      existencia: this.existencia,
      tipoProductoId: this.tipoProducto,
    };

    this.productoService.actualizarProducto(this.Id,producto).subscribe((data:any)=>{
      if(!data.esValido){
        this.Id = 0
        this.nombre = ""
        this.descripcion = ""
        this.precio = null
        this.existencia = null
        this.tipoProducto = null
        return
      }
      alert(data.mensaje);
      this.onBotonClick(1);
    });
  }
}
