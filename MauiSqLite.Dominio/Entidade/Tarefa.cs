using MauiSqLite.Dominio.Enum;
using SQLite;

namespace MauiSqLite.Dominio.Entidade
{
    public class Tarefa
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int UsuarioId { get; set; }
        public Status? Status { get; set; }


        public Tarefa()
        {
            this.DataCriacao = DateTime.Now;
            this.DataAtualizacao = DateTime.Now;
        }

        //[Ignore]
        //public Usuario Usuario
        //{
        //    get
        //    {
        //        if (this.UsuarioId == 0) return null;
        //        return UsuariosServico.Instancia().Todos().Find(u => u.Id == this.UsuarioId);
        //    }
        //}

        //[Ignore]
        //public string NomeUsuario
        //{
        //    get
        //    {
        //        if (this.Usuario == null) return "Sem Usuario";
        //        return Usuario?.Nome;
        //    }
        //}
    }
}
