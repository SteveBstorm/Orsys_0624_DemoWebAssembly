namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo1
    {
        public int MyValue { get; set; } = 42;

        public void Increment()
        {
            MyValue++;
        }

        public void ModifValue(int val)
        {
            MyValue += val;
        }

        public bool Check()
        {
            return MyValue < 50;
        }
    }
}
