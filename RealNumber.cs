namespace MultiDesktop
{
    public class RealNumber : Expression
    {
        private double value;

        public RealNumber(double value)
        {
            this.value = value;
        }

        public double evaluate()
        {
            return value;
        }
    }
}
