namespace ITry.Infrastructure.Helpers
{
    public static class WeekHelper
    {
        // abrovinch to set monday to start of week
        public static readonly int DayOfWeekNumber = DateTime.Today.DayOfWeek == System.DayOfWeek.Sunday ? 6 : ((int)DateTime.Today.DayOfWeek) - 1;
        public static readonly string DayOfWeekDisplayName = DateTime.Today.DayOfWeek.ToString();
        public static readonly DayOfWeek DayOfWeek = DateTime.Today.DayOfWeek;
    }
}
