using StarWarsClient.Commands;
using StarWarsClient.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace StarWarsClient.Views
{
    public partial class PeopleListView : Page
    {
        public PeopleListView()
        {
            InitializeComponent();
            DataContext = new PeopleViewModel();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is not DataGridRow row)
                return;

            if (row.DataContext is not PersonViewModel viewModel)
                return;

            if (PersonCommands.OpenDetailsCommand.CanExecute(viewModel))
                PersonCommands.OpenDetailsCommand.Execute(viewModel);
        }
    }
}
