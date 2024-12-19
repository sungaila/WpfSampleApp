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
        [NotifyDataErrorInfo]
        [CustomValidation(typeof(PersonViewModel), nameof(ValidateHeight))]
        public partial string Height { get; set; }

        [ObservableProperty]
        public partial string Mass { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [CustomValidation(typeof(PersonViewModel), nameof(ValidateBirthYear))]
        public partial string BirthYear { get; set; }

        [ObservableProperty]
        public partial GenderKind Gender { get; set; }

        [GeneratedRegex(@"^(\d*(\.\d+)?)$|unknown")]
        private static partial Regex NumberRegex();

        public static ValidationResult? ValidateHeight(string? height)
        {
            if (height != null && (height == "unknown" || height == "none" || double.TryParse(height, out _)))
                return ValidationResult.Success;

            return new ValidationResult("Die Größe muss entweder einer positiven Zahl oder \"unknown\" entsprechen.");
        }

        [GeneratedRegex(@"^(\d*(\.\d+)?\s?(BBY|ABY))|unknown")]
        private static partial Regex BirthYearRegex();

        public static ValidationResult? ValidateBirthYear(string? birthYear)
        {
            return birthYear != null && BirthYearRegex().IsMatch(birthYear)
                ? ValidationResult.Success
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
