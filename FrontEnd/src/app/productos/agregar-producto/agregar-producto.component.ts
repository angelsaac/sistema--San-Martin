import { Component, EventEmitter, Output } from '@angular/core';
import { ProductoService } from '../productos.service';


@Component({
  selector: 'app-agregar-producto',
  templateUrl: './agregar-producto.component.html',
  styleUrls: ['./agregar-producto.component.css']
})
export class AgregarProductoComponent {
  public nombre? :string;
  public descripcion? :string;
  public precio? :number | null;
  public existencia? :number | null;
  public tipoProducto? :number | null;
  @Output() toggle = new EventEmitter<void>();
  @Output() botonClickeado = new EventEmitter<number>();



  constructor(private productoService: ProductoService) { }
  onBotonClick(boton: number) {
    this.botonClickeado.emit(boton);
  }
  onSubmit() {
    // Crear un objeto con los datos del formulario
    const producto = {
      nombreProducto: this.nombre,
      descripcionProducto: this.descripcion,
      precio: this.precio,
      existencia: this.existencia,
      tipoProductoId: this.tipoProducto,
    };

    // Llamar al servicio para enviar la solicitud POST
    this.productoService.agregarProducto(producto).subscribe((data:any)=>{
      if(!data.esValido){
        alert(data.mensaje);
        this.nombre = ""
        this.descripcion = ""
        this.precio = null
        this.existencia = null
        this.tipoProducto = null
        return;
      }
      alert(`${data.datos.nombreProducto} agregado con exito`);
      this.onBotonClick(1);

    });
  }
}
