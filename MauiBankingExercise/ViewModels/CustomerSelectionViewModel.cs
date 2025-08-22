using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBankingExercise.Models;
using MauiBankingExercise.Services;

namespace MauiBankingExercise.ViewModels
{
    public class CustomerSelectionViewModel
    {
        private readonly SqliteDatabaseService _dbService;

        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerSelectionViewModel(SqliteDatabaseService dbService)
        {
            _dbService = dbService;

            Customers = new ObservableCollection<Customer>();

            LoadCustomers();
 
        }

        private void LoadCustomers()
        {

            var customers = connection.Table<Customer>().ToList(); 

            Customers.Clear();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
                
        
        }
    }
}
