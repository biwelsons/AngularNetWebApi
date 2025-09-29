import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PessoaComponent } from './features/pessoas/components/pessoa.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './core/auth/guards/auth.guard';


const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch:'full'},
  { path: 'login', component: LoginComponent },
  { path: 'pessoas', component: PessoaComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
