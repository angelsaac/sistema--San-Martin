import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent {
  public show:number = 1; 
  manejarBotonClickeado(boton: number) {
    this.show = boton;
    console.log(`Se hizo clic en ${boton} desde el componente padre.`);
    // Realiza la lógica que necesites aquí para diferenciar los botones.
  }
}