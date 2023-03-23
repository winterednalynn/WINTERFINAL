using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINTERFINAL
{
    public class AestheticWinter
    {
        string _AestheticWinterTitle;
        string _ArtName;
        int _Year;
        string _Artist;
        string _ArtInformation;
       

        public AestheticWinter(string artName, string artist )
        {
            
            _ArtName = artName;
            //_Year = year; 
            _Artist = artist;
            //    _ArtStyle = artStyle; 
        }

        public string AestheticWinterTitle { get => _AestheticWinterTitle; set => _AestheticWinterTitle = value; }
        public string ArtName { get => _ArtName; set => _ArtName = value; }
        public string Artist { get => _Artist; set => _Artist = value; }
        public int Year { get => _Year; set => _Year = value; }
        public string artInformation { get => _ArtInformation; set => _ArtInformation = value; }

        public override string ToString()
        {
            return $" {_ArtName} {_Artist} "; 
        }
    }

    
    
}
