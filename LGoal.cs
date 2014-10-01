using System;

namespace MultiDesktop
{
    public class LGoal : Goal
    {
        public LGoal(int ID, DateTime start) : base(ID)
        {
            StartDate = start;
            Scheme = 0;
            VisionID = 0;
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
                //Start = duration.Days;
            }
        }

        public int Scheme { get; set; }

        public int VisionID { get; set; }
    }
}
