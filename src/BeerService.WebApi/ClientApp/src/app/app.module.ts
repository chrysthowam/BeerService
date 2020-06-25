import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CervejaService } from './cerveja/cerveja.service';
import { CommonModule } from '@angular/common';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzTableModule } from 'ng-zorro-antd/table';
import { CadastroCervejaComponent } from './cerveja/cadastro-cerveja/cadastro-cerveja.component';
import { EdicaoCervejaComponent } from './cerveja/edicao-cerveja/edicao-cerveja.component';
import { VisualizacaoCervejaComponent } from './cerveja/visualizacao-cerveja/visualizacao-cerveja.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    CadastroCervejaComponent,
    EdicaoCervejaComponent,
    VisualizacaoCervejaComponent
  ],
  imports: [
    CommonModule,
    NgZorroAntdModule.forRoot(),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NzFormModule,
    NzTableModule,
    NzDividerModule,
    NzModalModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'cadastro-cerveja', component: CadastroCervejaComponent },
      { path: 'edicao-cerveja/:id', component: EdicaoCervejaComponent },
      { path: 'visualizacao-cerveja/:id', component: VisualizacaoCervejaComponent },
    ])
  ],
  providers: [
    CervejaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
