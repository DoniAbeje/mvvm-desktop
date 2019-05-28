using POSSample.Model;
using POSSample.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace POSSample.UI.ViewModel
{
    public class CustomerViewModel: ViewModelBase
    {
        
       

        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                return _AddCommand ?? (_AddCommand = new CommandHandler(() => AddCustomer(), true));
            }
        }

        private ICommand _UpdateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return _UpdateCommand ?? ( _UpdateCommand = new CommandHandler(() => UpdateCustomer(), true));
            }
         }

        private ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ?? (_DeleteCommand = new CommandHandler(() => DeleteCustomer(), true));
            }
        }
        private ICommand _ClearSearchCommand;
        public ICommand ClearSearchCommand
        {
            get
            {
                return _ClearSearchCommand ?? (_ClearSearchCommand = new CommandHandler(() => ClearSearchCustomer(), true));
            }
        }

        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _SearchCommand ?? (_SearchCommand = new CommandHandler(() => SearchCustomer(), true));
            }
        }
        private ICustomerDataService _CustomerDataService;

        private Customer _SelectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set
            {
                _SelectedCustomer = value;
                OnPropertyChanged();
            }
        }

        private Customer _NewCustomer;

        public Customer NewCustomer
        {
            get { return _NewCustomer; }
            set {
                _NewCustomer = value;
                OnPropertyChanged();
            }
        }

        private string _SearchKeyword;

        public string SearchKeyword
        {
            get { return _SearchKeyword; }
            set {
                _SearchKeyword = value;
                OnPropertyChanged();
            }
        }




        public CustomerViewModel(ICustomerDataService customerDataService)
        {
            _CustomerDataService = customerDataService;
            Customers = new ObservableCollection<Customer>();
            NewCustomer = new Customer();
        }

        
        
        public ObservableCollection<Customer> Customers { get; set; }



      

        public async Task LoadAsync()
        {
            Customers.Clear();
            var customers = await _CustomerDataService.GetAllAsync();
            
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

        private async void AddCustomer()
        {
            //Validate New Customer
            var customer = await _CustomerDataService.AddCustomerAsync(NewCustomer);
            NewCustomer = new Customer { };
            Customers.Add(customer);
        }

        private async void UpdateCustomer()
        {
            SelectedCustomer = await _CustomerDataService.UpdateCustomerAsync(SelectedCustomer);
            
        }

        private async void DeleteCustomer()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                SelectedCustomer = await _CustomerDataService.DeleteCustomerAsync(SelectedCustomer);
                Customers.Remove(SelectedCustomer);
            }
                
        }

        private async void SearchCustomer()
        {
            Customers.Clear();
            var customers = await _CustomerDataService.SearchCustomerAsync(SearchKeyword);

            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }
        private async void ClearSearchCustomer()
        {
            SearchKeyword = "";
            await LoadAsync();
        }


    }



}
