using CommunityToolkit.Mvvm.ComponentModel;
using SwipeCardViewDemo.Models;
using SwipeCardViewDemo.Services;
using System.Collections.ObjectModel;

namespace SwipeCardViewDemo.ViewModels
{
    public partial class MovieCharacterViewModel : ObservableObject
    {
        private readonly IMovieCharacterService _movieCharacterService;

        [ObservableProperty]
        private string _Name;

        [ObservableProperty]
        private string _Ancestry;

        [ObservableProperty]
        private string _House;

        [ObservableProperty]
        private string _Image;
        public ObservableCollection<MovieCharacter> MovieCharacters { get; set; } = new();

        public MovieCharacterViewModel(IMovieCharacterService movieCharacterService)
        {
            _movieCharacterService = movieCharacterService;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }


        private async Task LoadMovieCharacters()
        {
            var movieCharacterData = await _movieCharacterService.GetMovieCharacterDataAsync();
            MovieCharacters.Clear();

            foreach (var movieCharacter in movieCharacterData)
            {
                MovieCharacters.Add(movieCharacter);
            }
        }

        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                await LoadMovieCharacters();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("", "No Internet Connection.", "Ok");
            }
        }
    }
}
