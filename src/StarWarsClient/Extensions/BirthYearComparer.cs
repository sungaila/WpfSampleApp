using System.Collections;

namespace StarWarsClient.Extensions
{
    public class BirthYearComparer : IComparer<string>, IComparer
    {
        public int Compare(string? x, string? y)
        {
            if (x == y)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;

            if (x == "unknown")
                return -1;
            else if (y == "unknown")
                return 1;

            var yearX = x[..^3].Trim();
            var yearY = y[..^3].Trim();

            if (double.TryParse(yearX, out var numberX) && double.TryParse(yearY, out var numberY))
            {
                if (x.EndsWith("BBY"))
                    numberX *= -1;

                if (y.EndsWith("BBY"))
                    numberY *= -1;

                if (numberX < numberY)
                    return -1;
                else if (numberX == numberY)
                    return 0;
                else
                    return 1;
            }

            return 0;
        }

        public int Compare(object? x, object? y) => Compare(x as string, y as string);
    }
}
