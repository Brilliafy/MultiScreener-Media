using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MultiScreener_Media
{
    public class ContentListing
    {
        public ContentListing(ImageSource path, string name)
        {
            Path = path;
            Name = name;
        }
        public ImageSource Path { get; set; }

        public string Name { get; set; }
    }
}
