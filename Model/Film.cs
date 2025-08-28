namespace TheMoviesProject.MVVM.Model
{
    // Repræsenterer en film
    public class Film
    {
        public string Title { get; set; }
        public int Duration { get; set; } // i minutter
        public Genre Genre { get; set; }

        public override string ToString() => $"{Title} ({Duration} min) - {Genre}";
    }
}
