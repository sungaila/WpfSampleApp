using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace StarWarsClient.ViewModels
{
    /// <summary>
    /// Holds all people and calculates a few statistics for them.
    /// For the calculation the <see cref="Results"/> collection is observed for changes (either items added/removed or properties of items changed).
    /// </summary>
    public partial class PeopleViewModel : ObservableValidator
    {
        public PeopleViewModel()
        {
            Results.CollectionChanged += Results_CollectionChanged;
        }

        private void Results_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // attach and dettach the handler for changed item properties
            foreach (var item in (e.OldItems ?? Array.Empty<object>()).OfType<ObservableValidator>())
            {
                item.PropertyChanged -= Person_PropertyChanged;
            }

            foreach (var item in (e.NewItems ?? Array.Empty<object>()).OfType<ObservableValidator>())
            {
                item.PropertyChanged += Person_PropertyChanged;
            }

            // recalculate all statistics when the collection changes
            OnPropertyChanged(nameof(AverageHeight));
            OnPropertyChanged(nameof(AverageBirthYear));
            OnPropertyChanged(nameof(MaleFemaleRatio));
        }

        private void Person_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // recalculate a statstic depending on the property that has changed
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

        /// <summary>
        /// The average height of the people.
        /// </summary>
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

        /// <summary>
        /// The average birth year of the people.
        /// In-universe there is a standard using Before the Battle of Yavin (BBY) and After the Battle of Yavin (ABY). This must be taken into account to calculate the correct average.
        /// See <see href="https://web.archive.org/web/20241113211619/https://swapi.dev/documentation#people"/>.
        /// </summary>
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
                    ? $"{-average}BBY"
                    : $"{average}ABY";
            }
        }

        /// <summary>
        /// The ratio between male an female people.
        /// </summary>
        public double MaleFemaleRatio
        {
            get
            {
                if (Results.Count == 0)
                    return 0.0;

                var male = Results.Count(p => p.Gender == PersonViewModel.GenderKind.Male);
                var female = Results.Count(p => p.Gender == PersonViewModel.GenderKind.Female);

                if (female == 0)
                {
                    if (male > 0)
                        return 100.0;
                    else
                        return 0.0;
                }

                return male / (double)female;
            }
        }
    }
}