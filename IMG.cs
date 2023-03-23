using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WINTERFINAL
{
    public class IMG
    {
        BitmapImage _image;
        string _content;

        public IMG(BitmapImage image, string content)
        {
            Image = image;
            Content = content;
        }
        public IMG(string filePath, string content)
        {
            _image = new BitmapImage(new Uri(filePath));
            _content = content; 
        }

        public BitmapImage Image { get => _image; set => _image = value; }
        public string Content { get => _content; set => _content = value; }
    }
}
