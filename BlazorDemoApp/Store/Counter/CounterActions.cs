namespace BlazorDemoApp.Store.Counter
{
    public class IncrementCounterAction
    {
    }

    public class IncrementCounterBy2Action
    {
        public readonly int incrementValue = 2;
    }

    public class IncrementCounterByCustomValueAction
    {
        public readonly int incrementValue;
        public IncrementCounterByCustomValueAction(int value)
        {
            incrementValue = value;
        }
    }
}
