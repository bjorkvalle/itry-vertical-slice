using ITry.Application.Enums;
using ITry.Infrastructure.Helpers;

namespace ITry.Features
{
    public class TodoItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int Target { get; set; }
        public int Completed => CurrentWeek.TodoDays.Where(x => x.State == DayState.Success).Count();
        public TodoWeekModel CurrentWeek { get; set; }
    }

    public class TodoWeekModel
    {
        public TodoDayModel[] TodoDays { get; set; }

        //public TodoWeek()
        //{
        //    if (TodoDays == default)
        //        TodoDays = Enum.GetValues<WeekDays>().Select(day => new TodoDay() { Day = day }).ToArray();
        //}
    }

    public class TodoDayModel
    {
        //public int Id { get; set; }
        public bool IsActive => (int)Day <= WeekHelper.DayOfWeekNumber;
        public DayState State { get; set; }
        public WeekDays Day { get; set; }

        public DayState FormattedState
        {
            get
            {
                if (IsActive && State.Equals(DayState.Neutral))
                {
                    if ((int)Day == WeekHelper.DayOfWeekNumber)
                        return DayState.Warning;

                    return DayState.Fail;
                }

                return State;
            }
        }
    }
}
