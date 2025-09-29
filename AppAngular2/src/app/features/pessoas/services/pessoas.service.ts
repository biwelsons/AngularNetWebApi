import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from '../models/pessoa.model';
import { environment } from '../../../../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class PessoasService {
  private url = `${environment.apiUrl}/pessoas`;
  constructor(private http: HttpClient) { }

  getAll(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(`${this.url}/ativos`);
  }

  getById(id: number): Observable<Pessoa> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<Pessoa>(apiUrl);
  }

  savePessoa(pessoa: Pessoa): Observable<Pessoa> {
    return this.http.post<Pessoa>(this.url, pessoa, httpOptions);
  }

  updatePessoa(pessoa: Pessoa): Observable<Pessoa> {
    return this.http.put<Pessoa>(this.url, pessoa, httpOptions);
  }

  deletePessoa(id: number): Observable<void> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<void>(apiUrl, httpOptions);
  }
  
}
