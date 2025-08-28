using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TheMoviesProject.MVVM.Model;

namespace TheMoviesProject.MVVM.ViewModel
{
    public class AddFilmViewModel : INotifyPropertyChanged
    {
        // Binder til ObservableCollection i FileFilmRepository
        public ObservableCollection<Film> Films => FileFilmRepository.Films;

        // Inputfelter i UI
        private string title;
        public string Title { get => title; set { title = value; OnPropertyChanged(); } }

        private string durationText;
        public string DurationText { get => durationText; set { durationText = value; OnPropertyChanged(); } }

        public Genre[] Genres { get; } = (Genre[])System.Enum.GetValues(typeof(Genre));

        private Genre selectedGenre;
        public Genre SelectedGenre { get => selectedGenre; set { selectedGenre = value; OnPropertyChanged(); } }

        // Kommandoer
        public ICommand AddFilmCommand { get; }
        public ICommand DeleteFilmCommand { get; }

        public AddFilmViewModel()
        {
            AddFilmCommand = new RelayCommand(AddFilm, CanAddFilm);
            DeleteFilmCommand = new RelayCommand<Film>(DeleteFilm);
        }

        private void AddFilm()
        {
            if (int.TryParse(DurationText, out int duration))
            {
                Films.Add(new Film
                {
                    Title = Title,
                    Duration = duration,
                    Genre = SelectedGenre
                });
                Title = string.Empty;
                DurationText = string.Empty;
            }
        }

        private bool CanAddFilm() => !string.IsNullOrWhiteSpace(Title) && int.TryParse(DurationText, out _);

        private void DeleteFilm(Film film)
        {
            if (film != null && Films.Contains(film))
                Films.Remove(film);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
