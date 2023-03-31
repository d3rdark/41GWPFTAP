using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PeliculasMVVM.Models;
using Newtonsoft.Json;
using GalaSoft.MvvmLight.Command;

namespace PeliculasMVVM.ViewModels
{
    public class PeliculasViewModel : INotifyPropertyChanged
    {
        

        public ObservableCollection<Pelicula> Lista { get; set; } = new ObservableCollection<Pelicula>();
        public IEnumerable<Pelicula> PeliculasOrdenadas => Lista.OrderByDescending(x => x.Año);

        private Pelicula? pelicula;

        public Pelicula? Pelicula
        {
            get { return pelicula; }
            set
            {
                pelicula = value;
                PropertyChange("Pelicula");
            }
        }

        public string Vista { get; set; } = "Ver";
        public string? Error { get; set; }

        public ICommand CancelarCommand { get; set; }
        public ICommand CambiarVistaCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand GuardarCommand { get; set; } //Guardad los cambios de edicion
        public ICommand EliminarCommand { get; set; }

        public PeliculasViewModel()
        {
            
            CargarArchivos();
            
            CancelarCommand = new RelayCommand(Cancelar);
            CambiarVistaCommand = new RelayCommand<string>(CambiarVista);
            AgregarCommand = new RelayCommand(Agregar);
            GuardarCommand = new RelayCommand(Guardar);
            EliminarCommand = new RelayCommand(Eliminar);
        }

        private void Guardar()
        {
            if(Pelicula != null)
            {
                Lista[posicionPeliculaEditar] = Pelicula;
                GuardarArchivo();
                Cancelar();
            }
        }

        private void Eliminar()
        {
            if (Pelicula != null)
            {
                Lista.Remove(Pelicula);
                GuardarArchivo();
                Cancelar();
            }
        }

        private void Agregar()
        {
            if (Pelicula != null)
            {
                //Validar

                if (string.IsNullOrWhiteSpace(Pelicula.Titulo))
                {
                    Error = "";
                    PropertyChange("Error");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Pelicula.Imagen))
                {
                    Error = "";
                    PropertyChange("Error");
                    return;
                }

                if (!Uri.TryCreate(Pelicula.Imagen, UriKind.Absolute, out var uri))
                {
                    Error = "";
                    PropertyChange("Error");
                    return;
                }

                Lista.Add(Pelicula);

                CambiarVista("Ver");
                GuardarArchivo();
            }
        }

        private void GuardarArchivo()
        {
            var json = JsonConvert.SerializeObject(Lista);
            File.WriteAllText("peliculas.json", json);
        }

        public void CargarArchivos()
        {
            if (File.Exists("peliculas.json"))
            {
                var json = File.ReadAllText("peliculas.json");
                var datos = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>?>(json);
                

                if (datos != null)
                {
                    
                    Lista = datos;
                   
                }
                else
                {
                    Lista = new ObservableCollection<Pelicula>();
                }
            }
        }

        int posicionPeliculaEditar;

        private void CambiarVista(string x)
        {
            Vista = x;

            if (Vista == "Agregar")
            {
                Pelicula = new Pelicula();
            }

            if (Vista == "Editar")
            {
                if (pelicula != null)
                {
                    Pelicula clon = new Pelicula()
                    {
                        Año = pelicula.Año, 
                        Genero = pelicula.Genero, 
                        Imagen = pelicula.Imagen,
                        Sinopsis = pelicula.Sinopsis,
                        Titulo = pelicula.Titulo
                    };

                    posicionPeliculaEditar = Lista.IndexOf(pelicula); //el indice en la lista de la pelicula selccionada

                    pelicula = clon;
                }
            }
            PropertyChange();
        }

        private void Cancelar()
        {
            CambiarVista("Ver");
            Pelicula = null;
        }

        void PropertyChange(string? propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
