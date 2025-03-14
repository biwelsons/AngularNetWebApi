import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PessoasService } from './pessoas.service';
import { PessoaComponent } from './components/pessoa/pessoa.component';
import { LoginComponent } from './pages/login/login.component';
import { TokenInterceptor } from './interceptors/token.service';

@NgModule({
  declarations: [
    AppComponent,
    PessoaComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    FormsModule,
  ],
  providers: [HttpClientModule, 
              PessoasService,
              { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
