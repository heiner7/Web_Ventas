import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent implements OnInit {

  selectedPerson: number = 0;
  persons: any[] = [];
  ventas: any[] = [];
  totalVentas: number = 0;
  detalleVenta: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    // Obtener los datos de las personas desde una URL
    this.http.get<any[]>('https://localhost:5001/api/Personas/ObtenerPersonas').subscribe(data => {
      this.persons = data;
      this.loadVentas();
    });
  }

  // Método para cargar las ventas al seleccionar una persona
  loadVentas() {
    this.totalVentas = 0;
    // Obtener los datos de las ventas desde una URL utilizando this.selectedPerson como parámetro
    this.http.get<any[]>('https://localhost:5001/api/Ventas/ObtenerOrdenVenta/' + this.selectedPerson).subscribe(data => {
      this.ventas = data;
      // Obtener los detalles de venta para cada venta en this.ventas
      const ventasIds = this.ventas.map(venta => venta.id);
      console.log(ventasIds);
      this.http.get<any[]>('https://localhost:5001/api/Ventas/ObtenerDetallesOrdenVenta/' + ventasIds).subscribe(data => {
        this.detalleVenta = data;

        // Calcular el total de ventas
        this.totalVentas = this.detalleVenta.reduce((total, venta) => total + venta.precioTotalImpuestos, 0);
      });
    });
    
  }

}


