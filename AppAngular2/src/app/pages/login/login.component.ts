import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formularioLogin!: FormGroup;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.formularioLogin = new FormGroup({
      email: new FormControl(''),
      password: new FormControl('')
    });
  }

  onSubmit() {
    if (this.formularioLogin.valid) {
      const { email, password } = this.formularioLogin.value;

      this.authService.login(email, password).subscribe({
        next: (res) => {
          console.log('Login bem-sucedido:', res);
          this.router.navigate(['/pessoas']);
        },
        error: (err) => {
          console.error('Erro no login:', err);
        }
      });

    } else {
      console.log("Formulário inválido!");
    }
  }
}
