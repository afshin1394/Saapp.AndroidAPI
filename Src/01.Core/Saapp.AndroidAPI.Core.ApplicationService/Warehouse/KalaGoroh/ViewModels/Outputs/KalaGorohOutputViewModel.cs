using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.ViewModels.Outputs
{
    public class KalaGorohOutputViewModel
    {
        public int ccKalaCode { get; set; }
        public string NameKala { get; set; }
        public int ccGoroh { get; set; }
        public string NameGoroh { get; set; }
        public byte? CodeNoeGoroh { get; set; }
        public int? ccGorohLink { get; set; }
        public int? ccRoot { get; set; }
        public string CodeGoroh { get; set; }
    }
}
