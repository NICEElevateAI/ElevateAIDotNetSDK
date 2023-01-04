using ElevateAI.SDK.TranscriptResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.Responces
{
    public class TranscriptResponse
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public TranscriptModel Transcript { get; set; }
    }
}
