using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class Speech
    {
        public string SpeakerName { get; set; }
        public string Title { get; set; }
        public string SpeechType { get; set; }
        public string EvaluatorName { get; set; }
        public int MinLengthMinutes { get; set; }
        public int MaxLengthMinutes { get; set; }

    }
}
