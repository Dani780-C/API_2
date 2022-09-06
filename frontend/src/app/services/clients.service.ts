import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  public url = 'https://localhost:7290/api/Client/get-all-clients';
  
  constructor(private http: HttpClient) { }

  public getClients(): Observable<any>{
    return this.http.get<any>(this.url);
  }
}
