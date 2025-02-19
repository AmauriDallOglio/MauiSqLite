using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Enum;
using MauiSqLite.Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.Infra.Contexto
{
    public class MeuContexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Anexo> Anexo { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }


        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite($"Data Source={App.AppDatabasePath}");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o mapeamento do modelo
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            modelBuilder.ApplyConfiguration(new TarefaMapeamento());
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UsuarioModel>().ToTable("Usuario");


        }

        public async Task InseriTarefasDatabaseAsync()
        {
            if (!await Tarefa.AnyAsync()) // Verifica se a tabela está vazia
            {
                DateTime agora = DateTime.UtcNow;

                var listaTarefas = new List<Tarefa>
                {
                    new() { Titulo = "Revisão de Código", Descricao = "Verificar padrões de código", Status = Status.Analise, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Testes API", Descricao = "Executar testes unitários", Status = Status.ParaFazer, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Documentação", Descricao = "Escrever documentação", Status = Status.Desenvolvimento, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Deploy", Descricao = "Publicar versão final", Status = Status.Backlog, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Bug Fix", Descricao = "Corrigir erro crítico", Status = Status.Analise, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Refatoração", Descricao = "Melhorar código legado", Status = Status.ParaFazer, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Integração", Descricao = "Configurar APIs", Status = Status.Desenvolvimento, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Revisão Final", Descricao = "Última revisão antes do deploy", Status = Status.Backlog, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Planejamento Sprint", Descricao = "Organizar backlog para próxima sprint", Status = Status.ParaFazer, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Design UI", Descricao = "Criar wireframes para novo módulo", Status = Status.Desenvolvimento, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Automação CI/CD", Descricao = "Configurar pipeline no Azure DevOps", Status = Status.Analise, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Treinamento Equipe", Descricao = "Workshop sobre Clean Code", Status = Status.Backlog, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Testes de Performance", Descricao = "Rodar testes com JMeter", Status = Status.ParaFazer, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Auditoria de Código", Descricao = "Revisar padrões de segurança", Status = Status.Analise, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Melhoria UX", Descricao = "Otimizar experiência do usuário", Status = Status.Desenvolvimento, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Configuração Servidores", Descricao = "Ajustar parâmetros de escalabilidade", Status = Status.Backlog, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Automação de Relatórios", Descricao = "Gerar PDFs automaticamente", Status = Status.ParaFazer, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Correção de Logs", Descricao = "Padronizar registros de log", Status = Status.Analise, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Dashboard Analytics", Descricao = "Criar visualizações de métricas", Status = Status.Desenvolvimento, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Homologação Cliente", Descricao = "Realizar testes de aceitação", Status = Status.Backlog, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Backup Banco de Dados", Descricao = "Configurar backups automáticos", Status = Status.ParaFazer, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Documentação Técnica", Descricao = "Atualizar Wiki da equipe", Status = Status.Analise, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Refatoração de Queries", Descricao = "Otimizar SQL para melhorar desempenho", Status = Status.Desenvolvimento, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Validação de Segurança", Descricao = "Testes de penetração na aplicação", Status = Status.Backlog, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Automação de Testes", Descricao = "Escrever testes automatizados", Status = Status.ParaFazer, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Monitoramento de Erros", Descricao = "Configurar Sentry para logs", Status = Status.Analise, DataCriacao = agora, DataAtualizacao = agora },
                    new() { Titulo = "Aprimoramento API", Descricao = "Melhorar estrutura RESTful", Status = Status.Desenvolvimento, DataCriacao = agora, DataAtualizacao = agora }
                };

                await Tarefa.AddRangeAsync(listaTarefas);
                await SaveChangesAsync();
            }
        }

    }
}
