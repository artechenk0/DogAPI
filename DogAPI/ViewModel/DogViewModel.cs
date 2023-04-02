using DogAPI.Model;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace DogAPI.ViewModel
{
    public class DogViewModel : INotifyPropertyChanged
    {
        private string _imageUrl;

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
                    OnPropertyChanged(nameof(ImageUrl));
                }
            }
        }

        public ICommand RefreshCommand { get; }

        public DogViewModel()
        {
            RefreshCommand = new RelayCommand(Refresh);
        }

        private async void Refresh()
        {
            var dog = await HttpHelper.GetAsync<Dog>("https://dog.ceo/api/breeds/image/random");
            ImageUrl = dog.Message;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
