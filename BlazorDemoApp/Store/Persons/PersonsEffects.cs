using System.Net.Http.Json;

namespace BlazorDemoApp.Store.Persons
{
    public class PersonsEffects
    {
        private readonly HttpClient _httpClient;

        public PersonsEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod]
        public async Task HandleFetchPersonsAction(FetchPersonsAction action, IDispatcher dispatcher)
        {
            var persons = await _httpClient.GetFromJsonAsync<List<Person>?>("https://localhost:5001/Persons");
            dispatcher.Dispatch(new FetchPersonsResultAction(persons));
        }


    }
}
