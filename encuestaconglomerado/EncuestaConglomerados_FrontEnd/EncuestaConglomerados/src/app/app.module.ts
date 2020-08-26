import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EncuestaComponent } from './encuesta/encuesta.component';
import { EncuestaService } from '../services/encuesta.service';
import { FormsModule } from '@angular/forms';
import { AutenticacionComponent } from './autenticacion/autenticacion.component';
import { AdministradorComponent } from './administrador/administrador.component';
import { SabanaencuestaComponent } from './sabanaencuesta/sabanaencuesta.component';
import { GestionusuariosComponent } from './gestionusuarios/gestionusuarios.component';
import { DxPopupModule, DxButtonModule, DxTemplateModule,DxFormModule,DxRadioGroupModule, DxDataGridModule , DxSelectBoxModule } from 'devextreme-angular';

@NgModule({
  declarations: [
    AppComponent,
    EncuestaComponent,
    AutenticacionComponent,
    AdministradorComponent,
    SabanaencuestaComponent,
    GestionusuariosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    DxPopupModule,
    DxButtonModule,
    DxTemplateModule,
    DxFormModule,
    DxRadioGroupModule,
    DxDataGridModule,
    DxSelectBoxModule
  
  ],
  providers: [EncuestaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
