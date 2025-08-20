using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBankingExercise.ViewModels
{
    public class CustomerSelectionViewModel
    {
        private readonly SqliteDatabaseService _dbService;

        public ObservableCollection<CustomerSelectionViewModel> Customers { get; set; }

        public CustomerSelectionViewModel(SqliteDatabaseService dbService)
        {
            _dbService = dbService;

            Customers = new ObservableCollection<CustomerSelectionViewModel>();

            LoadCustomers();
 
        }

        private void LoadCustomers()
        {
            var connection = _dbService.GetConnection();

            var customers = connection.Table<CustomerSelectionViewModel>().ToList();

            Customers.Clear();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
                
        
        }
    }
}
