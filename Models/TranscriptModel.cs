using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.TranscriptResults
{


    public class Participant
    {
        public List<string> phrases { get; set; }
        public List<PhraseSegment> phraseSegments { get; set; }
    }

    public class RedactionSegment
    {
        public int startTimeOffset { get; set; }
        public int endTimeOffset { get; set; }
        public string result { get; set; }
        public double score { get; set; }
    }

    public class PhraseSegment
    {
        public int startTimeOffset { get; set; }
        public int endTimeOffset { get; set; }
        public int phraseIndex { get; set; }
        public double score { get; set; }
    }
    public class TranscriptModel
    {
        public Participant allParticipants { get; set; }
        public Participant participantTwo { get; set; }
        public Participant participantOne { get; set; }
        public List<RedactionSegment> redactionSegments { get; set; }
    }


}
