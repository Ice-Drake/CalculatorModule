using Library;

namespace MultiDesktop
{
    public class Goal : Task
    {
        public Goal(int ID)
        {
            this.ID = ID;
        }

        public int ID { get; internal set; }

        public string Category { get; set; }

        public string Predecessors { get; set; }
    }
}
