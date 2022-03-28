namespace EFCore_Ex.Models
{
    public class Song
    {
        public int ID {get; set;}
        public string Description {get; set;}

        public int GenreID {get; set;}
        public int MusicianID {get; set;}
    }
}