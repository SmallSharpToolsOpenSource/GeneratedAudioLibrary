using System;
using System.IO;

namespace GenerateAudioLibrary
{

    class Program
    {

        static void Main(string[] args)
        {
            var sourceFile = "C:\\Projects\\GeneratedAudioLibrary\\sample.mp3";
            var outputPath = "C:\\Projects\\GeneratedAudioLibrary\\Output";

            if (File.Exists(sourceFile))
            {
                var generator = new Generator(sourceFile, outputPath);
                generator.GenerateAudioLibrary();
            }
            else
            {
                Console.WriteLine("Unable to find source file: {0}", sourceFile);
            }
        }
    
    }

}
