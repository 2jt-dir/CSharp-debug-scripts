#nullable enable

using System;
using System.IO;

namespace jt2.debug_helper_extensions
{
    static class Object_extensions
    {
        static string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void DumpObject(this object x, string? prepend = null, string? postscript = null) {
            var jsonString = prepend + Newtonsoft.Json.JsonConvert.SerializeObject(x);
            var outputString = (prepend ?? "") + jsonString;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"),true))
            {
                outputFile.WriteLine(outputString);
                if (postscript is object) outputFile.WriteLine(postscript);
            }
        }

        public static void DumpString(this string xString, string? prepend = null, string? postscript = null) {
            var outputString = (prepend ?? "") + xString;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"),true))
            {
                outputFile.WriteLine(outputString);
                if (postscript is object) outputFile.WriteLine(postscript);
            }
        }
    }
}
