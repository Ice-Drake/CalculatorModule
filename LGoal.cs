using System;

namespace MultiDesktop
{
    public class LGoal : Goal
    {
        private bool isDueDateNull;

        public LGoal(int id, DateTime startDate) : base(id)
        {
            StartDate = startDate;
            Scheme = 0;
            VisionID = 0;
            isDueDateNull = false;
        }

        public DateTime StartDate
        {
            get
            {
                return DateTime.Today.AddDays(Start);
            }
            set
            {
                TimeSpan duration = value - DateTime.Today;
                Start = duration.Days;
            }
        }

        public DateTime DueDate
        {
            get
            {
                if (isDueDateNull)
                    return DateTime.MinValue;
                else
                    return DateTime.Today.AddDays(End);
            }
            set
            {
                if (value == DateTime.MinValue)
                {
                    End = Start + 365;
                    isDueDateNull = true;
                }
                else
                {
                    TimeSpan duration = value - DateTime.Today;
                    End = duration.Days;
                    isDueDateNull = false;
                }
            }
        }

        public int Scheme { get; set; }

        public int VisionID { get; set; }
    }
}
