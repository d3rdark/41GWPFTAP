using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MVVMXamarin.Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMXamarin.ViewModels
{
    public class AlumnosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PersonaModel> Grupo { get; set; } = new ObservableCollection<PersonaModel>();

        public PersonaModel Persona { get; set; } //Agregar, edirar, eliminar

        public ICommand CambiarVistaCommand { get; set; }
        public ICommand AgregarCommand { get; set; }

        public AlumnosViewModel()
        {
            CambiarVistaCommand = new Command(CambiarVista);
            AgregarCommand = new Command(Agregar);
        }

        //pages solo en xamarin


        private void Agregar(object obj)
        {
            throw new NotImplementedException();
        }

        private void CambiarVista(object obj)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
