import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';


@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  constructor(private http: HttpClient, private dialog: MatDialog) {}
  urlPost : string = 'http://localhost:5062/api/productos';
  urlPut : string = 'http://localhost:5062/api/productos';
  
  getProductos() {
    return this.http.get(`http://localhost:5062/api/productos`); 
  }
  deleteProductos(id:number) {
    return this.http.delete(`http://localhost:5062/api/productos/${id}`); 
  }
  agregarProducto(producto: any) {
    return this.http.post(this.urlPost, producto);
  }
  actualizarProducto(id: number, producto: any) {
    const url = `${this.urlPut}/${id}`; // Construir la URL completa con el ID
    return this.http.put(url, producto);
  }
  getTipoProductos() {
    return this.http.get(`http://localhost:5062/api/tiposproductos`); 
  }
  addTipoProductos(body:any) {
    return this.http.post(`http://localhost:5062/api/tiposproductos`, body); 
  }
  deleteTipoProductos(id:number) {
    return this.http.delete(`http://localhost:5062/api/tiposproductos/${id}`); 
  }
}
