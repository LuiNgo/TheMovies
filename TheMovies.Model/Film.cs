namespace TheMovies.Model
{
    public enum Genre
    {
        Action,
        Adventure,
        Comedy,
        Drama,
        Fantasy,
        Horror,
        Mystery,
        Krimi,
        Romance,
        ScienceFiction,
        Thriller,
        Western,
        War,
        Musical
    }

    public class Film
    {
        public string Title { get; set; }
        public int Duration { get; set; }   // minutter
        public Genre Genre { get; set; }
        public override string ToString() => $"{Title} ({Duration} min, {Genre})";
    }
}
