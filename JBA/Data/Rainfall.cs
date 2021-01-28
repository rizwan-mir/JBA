using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBA.Data
{
    class Rainfall
    {
        [Key]
        public int Id { get; set; }
        public int Xref { get; set; }
        public int Yref { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
