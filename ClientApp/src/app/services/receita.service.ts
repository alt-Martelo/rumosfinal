import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Receita } from '../models/receita.model';
import { Ingrediente } from '../models/ingrediente.model';

@Injectable({
  providedIn: 'root'
})
export class ReceitaService {
  private apiUrl = 'https://localhost:7231/api/Receitas';

  constructor(private http: HttpClient) { }

  private getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${token}`
    });
  }

  criarReceita(receita: Receita): Observable<any> {
    return this.http.post(this.apiUrl, receita, {
      headers: this.getAuthHeaders()
    });
  }

  getIngredientes(): Observable<Ingrediente[]> {
    return this.http.get<Ingrediente[]>(`${this.apiUrl}/Ingredientes`, {
      headers: this.getAuthHeaders()
    });
  }
}
