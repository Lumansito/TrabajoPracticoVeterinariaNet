using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Models;

namespace Models.Data;

public partial class VeterinariaContext : DbContext
{
    public VeterinariaContext()
    {
    }

    public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atencion> Atencion { get; set; }

    public virtual DbSet<AtencionesServicios> AtencionesServicios { get; set; }

    public virtual DbSet<ClienteMembresia> ClienteMembresia { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Especialidades> Especialidades { get; set; }

    public virtual DbSet<Especies> Especies { get; set; }

    public virtual DbSet<Jornada> Jornada { get; set; }

    public virtual DbSet<Mascotas> Mascotas { get; set; }

    public virtual DbSet<Membresia> Membresia { get; set; }

    public virtual DbSet<PrecioMembresia> PrecioMembresia { get; set; }

    public virtual DbSet<PrecioServicio> PrecioServicio { get; set; }

    public virtual DbSet<Raza> Raza { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("VeterinariaConnection"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atencion>(entity =>
        {
            entity.HasKey(e => e.IdAtencion).HasName("PK__ATENCION__E6F7276E87D2BD6D");

            entity.ToTable("ATENCION");

            entity.HasIndex(e => new { e.FechaHoraAtencion, e.DniCliente, e.NroMascota }, "UQ__ATENCION__C85563498B18CCBB").IsUnique();

            entity.Property(e => e.IdAtencion).HasColumnName("idAtencion");
            entity.Property(e => e.DniCliente).HasColumnName("dniCliente");
            entity.Property(e => e.DniProfesional).HasColumnName("dniProfesional");
            entity.Property(e => e.FechaHoraAtencion)
                .HasColumnType("datetime")
                .HasColumnName("fechaHoraAtencion");
            entity.Property(e => e.FechaHoraPago)
                .HasColumnType("datetime")
                .HasColumnName("fechaHoraPago");
            entity.Property(e => e.MontoApagar)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("montoAPagar");
            entity.Property(e => e.MotivoAtencion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivoAtencion");
            entity.Property(e => e.NroMascota).HasColumnName("nroMascota");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");

            entity.HasOne(d => d.DniProfesionalNavigation).WithMany(p => p.Atencion)
                .HasForeignKey(d => d.DniProfesional)
                .HasConstraintName("FK__ATENCION__dniPro__4E88ABD4");

            entity.HasOne(d => d.Mascotas).WithMany(p => p.Atencion)
                .HasForeignKey(d => new { d.DniCliente, d.NroMascota })
                .HasConstraintName("FK__ATENCION__4F7CD00D");
        });

        modelBuilder.Entity<AtencionesServicios>(entity =>
        {
            entity.HasKey(e => e.IdAtencion).HasName("PK__ATENCION__E6F7276E8F8C23A0");

            entity.ToTable("ATENCIONES_SERVICIOS");

            entity.Property(e => e.IdAtencion)
                .ValueGeneratedNever()
                .HasColumnName("idAtencion");
            entity.Property(e => e.CodServicio).HasColumnName("codServicio");

            entity.HasOne(d => d.CodServicioNavigation).WithMany(p => p.AtencionesServicios)
                .HasForeignKey(d => d.CodServicio)
                .HasConstraintName("FK__ATENCIONE__codSe__571DF1D5");

            entity.HasOne(d => d.IdAtencionNavigation).WithOne(p => p.AtencionesServicios)
                .HasForeignKey<AtencionesServicios>(d => d.IdAtencion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ATENCIONE__idAte__5812160E");
        });

        modelBuilder.Entity<ClienteMembresia>(entity =>
        {
            entity.HasKey(e => new { e.CodMembresia, e.DniCliente }).HasName("PK__CLIENTE___ACD63D0F2E14D05C");

            entity.ToTable("CLIENTE_MEMBRESIA");

            entity.Property(e => e.CodMembresia).HasColumnName("codMembresia");
            entity.Property(e => e.DniCliente).HasColumnName("dniCliente");
            entity.Property(e => e.FechaDesde).HasColumnName("fechaDesde");

            entity.HasOne(d => d.CodMembresiaNavigation).WithMany(p => p.ClienteMembresia)
                .HasForeignKey(d => d.CodMembresia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CLIENTE_M__codMe__403A8C7D");

            entity.HasOne(d => d.DniClienteNavigation).WithMany(p => p.ClienteMembresia)
                .HasForeignKey(d => d.DniCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CLIENTE_M__dniCl__412EB0B6");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.DniCliente).HasName("PK__CLIENTES__4975A8B87D4569DA");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.DniCliente)
                .ValueGeneratedNever()
                .HasColumnName("dniCliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.FechaAlta).HasColumnName("fechaAlta");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Especialidades>(entity =>
        {
            entity.HasKey(e => e.CodEspecialidad).HasName("PK__ESPECIAL__7424CD5977839C51");

            entity.ToTable("ESPECIALIDADES");

            entity.Property(e => e.CodEspecialidad).HasColumnName("codEspecialidad");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasMany(d => d.DniProfesional).WithMany(p => p.CodEspecialidad)
                .UsingEntity<Dictionary<string, object>>(
                    "ProfesionalesEspecialidades",
                    r => r.HasOne<Usuarios>().WithMany()
                        .HasForeignKey("DniProfesional")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PROFESION__dniPr__5DCAEF64"),
                    l => l.HasOne<Especialidades>().WithMany()
                        .HasForeignKey("CodEspecialidad")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PROFESION__codEs__5CD6CB2B"),
                    j =>
                    {
                        j.HasKey("CodEspecialidad", "DniProfesional").HasName("PK__PROFESIO__2B6E55E378F77055");
                        j.ToTable("PROFESIONALES_ESPECIALIDADES");
                        j.IndexerProperty<int>("CodEspecialidad").HasColumnName("codEspecialidad");
                        j.IndexerProperty<int>("DniProfesional").HasColumnName("dniProfesional");
                    });
        });

        modelBuilder.Entity<Especies>(entity =>
        {
            entity.HasKey(e => e.CodEspecie).HasName("PK__ESPECIES__055270E17C81DF89");

            entity.ToTable("ESPECIES");

            entity.Property(e => e.CodEspecie).HasColumnName("codEspecie");
            entity.Property(e => e.NombreEspecie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreEspecie");
        });

        modelBuilder.Entity<Jornada>(entity =>
        {
            entity.HasKey(e => new { e.NombreDia, e.HoraInicioJornada }).HasName("PK__JORNADA__832F43F75A5DD4E4");

            entity.ToTable("JORNADA");

            entity.Property(e => e.NombreDia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nombreDia");
            entity.Property(e => e.HoraInicioJornada).HasColumnName("horaInicioJornada");
            entity.Property(e => e.HoraFinJornada).HasColumnName("horaFinJornada");

            entity.HasMany(d => d.DniProfesional).WithMany(p => p.Jornada)
                .UsingEntity<Dictionary<string, object>>(
                    "ProfesionalesJornada",
                    r => r.HasOne<Usuarios>().WithMany()
                        .HasForeignKey("DniProfesional")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PROFESION__dniPr__6754599E"),
                    l => l.HasOne<Jornada>().WithMany()
                        .HasForeignKey("NombreDia", "HoraInicioJornada")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PROFESIONALES_JO__66603565"),
                    j =>
                    {
                        j.HasKey("NombreDia", "HoraInicioJornada", "DniProfesional").HasName("PK__PROFESIO__26DBEA7C0DF4FDE6");
                        j.ToTable("PROFESIONALES_JORNADA");
                        j.IndexerProperty<string>("NombreDia")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("nombreDia");
                        j.IndexerProperty<TimeOnly>("HoraInicioJornada").HasColumnName("horaInicioJornada");
                        j.IndexerProperty<int>("DniProfesional").HasColumnName("dniProfesional");
                    });
        });

        modelBuilder.Entity<Mascotas>(entity =>
        {
            entity.HasKey(e => new { e.DniCliente, e.NroMascota }).HasName("PK__MASCOTAS__303165D208B4A29A");

            entity.ToTable("MASCOTAS", tb => tb.HasTrigger("trg_AutoIncrementNroMascota"));

            entity.Property(e => e.DniCliente).HasColumnName("dniCliente");
            entity.Property(e => e.NroMascota).HasColumnName("nroMascota");
            entity.Property(e => e.CodEspecie).HasColumnName("codEspecie");
            entity.Property(e => e.CodRaza).HasColumnName("codRaza");
            entity.Property(e => e.FechaDefuncion).HasColumnName("fechaDefuncion");
            entity.Property(e => e.FechaNac).HasColumnName("fechaNac");
            entity.Property(e => e.NombreMascota)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreMascota");

            entity.HasOne(d => d.CodEspecieNavigation).WithMany(p => p.Mascotas)
                .HasForeignKey(d => d.CodEspecie)
                .HasConstraintName("FK__MASCOTAS__codEsp__49C3F6B7");

            entity.HasOne(d => d.CodRazaNavigation).WithMany(p => p.Mascotas)
                .HasForeignKey(d => d.CodRaza)
                .HasConstraintName("FK__MASCOTAS__codRaz__48CFD27E");

            entity.HasOne(d => d.DniClienteNavigation).WithMany(p => p.Mascotas)
                .HasForeignKey(d => d.DniCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MASCOTAS__dniCli__47DBAE45");
        });

        modelBuilder.Entity<Membresia>(entity =>
        {
            entity.HasKey(e => e.CodMembresia).HasName("PK__MEMBRESI__38416784D1D068B1");

            entity.ToTable("MEMBRESIA");

            entity.Property(e => e.CodMembresia).HasColumnName("codMembresia");
            entity.Property(e => e.AntiguedadMinimaCliente).HasColumnName("antiguedadMinimaCliente");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<PrecioMembresia>(entity =>
        {
            entity.HasKey(e => new { e.CodMembresia, e.FechaVigencia }).HasName("PK__PRECIO_M__4B55AB1CD8CB7C88");

            entity.ToTable("PRECIO_MEMBRESIA");

            entity.Property(e => e.CodMembresia).HasColumnName("codMembresia");
            entity.Property(e => e.FechaVigencia).HasColumnName("fechaVigencia");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.CodMembresiaNavigation).WithMany(p => p.PrecioMembresia)
                .HasForeignKey(d => d.CodMembresia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRECIO_ME__codMe__3D5E1FD2");
        });

        modelBuilder.Entity<PrecioServicio>(entity =>
        {
            entity.HasKey(e => new { e.CodServicio, e.FechaDesde }).HasName("PK__PRECIO_S__66868616DDE5FA47");

            entity.ToTable("PRECIO_SERVICIO");

            entity.Property(e => e.CodServicio).HasColumnName("codServicio");
            entity.Property(e => e.FechaDesde).HasColumnName("fechaDesde");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.CodServicioNavigation).WithMany(p => p.PrecioServicio)
                .HasForeignKey(d => d.CodServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRECIO_SE__codSe__5441852A");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.CodRaza).HasName("PK__RAZA__DF3302B0B90144C2");

            entity.ToTable("RAZA");

            entity.Property(e => e.CodRaza).HasColumnName("codRaza");
            entity.Property(e => e.NombreRaza)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRaza");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.CodServicio).HasName("PK__SERVICIO__709FC95B3A6E5155");

            entity.ToTable("SERVICIOS");

            entity.Property(e => e.CodServicio).HasColumnName("codServicio");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasMany(d => d.CodEspecialidad).WithMany(p => p.CodServicio)
                .UsingEntity<Dictionary<string, object>>(
                    "EspecialidadesServicios",
                    r => r.HasOne<Especialidades>().WithMany()
                        .HasForeignKey("CodEspecialidad")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ESPECIALI__codEs__619B8048"),
                    l => l.HasOne<Servicios>().WithMany()
                        .HasForeignKey("CodServicio")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ESPECIALI__codSe__60A75C0F"),
                    j =>
                    {
                        j.HasKey("CodServicio", "CodEspecialidad").HasName("PK__ESPECIAL__F7DD858E67B46088");
                        j.ToTable("ESPECIALIDADES_SERVICIOS");
                        j.IndexerProperty<int>("CodServicio").HasColumnName("codServicio");
                        j.IndexerProperty<int>("CodEspecialidad").HasColumnName("codEspecialidad");
                    });
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Dni).HasName("PK__USUARIOS__D87608A6B6A0F8DF");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Dni)
                .ValueGeneratedNever()
                .HasColumnName("dni");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.FechaAlta).HasColumnName("fechaAlta");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
