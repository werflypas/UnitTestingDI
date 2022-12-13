namespace UnitTestingDI
{
    public interface IController2
    {
        int AddThreeToThree();
    }

    public class Controller2 : IController2
    {
        protected readonly IController1 _controller1;

        public Controller2(IController1 controller1)
        {
            _controller1 = controller1;
        }

        public int AddThreeToThree()
        {
            return _controller1.GetNumberThree() + 3;
        }
    }
}
