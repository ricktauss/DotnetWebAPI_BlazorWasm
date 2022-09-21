namespace BlazorDemoApp.Store.Counter
{
    public static class CounterReducer
    {
        [ReducerMethod(typeof(IncrementCounterAction))]
        public static CounterState ReduceIncrementCounterAction(CounterState state) =>
            new CounterState(clickCount: state.ClickCount + 1);

        [ReducerMethod]
        public static CounterState ReduceIncrementCounterBy2Action(CounterState state, IncrementCounterBy2Action action) =>
            new CounterState(clickCount: state.ClickCount + action.incrementValue);

        [ReducerMethod]
        public static CounterState ReduceIncrementCounterByCustomValueAction(CounterState state, IncrementCounterByCustomValueAction action) =>
           new CounterState(clickCount: state.ClickCount + action.incrementValue);

    }
}
