namespace MedicoPlus.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MySQL : DbContext
    {
        public MySQL()
            : base("name=MySQL")
        {
        }

        public virtual DbSet<areas> areas { get; set; }
        public virtual DbSet<cities> cities { get; set; }
        public virtual DbSet<departaments> departaments { get; set; }
        public virtual DbSet<documents> documents { get; set; }
        public virtual DbSet<hospitals> hospitals { get; set; }
        public virtual DbSet<mkh> mkh { get; set; }
        public virtual DbSet<online> online { get; set; }
        public virtual DbSet<patients> patients { get; set; }
        public virtual DbSet<personal> personal { get; set; }
        public virtual DbSet<regions> regions { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<areas>()
                .Property(e => e.area)
                .IsUnicode(false);

            modelBuilder.Entity<areas>()
                .HasMany(e => e.personal)
                .WithRequired(e => e.areas)
                .HasForeignKey(e => e.area_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<areas>()
                .HasMany(e => e.patients)
                .WithRequired(e => e.areas)
                .HasForeignKey(e => e.area_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<areas>()
                .HasMany(e => e.hospitals)
                .WithOptional(e => e.areas)
                .HasForeignKey(e => e.area_id);

            modelBuilder.Entity<cities>()
                .Property(e => e.village)
                .IsUnicode(false);

            modelBuilder.Entity<cities>()
                .HasMany(e => e.patients)
                .WithRequired(e => e.cities)
                .HasForeignKey(e => e.city_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cities>()
                .HasMany(e => e.hospitals)
                .WithOptional(e => e.cities)
                .HasForeignKey(e => e.city_id);

            modelBuilder.Entity<cities>()
                .HasMany(e => e.personal)
                .WithRequired(e => e.cities)
                .HasForeignKey(e => e.city_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<departaments>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<departaments>()
                .HasMany(e => e.patients)
                .WithRequired(e => e.departaments)
                .HasForeignKey(e => e.dep_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<documents>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<documents>()
                .Property(e => e.formname)
                .IsUnicode(false);

            modelBuilder.Entity<hospitals>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<hospitals>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<hospitals>()
                .HasMany(e => e.departaments)
                .WithOptional(e => e.hospitals)
                .HasForeignKey(e => e.hosp_id);

            modelBuilder.Entity<hospitals>()
                .HasMany(e => e.patients)
                .WithOptional(e => e.hospitals)
                .HasForeignKey(e => e.transferhosp_id);

            modelBuilder.Entity<hospitals>()
                .HasMany(e => e.personal)
                .WithRequired(e => e.hospitals)
                .HasForeignKey(e => e.hosp_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hospitals>()
                .HasMany(e => e.patients1)
                .WithRequired(e => e.hospitals1)
                .HasForeignKey(e => e.refhosp_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mkh>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<mkh>()
                .Property(e => e.codes)
                .IsUnicode(false);

            modelBuilder.Entity<patients>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<patients>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<patients>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<patients>()
                .Property(e => e.cardnumber)
                .IsUnicode(false);

            modelBuilder.Entity<patients>()
                .Property(e => e.firstdiagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<patients>()
                .Property(e => e.seconddiagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<patients>()
                .Property(e => e.reject)
                .IsUnicode(false);

            modelBuilder.Entity<patients>()
                .Property(e => e.employed)
                .IsUnicode(false);

            modelBuilder.Entity<personal>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<personal>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<personal>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<regions>()
                .Property(e => e.region)
                .IsUnicode(false);

            modelBuilder.Entity<regions>()
                .HasMany(e => e.cities)
                .WithRequired(e => e.regions)
                .HasForeignKey(e => e.region_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<regions>()
                .HasMany(e => e.hospitals)
                .WithOptional(e => e.regions)
                .HasForeignKey(e => e.region_id);

            modelBuilder.Entity<regions>()
                .HasMany(e => e.patients)
                .WithRequired(e => e.regions)
                .HasForeignKey(e => e.region_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<regions>()
                .HasMany(e => e.personal)
                .WithRequired(e => e.regions)
                .HasForeignKey(e => e.region_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.online)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.personal)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
