namespace UnitTestingDI
{
    public interface IController1
    {
        int GetNumberThree();
    }

    public class Controller1 : IController1
    {
        public int GetNumberThree()
        {
            return 3;
        }
    }
}