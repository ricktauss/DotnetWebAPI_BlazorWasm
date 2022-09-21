
namespace BlazorDemoApp.Store.Persons
{
    public static class PersonsReducer
    {
        [ReducerMethod]
        public static PersonsState ReduceFetchPersonsAction(PersonsState state, FetchPersonsAction action) =>
            new PersonsState(isLoading: true, persons: null);

        [ReducerMethod]
        public static PersonsState ReduceFetchPersonsResultAction(PersonsState state, FetchPersonsResultAction action) =>
            new PersonsState(isLoading: false, persons: action.Persons);

    }

}
