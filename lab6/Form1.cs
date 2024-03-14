using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab6
{
    public partial class Form1 : Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Cliente> Clientes = new List<Cliente>();
        List<Alquiler> alquilers = new List<Alquiler>();
        List<DatosAlquiler> datosAlquilers = new List<DatosAlquiler>();
        public Form1()
        {
            InitializeComponent();
        }
        public void CargarClientes()
        {
            // leer archivo y cargar la lista
            string fileName = "Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Cliente cliente = new Cliente();
                cliente.Nit = Convert.ToInt16(reader.ReadLine());
                cliente.Nombre = reader.ReadLine();
                cliente.Direccion = reader.ReadLine();

                Clientes.Add(cliente);
            }
            reader.Close();
        }
        public void CargarAlquileres()
        {
            // leer archivo y cargar la lista
            string fileName = "Alquileres.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Alquiler alquiler = new Alquiler();
                alquiler.Nit = Convert.ToInt32(reader.ReadLine());
                alquiler.Placa = reader.ReadLine();
                alquiler.FechaAlq = reader.ReadLine();
                alquiler.Fechadev = reader.ReadLine();  
                alquiler.Recorridos = Convert.ToInt32(reader.ReadLine());

                alquilers.Add(alquiler);
            }
            reader.Close();
        }
        public void CargarVehiculos()
        {
            // leer archivo y cargar la lista
            string fileName = "Vehiculos.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Placa = reader.ReadLine();
                vehiculo.Marca = reader.ReadLine();
                vehiculo.Modelo = reader.ReadLine();
                vehiculo.Color = reader.ReadLine();
                vehiculo.Kilometro = Convert.ToInt32(reader.ReadLine());

                vehiculos.Add(vehiculo);
            }
            reader.Close();
        }
        private void Guardar(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var vehiculo in vehiculos)
            {
                writer.WriteLine(vehiculo.Placa);
                writer.WriteLine(vehiculo.Marca);
                writer.WriteLine(vehiculo.Modelo);
                writer.WriteLine(vehiculo.Color);
                writer.WriteLine(vehiculo.Kilometro);
            }
            writer.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vehiculo nuevehiculo = new Vehiculo();
            nuevehiculo.Placa = textBox2.Text;
            nuevehiculo.Marca = textBox3.Text;
            nuevehiculo.Modelo = textBox4.Text;
            nuevehiculo.Color = textBox5.Text;
            nuevehiculo.Kilometro = Convert.ToInt32(textBox6.Text);
            vehiculos.Add(nuevehiculo);
            Guardar("Vehiculos.txt");
            borrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clientes.Clear();
            CargarClientes();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Clientes ;
            dataGridView1.Refresh();
            vehiculos.Clear();
            CargarVehiculos();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = vehiculos;
            dataGridView2.Refresh();
        }
        private void borrar()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             CargarAlquileres();
            datosAlquilers.Clear();
            foreach (Alquiler alquiler in alquilers)
            {
                Cliente cliente = Clientes.FirstOrDefault(c => c.Nit == alquiler.Nit);
                if (cliente != null)
                {
                    
                    Vehiculo vehiculo = vehiculos.FirstOrDefault(v => v.Placa == alquiler.Placa);
                    if (vehiculo != null)
                    {

                        DatosAlquiler datosAlquiler = new DatosAlquiler();
                        datosAlquiler.Nombre = cliente.Nombre;
                        datosAlquiler.Placa = vehiculo.Placa;
                        datosAlquiler.Marca = vehiculo.Marca;
                        datosAlquiler.Modelo = vehiculo.Modelo;
                        datosAlquiler.Color = vehiculo.Color;
                        datosAlquiler.Fechadev = alquiler.Fechadev;
                        datosAlquiler.Total = vehiculo.Kilometro * alquiler.Recorridos;
                        datosAlquilers.Add(datosAlquiler);

                    }
                    
                }
                
            }
            int mayor = alquilers.Max(a => a.Recorridos);
            DatosAlquiler datosAlquiler1 = datosAlquilers.OrderByDescending(a => a.Total).First();
            label1.Text = mayor.ToString();
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = datosAlquilers;
            dataGridView3.Refresh();

        }
    }
}
