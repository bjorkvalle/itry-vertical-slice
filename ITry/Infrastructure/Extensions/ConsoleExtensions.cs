namespace ITry.Infrastructure.Extensions
{
    public static class ConsoleExtensions
    {
        public static void ToConsole<T>(this T item)
        {
            var toLog = item?.Serialize();
            Console.WriteLine(toLog);
        }

        public static void ToConsole<T>(this T item, bool condition)
        {
            if (!condition)
                return;

            ToConsole(item);
        }
    }
}
