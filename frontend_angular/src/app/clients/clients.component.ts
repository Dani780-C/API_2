import { Component, OnInit } from '@angular/core';

export interface Client{
  id: number,
  name: string
}

export const CLIENTS: Client[] = [
  { id: 12, name: 'Dr. Nice' },
  { id: 13, name: 'Bombasto' },
  { id: 14, name: 'Celeritas' },
  { id: 15, name: 'Magneta' },
  { id: 16, name: 'RubberMan' },
  { id: 17, name: 'Dynama' },
  { id: 18, name: 'Dr. IQ' },
  { id: 19, name: 'Magma' },
  { id: 20, name: 'Tornado' }
];

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  public client:Client = {
    id: 1,
    name: "Daniel"
  };

  public clients: Client[] = CLIENTS;
  constructor() { }

  public selectedClient?: Client;

  ngOnInit(): void {
  }

  public onSelect(client: Client): void{
    this.selectedClient = client;
  } 

}
