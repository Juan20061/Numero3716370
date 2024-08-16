using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numero3716370
{
    [SQLite.Table("signo")]
    public class Signo
    {
        [PrimaryKey]
        [AutoIncrement]
        [SQLite.Column("id")]
        public int id { get; set; }

        [SQLite.Column("numero")]
        public string? Numero { get; set; }

        [SQLite.Column("determinado")]
        public string? Determinado { get; set; }
        


    }
}
