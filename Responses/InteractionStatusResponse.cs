using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.Responces
{
    public class InteractionStatusResponse
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public InteractionStatus InteractionStatus { get; set; }
    }
}
