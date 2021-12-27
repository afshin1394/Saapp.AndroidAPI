using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Infra.Data.SqlServer.Common
{
    public class DatabaseOptions
    {
        public static string SectionName = "Database";
        public string ConnectionString { get; set; } = "your connectin string";
    }
}
