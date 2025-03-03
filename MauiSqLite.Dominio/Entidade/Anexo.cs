﻿using SQLite;

namespace MauiSqLite.Dominio.Entidade
{
    public class Anexo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Arquivo { get; set; }
        public int Id_Tarefa { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}