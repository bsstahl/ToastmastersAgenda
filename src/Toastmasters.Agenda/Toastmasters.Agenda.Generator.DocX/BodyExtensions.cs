using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toastmasters.Agenda.Generator.DocX
{
    public static class BodyExtensions
    {
        internal static void AddOfficersNames(this Body body)
        {
            var officers = body.ChildElements.Where(e => e.LocalName == "sdt");
            foreach (var officer in officers)
            {
                string officerName = "This Officer"; // officer.InnerText.GetOfficerName();
                var content = officer.ChildElements.Where(e => e.LocalName == "sdtContent");
                officer.RemoveAllChildren();
                officer.AppendChild(new Paragraph
                    (
                        new ParagraphProperties() { ParagraphStyleId = new ParagraphStyleId() { Val = "OfficerName" } },
                        new Run(new Text() { Text = officerName })
                    ));
            }
        }

    }
}
