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
            var path = System.IO.Path.GetDirectoryName(fullPath);
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException($"Folder '{path}' does not exist.");

            using (var wpDoc = WordprocessingDocument.Open(_templatePath, true))
            {
                var body = wpDoc.MainDocumentPart.Document.Body;
                body.AddOfficersNames();

                //foreach (var item in body.ChildElements)
                //{
                //    Console.WriteLine(item.InnerXml);
                //    Console.WriteLine();
                //}

                wpDoc.SaveAs(destinationPath);
            }
        }

        private static void CreateDocument(WordprocessingDocument wpDoc)
        {
            var mainPart = wpDoc.AddMainDocumentPart();
            mainPart.Document = new Document();

            var body = mainPart.Document.AppendChild(new Body());

            var p1 = body.AppendChild(new Paragraph());
            var p1Pr = p1.AppendChild(new ParagraphProperties()
            {
                SpacingBetweenLines = new SpacingBetweenLines()
                {
                    After = "0",
                    Line = "240",
                    LineRule = LineSpacingRuleValues.Auto
                },
                SectionProperties = new SectionProperties
                (
                    new PageSize() { Width = 12240, Height = 15840 },
                    new PageMargin()
                    {
                        Top = 288,
                        Right = 288,
                        Bottom = 288,
                        Left = 288,
                        Header = 720,
                        Footer = 720,
                        Gutter = 0
                    },
                    new Columns() { Space = "720" },
                    new DocGrid() { LinePitch = 360 }
                )
            });

            var banner = mainPart.AddImagePart(ImagePartType.Jpeg);
            using (var stream = new FileStream(@".\Images\Toastmasters Banner.jpg", FileMode.Open))
                banner.FeedData(stream);
            AddImageToBody(wpDoc, mainPart.GetIdOfPart(banner));

            var r = p1.AppendChild(new Run());
            var t = r.AppendChild(new Text() { Text = "President" });
        }

        private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 7406640L, Cy = 1346835L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Toastmaster Banner"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "Toastmaster Banner.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId //,
                                             // CompressionState = A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 7406640L, Cy = 1346835L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            // Append the reference to body, the element should be in a Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
        }
    }
}
