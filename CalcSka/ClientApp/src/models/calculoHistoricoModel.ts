import BaseModel from "./baseModel";
import Operacoes from "./enum/Operacoes";

export default class CalculoHistoricoModel extends BaseModel {
  valorPrimario: number = null;
  operacao: Operacoes = null;
  operacaoString: string = null;
  valorSecundario: number = null;
  resultado?: number = null;
  usuario: string = null;
  calculo: string = null;
};
