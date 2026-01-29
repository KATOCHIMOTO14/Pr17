using System;

namespace MusicCollectionApp
{
    public class MusicTrack
    {
       
        public string TrackTitle { get; set; }      
        public string Artist { get; set; }          
        public string Album { get; set; }           
        public int ReleaseYear { get; set; }        

        public MusicTrack()
        {
            TrackTitle = "";
            Artist = "";
            Album = "";
            ReleaseYear = DateTime.Now.Year;
        }
        /// <param name="title">Название композиции</param>
        /// <param name="artist">Исполнитель</param>
        /// <param name="album">Альбом</param>
        /// <param name="year">Год выпуска</param>
        public MusicTrack(string title, string artist, string album, int year)
        {
            TrackTitle = title;
            Artist = artist;
            Album = album;
            ReleaseYear = year;
        }

        public override string ToString()
        {
            return $"{TrackTitle} | {Artist} | {Album} | {ReleaseYear}";
        }
       
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(TrackTitle) &&
                   !string.IsNullOrWhiteSpace(Artist) &&
                   ReleaseYear >= 1900 &&
                   ReleaseYear <= DateTime.Now.Year + 1;
        }
    }
}