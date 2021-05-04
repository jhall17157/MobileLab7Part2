using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFactsLab.Models;
using SQLite;

namespace MyFactsLab.Data
{
    public class MyFactsDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public MyFactsDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(MyFacts).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(MyFacts)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<MyFacts>> GetFactsAsync()
        {
            return  Database.Table<MyFacts>().ToListAsync();
        }

        public Task<MyFacts> GetFactsAsync(int id)
        {
            return Database.Table<MyFacts>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveFactsAsync(MyFacts item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> InsertList(IEnumerable<MyFacts> items)
        {
            return Database.InsertAllAsync(items);
        }

        public Task<int> DeleteFactsAsync(MyFacts item)
        {
            return Database.DeleteAsync(item);
        }
        public Task<int> ClearAllAsync()
        {
            return Database.DeleteAllAsync<MyFacts>();
        }
    }
}
