using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Videos.Models
{
   // [Table("Video")]  //System.ComponentModel.DataAnnotations.Schema;
    public class Video
    {
        //[Key]//using System.ComponentModel.DataAnnotations;
        public  int Id
        {
            get;
            set;
        }
        public virtual string Title
        {
            get;
            set;
        }
        public virtual int Length
        {
            get;
            set;
        }
    }
}