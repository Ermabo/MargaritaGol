namespace MargaritaGOL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GOLContext : DbContext
    {
        public DbSet<CellState> CellStates { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Generation> Generations { get; set; }
        
        // Your context has been configured to use a 'GOLContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MargaritaGOL.GOLContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GOLContext' 
        // connection string in the application configuration file.
        public GOLContext()
            : base("GolDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}