namespace AppliancesWEB
{
    using System.Data.Entity;

    public partial class  AppliancesContext: DbContext
    {
        public AppliancesContext()
            : base("name=AppliancesConnectionString")
        {
           
        }

        public virtual DbSet<AuthUsers> AuthUsers { get; set; }
        public virtual DbSet<Callback> Callback { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<DataUsers> DataUsers { get; set; }
        public virtual DbSet<Equipments> Equipments { get; set; }
        public virtual DbSet<ListSupply> ListSupply { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PayData> PayData { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthUsers>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<AuthUsers>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<AuthUsers>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<AuthUsers>()
                .HasMany(e => e.Callback)
                .WithRequired(e => e.AuthUsers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AuthUsers>()
                .HasOptional(e => e.DataUsers)
                .WithRequired(e => e.AuthUsers);

            modelBuilder.Entity<AuthUsers>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.AuthUsers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Equipments)
                .WithRequired(e => e.Categories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contracts>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.Contracts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DataUsers>()
                .HasOptional(e => e.PayData)
                .WithRequired(e => e.DataUsers);

            modelBuilder.Entity<Equipments>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Equipments>()
                .HasMany(e => e.ListSupply)
                .WithRequired(e => e.Equipments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipments>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Equipments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipments>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.Equipments)
                .HasForeignKey(e => e.idSupplyEquip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Summary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PayData>()
                .Property(e => e.NumberCard)
                .IsUnicode(false);

            modelBuilder.Entity<PayData>()
                .Property(e => e.Holder)
                .IsUnicode(false);

            modelBuilder.Entity<PayData>()
                .Property(e => e.DateEnd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PayData>()
                .Property(e => e.CVC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Statuses>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Statuses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Suppliers>()
                .HasMany(e => e.ListSupply)
                .WithRequired(e => e.Suppliers)
                .WillCascadeOnDelete(false);
        }
    }
}
