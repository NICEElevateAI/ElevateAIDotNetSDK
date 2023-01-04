using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.Responces
{
    public class DeclareInteractionResponse
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public Guid? InteractionIdentifier { get; set; }
    }
}
