import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpResponse } from "@angular/common/http";
import { RetornoListarCerveja } from "./retorno-listar-cerveja";
import { Cerveja } from "./cerveja";
import { Retorno } from "./retorno";

@Injectable()
export class CervejaService {

  constructor(private http: HttpClient) { }

  protected url: string = "https://localhost:44314/";

  listarCervejas(nome: string, ingredientes: string, teorAlcoolico: string,
    temperatura: string, cor: string): Observable<RetornoListarCerveja> {
    return this.http.get<RetornoListarCerveja>(this.url + "cerveja/listar", {
      params: {
        nome,
        ingredientes,
        teorAlcoolico,
        temperatura,
        cor
      }
    });
  }

  consultarCerveja(id: string): Observable<object> {
    return this.http.get<Cerveja>(this.url + "cerveja/" + id);
  }

  excluirCerveja(id: string): Observable<Retorno> {
    return this.http.post<Retorno>(
      this.url + "cerveja/excluir",
      {
        "id": id
      }
    );
  }

  cadastrarCerveja(nome: string, descricao: string, harmonizacao: string,
    cor: string, categoria: string, teorAlcoolico: number, ingredientes: string,
    temperaturaInicial: number, temperaturaFinal: number, imagem: string): Observable<Retorno> {

    return this.http.post<Retorno>(
      this.url + "cerveja/incluir",
      {
        "nome": nome,
        "descricao": descricao,
        "harmonizacao": harmonizacao,
        "cor": cor,
        "categoria": categoria,
        "teorAlcoolico": teorAlcoolico,
        "ingredientes": ingredientes,
        "temperaturaInicial": temperaturaInicial,
        "temperaturaFinal": temperaturaFinal,
        "imagem": imagem
      }
    );
  }

  uploadIMagem(imagem: File): Observable<Retorno> {

    const formData: FormData = new FormData();
    formData.append(imagem.name, imagem);

    return this.http.post<Retorno>(
      this.url + "file/upload", formData
    )
  }

  editarCerveja(id: string, nome: string, descricao: string, harmonizacao: string,
    cor: string, categoria: string, teorAlcoolico: number, ingredientes: string,
    temperaturaInicial: number, temperaturaFinal: number): Observable<Retorno> {

    return this.http.post<Retorno>(
      this.url + "cerveja/editar",
      {
        "id": id,
        "nome": nome,
        "descricao": descricao,
        "harmonizacao": harmonizacao,
        "cor": cor,
        "categoria": categoria,
        "teorAlcoolico": teorAlcoolico,
        "ingredientes": ingredientes,
        "temperaturaInicial": temperaturaInicial,
        "temperaturaFinal": temperaturaFinal
      }
    );
  }
}
