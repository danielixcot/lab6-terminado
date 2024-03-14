using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Alquiler
    {
        int nit;
        string placa;
        string fechaAlq;
        string fechadev;
        int recorridos;

        public int Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public string FechaAlq { get => fechaAlq; set => fechaAlq = value; }
        public string Fechadev { get => fechadev; set => fechadev = value; }
        public int Recorridos { get => recorridos; set => recorridos = value; }
    }
}
