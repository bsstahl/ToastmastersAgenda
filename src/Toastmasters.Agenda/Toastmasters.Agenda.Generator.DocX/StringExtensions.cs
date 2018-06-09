using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Generator.DocX
{
    public static class StringExtensions
    {
        internal static void ValidateDestinationPath(this string fullPath)
        {
            var path = System.IO.Path.GetDirectoryName(fullPath);
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException($"Folder '{path}' does not exist.");
        }

    }
}
