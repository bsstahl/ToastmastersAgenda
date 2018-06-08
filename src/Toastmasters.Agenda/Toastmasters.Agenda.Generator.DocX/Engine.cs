using DocumentFormat.OpenXml.Packaging;
using System;
using System.IO;
using Toastmasters.Agenda.Entities;

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
            var path = System.IO.Path.GetDirectoryName(fullPath);
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException($"Folder '{path}' does not exist.");

            var wpDoc = WordprocessingDocument.Open(_templatePath, true);
            var body = wpDoc.MainDocumentPart.Document.Body;
            
            foreach (var item in body.ChildElements)
            {
                Console.WriteLine(item.InnerXml);
            }

            wpDoc.SaveAs(destinationPath);

            throw new NotImplementedException();
        }
    }
}
