using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StarWarsClient.ViewModels
{
    /// <summary>
    /// Holds information for a single person and has some custom validation logic.
    /// </summary>
    public partial class PersonViewModel : ObservableValidator
    {
        [ObservableProperty]
        public partial string Name { get; set; }

        [ObservableProperty]
        public partial uint Height { get; set; }

        [ObservableProperty]
        public partial uint Mass { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [CustomValidation(typeof(PersonViewModel), nameof(ValidateBirthYear))]
        public partial string BirthYear { get; set; }

        [ObservableProperty]
        public partial GenderKind Gender { get; set; }

        [GeneratedRegex(@"^(\d*(\.\d*)?\s?(BBY|ABY))|unknown")]
        private static partial Regex BirthYearRegex();

        public static ValidationResult ValidateBirthYear(string? birthYear, ValidationContext context)
        {
            return birthYear != null && BirthYearRegex().IsMatch(birthYear)
                ? ValidationResult.Success!
                : new ValidationResult("Das Geburtsjahr muss dem Muster \"{Jahreszahl} BBY\", \"{Jahreszahl} ABY\" oder \"unknown\" entsprechen.");
        }

        public enum GenderKind
        {
            Unknown,
            Male,
            Female,
            NotApplicable
        }
    }
}
