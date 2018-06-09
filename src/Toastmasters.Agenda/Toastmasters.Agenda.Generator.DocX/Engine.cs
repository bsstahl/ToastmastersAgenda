using System;
using System.IO;
using Toastmasters.Agenda.Entities;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.Linq;

namespace Toastmasters.Agenda.Generator.DocX
{
    public class Engine : Interfaces.IAgendaGenerator
    {
        string _templatePath;

        public Engine(string templatePath)
        {
            _templatePath = templatePath;
        }

        public void CreateAgenda(Meeting meeting, string destinationPath)
        {
            var fullPath = System.IO.Path.GetFullPath(destinationPath);
            fullPath.ValidateDestinationPath();

            using (var wpDoc = WordprocessingDocument.Open(_templatePath, true))
            {
                var body = wpDoc.MainDocumentPart.Document.Body;
                body.AddOfficersNames();

                wpDoc.SaveAs(destinationPath);
            }
        }

    }
}
