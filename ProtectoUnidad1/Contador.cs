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
    public class Contador : INotifyPropertyChanged
    {

        public int Puntuacion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ComandoMasMenos { get; set; }
        public ICommand ComandoLimpiar { get; set; }

        public Contador()
        {
            ComandoMasMenos = new RelayCommand<bool>(MasMenos);
            ComandoLimpiar = new RelayCommand(Limpiar);
        }

        public void MasMenos(bool voto)
        {
            if (voto == true)
            {
                Puntuacion++;
            }
            else if (voto == false && Puntuacion != 0)
            {
                Puntuacion--;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Limpiar()
        {
            Puntuacion = 0;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
