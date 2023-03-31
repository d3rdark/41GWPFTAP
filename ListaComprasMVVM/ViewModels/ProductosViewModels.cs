using ListaComprasMVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;

namespace ListaComprasMVVM.ViewModels
{
    public class ProductosViewModels : INotifyPropertyChanged
    {
        public ObservableCollection<Producto> Productos { get; set; } = new ObservableCollection<Producto>();

        public Producto? Producto { get; set; }

        public string? Error { get; set; }

        public ICommand AgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand EditarCommand { get; set; }

        public ICommand CancelarCommand { get; set; }
        public ICommand CambiarVistaCommand { get; set; }

        public string Vista { get; set; } = "ver";

        public ProductosViewModels()
        {
            Abri();
            AgregarCommand = new RelayCommand(Agregar);
            CancelarCommand = new RelayCommand(Cancelar);
            CambiarVistaCommand = new RelayCommand<string>(CambiarVista);
            EliminarCommand = new RelayCommand(Eliminar);
            EditarCommand = new RelayCommand(Editar);
        }

        int posicionOriginal;

        private void CambiarVista(string obj)
        {
            Vista = obj;
            if (obj == "agregar")
            {
                Producto = new Producto();
            }
            else if (obj == "editar")
            {
                if (Producto != null)
                {
                    //clonar el objeto original
                    posicionOriginal = Productos.IndexOf(Producto);

                    var clon = new Producto()
                    {
                        Cantidad = Producto.Cantidad,
                        Descripcion = Producto.Descripcion
                    };
                    Producto = clon;
                }
            }


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vista)));
        }

        private void Cancelar()
        {
            Producto = null;
            Vista = "ver";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vista"));
        }

        void Agregar()
        {
            if (Producto != null)
            {
                Error = "";

                //Validar

                if (string.IsNullOrWhiteSpace(Producto.Cantidad))
                {
                    Error = "Escribir la cantidad del producto";
                }

                if (string.IsNullOrWhiteSpace(Producto.Descripcion))
                {
                    Error = "Escribir la descripcion del producto";
                }

                //Agregar

                if (Error == "") //Si es valido
                {
                    Productos.Add(Producto);
                    Vista = "ver";
                    Guardad();
                }

                //Guardar

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

            }
        }

        void Editar()
        {
            if (Producto != null)
            {
                Productos[posicionOriginal] = Producto;
                Guardad();
                CambiarVista("ver");
            }
        }

        void Eliminar()
        {
            /*Verificamos que el producto no sea nulo, despues 
             de utiliza el metodo remove
             de la lista Productos. Guardamos los datos 
            con el metodo Guardar();. 
            Despues cambiamos la vista con el metodo 
            CambiarVista utilizando el parametro ver
            Que es de tipo string.*/
            if (Producto != null)
            {
                Productos.Remove(Producto);
                Guardad();
                CambiarVista("ver");
            }
        }

        void Guardad()
        {
            var json = JsonConvert.SerializeObject(Productos);
            File.WriteAllText("productos.json", json);
        }

        void Abri()
        {
            if (File.Exists("productos.json"))
            {
                var json = File.ReadAllText("productos.json");
                var datos = JsonConvert.DeserializeObject<ObservableCollection<Producto>>(json);

                if (datos == null)
                {
                    Productos = new ObservableCollection<Producto>();
                }
                else
                {
                    Productos = datos;
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
