using System;
using System.IO;
using IdSharp.Tagging.ID3v2;

namespace GenerateAudioLibrary
{

    public class Generator
    {

        public string SourceFile { get; set; }
        public string OutputPath { get; set; }

        public Generator(string sourceFile, string outputPath)
        {
            SourceFile = sourceFile;
            OutputPath = outputPath;

            try
            {
                GenerateAudioLibrary();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        public void GenerateAudioLibrary()
        {
            var index1 = 0;
            var index2 = 0;
            var index3 = 0;
            var index4 = 0;

            var token = "";
            var artist = "";
            var album = "";
            var song = "";

            int lastIndex = 25; // full alphabet
            //int lastIndex = 2; // only A, B, C

            while (index1 <= lastIndex)
            {
                while (index2 <= lastIndex)
                {
                    Console.WriteLine(Char.ConvertFromUtf32(index1 + 65) + Char.ConvertFromUtf32(index2 + 65));
                    while (index3 <= 4)
                    {
                        while (index4 <= 9)
                        {
                            token = Char.ConvertFromUtf32(index1 + 65) + Char.ConvertFromUtf32(index2 + 65);
                            artist = token + " Artist";
                            album = token + " Album " + (index3 + 1);
                            song = album + " Song " + (index4 + 1);

                            CreateAudioFile(artist, album, song);

                            index4++;
                        }
                        index3++;
                        index4 = 0;
                    }
                    index2++;
                    index3 = 0;
                }
                index1++;
                index2 = 0;
            }
        }

        private void CreateAudioFile(string artist, string album, string song)
        {
            var outputDirectoryPath = Path.Combine(OutputPath, artist, album);
            var outputFilePath = Path.Combine(outputDirectoryPath, song + ".mp3");

            if (File.Exists(outputFilePath))
            {
                return;
            }

            if (!Directory.Exists(outputDirectoryPath))
            {
                Directory.CreateDirectory(outputDirectoryPath);
            }

            //if (File.Exists(outputFilePath))
            //{
            //    File.Delete(outputFilePath);
            //}

            File.Copy(SourceFile, outputFilePath);

            var tag = new ID3v2Tag(outputFilePath);
            tag.Artist = artist;
            tag.Album = album;
            tag.AlbumArtist = artist;
            tag.Title = song;

            tag.Save(outputFilePath);
        }

    }

}
