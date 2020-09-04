using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ImageMagick;
using System.Drawing;

namespace GameOfLife
{
    public class GifCreator
    {

        public void CreateGif(int[,] boardState)
        {
            using (MagickImageCollection collection = new MagickImageCollection())
            {
                // Add first image and set the animation delay (in 1/100th of a second) 
                CreatePNG();
                collection.Add("GameOfLife.png");
                collection[0].AnimationDelay = 100; // in this example delay is 1000ms/1sec

                // Add second image, set the animation delay (in 1/100th of a second) and flip the image
                CreatePNG();
                collection.Add("GameOfLife.png");
                collection[1].AnimationDelay = 100; // in this example delay is 1000ms/1sec
                //collection[1].Flip();

                // Optionally reduce colors
                var settings = new QuantizeSettings();
                settings.Colors = 256;
                collection.Quantize(settings);

                // Optionally optimize the images (images should have the same size).
                collection.Optimize();

                // Save gif
                collection.Write("GameOfLife.Animated.gif");
            }
        }

        public void CreatePNG()
        {
            // Start the process...  
            Bitmap memoryImage;
            memoryImage = new Bitmap(1000, 900);
            Size s = new Size(memoryImage.Width, memoryImage.Height);

            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            //That's it! Save the image in the directory and this will work like charm.  
            string fileName = "GameOfLife.png";

            // save it  
            memoryImage.Save(fileName);
        }
    }

}
