using StarWarsClient.ViewModels;
using System.Windows.Controls;

namespace StarWarsClient.Views
{
    public partial class PeopleListView : Page
    {
        public PeopleListView()
        {
            InitializeComponent();
            DataContext = new PeopleViewModel();
        }
    }
}
