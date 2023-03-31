using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Enlace
{
    public class Rectangulo : INotifyPropertyChanged
    {
        private int altura;

        public int Altura
        {
            get { return altura; }
            set
            {
                altura = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        private int ancho;

        public int Ancho
        {
            get { return ancho; }
            set
            {
                ancho = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public int Area
        {
            get
            {
                return Altura * Ancho;
            }
        }

        public int Perimetro => Altura * 2 + Ancho * 2;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
