import { ResultListarCerveja } from "./result-listar-cerveja";
import { Errors } from "./errors";

export class RetornoListarCerveja {
  success: boolean;
  result: ResultListarCerveja;
  errors: Errors;
}
