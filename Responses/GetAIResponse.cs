using ElevateAI.SDK.AIResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.Responses
{
    public class AIResponse
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public AIModel AIResults { get; set; }
    }
}
