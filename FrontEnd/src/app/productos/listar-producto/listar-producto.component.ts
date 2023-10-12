import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ProductoService } from '../productos.service';
@Component({
  selector: 'app-listar-producto',
  templateUrl: './listar-producto.component.html',
  styleUrls: ['./listar-producto.component.css']
})
export class ListarProductoComponent implements OnInit {
  @Output() toggle = new EventEmitter<number>();
  @Output() botonClickeado = new EventEmitter<number>();

  public idActualizar?:number;
  productos?: any[];
  public scope :number = 1;
  productoXid?: any;

  constructor(private productoService: ProductoService) {}

  ngOnInit(): void {
    this.productoService.getProductos().subscribe((data: any) => {
      this.productos = data.datos;
    });
  }

  borrarProducto(id:number){
    var resultado = window.confirm('Estas seguro?');
    if (resultado === true) {
      this.productoService.deleteProductos(id).subscribe(
        () => {
          alert('Producto eliminado correctamente.');
          location.reload()
        },
        error => {
          alert('Error al eliminar el producto:'+ error);
          // Manejo de errores, si es necesario.
        }
      )  
    }
  }

  onBotonClick(boton: number) {
    this.botonClickeado.emit(boton);
  }
}
