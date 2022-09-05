import { Component, OnInit } from '@angular/core';
import { ClientsService } from 'src/app/services/clients.service';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.scss']
})
export class ClientsComponent implements OnInit {

  public clients: any;
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'phoneNumber', 'calledServices'];

  constructor(private clientsService: ClientsService) { }

  ngOnInit(): void {
    this.getAllClients();
  }

  public getAllClients(): void{
    this.clientsService.getClients().subscribe((result) => 
    {
      this.clients = result;
    });
  } 

}
