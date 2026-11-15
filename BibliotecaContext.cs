using Microsoft.EntityFrameworkCore;


namespace MyEstudos
{
    public class BibliotecaContext : DbContext
    {
        // Nome da variável de ambiente que guarda a connection string (assim a senha não fica no código)
        private const string VariavelConexao = "BIBLIOTECA_CONNECTION";

        //Mapeia a tabela no banco de dados
        public DbSet<Livro> Livros { get; set; }

        // Define qual banco utilizar: agora MySQL 🔌
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = Environment.GetEnvironmentVariable(VariavelConexao);

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"Defina a variável de ambiente {VariavelConexao}. " +
                    "Exemplo: Server=localhost;Port=3306;Database=biblioteca;User=root;Password=SUA_SENHA;");
            }

            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroFisico>();
            modelBuilder.Entity<Ebook>();
        }
    }
}
