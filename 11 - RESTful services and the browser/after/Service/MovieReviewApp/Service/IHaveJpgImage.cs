using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MovieReviewApp.Service
{
    public interface IHaveJpgImage
    {
        void WriteImage(Stream stream);
    }
}
