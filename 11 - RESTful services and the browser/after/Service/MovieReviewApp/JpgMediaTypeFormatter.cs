using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using MovieReviewApp.Service;

namespace MovieReviewApp
{
    public class JpgMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public JpgMediaTypeFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpg"));
            this.AddQueryStringMapping("$format", "jpg", "image/jpg");
            this.AddMediaRangeMapping("image/*", "image/jpg");
        }
        
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(IHaveJpgImage).IsAssignableFrom(type);
        }

        public override void WriteToStream(Type type, object value, Stream stream, System.Net.Http.Headers.HttpContentHeaders contentHeaders)
        {
            IHaveJpgImage jpeg = (IHaveJpgImage)value;
            jpeg.WriteImage(stream);
        }
    }
}