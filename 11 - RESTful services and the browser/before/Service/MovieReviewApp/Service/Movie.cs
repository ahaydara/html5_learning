using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieReviewApp.Service
{
    public class Movie : IHaveJpgImage
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Rating { get; set; }
        [Range(1900, 2050)]
        public int YearReleased { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        
        internal string PosterName { get; set; }

        public void WriteImage(Stream stream)
        {
            if (PosterName == null) return;

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content\\Posters");
            path = Path.Combine(path, this.PosterName);
            if (!File.Exists(path)) return;
            using (var fs = File.OpenRead(path))
            {
                fs.CopyTo(stream);
            }
        }
    }
}