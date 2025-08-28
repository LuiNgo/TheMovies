using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TheMoviesProject.MVVM.Model
{
    // Gemmer film til fil og holder fælles ObservableCollection
    public class FileFilmRepository : IFilmRepository
    {
        private readonly string filePath;
        private readonly List<Film> films = new();

        public FileFilmRepository(string path = "films.json")
        {
            filePath = Path.IsPathRooted(path)
                ? path
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            LoadFilms();
        }

        private void LoadFilms()
        {
            if (!File.Exists(filePath)) return;

            var options = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
            var json = File.ReadAllText(filePath);
            var loaded = JsonSerializer.Deserialize<List<Film>>(json, options);
            if (loaded != null) films.AddRange(loaded);
        }

        public void AddFilm(Film film)
        {
            if (film == null) throw new ArgumentNullException(nameof(film));
            films.Add(film);
        }

        public void SaveFilms()
        {
            var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } };
            var json = JsonSerializer.Serialize(films, options);
            File.WriteAllText(filePath, json);
        }

        public List<Film> GetAllFilms() => films.ToList();

        // Fælles ObservableCollection for binding
        public static ObservableCollection<Film> Films { get; } = new ObservableCollection<Film>();
    }
}
