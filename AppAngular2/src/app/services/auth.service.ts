import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, Observable, tap, throwError } from 'rxjs';

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
      { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    ).pipe(
      tap((res: any) => {
        if (res.token) {
          localStorage.setItem('token', res.token); // Armazena o token
        }
      }),
      catchError(this.handleError) // Captura os erros da API
    );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'Ocorreu um erro inesperado. Tente novamente mais tarde.';

    if (error.status === 401 || error.status === 400) {
      errorMessage = error.error?.message || 'E-mail ou senha incorretos.';
    }

    return throwError(() => new Error(errorMessage));
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}