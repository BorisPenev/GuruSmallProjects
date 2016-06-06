using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Guru_Barcode_Generator
{
    public class Barcode:  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static Random randomNumber;
        private string text = string.Empty;
        public string Text
        {
            get { return this.text; }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }

        public ICommand GetRandomNumberCommand { get; set; }

        public Barcode()
        {
            this.GetRandomNumberCommand = new DelegateCommand(GetNextRandomNumberExecuted);
            Barcode.randomNumber = new Random();
            this.GetNextRandomNumberExecuted();
        }

        private void GetNextRandomNumberExecuted(object obj = null)
        {
            this.Text = Barcode.randomNumber.Next(0, int.MaxValue).ToString();
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
