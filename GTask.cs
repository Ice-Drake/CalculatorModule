using System;
using System.Collections.Generic;
using DDay.iCal;

namespace MultiDesktop
{
    public class GTask
    {
        public GTask(ITodo todo, int goalID)
        {
            Todo = todo;
            RelatedGoalID = goalID;
        }

        public ITodo Todo { get; internal set; }
        public int RelatedGoalID { get; internal set; }
    }
}
