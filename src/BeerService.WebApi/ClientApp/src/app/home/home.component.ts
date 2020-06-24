import { Component, OnInit } from '@angular/core';
import { CervejaService } from '../cerveja/cerveja.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Cerveja } from '../cerveja/cerveja';
import { Errors } from "../cerveja/errors";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public cervejas: Cerveja[];
  public mensagens: string[];
  public alertBox: string;

  private idExclusao: string; 

  isVisible = false;

  constructor(private cervejaService: CervejaService) { }

  excluirCerveja(id: string): void {
    this.idExclusao = id;
    this.showModal();
  }
     
  ngOnInit(): void {
    this.fetchData();
  }

  fetchData() {
    this.cervejaService.listarCervejas()
      .subscribe(
        retorno => {
          this.cervejas = retorno.result.cervejas;
        }
      );
  }

  showModal(): void {
    this.isVisible = true;
  }

  handleOk(): void {
    this.cervejaService.excluirCerveja(this.idExclusao)
      .subscribe(
        () => {
          this.alertBox = 'alert alert-success';
          this.mensagens = ['Cerveja excluída com sucesso!'];
          this.fetchData();
        },
        (response: HttpErrorResponse) => {
          this.alertBox = 'alert alert-danger';
          if (response.status === 400) {
            const retorno = <Errors>response.error.errors;

            this.mensagens = retorno.Id;

          } else {
            this.mensagens = [response.message];
          }
        }
    );
    this.isVisible = false;
  }

  handleCancel(): void {
    this.isVisible = false;
  }
}
