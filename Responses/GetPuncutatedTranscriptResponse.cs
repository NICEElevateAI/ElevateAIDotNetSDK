
using ElevateAI.SDK.PunctuatedTranscriptResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.Responses
{
    public class PunctuatedTranscriptResponse
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public PunctuatedTranscriptModel Transcript { get; set; }
    }
}
