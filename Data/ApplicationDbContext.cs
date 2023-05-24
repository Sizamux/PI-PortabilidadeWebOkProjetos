using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PI_PorrtabilidadeWebOkPrrojetos.Models;

namespace PI_PorrtabilidadeWebOkPrrojetos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PI_PorrtabilidadeWebOkPrrojetos.Models.ItnServRec> ItnServRec { get; set; } = default!;
        public DbSet<PI_PorrtabilidadeWebOkPrrojetos.Models.OrdServico> OrdServico { get; set; } = default!;
        public DbSet<PI_PorrtabilidadeWebOkPrrojetos.Models.OrdRecebimento> OrdRecebimento { get; set; } = default!;
    }
}