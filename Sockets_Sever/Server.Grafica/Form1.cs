using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Grafica
{
    public partial class Form1 : Form
    {
        int Grafica=250;// Variable de la grafica, para variar el ancho de la muestra
        Socket miPrimerSocket = null;
        IPEndPoint miDireccion = null;
        Socket Escuchar = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Lb_estado.Text = "sin estado ..";
            Lb_estado.BackColor = Color.Red;


            miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // paso 2 - creamos el socket
            miDireccion = new IPEndPoint(IPAddress.Any, 1234);

            //paso 3 - IPAddress.Any significa que va a escuchar al cliente en toda la red

            // paso 4
            miPrimerSocket.Bind(miDireccion); // Asociamos el socket a miDireccion

            miPrimerSocket.Listen(10); // Lo ponemos a escucha

            Console.WriteLine("Escuchando...");
            Lb_estado.Text = "Escuchando ..";
            Lb_estado.BackColor = Color.Orange;
            Escuchar = miPrimerSocket.Accept();
        }



        public  void Conectar()
        {
             
            try
            {
                //creamos el nuevo socket, para comenzar a trabajar con él
                //La aplicación queda en reposo hasta que el socket se conecte a el cliente
                //Una vez conectado, la aplicación sigue su camino 

                Console.WriteLine("Conectado con exito");
                Lb_estado.Text = "Conectado con Éxito";
                Lb_estado.BackColor = Color.Green;


                byte[] byRec = new byte[1024];
                int newSize = Escuchar.Receive(byRec, 0, byRec.Length, 0);
                Array.Resize(ref byRec, newSize);
                string result = Encoding.Default.GetString(byRec);
                Console.WriteLine($"El cliente dice: {result}");

                //Thread.Sleep(1000);

                graficoRendimiento.Series["WIFI"].Points.AddY(result);
                // En cuanto tenemos la cantidad de datos necesarios para la lectura...
                // Comenzamos a borrar la gráfica para que no se aglutinen los trazos.

                if (graficoRendimiento.Series["WIFI"].Points.Count > Grafica)
                {
                    // Borra desde X = 0.
                    graficoRendimiento.Series["WIFI"].Points.RemoveAt(0);
                }
                
                miPrimerSocket.Close(); //Luego lo cerramos
                //miPrimerSocket.Close(); //Luego lo cerramos

            }

            catch (Exception error)
            {
               

                Console.WriteLine("Error: {0}", error.ToString());

            }

            Console.WriteLine("Presione cualquier tecla para terminar");

        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            iniciarTimer.Enabled = true;//Empiece a graficar
            btnEncender.Text = "conectado";
        }

        private void iniciarTimer_Tick(object sender, EventArgs e)
        {
            Conectar();
        }
    }
}
