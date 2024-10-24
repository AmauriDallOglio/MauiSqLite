namespace MauiSqLite.App.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now; // Define a data atual por padrão
        public bool Ativo { get; set; } = true; // Define como ativo por padrão

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
