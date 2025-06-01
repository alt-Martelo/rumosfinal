import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Receita } from '../models/receita.model';
import { Ingrediente } from '../models/ingrediente.model';

@Injectable({
  providedIn: 'root'
})
export class ReceitaService {
  private apiUrl = 'https://localhost:7231/api/Receitas/'

  constructor(private http: HttpClient) { }

  criarReceita(receita: Receita): Observable<any> {
    return this.http.post(this.apiUrl, receita);
  }
  getIngredientes(): Observable<Ingrediente[]> {
    return this.http.get<Ingrediente[]>(`${this.apiUrl}/Ingredientes`);
  }
}
