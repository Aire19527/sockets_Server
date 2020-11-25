using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;               //   Paso 1
using System.Net.Sockets;
using System.Text;

namespace Test.Sockets
{

    class Program
    {


        // do in ctor or some init method

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

          
            Conectar();


        }

        public static void Conectar()
        {

            Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // paso 2 - creamos el socket
            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Any, 1234);

            //paso 3 -IPAddress.Any significa que va a escuchar al cliente en toda la red

            try
            {
                // paso 4
                miPrimerSocket.Bind(miDireccion); // Asociamos el socket a miDireccion

                miPrimerSocket.Listen(10); // Lo ponemos a escucha

                Console.WriteLine("Escuchando...");

                Socket Escuchar = miPrimerSocket.Accept();

                //creamos el nuevo socket, para comenzar a trabajar con él

                //La aplicación queda en reposo hasta que el socket se conecte a el cliente

                //Una vez conectado, la aplicación sigue su camino 

                Console.WriteLine("Conectado con exito");



                /*Aca ponemos todo lo que queramos hacer con el socket, osea antes de

                cerrarlo je*/

                while (true)
                {
                    byte[] byRec = new byte[1024];
                    int newSize = Escuchar.Receive(byRec, 0, byRec.Length, 0);
                    Array.Resize(ref byRec, newSize);

                    Console.WriteLine($"El cliente dice: {Encoding.Default.GetString(byRec)}");

                    Thread.Sleep(1000);
                }
            

                miPrimerSocket.Close(); //Luego lo cerramos
            }

            catch (Exception error)

            {

                Console.WriteLine("Error: {0}", error.ToString());

            }

            Console.WriteLine("Presione cualquier tecla para terminar");

        }





        public static void ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}.{1}     ",
                    computerProperties.HostName, computerProperties.DomainName);


            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return;
            }

            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            foreach (NetworkInterface adapter in nics)
            {
                var res = adapter.Speed;

                Console.WriteLine("Velocidad internet: " + res);
                IPInterfaceProperties properties = adapter.GetIPProperties();
                Console.WriteLine();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Physical Address ........................ : {0}",
                           adapter.GetPhysicalAddress().ToString());
                Console.WriteLine("  Operational status ...................... : {0}",
                    adapter.OperationalStatus);
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                Console.WriteLine("  IP version .............................. : {0}", versions);
                //  ShowIPAddresses(properties);

                // The following information is not useful for loopback adapters.
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }
                Console.WriteLine("  DNS suffix .............................. : {0}",
                    properties.DnsSuffix);

                string label;
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                    Console.WriteLine("  MTU...................................... : {0}", ipv4.Mtu);
                    if (ipv4.UsesWins)
                    {

                        IPAddressCollection winsServers = properties.WinsServersAddresses;
                        if (winsServers.Count > 0)
                        {
                            label = "  WINS Servers ............................ :";
                            //  ShowIPAddresses(label, winsServers);
                        }
                    }
                }

                Console.WriteLine("  DNS enabled ............................. : {0}",
                    properties.IsDnsEnabled);
                Console.WriteLine("  Dynamically configured DNS .............. : {0}",
                    properties.IsDynamicDnsEnabled);
                Console.WriteLine("  Receive Only ............................ : {0}",
                    adapter.IsReceiveOnly);
                Console.WriteLine("  Multicast ............................... : {0}",
                    adapter.SupportsMulticast);
                //ShowInterfaceStatistics(adapter);

                Console.WriteLine();
            }
        }

        public static void ShowIPStatistics(NetworkInterfaceComponent version)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat = null;
            switch (version)
            {
                case NetworkInterfaceComponent.IPv4:
                    ipstat = properties.GetIPv4GlobalStatistics();
                    Console.WriteLine("{0}IPv4 Statistics ", Environment.NewLine);
                    break;
                case NetworkInterfaceComponent.IPv6:
                    ipstat = properties.GetIPv4GlobalStatistics();
                    Console.WriteLine("{0}IPv6 Statistics ", Environment.NewLine);
                    break;
                default:
                    throw new ArgumentException("version");
                    //    break;
            }
            Console.WriteLine("  Forwarding enabled ...................... : {0}", ipstat.ForwardingEnabled);
            Console.WriteLine("  Interfaces .............................. : {0}", ipstat.NumberOfInterfaces);
            Console.WriteLine("  IP addresses ............................ : {0}", ipstat.NumberOfIPAddresses);
            Console.WriteLine("  Routes .................................. : {0}", ipstat.NumberOfRoutes);
            Console.WriteLine("  Default TTL ............................. : {0}", ipstat.DefaultTtl);
            Console.WriteLine("");
            Console.WriteLine("  Inbound Packet Data:");
            Console.WriteLine("      Received ............................ : {0}", ipstat.ReceivedPackets);
            Console.WriteLine("      Forwarded ........................... : {0}", ipstat.ReceivedPacketsForwarded);
            Console.WriteLine("      Delivered ........................... : {0}", ipstat.ReceivedPacketsDelivered);
            Console.WriteLine("      Discarded ........................... : {0}", ipstat.ReceivedPacketsDiscarded);
            Console.WriteLine("      Header Errors ....................... : {0}", ipstat.ReceivedPacketsWithHeadersErrors);
            Console.WriteLine("      Address Errors ...................... : {0}", ipstat.ReceivedPacketsWithAddressErrors);
            Console.WriteLine("      Unknown Protocol Errors ............. : {0}", ipstat.ReceivedPacketsWithUnknownProtocol);
            Console.WriteLine("");
            Console.WriteLine("  Outbound Packet Data:");
            Console.WriteLine("      Requested ........................... : {0}", ipstat.OutputPacketRequests);
            Console.WriteLine("      Discarded ........................... : {0}", ipstat.OutputPacketsDiscarded);
            Console.WriteLine("      No Routing Discards ................. : {0}", ipstat.OutputPacketsWithNoRoute);
            Console.WriteLine("      Routing Entry Discards .............. : {0}", ipstat.OutputPacketRoutingDiscards);
            Console.WriteLine("");
            Console.WriteLine("  Reassembly Data:");
            Console.WriteLine("      Reassembly Timeout .................. : {0}", ipstat.PacketReassemblyTimeout);
            Console.WriteLine("      Reassemblies Required ............... : {0}", ipstat.PacketReassembliesRequired);
            Console.WriteLine("      Packets Reassembled ................. : {0}", ipstat.PacketsReassembled);
            Console.WriteLine("      Packets Fragmented .................. : {0}", ipstat.PacketsFragmented);
            Console.WriteLine("      Fragment Failures ................... : {0}", ipstat.PacketFragmentFailures);
            Console.WriteLine("");
        }
    }
}
