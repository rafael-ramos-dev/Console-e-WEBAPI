using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Monitor.App.Monitor
{

    public static class CadastroMonitor
    {
        static  FileSystemWatcher _fileWatcher;

        private static bool _IsMonitoring = false;
        public static bool IsMonitoring
        {
            get { return _IsMonitoring; }
        }
        static CadastroMonitor()
        {
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Created += _fileWatcher_Created;
        }

        private static void _fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Cadastrando arquivo: {e.FullPath}");
            Cadastro.CadastroManager.DoCadastro(e.FullPath);
        }

        public static void IniciarMonitoramentoDeArquivos(string DiretorioDeMonitoramento, string Filter = "*.*")
        {
            _fileWatcher.Path = DiretorioDeMonitoramento;
            _fileWatcher.Filter = Filter;
            _fileWatcher.IncludeSubdirectories = true;
            _fileWatcher.EnableRaisingEvents = true;

            _IsMonitoring = true;
        }

        public static void FinalizarMonitoramentoDeArquivos()
        {
            _fileWatcher.IncludeSubdirectories = false;
            _fileWatcher.EnableRaisingEvents = false;
            _IsMonitoring = false;
        }


    }
}
