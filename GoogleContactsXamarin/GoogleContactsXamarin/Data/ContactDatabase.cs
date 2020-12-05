using GoogleContactsXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleContactsXamarin.Data
{
    public class ContactDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public ContactDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Contact>().Wait();
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await database.Table<Contact>().ToListAsync();
        }

        public Task<int> SaveContactAsync(Contact contact)
        {
            if(contact.ID != 0)
            {
                return database.UpdateAsync(contact);
            }
            else
            {
                return database.InsertAsync(contact);
            }
        }

        public Task<int> DeleteContactAsync(Contact contact)
        {
            return database.DeleteAsync(contact);
        }
    }
}
