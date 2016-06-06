using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Guru_Stopwatch_with_extra_features
{
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

		private string name;
        private TimeSpan elapsedTime;
		public string Name
		{
			get 
			{ 
				return this.name; 
			}
		    set
		    {
		        if (this.name != value)
		        {
		            this.name = value;
                    this.OnPropertyChanged("Name");
		        }
                
		    }
		}

        private bool isDispacherTimerRunning = false;

        public bool IsDispacherTimerRunning
        {
            get { return this.isDispacherTimerRunning; }
            set
            {
                if (isDispacherTimerRunning != value)
                {
                this.isDispacherTimerRunning = value;
                    
                }
                this.OnPropertyChanged("IsDispacherTimerRunning");
            }
        }

        private bool isDispacherTimerPaused = false;

        public bool IsDispacherTimerPaused
        {
            get { return this.isDispacherTimerPaused; }
            set
            {
                if (isDispacherTimerPaused != value)
                {
                    this.isDispacherTimerPaused = value;

                }
                this.OnPropertyChanged("IsDispacherTimerPaused");
            }
        }

        private int counter;

        public int Counter
        {
            get { return counter; }
            set
            {
                counter = value;
                this.OnPropertyChanged("Counter");
            }
        }


        public TimeSpan ElapsedTime
        {
            get
            {
                return this.elapsedTime;
            }
            set
            {
                if (this.elapsedTime != value)
                {
                    this.elapsedTime = value;
                    this.OnPropertyChanged("ElapsedTime");
                }
            }
        }

        private bool isStartButtonEnabled = true;

        public bool IsStartButtonEnabled
        {
            get
            {
                return this.isStartButtonEnabled;
            }
            set
            {
                if (this.isStartButtonEnabled != value)
                {
                    isStartButtonEnabled = value;
                    this.OnPropertyChanged("IsStartButtonEnabled");
                }
            }
        }
        

        public Customer()
        {
                
        }

        public Customer(string name)
		{
			this.name = name;
            this.ElapsedTime = new TimeSpan();
            
		}

       

        public static ObservableCollection<Customer> GetCustomers()
		{
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

            customers.Add(new Customer("Client 1"));
            customers.Add(new Customer("Client 2"));
            customers.Add(new Customer("Client 3"));
            customers.Add(new Customer("Client 4"));

            return customers;
		}

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, args);
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

	}
}
