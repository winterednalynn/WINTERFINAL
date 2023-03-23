using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace WINTERFINAL
{//EDNA LYNN LAXA 
// MARCH 15, 2023 
// CSI PROGRAMMING II 
// WINTER FINAL 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlowDocument fdDisplay = new FlowDocument();
        List<AestheticWinter> WinterArt = new List<AestheticWinter>();
        OpenFileDialog op = new OpenFileDialog();
        List<IMG> LoadPictures = new List<IMG>(); 

     
        


        public MainWindow()
        {
            InitializeComponent();
            TitleImage(); // Made title image 
            DisplayList(); // Calling Display List Method 
            Preload(); // Calling Preload (ListView) 
           
         


        }
        public void TitleImage() // Structure for title image. 
        {
            // File explorer diaglog. Detects file addresses 
            OpenFileDialog op = new OpenFileDialog();

            //Make a selection will prompt at the upper left header when file open. 
            op.Title = "Make A Selection";

            //Targeted file format. 
            op.Filter = "Choose Image that contains | *.jpg; *.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpege)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png) | *.png";

            //Translating my string (Location of image) to an image. 
            string filePath = @"C:\School\Programming 122\WINTERFINAL\WinterFinalTItle.jpg";
            imgWinterDisplay.Source = new BitmapImage(new Uri(filePath));
        }



        private void btnSubmitArtwork_Click(object sender, RoutedEventArgs e) //SUBMIT ARTWORK BUTTON
        {

            FormattedRunDisplay(); // When submit button queues an event , method formatted rundisplay is prompt. 
          





        }

        private void Button_Click(object sender, RoutedEventArgs e) // SELECT IMAGE BUTTON 
        {
      

            OpenFileDialog op = new OpenFileDialog(); // This opens the file 
            op.Title = "Make a selection";
            op.Filter = "Choose Image that contains | *.jpg; *.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpege)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png) | *.png";

            if (op.ShowDialog() == true) // When file opens 
            {
                string filePath = op.FileName;

                imgWinter1.Source = new BitmapImage(new Uri(op.FileName)); //Selected picture will display in imgwinter1. 
                lbimglocation.Content = filePath; //LOCATION OF IMG WILL PROMPT HERE. 
            }
          
            

        }
        private void FormattedRunDisplay() //DESIRE FORMAT IN RTB 
        {
            string ArtName = txtArtName.Text; //VALUE FOR TXTBOX = ART NAME 
            string Artist = txtArtist.Text;  //VALUE FOR TXTBOX = ARTIST NAME 
            string ArtInformation = txtArtInformation.Text; //VALUE FOR TXTBOX = ARTINFORMATION 


            bool yearSelected = YearPicker.SelectedDate.HasValue; // Using bool condition  
            DateTime selectedYear = DateTime.Now; 

            if (yearSelected) // Date picker. When date is selected. 
            {
                selectedYear = YearPicker.SelectedDate.Value; // gives year value. 


            }
            Run runYear = new Run(selectedYear.Year.ToString()); // DISPLAYS ONLY YEAR 
            runYear.FontSize = 10; // SMALLER FONT SIZE 


            rtbDisplay.Document = fdDisplay; // RTB ADVANCE structure. 
            Paragraph p = new Paragraph(); // VALUING P for Pargraph 


            Run runArtName = new Run // Like RUNDISPLAY but manual. 
           ($"{ArtName}\n");
            runArtName.FontSize = 24; // BIGGER FONT THAN EVERYTHING ELSE IN RTB 
            runArtName.Foreground = Brushes.DeepPink; // COLORED PINK. 


            Run runBody = new Run( // RunDisplay : Art information entered by user . 
            $"{Artist}\n"
           + $"{ArtInformation}");
            runBody.FontSize = 14; // FONT 14 

            p.Inlines.Add(runYear);  //STRUCTURE of RTB . DISPLAYS LIST LIKE for Year , art and Info . 
            p.Inlines.Add("\n");
            p.Inlines.Add(runArtName);
            p.Inlines.Add("\n");
            p.Inlines.Add(runBody);

            fdDisplay.Blocks.Add(p);
            
         

         


        }
        private void AdvRTB() // STRUCTURE FOR RTB ADV.  
        {
            rtbDisplay.Document = fdDisplay;
            Paragraph p = new Paragraph();

            Run run = new Run();

            p.Inlines.Add(run);

            fdDisplay.Blocks.Add(p);



        }

        private void YearSelected() //Figuring out how to display year only. 
        {
            rtbDisplay.Document = fdDisplay; // Structure to run will = optimize read-ability. 
            Paragraph p = new Paragraph(); // Block flow content 

            Run run = new Run(); // Inline element. 

            p.Inlines.Add(run); 

            fdDisplay.Blocks.Add(p); 

            bool yearSelected = YearPicker.SelectedDate.HasValue;
            DateTime selectedYear = DateTime.Now;

            if (yearSelected)
            {
                selectedYear = YearPicker.SelectedDate.Value;


            }
            Run runYear = new Run(selectedYear.ToString()); 
            runYear.FontSize = 10; // SIZE 10 for the year, small font. 



        }
        public void DisplayList() // Trying to figure out how to use LISTVIEW 
        {
            List<AestheticWinter> WinterArt = new List<AestheticWinter>(); // New list. 

            foreach (AestheticWinter item in WinterArt)
            {
                lvWinter.Items.Add(txtArtName.Text); 
                MessageBox.Show(WinterArt[0].ArtName);
            }

         

        }

        public void Preload()
        {
            AestheticWinter winter = new AestheticWinter("Freeze Breeze Trees", "JaqLin");
            WinterArt.Add(winter);

            lvWinter.Items.Add(WinterArt[0].ArtName);
            lvWinter.Items.Add(WinterArt[0].Artist);
            lvWinter.Items.Add(new AestheticWinter("Freeze Breeze Trees", "JaqLin"));
            lvWinter.Items.Add(new AestheticWinter("Freeze Lake Breeze", "JaqLin"));
            lvWinter.Items.Add(new AestheticWinter("Rose Freeze", "JaqLin"));


        }
        public void ImageDisplayer(IMG image) // Giving value to imgDisplayers in XAML 
        {
            imgWinter1.Source = image.Image;
            imgWinter2.Source = image.Image;
            imgWinter3.Source = image.Image;

        }
        public void Loading()
        {
            string filepath1 = @"C:\School\Programming 122\WINTERFINAL\WinterLake.jpg"; // Properties of images
            IMG Lake = new IMG(filepath1, "Winter Lake");// Queue file path 
            LoadPictures.Add(Lake);

            string filepath2 = @"C:\School\Programming 122\WINTERFINAL\WinterSnow.jpg";// Properties of images
            IMG Snow = new IMG(filepath2, "Winter Snow"); // Queue file path 
            LoadPictures.Add(Snow);

            string filepath3 = @"C:\School\Programming 122\WINTERFINAL\WinterTree.jpg";// Properties of images
            IMG Tree = new IMG(filepath3, "Winter Tree");// Queue file path 
            LoadPictures.Add(Tree);

        }


        
           
        
    }
}
