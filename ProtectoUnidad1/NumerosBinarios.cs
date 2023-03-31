using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ProtectoUnidad1
{
    public class NumerosBinarios : INotifyPropertyChanged
    {
        public ICommand GenerarBinario { get; set; }
        public ICommand VerificarCommand { get; set; }

        int numero;
        bool jugar = false;

        public string Mensaje { get; set; }

        public int Valor { get; set; }

        public string Binario
        {
            get { return Convert.ToString(numero, 2); }
        }

        public bool Jugar => jugar;

        public bool Correcto { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GenerarNuevo()
        {
            Mensaje = "";
            Random random = new Random();
            numero = random.Next(1, 255);
            jugar = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            
        }

        public void Verificar()
        {
            if (jugar)
            {
                if (Valor == numero)
                {
                    jugar = false;
                    Correcto = true;
                    Mensaje = "El valor es correcto.";
                    Valor = 0;
                }
                else if(Valor != numero)
                {
                    Correcto = false;
                    Mensaje = "El valor es incorrecto.";
               
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public NumerosBinarios()
        {
            GenerarBinario = new RelayCommand(GenerarNuevo);
            VerificarCommand = new RelayCommand(Verificar);
        }
    }
}
