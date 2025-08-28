using System.Collections.Generic;

namespace TheMoviesProject.MVVM.Model
{
    // Interface til film-repository
    public interface IFilmRepository
    {
        void AddFilm(Film film);
        void SaveFilms();
        List<Film> GetAllFilms();
    }
}
