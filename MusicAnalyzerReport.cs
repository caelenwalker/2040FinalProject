using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Music_Playlist_Analyzer {
    public static class MusicAnalyzerReport {
        public static string GenerateText(List<Song> songs) {
            string report = "*** Music Playlist Report ***\n\n";

            if(songs.Count() < 1) {
                report += "No data available.\n";
                return report;
            }

            report += $"Songs that received 200 or more plays: \n";
            var plays = from song in songs where song.Plays > 200 select song;
            if (plays.Count() > 0) {
                foreach(var x in plays) {
                    report += x.ToString() + "\n";
                }
            }
            else {
                report += "Not available\n";
            }

            report += $"\nNumber of Alternative songs: ";
            var altGenre = from song in songs where song.Genre == "Alternative" select song;
            report += altGenre.Count() + "\n";

            report += $"\nNumber of Hip-Hop/Rap songs: ";
            var rapGenre = from song in songs where song.Genre == "Hip-Hop/Rap" select song;
            report += rapGenre.Count() + "\n";
        
            report += $"\nSongs from the album Welcome to the Fishbowl: \n";
            var album = from song in songs where song.Album == "Welcome to the Fishbowl" select song;
            if (album.Count() > 0) {
                foreach(var x in album) {
                    report += x.ToString() + "\n";
                }
            }
            else {
                report += "Not available\n";
            }

            report += $"\nSongs from before 1970: \n";
            var year = from song in songs where song.Year < 1970 select song;
            if (year.Count() > 0) {
                foreach(var x in year) {
                    report += x.ToString() + "\n";
                }
            }
            else {
                report += "Not available\n";
            }

            report += $"\nSong names longer than 85 characters: \n";
            var songSize = from song in songs where song.Name.Count() > 85 select song;
            if (songSize.Count() > 0) {
                foreach(var x in songSize) {
                    report += x.ToString() + "\n";
                }
            }
            else {
                report += "Not available\n";
            }
            
            var longestSong = from song in songs where song.Size == ((from stats in songs select stats.Size).Max()) select song;
            report += $"\nLongest song: \n";
            if (longestSong.Count() > 0) {
                foreach(var x in longestSong) {
                    report += x.ToString() + "\n";
                }
            }
            else {
                report += "Not available\n";
            }
            return report;
        }
    }
}