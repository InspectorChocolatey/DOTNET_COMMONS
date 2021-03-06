﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.Text;

namespace TrackingClients
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IStackCalculator
    {
        [OperationContract]
        void Enter(double value);
        [OperationContract]
        double Add();
        [OperationContract]
        double Subtract();
        [OperationContract]
        double Multiply();
        [OperationContract]
        double Divide();
    }
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class StackCalculator : IStackCalculator
    {
        Stack<double> values = new Stack<double>();
        public void Enter(double value)
        {
            this.values.Push(value);
            Trace("Adding {0} to stack - {1}", value, GetStack());
        }

        public double Add()
        {
            return this.Process((x, y) => x + y, "+");
        }

        public double Subtract()
        {
            return this.Process((x, y) => x - y, "-");
        }

        public double Multiply()
        {
            return this.Process((x, y) => x * y, "*");
        }

        public double Divide()
        {
            return this.Process((x, y) => x / y, "/");
        }

        private double Process(Func<double, double, double> operation, string symbol)
        {
            double op2 = this.values.Pop();
            double op1 = this.values.Pop();
            double result = operation(op1, op2);
            this.values.Push(result);
            Trace("{0} {1} {2} = {3} - {4}", op1, symbol, op2, result, GetStack());
            return result;
        }

        private void Trace(string format, params object[] args)
        {
            string text = string.Format(CultureInfo.InvariantCulture, format, args);
            Console.WriteLine("[{0} client(s) connected] {1}", ClientTrackerChannelInitializer.ConnectedClientCount, text);
        }

        private string GetStack()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            sb.Append(string.Join(", ", this.values));
            sb.Append(']');
            return sb.ToString();
        }
    }
}
