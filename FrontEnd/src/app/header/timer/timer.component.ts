import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.css']
})
export class TimerComponent implements OnInit {
  public fecha?: string; // Usamos un objeto Date para almacenar la fecha y hora actual

  constructor() { }

  ngOnInit(): void {
    this.actualizarFecha(); // Llamar a la función al iniciar el componente

    setInterval(() => {
      this.actualizarFecha();
    }, 1000);
  }
  actualizarFecha() {
    const date = new Date(); 
    this.fecha = date.toLocaleString('es-MX')
  }
}
