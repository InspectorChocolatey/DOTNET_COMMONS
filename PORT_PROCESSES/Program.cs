namespace Basics
{
    using System;
    using System.Collections.Generic;
    
    class Program : PortManager
    {
        static void Main(string[] args)
        {
            List<Port> ports = PortManager.GetNetStatPorts();

            Console.WriteLine();

            foreach (Port port in PortManager.GetNetStatPorts())
            {
                string portname = port.name;
                string portnumber = port.port_number;
                string processname = port.process_name;
                string protocol = port.protocol;

                Console.WriteLine("Portname: {0}", portname);
                Console.WriteLine("Portnumber: {0}", portnumber);
                Console.WriteLine("Process Name: {0}", processname);
                Console.WriteLine("Protocol: {0}", protocol);
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
                if (port.port_number == portNumber)
                {
                    return port;
                }
                else
                {
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
