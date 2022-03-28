using System;
using System.Collections.Generic;

namespace EFCore_Ex.Models
{
    public class Genre
    {
        public int ID {get; set;}
        public string Description {get; set;}

        public ICollection<Musician> Musicians { get; set; }



    }
}