using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Guru_Stopwatch_with_extra_features
{
    public class MyViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> customers;
        int counter = 0;


        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (this.customers == null)
                {
                    this.customers = Customer.GetCustomers();
                }

                return this.customers;
            }
        }
        public ICommand StartButtonCommand { get; set; }
        public ICommand PauseButtonCommand { get; set; }
        public ICommand ResetButtonCommand { get; set; }

        public MyViewModel()
        {
            this.StartButtonCommand = new DelegateCommand(OnStartButtonCommandExecuted);
            this.PauseButtonCommand = new DelegateCommand(OnPauseButtonCommandExecuted);
            this.ResetButtonCommand = new DelegateCommand(OnResetButtonCommandExecuted);
                
        }

        private void OnStartButtonCommandExecuted(object obj)
        {
            var customer = obj as Customer;

            if (customer != null)
            {
                customer.IsDispacherTimerRunning = true;
                customer.IsStartButtonEnabled = false;
                //customer.ElapsedTime.Start();

                System.Windows.Threading.DispatcherTimer myDispatcherTimer =
                    new System.Windows.Threading.DispatcherTimer();
                myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1); // 1 second
                myDispatcherTimer.Tick -= (s, args) => Each_Tick(customer, myDispatcherTimer);
                myDispatcherTimer.Tick += (s, args) => Each_Tick(customer, myDispatcherTimer);
                myDispatcherTimer.Start();

                //customer.Counter = counter;
            }
        }
        // A variable to count with.

        // Raised every 100 miliseconds while the DispatcherTimer is active.
        public void Each_Tick(Customer o, DispatcherTimer currentDispacherTimer)
        {
            if (o.IsDispacherTimerRunning)
            {
                o.Counter++;
                o.ElapsedTime = new TimeSpan(0, 0, 0, o.Counter);
                
            }
            else
            {
                currentDispacherTimer.Stop();

                o.ElapsedTime = new TimeSpan(0, 0, 0, o.Counter);
            }
            
        }
        private void OnPauseButtonCommandExecuted(object obj)
        {
            var customer = obj as Customer;

            if (customer != null)
            {
                customer.IsDispacherTimerRunning = false;
                customer.IsStartButtonEnabled = true;
            }
        }
        private void OnResetButtonCommandExecuted(object obj)
        {
            var customer = obj as Customer;

            if (customer != null)
            {
                customer.IsStartButtonEnabled = true;
                //customer.IsDispacherTimerPaused = false;
                //customer.IsDispacherTimerRunning = false;
                if (customer.IsDispacherTimerRunning)
                {
                    customer.IsDispacherTimerRunning = false;
                }
                customer.Counter = 0;
                customer.ElapsedTime = new TimeSpan(0, 0, 0, 0, 0);
            }
        }
    }
}
