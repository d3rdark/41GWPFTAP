using System;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Enlace
{
    public class ParImpar : INotifyPropertyChanged
    {
        public ICommand GenerarComando { get; set; }

        public int Numero { get; set; }

        public string Resultado
        {
            get
            {
                return Numero % 2 == 0 ? "PAR" : "IMPAR";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Generar()
        {
            Random r = new Random();
            Numero = r.Next(1, 100);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public ParImpar()
        {
            GenerarComando = new RelayCommand(Generar);
        }
    }
}
