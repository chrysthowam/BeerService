import { Component, OnInit } from '@angular/core';
import { CervejaService } from '../../cerveja/cerveja.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Errors } from "../errors";
import { ActivatedRoute } from '@angular/router';
import { Router } from "@angular/router"
import { Cerveja } from '../cerveja';

@Component({
  selector: 'app-edicao-cerveja',
  templateUrl: './edicao-cerveja.component.html',
})
export class EdicaoCervejaComponent implements OnInit {

  public success: boolean;

  private cerveja: Cerveja = new Cerveja;

  public id: string;
  public alertBox: string;

  public mensagensNome: string[] = [];
  public mensagensDescricao: string[] = [];
  public mensagensHarmonizacao: string[] = [];
  public mensagensCategoria: string[] = [];
  public mensagensCor: string[] = [];
  public mensagensIngredientes: string[] = [];
  public mensagensBusiness: string[] = [];

  constructor(private cervejaService: CervejaService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.consultarCerveja();
  }

  consultarCerveja() {
    this.cervejaService.consultarCerveja(this.id)
      .subscribe((cerveja: Cerveja) => {

        this.cerveja = cerveja.cerveja;

       });
  }

  editarCerveja() {
    this.cervejaService.editarCerveja(this.cerveja.id, this.cerveja.nome, this.cerveja.descricao,
      this.cerveja.harmonizacao, this.cerveja.cor, this.cerveja.categoria, this.cerveja.teorAlcoolico,
      this.cerveja.ingredientes, this.cerveja.temperaturaInicial, this.cerveja.temperaturaFinal)
      .subscribe(
        () => {
          console.log("lolk");
          this.alertBox = 'alert alert-success';
          this.mensagensBusiness = ['Edição realizada com sucesso!'];
          this.router.navigate(['/'])
        },
        (response: HttpErrorResponse) => {
          console.log("erro");
          this.alertBox = 'alert alert-danger';
          if (response.status === 400) {
            const retorno = <Errors>response.error.errors;

            this.mensagensCategoria = retorno.Categoria;
            this.mensagensCor = retorno.Cor;
            this.mensagensDescricao = retorno.Descricao;
            this.mensagensHarmonizacao = retorno.Harmonizacao;
            this.mensagensIngredientes = retorno.Ingredientes;
            this.mensagensNome = retorno.Nome;
            this.mensagensBusiness = retorno.business;
          } else {
            this.mensagensBusiness = [response.message];
          }
        }
      );
  }
}
