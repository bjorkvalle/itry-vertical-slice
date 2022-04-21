using ITry.Application.Enums;

namespace ITry.Application.DomainModels
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int Target { get; set; }
        public TodoWeek CurrentWeek { get; set; }
        public List<TodoWeek> HistoricWeeks { get; set; }
    }

    public class TodoWeek
    {
        public int WeekNumber { get; set; }
        public TodoDay[] TodoDays { get; set; }

        public TodoWeek()
        {
            if (TodoDays == default)
                TodoDays = Enum.GetValues<WeekDays>().Select(day => new TodoDay() { Day = day }).ToArray();
        }
    }

    public class TodoDay
    {
        //public int Id { get; set; }
        //public bool IsActive => true;// (int)Day < dayOfWeek;
        public DayState State { get; set; }
        public WeekDays Day { get; set; }
    }
}
