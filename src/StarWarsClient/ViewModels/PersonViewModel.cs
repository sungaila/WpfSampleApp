using CommunityToolkit.Mvvm.ComponentModel;

namespace StarWarsClient.ViewModels
{
    public class PersonViewModel : ObservableValidator
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private uint _height;

        public uint Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private uint _mass;

        public uint Mass
        {
            get => _mass;
            set => SetProperty(ref _mass, value);
        }

        private string _birthYear = string.Empty;

        public string BirthYear
        {
            get => _birthYear;
            set => SetProperty(ref _birthYear, value);
        }

        private string _gender = string.Empty;

        public string Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }
    }
}
