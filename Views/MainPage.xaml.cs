using SwipeCardViewDemo.ViewModels;

namespace SwipeCardViewDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MovieCharacterViewModel movieCharacterViewModel)
        {
            InitializeComponent();
            BindingContext = movieCharacterViewModel;
        }
    }
}
