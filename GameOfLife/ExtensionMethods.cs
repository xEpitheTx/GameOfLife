using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameOfLife
{
    public static class ExtensionMethods
    {

        public static Bitmap ResizeImage(this Bitmap image, int upScaleBy)
        {
            Bitmap enhancedImage = new Bitmap(image.Height * upScaleBy, image.Width * upScaleBy);
            for (int ogPixelRow = 0; ogPixelRow < image.Height; ogPixelRow++)
            {
                for (int ogPixelColumn = 0; ogPixelColumn < image.Width; ogPixelColumn++)
                {
                    Color pixelToEnhanceColor = image.GetPixel(ogPixelRow, ogPixelColumn);
                    for (int enhancedPixelRow = ogPixelRow * upScaleBy; enhancedPixelRow < ogPixelRow * upScaleBy + upScaleBy; enhancedPixelRow++)
                    {
                        for (int enhancedpixelColumn = ogPixelColumn * upScaleBy; enhancedpixelColumn < ogPixelColumn * upScaleBy + upScaleBy; enhancedpixelColumn++)
                        {
                            enhancedImage.SetPixel(enhancedPixelRow, enhancedpixelColumn, pixelToEnhanceColor);
                        }
                    }
                }
            }
            return enhancedImage;
        }
    }
}
