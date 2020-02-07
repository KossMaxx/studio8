using Logic.Interfaces;

namespace Logic
{
    public class Calculator:ICalculator
    {
        public int Square(int value)
        {
            return value * value;
        }

        public int Cube(int value)
        {
            return value * value * value;
        }
    }
}
