#nullable enable

using System;
using System.IO;

namespace jt2.debug_helper_extensions
{
    static class To_json_extensions
    {
        static string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static string ObjectToJson(this object x, string? prepend = null, string? postscript = null) {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(x);
            string returnString = $"{prepend ?? ""}{jsonString}\n{postscript}";
            return jsonString;
        }
    }

    static class Dump_to_textFile_extensions
    {
        static string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void DumpObject(this object x, string? prepend = null, string? postscript = null) {
            var jsonString = (prepend ?? "") + Newtonsoft.Json.JsonConvert.SerializeObject(x);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"),true))
            {
                outputFile.WriteLine(jsonString);
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
