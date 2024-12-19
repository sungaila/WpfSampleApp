using System.Collections;

namespace StarWarsClient.Extensions
{
    public class NumberComparer : IComparer<string>, IComparer
    {
        public int Compare(string? x, string? y)
        {
            if (x == y)
                return 0;

            if (x == "unknown")
                return -1;
            else if (y == "unknown")
                return 1;
            else if (x == "none")
                return -1;
            else if (y == "none")
                return 1;

            if (double.TryParse(x, out var numberX) && double.TryParse(y, out var numberY))
            {
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
