using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK
{ 
    public class InteractionStatus
    {
        public string identifier { get; set; }
        public string status { get; set; }
        public DateTime declared { get; set; }
        public object? uploaded { get; set; }
        public DateTime? downloaded { get; set; }
        public DateTime? processed { get; set; }
        public object errorMessage { get; set; }
    }
}
