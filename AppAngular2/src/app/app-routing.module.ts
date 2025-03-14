import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PessoaComponent } from './components/pessoa/pessoa.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './guards/auth.guard';


const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch:'full'},
  {path: 'pessoas', component: PessoaComponent},
  { path: 'login', component: LoginComponent },
  { path: 'pessoas', component: PessoaComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
