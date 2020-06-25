import { Component, OnInit } from '@angular/core';
import { CervejaService } from '../cerveja.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Errors } from "../errors";
import { ActivatedRoute } from '@angular/router';
import { Router } from "@angular/router"
import { Cerveja } from '../cerveja';
import { RetornoConsultarCerveja } from '../retorno-consultar-cerveja';
import { Retorno } from '../retorno';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-visualizacao-cerveja',
  templateUrl: './visualizacao-cerveja.component.html',
})
export class VisualizacaoCervejaComponent implements OnInit {

  public success: boolean;

  private cerveja: Cerveja = new Cerveja;

  public id: string;
  public alertBox: string;
  imageToShow: any;

  constructor(private cervejaService: CervejaService, private sanitizer: DomSanitizer,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.consultarCerveja();
  }

  consultarCerveja() {
    this.cervejaService.consultarCerveja(this.id)
      .subscribe((retorno: RetornoConsultarCerveja) => {

        this.cerveja = <Cerveja>retorno.cerveja;

        this.consultarImagem(this.cerveja.imagem);

       });
  }

  consultarImagem(imagem: string) {
    this.cervejaService.downloadImagem(imagem).subscribe((data: Retorno) => {

      console.log(data.result);

      let objectURL = 'data:image/jpeg;base64,' + data.result;
      this.imageToShow = this.sanitizer.bypassSecurityTrustUrl(objectURL);

      console.log(this.imageToShow);

    }, error => {
      console.log(error);
    });
  }

  createImageFromBlob(image: Blob) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
      this.imageToShow = reader.result;
    }, false);

    if (image) {
      reader.readAsDataURL(image);
    }
  }
}
