using System.Data.Entity;

namespace WordsISay_v1.Models
{
    public class WordsISay_v1_Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<WordsISay_v1.Models.WordsISay_v1_Context>());

        public WordsISay_v1_Context() : base("name=WordsISay_v1_Context")
        {
        }

        public DbSet<Story> Stories { get; set; }
    }
}
