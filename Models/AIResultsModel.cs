using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.AIResults
{
 
    public class AllParticipants
    {
        public List<EnlightenBundle> enlightenBundles { get; set; }
        public List<VoiceActivitySegment> voiceActivitySegments { get; set; }
    }

    public class EnlightenBundle
    {
        public string name { get; set; }
        public List<Model> models { get; set; }
    }

    public class Model
    {
        public string name { get; set; }
        public double score { get; set; }
        public double minScore { get; set; }
        public double minScoreOffset { get; set; }
        public double maxScore { get; set; }
        public double maxScoreOffset { get; set; }
        public double quartile1 { get; set; }
        public double quartile2 { get; set; }
        public double quartile3 { get; set; }
        public double quartile4 { get; set; }
    }

    public class Participant
    {
        public List<EnlightenBundle> enlightenBundles { get; set; }
        public List<VoiceActivitySegment> voiceActivitySegments { get; set; }
    }


    public class AIModel
    {
        public AllParticipants allParticipants { get; set; }
        public Participant participantOne { get; set; }
        public Participant participantTwo { get; set; }
    }

    public class VoiceActivitySegment
    {
        public int startTimeOffset { get; set; }
        public int endTimeOffset { get; set; }
        public string result { get; set; }
    }


}
