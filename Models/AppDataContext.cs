using Microsoft.EntityFrameworkCore;

namespace MinimalApiProject.Models;

public class AppDataContext : DbContext{
   // Construtor que configura o contexto com as opções passadas
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        // Propriedades DbSet para manipular entidades no banco de dados
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        // Você pode adicionar mais DbSets para outras entidades aqui

        // Sobrescreva o método OnModelCreating se você precisar de configurações personalizadas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Exemplo de configuração de modelo: especificando regras de chave estrangeira, índices, etc.
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Pagamentos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId);

            // Configurações adicionais podem ser feitas conforme necessário
        }
}