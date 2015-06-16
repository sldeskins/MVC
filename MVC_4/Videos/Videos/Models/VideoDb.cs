using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;


namespace Videos.Models
{
    public class VideoDb : DbContext
    {
        public VideoDb ()
            : base("DefaultConnection")
        {
            //Debug.Write(" >>myhere " + Database.Connection.ConnectionString);
        }
        public DbSet<Video> Videos
        {
            get;
            set;
        }

    }
}