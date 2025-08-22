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
        private static SqliteDatabaseService _instance;

        public static SqliteDatabaseService GetInstance()
        {
            
                if (_instance == null)
                {
                    _instance = new SqliteDatabaseService();
                }
                return _instance;
            
        }

        private readonly SQLiteConnection _connection;

        public string GetDbPath()
        {
            string filename = "banking.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, filename);
        }
        public SqliteDatabaseService()
        {

            _connection = new SQLiteConnection(GetDbPath());

           
            BankingSeeder.Seed(_connection);
        
        }

        public List<Customer> GetCustomers()
        { 
            return _connection.Table<Customer>().ToList();

        }


    }
}
