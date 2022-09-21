using BlazorDemoApp.Store.Counter;
using BlazorDemoApp.Store.Persons;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoApp.Shared
{
    public partial class NavMenu : IDisposable
    {
        [Inject]
        private IState<CounterState> CounterState { get; set; }

        [Inject]
        private IState<PersonsState> PersonsState { get; set; }


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                CounterState.StateChanged += StateChanged;
                PersonsState.StateChanged += StateChanged;
            }
        }

        public void StateChanged(object sender, EventArgs args)
        {
            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            CounterState.StateChanged -= StateChanged;
            PersonsState.StateChanged -= StateChanged;
        }
    }
}
