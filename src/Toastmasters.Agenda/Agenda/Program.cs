using System;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            string templatePath = @"..\..\..\..\..\..\Templates\Sample Agenda 3.docx";
            string outputFilePathFormat = @"..\..\..\..\..\..\..\..\..\Documents\Agendas\GeneratedAgenda_{0}.docx";

            string outputFilePath = string.Format(outputFilePathFormat, Guid.NewGuid().ToString());
            var meeting = new Toastmasters.Agenda.Entities.Meeting();
            // TODO: Set meeting properties

            var gen = new Toastmasters.Agenda.Generator.DocX.Engine(templatePath);
            gen.CreateAgenda(meeting, outputFilePath);
        }
    }
}
