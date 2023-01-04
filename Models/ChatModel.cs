using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK.ChatData
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Message
    {
        public string participant_id { get; set; }
        public DateTime timestamp { get; set; }
        public string content { get; set; }
    }

    public class Participant
    {
        public string participant_id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class ChatModel
    {
        public List<Participant> participants { get; set; }
        public List<Message> messages { get; set; }
    }


}
