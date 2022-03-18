using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APIW.Models
{
    public partial class PRUEBA1Context : DbContext
    {
        public PRUEBA1Context()
        {
        }

        public PRUEBA1Context(DbContextOptions<PRUEBA1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<HorasExtra> HorasExtra { get; set; }
        public virtual DbSet<InfoContactoUsuario> InfoContactoUsuario { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolContacto> RolContacto { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AMG;Database=PRUEBA1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__departam__64F37A16C5E08E7C");

                entity.ToTable("departamento");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.DescripcionDepartamento)
                    .IsRequired()
                    .HasColumnName("descripcion_departamento")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__estado__86989FB27DA48DA9");

                entity.ToTable("estado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.DescripcionEstado)
                    .IsRequired()
                    .HasColumnName("descripcion_estado")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HorasExtra>(entity =>
            {
                entity.HasKey(e => e.IdHE)
                    .HasName("PK__horas_ex__D6EA305E537A18BF");

                entity.ToTable("horas_extra");

                entity.Property(e => e.IdHE).HasColumnName("id_h_e");

                entity.Property(e => e.Dia)
                    .HasColumnName("dia")
                    .HasColumnType("date");

                entity.Property(e => e.HoraFin).HasColumnName("hora_fin");

                entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.HorasExtra)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__horas_ext__id_us__47DBAE45");
            });

            modelBuilder.Entity<InfoContactoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdInfo)
                    .HasName("PK__infoCont__86741B5C60B64DB0");

                entity.ToTable("infoContactoUsuario");

                entity.Property(e => e.IdInfo).HasColumnName("id_info");

                entity.Property(e => e.IdRolCont).HasColumnName("id_rol_cont");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NombreCompletoContacto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoContacto).HasColumnName("telefono_contacto");

                entity.HasOne(d => d.IdRolContNavigation)
                    .WithMany(p => p.InfoContactoUsuario)
                    .HasForeignKey(d => d.IdRolCont)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__infoConta__id_ro__3F466844");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.InfoContactoUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__infoConta__id_us__403A8C7D");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.IdJob)
                    .HasName("PK__job__D366B1F7D3A9C953");

                entity.ToTable("job");

                entity.Property(e => e.IdJob).HasColumnName("id_job");

                entity.Property(e => e.DescripcionJob)
                    .IsRequired()
                    .HasColumnName("descripcion_job")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__rol__6ABCB5E0069FE974");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.DescRol)
                    .IsRequired()
                    .HasColumnName("desc_rol")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolContacto>(entity =>
            {
                entity.HasKey(e => e.IdRolCont)
                    .HasName("PK__rol_cont__D114E5A031FBC82C");

                entity.ToTable("rol_contacto");

                entity.Property(e => e.IdRolCont).HasColumnName("id_rol_cont");

                entity.Property(e => e.DescRolCont)
                    .IsRequired()
                    .HasColumnName("desc_rol_cont")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("PK__solicitu__5C0C31F3566CBFBA");

                entity.ToTable("solicitud");

                entity.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");

                entity.Property(e => e.ComentarioEncargado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComentarioSolicitante)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEmicion)
                    .HasColumnName("fecha_emicion")
                    .HasColumnType("date");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__solicitud__id_es__44FF419A");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__solicitud__id_ti__440B1D61");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__solicitud__id_us__4316F928");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__tipo__CF901089BF2C8BD4");

                entity.ToTable("tipo");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.DescripcionTipo)
                    .IsRequired()
                    .HasColumnName("descripcion_tipo")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__4E3E04ADC75757C0");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Contrasenna)
                    .IsRequired()
                    .HasColumnName("contrasenna")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContrasennaUsuario)
                    .IsRequired()
                    .HasColumnName("Contrasenna_usuario")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Encargado).HasColumnName("encargado");

                entity.Property(e => e.FechaContratacion)
                    .HasColumnName("fechaContratacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdJob).HasColumnName("id_job");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombre_usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellidoUsuario)
                    .IsRequired()
                    .HasColumnName("primer_apellido_usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellidoUsuario)
                    .IsRequired()
                    .HasColumnName("segundo_apellido_usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__id_depa__3C69FB99");

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__id_job__3B75D760");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__id_rol__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
