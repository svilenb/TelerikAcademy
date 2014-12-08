namespace StringAppearances
{

    public class StringAppearancesService : IStringAppearancesService
    {
        public int CountAppearances(string searched, string text)
        {
            int counter = 0;
            int lastIndex = text.IndexOf(searched);
            while (lastIndex != -1)
            {
                counter++;
                lastIndex = text.IndexOf(searched, lastIndex + 1);
            }

            return counter;
        }
    }
}
