using System;
using System.Collections.Generic;

namespace EFCore_Ex.Models
{
    public class Musician
    {
        public int ID {get; set;}
        public string Description {get; set;}

        public ICollection<Song> Songs { get; set; }
    }
}