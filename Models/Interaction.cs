using ElevateAI.SDK.TranscriptResults;
using ElevateAI.SDK.ChatData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK
{
    public class Interaction
    {
        public string type { get; set; }
        public string languageTag { get; set; }
        public string vertical { get; set; }
        public string audioTranscriptionMode { get; set; }
        public bool includeAiResults { get; set; }
        public Uri? downloadUri { get; set; }
	public string? originalFilename {get; set;}
	public string? externalIdentifier {get; set;}
        public TranscriptModel? transcript { get; set; }
        public ChatModel? chat { get; set; }

    }

    public class InteractionDeclareResponse
    {
        public string interactionIdentifier { get; set; }
    }
}
