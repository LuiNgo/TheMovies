namespace TheMovies.Model
{
    public interface IFilmRepository
    {
        void AddFilm(Film film);
        void SaveFilms();
        // (kan udvides senere, fx GetAllFilms / FindFilm)
    }
}
