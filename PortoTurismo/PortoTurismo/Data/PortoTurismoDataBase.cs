using PortoTurismo.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PortoTurismo.Data
{
    public class PortoTurismoDataBase
    {
        readonly SQLiteAsyncConnection database;

        public PortoTurismoDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Passenger>().Wait();
        }

        public Task<Passenger> GetPassengerByKeyAsync(int id)
        {
            return database.Table<Passenger>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Passenger>> GetPassengersAsync()
        {
            return database.Table<Passenger>().ToListAsync();
        }

        public Task<int> SavePassengerAsync(Passenger passenger)
        {
            if (passenger.Id != 0)
            {
                return database.UpdateAsync(passenger);
            }
            else
            {
                return database.InsertAsync(passenger);
            }
        }

        public Task<int> DeletePassengerAsync(Passenger passenger)
        {
            return database.DeleteAsync(passenger);
        }

        public async Task<List<Passenger>> FilterPassengerNameOrRG(string term)
        {
            return await database.Table<Passenger>()
                .Where(i => i.Name.ToUpper().Contains(term.ToUpper()) 
                    || i.Document.Contains(term))
                .ToListAsync();
        }


        internal async Task<Passenger> GetPassengersByNameAsync(string name)
        {
            return await database.Table<Passenger>()
              .Where(i => i.Name.Equals(name))
              .FirstOrDefaultAsync();
        }

        internal async Task<Passenger> GetPassengersByPassengerTelephoneAsync(string telephone)
        {
            var tel = telephone.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
            return await  database.Table<Passenger>()
              .Where(i => i.Telephone.Equals(tel))
              .FirstOrDefaultAsync();
        }

        internal async Task<Passenger> GetPassengersByPassengerDocumentAsync(string document)
        {
            var doc = document.Replace("-", String.Empty).Replace(".", String.Empty);
            return await database.Table<Passenger>()
            .Where(i => i.Document.Equals(doc))
            .FirstOrDefaultAsync();
        }

      
    }
}


//public Task<List<TodoItem>> GetItemsAsync()
//{
//    return database.Table<TodoItem>().ToListAsync();
//}

//public Task<List<TodoItem>> GetItemsNotDoneAsync()
//{
//    return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
//}

//public Task<TodoItem> GetItemAsync(int id)
//{
//    return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
//}

//public Task<int> SaveItemAsync(TodoItem item)
//{
//    if (item.ID != 0)
//    {
//        return database.UpdateAsync(item);
//    }
//    else
//    {
//        return database.InsertAsync(item);
//    }
//}

//public Task<int> DeleteItemAsync(TodoItem item)
//{
//    return database.DeleteAsync(item);
//}
