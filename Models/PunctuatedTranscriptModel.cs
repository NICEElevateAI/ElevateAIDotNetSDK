using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.PunctuatedTranscriptResult
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class RedactionSegment
    {
        public int startTimeOffset { get; set; }
        public int endTimeOffset { get; set; }
        public string result { get; set; }
        public int score { get; set; }
    }

    public class PunctuatedTranscriptModel
    {
        public List<SentenceSegment> sentenceSegments { get; set; }
        public List<RedactionSegment> redactionSegments { get; set; }
    }

    public class SentenceSegment
    {
        public string participant { get; set; }
        public int startTimeOffset { get; set; }
        public int endTimeOffset { get; set; }
        public string phrase { get; set; }
        public double score { get; set; }
    }


}
