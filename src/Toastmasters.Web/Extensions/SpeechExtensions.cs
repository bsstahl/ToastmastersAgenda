using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toastmasters.Agenda.Entities;

namespace Toastmasters.Web.Extensions
{
    public static class SpeechExtensions
    {
        public static Speech Create(this Speech ignore, string name, string title, string evaluator, int speechType)
        {
            var result = new Toastmasters.Agenda.Entities.Speech();
            result.SpeakerName = name;
            result.Title = title;
            result.EvaluatorName = evaluator;

            if (speechType == 1)
            {
                result.SpeechType = "Icebreaker Speech (4 to 6 Minutes)";
                result.MinLengthMinutes = 4;
                result.MaxLengthMinutes = 6;
            }
            else if (speechType == 2)
            {
                result.SpeechType = "Prepared Speech (5 to 7 Minutes)";
                result.MinLengthMinutes = 5;
                result.MaxLengthMinutes = 7;
            }
            else if (speechType == 3)
            {
                result.SpeechType = "Extended Speech (8 to 10 Minutes)";
                result.MinLengthMinutes = 8;
                result.MaxLengthMinutes = 10;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(speechType));

            return result;
        }

    }
}
