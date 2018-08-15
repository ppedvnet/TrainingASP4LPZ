namespace Snacklager.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Security.Principal;

    public partial class SnacklagerDB : DbContext
    {
        public SnacklagerDB(string connecitonString) : base(connecitonString)
        {

        }

        //public SnacklagerDB()
        //    : base("name=SnacklagerDBModel")
        //{
        //}

        public virtual DbSet<Lager> Lager { get; set; }
        public virtual DbSet<Lagerhaltung> Lagerhaltung { get; set; }
        public virtual DbSet<Snack> Snack { get; set; }
        public virtual DbSet<SnackArt> SnackArt { get; set; }
        public virtual DbSet<Zutaten> Zutaten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lager>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Lagerhaltung>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Snack>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Zutaten>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries<Entity>().Where(x => x.State == EntityState.Modified))
            {
                item.Entity.Modified = DateTime.Now;
                item.Entity.ModifiedBy = WindowsIdentity.GetCurrent().Name;
            }

            foreach (var item in ChangeTracker.Entries<Entity>().Where(x => x.State == EntityState.Added))
            {
                item.Entity.Modified = DateTime.Now;
                item.Entity.Added = item.Entity.Modified.Value;
                item.Entity.ModifiedBy = WindowsIdentity.GetCurrent().Name;
            }

            return base.SaveChanges();
        }
    }
}
