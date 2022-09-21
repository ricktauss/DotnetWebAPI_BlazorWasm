namespace BlazorDemoApp.Pages
{
    public partial class FluxorPersonsPage
    {
        [Inject]
        private IState<PersonsState> PersonsState { get; set; }

        [Inject]
        private IDispatcher Dispatcher { get; set; }
        
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if(PersonsState.Value.Persons == null) Dispatcher.Dispatch(new FetchPersonsAction());
        }
    }
}
