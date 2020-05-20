using System;
using System.Collections.Generic;
using System.IO;

namespace Music_Playlist_Analyzer {
    public static class MusicAnalyzerLoader {
        private static int NumItemsInRow = 8;

        public static List<Song> Load(string csvDataFilePath) {
            List<Song> songs = new List<Song>();

            try {
                using (var reader = new StreamReader(csvDataFilePath)) {
                    int lineNumber = 0;
                    while (!reader.EndOfStream) {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;
                        
                        var values = line.Split('\t');

                        if (values.Length != NumItemsInRow) {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try {
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            
                            Song song = new Song(name, artist, album, genre, size, time, year, plays);
                            songs.Add(song);
                        }
                        catch (FormatException e) {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            } catch (Exception e) {
                throw new Exception($"Unable to open {csvDataFilePath} ({e.Message}).");
            }
            return songs;
        }
    }
}