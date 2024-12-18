using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace StarWarsClient.ViewModels
{
    public partial class PeopleViewModel : ObservableValidator
    {
        public PeopleViewModel()
        {
            Results.CollectionChanged += Results_CollectionChanged;
        }

        private void Results_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in (e.OldItems ?? Array.Empty<object>()).OfType<ObservableValidator>())
            {
                item.PropertyChanged -= Person_PropertyChanged;
            }

            foreach (var item in (e.NewItems ?? Array.Empty<object>()).OfType<ObservableValidator>())
            {
                item.PropertyChanged += Person_PropertyChanged;
            }

            OnPropertyChanged(nameof(AverageHeight));
            OnPropertyChanged(nameof(AverageBirthYear));
            OnPropertyChanged(nameof(MaleFemaleRatio));
        }

        private void Person_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(PersonViewModel.Height):
                    OnPropertyChanged(nameof(AverageHeight));
                    break;
                case nameof(PersonViewModel.BirthYear):
                    OnPropertyChanged(nameof(AverageBirthYear));
                    break;
                case nameof(PersonViewModel.Gender):
                    OnPropertyChanged(nameof(MaleFemaleRatio));
                    break;
                default:
                    break;
            }
        }

        public ObservableCollection<PersonViewModel> Results { get; } = [];

        public double AverageHeight
        {
            get
            {
                if (Results.Count == 0)
                    return 0.0;

                return Results.Sum(p => p.Height) / (double)Results.Count;
            }
        }

        [GeneratedRegex(@"\d*(\.\d*)?")]
        private static partial Regex BirthYearPrefixRegex();

        public string AverageBirthYear
        {
            get
            {
                if (Results.Count == 0)
                    return string.Empty;

                var valuesBBY = Results.Where(p => p.BirthYear.EndsWith("BBY")).Select(p => double.Parse(BirthYearPrefixRegex().Match(p.BirthYear).Value));
                var valuesABY = Results.Where(p => p.BirthYear.EndsWith("ABY")).Select(p => double.Parse(BirthYearPrefixRegex().Match(p.BirthYear).Value));

                var average = valuesABY.Sum() + (-1 * valuesBBY.Sum());

                return average < 0.0
                    ? $"{average}BBY"
                    : $"{average}ABY";
            }
        }

        public double MaleFemaleRatio
        {
            get
            {
                if (Results.Count == 0)
                    return 0.0;

                var male = Results.Count(p => p.Gender == PersonViewModel.GenderKind.Male);
                var female = Results.Count(p => p.Gender == PersonViewModel.GenderKind.Female);

                return male / (double)female;
            }
        }
    }
}