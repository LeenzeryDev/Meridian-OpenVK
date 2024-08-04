using System;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;

namespace VkLib.Core.Audio
{
    public class User
    {
        public int id { get; set; }
        public string photo { get; set; }
        public string name { get; set; }
        public string name_gen { get; set; }
    }

    /// <summary>
    /// Audio
    /// <seealso cref="http://vk.com/dev/audio_object"/>
    /// </summary>
    public class VkAudio
    {
        public string Unique_id { get; set; }
        public int Aid { get; set; }
        public object Album { get; set; }
        public bool Manifest { get; set; }
        public bool Keys { get; set; }
        public int Genre { get; set; }
        public string Genre_str { get; set; }
        public int? Lyrics { get; set; }
        public bool Added { get; set; }
        public bool Editable { get; set; }
        public bool Searchable { get; set; }
        public bool Explicit { get; set; }
        public bool Withdrawn { get; set; }
        public bool Ready { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Owner id
        /// </summary>
        public long Owner_Id { get; set; }

        /// <summary>
        /// Album id
        /// </summary>
        public long AlbumId { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Artist
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Lyrics id
        /// </summary>
        public long LyricsId { get; set; }

        /// <summary>
        /// Genre id
        /// <seealso cref="http://vk.com/dev/audio_genres"/>
        /// </summary>
        public long GenreId { get; set; }

        internal static VkAudio FromJson(JToken json)
        {
            if (json == null)
                throw new ArgumentException("Json can not be null.");

            var result = new VkAudio();

            result.Aid = (int)json["aid"];
            
            result.Owner_Id = json["owner_id"].Value<long>();
            result.Duration = TimeSpan.FromSeconds(json["duration"].Value<double>());
            result.Url = json["url"].Value<string>();

            try
            {
                result.Title = WebUtility.HtmlDecode(json["title"].Value<string>()).Trim();
                result.Artist = WebUtility.HtmlDecode(json["artist"].Value<string>()).Trim();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                result.Title = json["title"].Value<string>().Trim();
                result.Artist = json["artist"].Value<string>().Trim();
            }

            if (json["genre_id"] != null)
                result.GenreId = json["genre_id"].Value<long>();

            return result;
        }
    }
}
