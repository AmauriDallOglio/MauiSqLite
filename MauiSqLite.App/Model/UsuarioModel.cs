namespace MauiSqLite.App.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now; // Define a data atual por padrão
        public bool Ativo { get; set; } = true; // Define como ativo por padrão
    }
}
