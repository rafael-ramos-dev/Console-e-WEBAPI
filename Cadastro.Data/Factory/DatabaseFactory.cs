using Cadastro.Data.Database;
using Cadastro.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Data.Factory
{
    public static class DatabaseFactory
    {
        public static ICustomDatabase BuildDatabase()
        {
            return new SqliteDatabase();
        }
    }
}
