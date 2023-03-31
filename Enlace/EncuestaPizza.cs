using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Enlace
{
    public class EncuestaPizza : INotifyPropertyChanged
    {
        private int[] votos = new int[2];

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ComandoSi { get; set; }

        public ICommand ComandoNo { get; set; }

        public double Opcion1
        {
            get
            {
                return Total == 0 ? 0 : (votos[0] * 100.0 / Total);
            }
        }

        public double Opcion2
        {
            get { return Total == 0 ? 0 : (votos[1] * 100.0 / Total); }
        }

        public int Total
        {
            get { return votos[0] + votos[1]; }
        }

        public void VotoSi()
        {
            votos[0]++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void VotoNo()
        {
            votos[1]++;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public EncuestaPizza()
        {
            ComandoSi = new RelayCommand(VotoSi);
            ComandoNo = new RelayCommand(VotoNo);
        }
    }
}
