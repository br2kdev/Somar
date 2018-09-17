using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSomarUI.Modules
{
    public static class ExtendBitmap
    {
        private class ImageDimensions
        {
            public int Height { get; set; }
            public int Width { get; set; }
        }

        public static Bitmap GetResizedImage(Bitmap original, Int32 maxWidth, Int32 maxHeight)
        {
            try
            {
                if (ImageIsBox(original))
                    return new Bitmap(original, maxWidth, maxHeight);

                var newDimensions = CalculateNewDimensionsForImage(original, maxWidth, maxHeight);

                return new Bitmap(original, newDimensions.Width, newDimensions.Height);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return null;
        }

        private static Bitmap LoadOriginalImage(string imagePath)
        {
            using (FileStream fs = new FileStream(imagePath, FileMode.Open))
            {
                return new Bitmap(fs);
            }
        }

        private static bool ImageIsBox(Bitmap original)
        {
            return original.Height == original.Width;
        }

        private static ImageDimensions CalculateNewDimensionsForImage(Bitmap original, int boxWidth, int boxHeight)
        {
            //calculate aspect ratio
            var aspect = original.Width / (float)original.Height;
            int newWidth, newHeight;

            //calculate new dimensions based on aspect ratio
            newWidth = (int)(boxWidth * aspect);
            newHeight = (int)(newWidth / aspect);

            //if one of the two dimensions exceed the box dimensions
            if (newWidth > boxWidth || newHeight > boxHeight)
            {
                //depending on which of the two exceeds the box dimensions set it as the box dimension and calculate the other one based on the aspect ratio
                if (newWidth > newHeight)
                {
                    newWidth = boxWidth;
                    newHeight = (int)(newWidth / aspect);
                }
                else
                {
                    newHeight = boxHeight;
                    newWidth = (int)(newHeight * aspect);
                }
            }

            return new ImageDimensions()
            {
                Height = newHeight,
                Width = newWidth
            };
        }

        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
