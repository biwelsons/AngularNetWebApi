import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthService } from '../../core/auth/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formularioLogin!: FormGroup;
  errorMessage: string | null = null;
  

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.formularioLogin = new FormGroup({
      email: new FormControl(''),
      password: new FormControl('')
    });
  }

  onSubmit() {
    if (this.formularioLogin.invalid) {
      this.errorMessage = 'Por favor, preencha os campos corretamente.';
      return;
    }

    const { email, password } = this.formularioLogin.value;
    this.errorMessage = null;

    this.authService.login(email, password).subscribe({
      next: () => {
        this.router.navigate(['/pessoas']);
      },
      error: (error) => {
        this.errorMessage = error.message;
      }
    });
  }
}
