namespace BlazorDemoApp.Store.Persons
{
    [FeatureState]
    public class PersonsState
    {
        public bool IsLoading { get; }
        public List<Person>? Persons { get; }

        private PersonsState() { }
        public PersonsState(bool isLoading, List<Person>? persons)
        {
            IsLoading = isLoading;
            Persons = persons ?? new List<Person>();
        }
    }
}
