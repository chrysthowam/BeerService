import { Component } from '@angular/core';
import { CervejaService } from '../../cerveja/cerveja.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Errors } from "../errors";

@Component({
  selector: 'app-cadastro-cerveja',
  templateUrl: './cadastro-cerveja.component.html',
})
export class CadastroCervejaComponent {

  public success: boolean;
  public nome: string;
  public descricao: string;
  public harmonizacao: string;
  public cor: string;
  public categoria: string;
  public teorAlcoolico: number;
  public ingredientes: string;
  public temperaturaInicial: number;
  public temperaturaFinal: number;
  public imagem: string;
  public alertBox: string;

  public mensagensNome: string[] = [];
  public mensagensDescricao: string[] = [];
  public mensagensHarmonizacao: string[] = [];
  public mensagensCategoria: string[] = [];
  public mensagensCor: string[] = [];
  public mensagensIngredientes: string[] = [];
  public mensagensBusiness: string[] = [];

  public cores: string[] = [ '', 'Palha', 'Amarelo', 'Ouro', 'Âmbar',
    'Profundo âmbar', 'Cobre', 'Profundo cobre', 'Castanho',
    'Castanho escuro', 'Castanho muito escuro', 'Preto', 'Preto opaco'];
  corSelecionada: string = '';

  fileToUpload: File = null;

  constructor(private cervejaService: CervejaService) { }

  cadastrarCerveja() {

    this.cor = this.corSelecionada;

    if (this.fileToUpload != undefined) {
      this.imagem = this.fileToUpload.name;
    }

    this.cervejaService.cadastrarCerveja(this.nome, this.descricao,
      this.harmonizacao, this.cor, this.categoria, this.teorAlcoolico,
      this.ingredientes, this.temperaturaInicial, this.temperaturaFinal,
      this.imagem)
      .subscribe(
        () => {
          this.alertBox = 'alert alert-success';
          this.mensagensBusiness = ['Cerveja cadastrada com sucesso!'];

          this.cervejaService.uploadIMagem(this.fileToUpload).subscribe();
        },
        (response: HttpErrorResponse) => {
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

  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }
}
