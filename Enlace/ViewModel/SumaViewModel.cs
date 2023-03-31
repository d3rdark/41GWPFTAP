using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Enlace.ViewModel
{
    public class SumaViewModel : INotifyPropertyChanged
    {
        //public Sumar SumarObjeto { get; set; }

        //public ICommand SumarCommand { get; set; }

        //public SumaViewModel()
        //{

        //    SumarObjeto = new Sumar();
        //    SumarCommand = new RelayCommand(SumarNumeros);
        //}

        //private void SumarNumeros()
        //{
        //    SumarObjeto.Resultados = SumarObjeto.Num1 + SumarObjeto.Num2;

        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
           
        //}



        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
