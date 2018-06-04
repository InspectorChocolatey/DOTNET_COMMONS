namespace DOTNET_COMMONS
{
    using System;

    class Program : PortManager
    {
        static void Main(string[] args)
        {
            foreach (Port port in PortManager.GetNetStatPorts())
            {
                Console.WriteLine("Portname: {0}", port.name);
                Console.WriteLine("Portnumber: {0}", port.port_number);
                Console.WriteLine("Process Name: {0}", port.process_name);
                Console.WriteLine("Protocol: {0}", port.protocol);
            }
            Wait(); // Once user hits enter, grab the info regarding a specified port number
            string portNumber = "135";
            if (GetPort(portNumber) != null)
            {
                Console.WriteLine(GetPort(portNumber).process_name);
                Console.WriteLine(GetPort(portNumber).port_number);
                Console.WriteLine(GetPort(portNumber).name);
                Console.WriteLine(GetPort(portNumber).protocol);
            }
            Wait(); // Once the user hits enter, exit the application
        }

        public static Port GetPort(string portNumber)
        {
            foreach (Port port in PortManager.GetNetStatPorts())
            {
                if (port.port_number == portNumber) {
                    return port;
                } else {
                    continue;
                }
            }
            return null;
        }

        public static void Wait()
        {
            Console.ReadKey();
        }
    }
}
