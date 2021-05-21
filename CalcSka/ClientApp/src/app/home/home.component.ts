import { Component, Inject } from '@angular/core';
import Operacoes from '../../models/enum/Operacoes';
import { HttpClient } from '@angular/common/http';
import CalculoHistoricoModel from '../../models/calculoHistoricoModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  http: HttpClient;
  baseUrl: string;
  public number = 0;
  public calculo: string = null;
  public resultado: string = '0';
  public operacao = null;
  public valorPrimario = null;
  public valorSecundario = null;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public async setValor(valor: number, virgula: string = null) {
    if (this.operacao == null) {
      if (this.valorPrimario > 0) {
        if (virgula == null) {
          this.valorPrimario = `${this.valorPrimario}${valor}`;
          this.resultado = this.valorPrimario;
        } else {
          if (!this.valorPrimario.toString().includes('.')) {
            this.valorPrimario = `${this.valorPrimario}${virgula}`;
            this.resultado = this.valorPrimario;
          }
        }
      } else {
        if (virgula == null) {
          if (this.valorPrimario != null && this.valorPrimario.toString().includes('.')) {
            this.valorPrimario = `${this.valorPrimario}${valor}`;
            this.resultado = this.valorPrimario;
          } else {
            this.valorPrimario = valor;
            this.resultado = this.valorPrimario;
          }
        } else {
          if (!this.valorPrimario.toString().includes('.')) {
            this.valorPrimario = `${this.valorPrimario}${virgula}`;
            this.resultado = this.valorPrimario;
          }
        }
      }
    } else {
      if (this.valorSecundario > 0) {
        if (virgula == null) {
          this.valorSecundario = `${this.valorSecundario}${valor}`;
          this.resultado = this.valorSecundario;
        } else {
          if (!this.valorSecundario.toString().includes('.')) {
            this.valorSecundario = `${this.valorSecundario}${virgula}`;
            this.resultado = this.valorSecundario;
          }
        }
      } else {
        if (virgula == null) {
          if (this.valorSecundario != null && this.valorSecundario.toString().includes('.')) {
            this.valorSecundario = `${this.valorSecundario}${valor}`;
            this.resultado = this.valorSecundario;
          } else {
            this.valorSecundario = valor;
            this.resultado = this.valorSecundario;
          }
        } else {
          if (!this.valorSecundario.toString().includes('.')) {
            this.valorSecundario = `${this.valorSecundario}${virgula}`;
            this.resultado = this.valorSecundario;
          }
        }
      }
    }
  }


  public async setOperacao(operacao: Operacoes) {
    this.operacao = operacao;
    var operacaoString;
    if (this.operacao == Operacoes.Adicao) {
      operacaoString = " + ";
    } else if (this.operacao == Operacoes.Subtracao) {
      operacaoString = " - ";
    } else if (this.operacao == Operacoes.Multiplicacao) {
      operacaoString = " x ";
    } else if (this.operacao == Operacoes.Divisao) {
      operacaoString = " ÷ ";
    }
    this.resultado = operacaoString;
  }

  public async clear() {
    this.number = 0;
    this.calculo = null;
    this.resultado = '0';
    this.operacao = null;
    this.valorPrimario = 0;
    this.valorSecundario = 0;
  }

  public async calcular() {
    var resultado = 0;
    var operacao;
    var post = new CalculoHistoricoModel();
    post.valorSecundario = Number(this.valorSecundario);
    post.valorPrimario = Number(this.valorPrimario);
    post.operacao = this.operacao;
    this.http.post<CalculoHistoricoModel>(this.baseUrl + 'save', { ...post }).subscribe(
      result => {
        resultado = Number(result.resultado);
        if (this.operacao == Operacoes.Adicao) {
          operacao = " + ";
        } else if (this.operacao == Operacoes.Subtracao) {
          operacao = " - ";
        } else if (this.operacao == Operacoes.Multiplicacao) {
          operacao = " x ";
        } else if (this.operacao == Operacoes.Divisao) {
          operacao = " ÷ ";
        }
        var resultadoString = resultado.toFixed(2).replace('.', '.').replace('.00', '');
        this.calculo = `${this.valorPrimario}${operacao}${this.valorSecundario} =`;
        this.resultado = `${resultadoString}`;
        this.valorPrimario = resultado;
        this.valorSecundario = 0;
        this.operacao = 0;

      }, error => console.error(error)

    );

  }
}

