using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Extensions
{
    public static class StreamExtensions
    {
        public static void SaveToFile(this System.IO.Stream stream, string outputFilePath)
        {
            var writer = new System.IO.FileStream(outputFilePath, System.IO.FileMode.CreateNew);
            stream.CopyTo(writer);
            writer.Close();
        }

    }
}
