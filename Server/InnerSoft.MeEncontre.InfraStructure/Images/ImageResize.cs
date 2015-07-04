using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

namespace MeEncontre.Infrastructure.Images
{
    public static class ImageResize
    {

        public static void Resize(HttpPostedFileBase file, string Pasta, string NomeFoto, int ThumbSize, int NormalSize, int ZoomSize)
        {

            string savedFileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Files");
            savedFileName = System.IO.Path.Combine(savedFileName, Pasta);

            if (!Directory.Exists(savedFileName))
            {
                Directory.CreateDirectory(savedFileName);
            }

            DeleteFoto(NomeFoto, Pasta);

            var fotoThumb = System.IO.Path.Combine(savedFileName, NomeFoto);
            var fotoZoom = System.IO.Path.Combine(savedFileName, "z" + NomeFoto);            
            var fotoNormal = System.IO.Path.Combine(savedFileName, "n" + NomeFoto);

            byte[] fileBytes = new byte[file.ContentLength];
            using (System.IO.Stream stream = file.InputStream)
            {
                stream.Read(fileBytes, 0, file.ContentLength);
            }

            System.IO.File.WriteAllBytes(fotoThumb, ImageResize.ResizeImageFile(fileBytes, ThumbSize));
            System.IO.File.WriteAllBytes(fotoNormal, ImageResize.ResizeImageFile(fileBytes, NormalSize));
            System.IO.File.WriteAllBytes(fotoZoom, ImageResize.ResizeImageFile(fileBytes, ZoomSize));            
            

        }
        public static void DeleteFoto(string Pasta, string Nomefoto)
        {
            try
            {
                if (Nomefoto != null)
                {
                    string savedFileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Files");
                    savedFileName = System.IO.Path.Combine(savedFileName, Pasta);
                    string thumb = System.IO.Path.Combine(savedFileName, Nomefoto);
                    string zoom = System.IO.Path.Combine(savedFileName, "z" + Nomefoto);
                    string normal = System.IO.Path.Combine(savedFileName, "n" + Nomefoto);

                    if (System.IO.File.Exists(thumb))
                    {
                        System.IO.File.Delete(thumb);
                    }

                    if (System.IO.File.Exists(zoom))
                    {
                        System.IO.File.Delete(zoom);
                    }

                    if (System.IO.File.Exists(normal))
                    {
                        System.IO.File.Delete(normal);
                    }
                }
            }
            catch { }        
        }


        /// <summary>
        /// Resizes an image
        /// </summary>
        /// <param name="imageFile">the byte array of the file</param>
        /// <param name="targetSize">the target size of the file (may affect width or height) 
        /// depends on orientation of file (landscape or portrait)</param>
        /// <returns>Byte array containing the resized file</returns>
        public static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        {
            using (System.Drawing.Image oldImage =
                System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
            {
                Size newSize = CalculateDimensions(oldImage.Size, targetSize);

                using (Bitmap newImage =
                    new Bitmap(newSize.Width,
                        newSize.Height, PixelFormat.Format24bppRgb))
                {
                    using (Graphics canvas = Graphics.FromImage(newImage))
                    {
                        canvas.SmoothingMode = SmoothingMode.AntiAlias;
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        canvas.DrawImage(oldImage,
                            new Rectangle(new Point(0, 0), newSize));

                        MemoryStream m = new MemoryStream();
                        newImage.Save(m, ImageFormat.Jpeg);
                        return m.GetBuffer();
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the new size of the image based on the target size
        /// </summary>
        /// <param name="oldSize">Is the size of the original file</param>
        /// <param name="targetSize">Is the target size of the resized file</param>
        /// <returns>The new size</returns>
        private static Size CalculateDimensions(Size oldSize, int targetSize)
        {
            Size newSize = new Size();
            if (oldSize.Height > oldSize.Width)
            {
                newSize.Width =
                    (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
                newSize.Height = targetSize;
            }
            else
            {
                newSize.Width = targetSize;
                newSize.Height =
                    (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
            }
            return newSize;
        }
    }
}
