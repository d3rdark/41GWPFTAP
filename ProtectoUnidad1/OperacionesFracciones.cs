using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace ProtectoUnidad1
{
    public class OperacionesFracciones : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SumaComando { get; set; }
        public ICommand LimpiarComando { get; set; }
        public ICommand RestaComando { get; set; }

        public int? NumeradorL { get; set; } 
        public int? DenominadorL { get; set; }

        public int? NumeradorR { get; set; }
        public int? DenominadorR { get; set; }

        public int? ReDenominador { get; set; }
        public int? ReNumerador { get; set; }

        public string Simbolo { get; set; } = "";

        public void Sumar()
        {
            if ( DenominadorL == DenominadorR)
            {
                ReNumerador = (NumeradorL + NumeradorR);
                ReDenominador = DenominadorL;
                Simbolo = "+";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
            else
            {
                ReNumerador = (NumeradorL * DenominadorR) + (DenominadorL * NumeradorR);
                ReDenominador = (DenominadorL * DenominadorR);
                Simbolo = "+";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public void Resta()
        {
            
            if (DenominadorL == DenominadorR)
            {
                ReNumerador = (NumeradorL - NumeradorR);
                ReDenominador = DenominadorL;
                Simbolo = "-";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
            else
            {
                ReNumerador = (NumeradorL * DenominadorR) - (DenominadorL * NumeradorR);
                ReDenominador = (DenominadorL * DenominadorR);
                Simbolo = "-";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public void Limpiar()
        {
            NumeradorL = null;
            NumeradorR = null;
            DenominadorL = null;
            DenominadorR = null;

            ReNumerador = null;
            ReDenominador = null;
            Simbolo = "";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public OperacionesFracciones()
        {
            SumaComando = new RelayCommand(Sumar);
            LimpiarComando = new RelayCommand(Limpiar);
            RestaComando = new RelayCommand(Resta);
        }

    }
}
