using DIO.Series;
using DIO.Series.Classes;
using System;

/*
Classe que herdeira da classe "EntidadeBase";
A classe "SerieRepositorio" implementa uma Interface (IRepositorio) do tipo Série (classe base);
É o repositorio do nosso código
*/
namespace Dio.Series
{
    public class Serie: EntidadeBase //Instancia da class EntidadeBase
    {
        //Atributos

        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido{get; set;}

        //Metodo Construtor
        public Serie (int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        //Metodos

        //Subscrever o metodo ToString: ao executar o Writline, ele vai subscrever o metodo ToString 
        public override string ToString()
        {
            //Enviroment.NewLine: cria uma nova linha; Depende do sistema operativo
            string retorno = "";
            retorno+= "Género :" + this.Genero + Environment.NewLine;
            retorno+= "Título: " + this.Titulo + Environment.NewLine;
            retorno+= "Descrição: " + this.Descricao + Environment.NewLine;
            retorno+= "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno+= "Excluido: " + this.Excluido + Environment.NewLine;
            return retorno;
        }

        //Metodo que retorna o titulo: vamos usar quando estivermos a fazer a listagem das séries;
        //Criamos para evitar trabalhar com os atributos de forma direita
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaexcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}