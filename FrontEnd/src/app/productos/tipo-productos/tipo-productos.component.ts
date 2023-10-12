import { Component, EventEmitter, Output } from '@angular/core';
import { ProductoService } from '../productos.service';

@Component({
  selector: 'app-tipo-productos',
  templateUrl: './tipo-productos.component.html',
  styleUrls: ['./tipo-productos.component.css']
})
export class TipoProductosComponent {
  public nombre? :string;
  public descripcion? :string;
  tipoProductos? : any;
  @Output() botonClickeado = new EventEmitter<number>();
  constructor(private productoService: ProductoService) {}

  ngOnInit(): void {
    this.productoService.getTipoProductos().subscribe((data: any) => {
      this.tipoProductos = data.datos;
    });
  }
  onBotonClick(boton: number) {
    this.botonClickeado.emit(boton);
  }

  onSubmit() {
    // Crear un objeto con los datos del formulario
    const tipoProducto = {
      nombreTipoProducto: this.nombre,
      descripcionTipoProducto: this.descripcion,
    };
    // Llamar al servicio para enviar la solicitud POST
    this.productoService.addTipoProductos(tipoProducto).subscribe((data:any)=>{
      if(!data.esValido){
        alert(data.mensaje);
        this.nombre = ""
        this.descripcion = ""
        return;
      }
      alert(`${data.datos.nombreTipoProducto} agregado con exito`);
      this.productoService.getTipoProductos().subscribe((data: any) => {
        this.tipoProductos = data.datos;
      });
      this.nombre = ""
      this.descripcion = ""
      // this.onBotonClick(1);
    });
  }

  borrarTipoProducto(id:number){
    var resultado = window.confirm('Estas seguro?');
    if (resultado === true) {
      this.productoService.deleteTipoProductos(id).subscribe(
        () => {
          alert('Tipo Producto eliminado correctamente.');
          this.productoService.getTipoProductos().subscribe((data: any) => {
            this.tipoProductos = data.datos;
          });
        },
        error => {
          alert('Error al eliminar el Tipo Producto:'+ error);
          // Manejo de errores, si es necesario.
        }
      )  
    }
  }

}
