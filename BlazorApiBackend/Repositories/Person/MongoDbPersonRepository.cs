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


        public Person? FindById(object entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> FindByIdAsync(object entityId)
        {
            return await _personCollection.Find(p => entityId.Equals(p.Id)).FirstOrDefaultAsync();
        }


        public Person? Insert(Person entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> InsertAsync(Person entity)
        {
            await _personCollection.InsertOneAsync(entity);
            return await FindByIdAsync(entity.Id);
        }


        public Person? Update(object entityId, Person entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> UpdateAsync(object entityId, Person entity)
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


        public void DeleteById(object entityId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(object entityId)
        {
            await _personCollection.DeleteOneAsync(p => entityId.Equals(p.Id));
        }



        #endregion 
    }
}
