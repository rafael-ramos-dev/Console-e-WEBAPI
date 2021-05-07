using Cadastro.Data.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Data.Database
{
    public class SqliteDatabase : ICustomDatabase
    {
        SqliteConnection _connection;
        public SqliteDatabase()
        {
            this._connection = new SqliteConnection(@"Data Source=db\Cliente.db");
        }
        

        public IDbConnection GetCurrentConnection()
        {
            return _connection;
        }
    }
}
