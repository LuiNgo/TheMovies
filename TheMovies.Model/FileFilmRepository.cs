using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TheMovies.Model
{
    public class FileFilmRepository : IFilmRepository
    {
        private readonly string filePath;
        private readonly List<Film> films = new();

        // Valgfri sti; ellers gemmes i "films.json" ved app'ens outputmappe
        public FileFilmRepository(string path = "films.json")
        {
            filePath = Path.IsPathRooted(path)
                ? path
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            LoadFilms();
        }

        public void AddFilm(Film film)
        {
            if (film == null) throw new ArgumentNullException(nameof(film));
            films.Add(film);
        }

        public void SaveFilms()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() } // gem enum som tekst
            };

            var json = JsonSerializer.Serialize(films, options);
            File.WriteAllText(filePath, json);
        }

        private void LoadFilms()
        {
            if (!File.Exists(filePath)) return;

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            var json = File.ReadAllText(filePath);
            var loaded = JsonSerializer.Deserialize<List<Film>>(json, options);
            if (loaded != null) films.AddRange(loaded);
        }
    }
}
