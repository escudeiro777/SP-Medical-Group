using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SENAI_SP_Medical_Group.Domains;

#nullable disable

namespace SENAI_SP_Medical_Group.Contexts
{
    public partial class SpMedicalGroupContext : DbContext
    {
        public SpMedicalGroupContext()
        {
        }

        public SpMedicalGroupContext(DbContextOptions<SpMedicalGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especializacao> Especializacaos { get; set; }
        public virtual DbSet<ImagemUsuario> ImagemUsuarios { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<SituacaoConsultum> SituacaoConsulta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               optionsBuilder.UseSqlServer("Data Source=NOTE0113D1\\SQLEXPRESS; initial catalog=MEDICALGROUP_SP; user Id=sa; pwd=Senai@132;");
                //optionsBuilder.UseSqlServer("Data Source=NOTE0113D1\\SQLEXPRESS; initial catalog=MEDICALGROUP_SP; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__clinica__C73A6055F3585517");

                entity.ToTable("clinica");

                entity.HasIndex(e => e.Cnpj, "UQ__clinica__35BD3E48F219D669")
                    .IsUnique();

                entity.HasIndex(e => e.EndClinica, "UQ__clinica__46E251D06301317F")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__clinica__9BF93A30FE6579FB")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.EndClinica)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endClinica");

                entity.Property(e => e.HoraAberto).HasColumnName("horaAberto");

                entity.Property(e => e.HoraFechado).HasColumnName("horaFechado");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__consulta__CA9C61F54388A109");

                entity.ToTable("consulta");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("datetime")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.IdSituacaoConsulta).HasColumnName("idSituacaoConsulta");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__consulta__idMedi__51300E55");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__consulta__idPaci__503BEA1C");

                entity.HasOne(d => d.IdSituacaoConsultaNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacaoConsulta)
                    .HasConstraintName("FK__consulta__idSitu__5224328E");
            });

            modelBuilder.Entity<Especializacao>(entity =>
            {
                entity.HasKey(e => e.IdEspecializacao)
                    .HasName("PK__especial__FC35476CBC68F4F8");

                entity.ToTable("especializacao");

                entity.HasIndex(e => e.NomeEspecializacao, "UQ__especial__72E3A010390CE7D8")
                    .IsUnique();

                entity.Property(e => e.IdEspecializacao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEspecializacao");

                entity.Property(e => e.NomeEspecializacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeEspecializacao");
            });

            modelBuilder.Entity<ImagemUsuario>(entity =>
            {
                entity.HasKey(e => e.IdImagem)
                    .HasName("PK__imagemUs__EA9A7137283D970B");

                entity.ToTable("imagemUsuario");

                entity.HasIndex(e => e.IdUsuario, "UQ__imagemUs__645723A7F91871C5")
                    .IsUnique();

                entity.Property(e => e.IdImagem).HasColumnName("idImagem");

                entity.Property(e => e.Binario)
                    .IsRequired()
                    .HasColumnName("binario");

                entity.Property(e => e.DataInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("data_inclusao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.ImagemUsuario)
                    .HasForeignKey<ImagemUsuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__imagemUsu__idUsu__55F4C372");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__medico__4E03DEBA29242010");

                entity.ToTable("medico");

                entity.HasIndex(e => e.Crm, "UQ__medico__D836F7D173A6A471")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("crm");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecializacao).HasColumnName("idEspecializacao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeMedico");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__medico__idClinic__46B27FE2");

                entity.HasOne(d => d.IdEspecializacaoNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecializacao)
                    .HasConstraintName("FK__medico__idEspeci__47A6A41B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__medico__idUsuari__45BE5BA9");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__paciente__F48A08F273E7CFEB");

                entity.ToTable("paciente");

                entity.HasIndex(e => e.Telefone, "UQ__paciente__2A16D97F3EA7EBB3")
                    .IsUnique();

                entity.HasIndex(e => e.Rg, "UQ__paciente__32143310ABBC9403")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__paciente__D836E71F49B68AE3")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataNasc)
                    .HasColumnType("date")
                    .HasColumnName("dataNasc");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nomePaciente");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("rg");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__paciente__idUsua__4D5F7D71");
            });

            modelBuilder.Entity<SituacaoConsultum>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoConsulta)
                    .HasName("PK__situacao__7E8503D1832790A8");

                entity.ToTable("situacaoConsulta");

                entity.Property(e => e.IdSituacaoConsulta)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacaoConsulta");

                entity.Property(e => e.SituacaoConsulta)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("situacaoConsulta");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF39E2BB8D");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9F045CC7C6")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6025F092C");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61645D9DAF53")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__395884C4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
