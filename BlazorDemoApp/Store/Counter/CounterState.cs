namespace BlazorDemoApp.Store.Counter
{
    [FeatureState]
    public class CounterState
    {
        public int ClickCount { get; }

        private CounterState() { } // Required for creating initial state

        public CounterState(int clickCount) => ClickCount = clickCount;
    }

    /*
     * Notes:
            State should be decorated with [FeatureState] for automatic discovery when services.AddFluxor is called.
            State should be immutable.
            A parameterless constructor is required on state for determining the initial state, and can be private or public.
     */
}
