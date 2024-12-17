using CommunityToolkit.Mvvm.ComponentModel;
using StarWarsClient.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StarWarsClient.ViewModels
{
    public class PeopleViewModel : ObservableValidator
    {
        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public ObservableCollection<PersonViewModel> Results { get; } = [];

        public ICommand RefreshCommand { get; } = PeopleCommands.RefreshCommand;
    }
}