import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5239/api/auth';

  constructor(private http: HttpClient, private router: Router) {}

  login(email: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, { 
        Email: email,
        Password: password 
      }, 
      {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }) 
      }
    ).pipe(
      tap((res: any) => {
        if (res.token) {
          localStorage.setItem('token', res.token); // Armazena o token
        }
      })
    );
  }
  

  // Método para verificar se o usuário está autenticado
  isAuthenticated(): boolean {
    return !!localStorage.getItem('token'); // Se tem token, está autenticado
  }

  // Método para logout
  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']); // Redireciona para a tela de login
  }

  // Método para pegar o token armazenado
  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
