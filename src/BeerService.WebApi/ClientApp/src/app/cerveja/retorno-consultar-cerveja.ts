import { Cerveja } from "./cerveja";
import { Errors } from "./errors";

export class RetornoConsultarCerveja {
  success: boolean;
  result: Cerveja;
  errors: Errors;
}
