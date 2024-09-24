using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSQLite
{
    public class Customer
    {
        [PrimaryKey]
        [AutoIncrement]

        [Column("id")]
        public int Id { get; set; }

        [Column("Producto")]
        public string Producto { get; set; }

        [Column("Stock")]
        public string Stock { get; set; }

        [Column("Precio")]
        public string Precio { get; set; }

        [Column("Marca")]
        public string Marca { get; set; }

        [Column("Ventas")]
        public string Ventas { get; set; }

        [Column("Estado")]
        public string Estado { get; set; }
    }
}
