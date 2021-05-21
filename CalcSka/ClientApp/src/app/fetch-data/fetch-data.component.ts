import { Component, Inject, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import CalculoHistoricoModel from '../../models/calculoHistoricoModel';
import { error } from 'protractor';
import Operacoes from '../../models/enum/Operacoes';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements AfterViewInit {
  public historicos: CalculoHistoricoModel[];
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }
  private async load() {
    this.http.get<CalculoHistoricoModel[]>(this.baseUrl + 'historico').subscribe(
      result => {
        this.historicos = result.map(x => ({
          ...x,
          operacaoString: x.operacao == Operacoes.Adicao ? 'Adição' : x.operacao == Operacoes.Subtracao ? 'Subtração' : x.operacao == Operacoes.Multiplicacao ? 'Multiplicação' : x.operacao == Operacoes.Divisao ? 'Divisão' : ' ',
          dataCriacao: new Date(x.dataCriacao).toLocaleDateString()
        }));
      }, error => console.error(error)
    );
  }
  ngAfterViewInit() {
    this.load();
  }
}

