using BlazorApiBackend.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApiBackend.Repositories
{
    public class MongoDbPersonRepository : IPersonRepository
    {
        #region fields

        private readonly IMongoCollection<Person> _personCollection;

        #endregion

        #region constructor

        public MongoDbPersonRepository(IOptions<PersonStoreDatabaseSettings> personStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(personStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(personStoreDatabaseSettings.Value.DatabaseName);
            var databases = mongoClient.ListDatabases();
            _personCollection = mongoDatabase.GetCollection<Person>(personStoreDatabaseSettings.Value.PersonCollectionName);
        }

        #endregion

        #region methods

        //Sync methods not implemented!

        public IEnumerable<Person> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> FindAllAsync()
        {
            return await _personCollection.Find(p => true).ToListAsync();
        }


        public Person? FindById(string entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> FindByIdAsync(string entityId)
        {
            return await _personCollection.Find(p => entityId.Equals(p.Id)).FirstOrDefaultAsync();
        }


        public Person? Insert(Person entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> InsertAsync(Person person)
        {
            await _personCollection.InsertOneAsync(person);
            return await FindByIdAsync(person.Id);
        }


        public Person? Update(string entityId, Person entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> UpdateAsync(string entityId, Person entity)
        {
            await _personCollection.ReplaceOneAsync(p => entityId.Equals(p.Id), entity);
            return await FindByIdAsync(entityId);
        }


        public void Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Person entity)
        {
            await _personCollection.DeleteOneAsync(p => entity.Id.Equals(p.Id));
        }


        public void DeleteById(string entityId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(string entityId)
        {
            await _personCollection.DeleteOneAsync(p => entityId.Equals(p.Id));
        }



        #endregion 
    }
}
