using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Monitor.App
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando monitoramento...");

            Monitor.CadastroMonitor.IniciarMonitoramentoDeArquivos(@"C:\temp");

            while (Monitor.CadastroMonitor.IsMonitoring)
            {
                
            }

            Console.WriteLine("Finalizando monitoramento...");
        }
    }
}
