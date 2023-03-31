using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enlace
{
    public class Sumar : INotifyPropertyChanged
    {
        private int nun1;

        public int Num1
        {
            get { return nun1; }
            set
            {
                nun1 = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        private int num2;

       

        public int Num2
        {
            get { return num2; }
            set
            {
                num2 = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public int Suma { get 
            { 
                return  Num1 + Num2;
            }
        }

        public int Resultados { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
