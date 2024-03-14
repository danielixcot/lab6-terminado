using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class DatosAlquiler
    {
        string nombre;
        string placa;
        string marca;
        string modelo;
        string color;
        string fechadev;
        int total;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public string Fechadev { get => fechadev; set => fechadev = value; }
        public int Total { get => total; set => total = value; }
    }
}
