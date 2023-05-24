using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PI_PorrtabilidadeWebOkPrrojetos.Models;

public partial class OkprojetosContext : DbContext
{
    public OkprojetosContext()
    {
    }

    public OkprojetosContext(DbContextOptions<OkprojetosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<ItnServRec> ItnServRecs { get; set; }

    public virtual DbSet<OrdRecebimento> OrdRecebimentos { get; set; }

    public virtual DbSet<OrdServico> OrdServicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=okprojetos;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ItnServRec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Itn_Serv__3214EC07E24937C4");

            entity.ToTable("Itn_Serv_Rec");

            entity.Property(e => e.DataDeCriacao)
                .HasColumnType("datetime")
                .HasColumnName("data_de_criacao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdOrdRec).HasColumnName("id_OrdRec");
            entity.Property(e => e.IdOrdServ).HasColumnName("id_OrdServ");
            entity.Property(e => e.UltimaModificacao)
                .HasColumnType("datetime")
                .HasColumnName("ultima_modificacao");
            entity.Property(e => e.Valor)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdOrdRecNavigation).WithMany(p => p.ItnServRecs)
                .HasForeignKey(d => d.IdOrdRec)
                .HasConstraintName("FK_OrdRec");

            entity.HasOne(d => d.IdOrdServNavigation).WithMany(p => p.ItnServRecs)
                .HasForeignKey(d => d.IdOrdServ)
                .HasConstraintName("FK_OrdServ");
        });

        modelBuilder.Entity<OrdRecebimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ord_Rece__3214EC07083AF7C2");

            entity.ToTable("Ord_Recebimento");

            entity.Property(e => e.DataDeCriacao)
                .HasColumnType("datetime")
                .HasColumnName("data_de_criacao");
            entity.Property(e => e.DataDeRecebimento)
                .HasColumnType("datetime")
                .HasColumnName("data_de_recebimento");
            entity.Property(e => e.NumeroNf)
                .HasMaxLength(45)
                .IsFixedLength()
                .HasColumnName("numero_Nf");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.UltimaModificacao)
                .HasColumnType("datetime")
                .HasColumnName("ultima_modificacao");
        });

        modelBuilder.Entity<OrdServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ord_Serv__3214EC07A6E76C4B");

            entity.ToTable("Ord_Servicos");

            entity.Property(e => e.DataDeCriacao)
                .HasColumnType("datetime")
                .HasColumnName("data_de_criacao");
            entity.Property(e => e.DescricaoPo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descricao_PO");
            entity.Property(e => e.FaseAtual)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("fase_atual");
            entity.Property(e => e.NomeOperadora)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nome_operadora");
            entity.Property(e => e.NumeroPo)
                .HasMaxLength(45)
                .IsFixedLength()
                .HasColumnName("numero_PO");
            entity.Property(e => e.UltimaModificacao)
                .HasColumnType("datetime")
                .HasColumnName("ultima_modificacao");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
