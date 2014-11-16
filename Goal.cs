using Library;

namespace MultiDesktop
{
    public class Goal : Task
    {
        public int ID { get; private set; }
        public string Category { get; set; }
        public string Desc { get; set; }
        public string Predecessors { get; set; }

        public Goal(int id)
        {
            ID = id;
        }
    }
}
