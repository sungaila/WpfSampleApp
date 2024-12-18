using AutoMapper;
using CommunityToolkit.Mvvm.Input;
using StarWarsClient.ViewModels;
using StarWarsClient.Views;
using System.Windows;
using System.Windows.Input;

namespace StarWarsClient.Commands
{
    public static class PersonCommands
    {
        private static readonly IMapper _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();

        public static ICommand OpenDetailsCommand { get; } = new RelayCommand<PersonViewModel>(context =>
        {
            if (context == null)
                return;

            // create a copy of the view model
            // such that changes in the dialog don't change the source directly
            var personCopy = new PersonViewModel();
            _mapper.Map(context, personCopy);

            // open a modal dialog
            var dialog = new PersonDetailWindow
            {
                DataContext = personCopy,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Title = personCopy.Name
            };

            if (dialog.ShowDialog() == true && !personCopy.HasErrors)
            {
                // if the dialog was accepted
                // copy all changes into the original view model back
                _mapper.Map(personCopy, context);
            }
        },
        (context) => context != null);
    }
}