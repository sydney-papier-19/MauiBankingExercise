using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;                      
using SQLite;                         // for SQLiteConnection
using Microsoft.Maui.Storage;         // for FileSystem.AppDataDirectory
using MauiBankingExercise.Models;     // so it knows about Customer
using MauiBankingExercise.Services;   // so it sees BankingSeeder

namespace MauiBankingExercise.Services
{
    public class SqliteDatabaseService 
    {
        private readonly SQLiteConnection _connection;

        public SqliteDatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "banking.db3");

            _connection = new SQLiteConnection(dbPath);

            _connection.CreateTable<Customer>();

            if (_connection.Table<Customer>().Any())
            {
                BankingSeeder.Seed(_connection);
            }
        
        }

        public SQLiteConnection GetConnection() => _connection;
    }
}
