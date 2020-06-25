import { Cerveja } from "./cerveja";
import { Errors } from "./errors";

export class RetornoConsultarCerveja {
  success: boolean;
  cerveja: Cerveja;
  errors: Errors;
}
