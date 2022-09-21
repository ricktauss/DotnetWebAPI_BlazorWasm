namespace BlazorDemoApp.Store.Persons
{
    public class FetchPersonsAction
    {
    }

    public class FetchPersonsResultAction
    {
        public List<Person>? Persons { get; }

        public FetchPersonsResultAction(List<Person>? persons)
        {
            Persons = persons;
        }
    }
}
