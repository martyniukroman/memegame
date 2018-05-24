namespace DAL
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;


    public class MemeContext : DbContext
    {
        
        public MemeContext()
            : base("name=MemeDb")
        {
        }
         public virtual DbSet<Meme> Memes { get; set; }
    }


}