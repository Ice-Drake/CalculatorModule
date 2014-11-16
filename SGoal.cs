using System;

namespace MultiDesktop
{
    public class SGoal : Goal
    {
        private LGoal lGoal;
        private bool isStartDateNull;

        public SGoal(int id, DateTime dueDate) : base(id)
        {
            DueDate = dueDate;
            Priority = 0;
            isStartDateNull = false;
        }

        public DateTime StartDate
        {
            get
            {
                if (isStartDateNull)
                    return DateTime.MinValue;
                else
                    return DateTime.Today.AddDays(Start);
            }
            set
            {
                if (value == DateTime.MinValue)
                {
                    if (lGoal != null)
                        Start = lGoal.Start;
                    else
                        Start = End - 30;
                    isStartDateNull = true;
                }
                else
                {
                    TimeSpan duration = value - DateTime.Today;
                    Start = duration.Days;
                    isStartDateNull = false;
                }
            }
        }

        public DateTime DueDate
        {
            get
            {
                return DateTime.Today.AddDays(End);
            }
            set
            {
                TimeSpan duration = value - DateTime.Today;
                End = duration.Days;
            }
        }

        public int Priority { get; set; }

        public LGoal LGoal
        {
            get
            {
                return lGoal;
            }
            set
            {
                lGoal = value;
                if (lGoal != null && isStartDateNull)
                    Start = lGoal.Start;
            }
        }
    }
}
