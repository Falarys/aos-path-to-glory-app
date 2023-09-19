using SQLite;

namespace AosPathToGlory
{
    public class AosPathToGloryDatabase
    {
        private SQLiteAsyncConnection _database;

        public AosPathToGloryDatabase()
        {
        }

        async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            //await _database.DropTableAsync<AosArmy>();
            await _database.CreateTableAsync<AosArmy>(CreateFlags.ImplicitPK | CreateFlags.AutoIncPK);
            //await _database.DeleteAllAsync<AosArmy>();
        }

        public async Task<AsyncTableQuery<AosArmy>> GetArmiesAsync()
        {
            await Init();
            return _database.Table<AosArmy>();
        }

        public async Task<int> SaveItemAsync(AosArmy item)
        {
            await Init();
            if (item.Id.HasValue)
                return await _database.UpdateAsync(item);
            else
                return await _database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(AosArmy item)
        {
            await Init();
            return await _database.DeleteAsync(item);
        }
    }
}
