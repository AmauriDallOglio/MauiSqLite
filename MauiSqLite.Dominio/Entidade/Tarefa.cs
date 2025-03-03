﻿using MauiSqLite.Dominio.Enum;

namespace MauiSqLite.Dominio.Entidade
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int? Id_Usuario { get; set; }
        public Status? Status { get; set; }

        public Tarefa()
        {
            AdicionaDataCriacao();
        }

        public Tarefa DadosIncluir(string titulo, string descricao, Status status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            AdicionaDataCriacao();
            return this;
        }

        public void AdicionaDataCriacao()
        {
            this.DataCriacao = DateTime.Now;
        }


        public void AdicionaDataAlteracao()
        {
            this.DataAtualizacao = DateTime.Now;
        }
    }
}
