using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using TheMoviesProject.MVVM.View;

namespace TheMoviesProject.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Scenarie 1: Filmoversigt
        public UserControl FilmView { get; } = new AddFilmView();

        private UserControl currentView;
        public UserControl CurrentView
        {
            get => currentView;
            set { currentView = value; OnPropertyChanged(); }
        }

        private bool isFilmViewSelected = true;
        public bool IsFilmViewSelected
        {
            get => isFilmViewSelected;
            set
            {
                isFilmViewSelected = value;
                OnPropertyChanged();
                if (value) CurrentView = FilmView;
            }
        }

        public MainViewModel() { CurrentView = FilmView; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
