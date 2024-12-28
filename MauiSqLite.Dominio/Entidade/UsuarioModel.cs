namespace MauiSqLite.Dominio.Entidade
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;

        public UsuarioModel Incluir(string nome, string email, string telefone, DateTime dataNascimento, DateTime dataCadastro, bool ativo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            Ativo = ativo;

            return this;
        }
    }
}