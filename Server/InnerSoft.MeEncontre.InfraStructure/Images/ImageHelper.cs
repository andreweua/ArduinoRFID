using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MeEncontre.Infrastructure.Images
{
    public static class ImageHelper
    {
        public enum AnchorPosition
        {
            Top,
            Center,
            Bottom,
            Left,
            Right
        }
        public static void ConfirmarImagem(string CodProdutoChave, string CodProduto, string imageFolderTemp, string imageFolder, string fileExtension)
        {
            //save uploaded image
            bool objReturn = false;
            string PathNormalTempImage = imageFolderTemp + string.Format(@"\{0}{1}", CodProdutoChave, fileExtension);
            string PathThumbTempImage = imageFolderTemp + string.Format(@"\{0}thumb{1}", CodProdutoChave, fileExtension);
            string PathZoomTempImage = imageFolderTemp + string.Format(@"\{0}zoom{1}", CodProdutoChave, fileExtension);

            string PathNormalImage = imageFolder + string.Format(@"\{0}{1}", CodProduto, fileExtension);
            string PathThumbImage = imageFolder + string.Format(@"\{0}thumb{1}", CodProduto, fileExtension);
            string PathZoomImage = imageFolder + string.Format(@"\{0}zoom{1}", CodProduto, fileExtension);

            if (File.Exists(PathNormalImage))
                File.Delete(PathNormalImage);

            if (File.Exists(PathThumbImage))
                File.Delete(PathThumbImage);

            if (File.Exists(PathZoomImage))
                File.Delete(PathZoomImage);

            File.Move(PathNormalTempImage, PathNormalImage);
            File.Move(PathThumbTempImage, PathThumbImage);
            File.Move(PathZoomTempImage, PathZoomImage);

        }

        public static void ConfirmarImagemSimples(string CodProdutoChave, string CodProduto, string imageFolderTemp, string imageFolder, string fileExtension)
        {
            //save uploaded image
            bool objReturn = false;
            string PathNormalTempImage = imageFolderTemp + string.Format(@"\{0}{1}", CodProdutoChave, fileExtension);

            string PathNormalImage = imageFolder + string.Format(@"\{0}{1}", CodProduto, fileExtension);

            if (File.Exists(PathNormalImage))
                File.Delete(PathNormalImage);

            File.Move(PathNormalTempImage, PathNormalImage);

        }

        public static void SalvarImagem(string Foto, byte[] image, string imageFolder, string fileExtension, bool produto)
        {
            string PathNormalImage = imageFolder + string.Format(@"\n{0}", Foto);
            string PathThumbImage = imageFolder + string.Format(@"\{0}", Foto);
            string PathZoomImage = imageFolder + string.Format(@"\z{0}", Foto);

            if (File.Exists(PathNormalImage))
                File.Delete(PathNormalImage);

            if (File.Exists(PathThumbImage))
                File.Delete(PathThumbImage);

            if (File.Exists(PathZoomImage))
                File.Delete(PathZoomImage);

            MemoryStream file = new MemoryStream(image);
            System.Drawing.Image tmpImage = Image.FromStream(file);

         
            tmpImage = ResizeImageProporcional(tmpImage, 1000, 1000);

         
            tmpImage.Save(PathZoomImage, tmpImage.RawFormat);
            tmpImage.Dispose();
            file.Dispose();



            System.Drawing.Image NormalImage = ResizeImageProporcional(PathZoomImage, 200, 200);
            if (NormalImage != null)
            {
                System.Drawing.Imaging.ImageFormat imageFormat = new System.Drawing.Imaging.ImageFormat(new Guid());

                switch (fileExtension.ToLower())
                {
                    case ".jpg":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".png":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case ".gif":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    default:
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                }
                NormalImage.Save(PathNormalImage, imageFormat);
                NormalImage.Dispose();
            }


            System.Drawing.Image ThumbImage = ResizeImageProporcional(PathZoomImage, 80, 80);
            if (ThumbImage != null)
            {
                System.Drawing.Imaging.ImageFormat imageFormat = new System.Drawing.Imaging.ImageFormat(new Guid());

                switch (fileExtension.ToLower())
                {
                    case ".jpg":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".png":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case ".gif":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    default:
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                }
                ThumbImage.Save(PathThumbImage, imageFormat);
                ThumbImage.Dispose();

            }
        }

        public static void SalvarImagemSimples(string CodProduto, byte[] image, string imageFolder, string fileExtension)
        {
            string PathNormalImage = imageFolder + string.Format(@"\{0}{1}", CodProduto, fileExtension);

            if (File.Exists(PathNormalImage))
                File.Delete(PathNormalImage);

            MemoryStream file = new MemoryStream(image);
            System.Drawing.Image tmpImage = Image.FromStream(file);

            tmpImage.Save(PathNormalImage, tmpImage.RawFormat);
            tmpImage.Dispose();
            file.Dispose();

        }

        public static byte[] GetBytesFromUrl(string url)
        {
            byte[] b;
            System.Net.HttpWebRequest myReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.WebResponse myResp = myReq.GetResponse();

            Stream stream = myResp.GetResponseStream();
            //int i;
            using (BinaryReader br = new BinaryReader(stream))
            {
                //i = (int)(stream.Length);
                b = br.ReadBytes(500000);
                br.Close();
            }
            myResp.Close();
            return b;
        }

        public static void WriteBytesToFile(string fileName, byte[] content)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            try
            {
                w.Write(content);
            }
            finally
            {
                fs.Close();
                w.Close();
            }
        } 


        public static Image ResizeImage(string pathImageTemp, int imageWidth, int imageHeight)
        {
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(pathImageTemp);
            return ResizeImage(fullSizeImg, imageHeight, imageHeight);
        }
        public static Image ResizeImage(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            bmPhoto.MakeTransparent(Color.Transparent);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Transparent);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;



            grPhoto.DrawImage(imgPhoto,
                new Rectangle(-1, -1, Width + 1, Height + 1),
                new Rectangle(0, 0, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }
        public static System.Drawing.Image ResizeImageProporcional(System.Drawing.Image Image, int maxWidth, int maxHeight)
        {
            System.Drawing.Image fullSizeImg = Image;
            decimal WidthFactor = (decimal)maxWidth / (decimal)fullSizeImg.Width;
            decimal HeigntFactor = (decimal)maxHeight / (decimal)fullSizeImg.Height;
            decimal Factor = (HeigntFactor > WidthFactor) ? WidthFactor : HeigntFactor;

            int newWidth = (int)((decimal)fullSizeImg.Width * Factor);
            int newHeight = (int)((decimal)fullSizeImg.Height * Factor);

            return ResizeImage(fullSizeImg, newWidth, newHeight);

        }
        public static System.Drawing.Image ResizeImageProporcional(string pathImageTemp, int MaxWidth, int MaxHeight)
        {
            System.Drawing.Image image = null;
            try
            {
                image = ResizeImageProporcional(System.Drawing.Image.FromFile(pathImageTemp), MaxWidth, MaxHeight);
            }
            catch
            { }

            return image;

        }
        public static System.Drawing.Image CropImage(System.Drawing.Image imgPhoto, int Width,
                    int Height, AnchorPosition Anchor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentW;
                switch (Anchor)
                {
                    case AnchorPosition.Top:
                        destY = 0;
                        break;
                    case AnchorPosition.Bottom:
                        destY = (int)
                            (Height - (sourceHeight * nPercent));
                        break;
                    default:
                        destY = (int)
                            ((Height - (sourceHeight * nPercent)) / 2);
                        break;
                }
            }
            else
            {
                nPercent = nPercentH;
                switch (Anchor)
                {
                    case AnchorPosition.Left:
                        destX = 0;
                        break;
                    case AnchorPosition.Right:
                        destX = (int)
                          (Width - (sourceWidth * nPercent));
                        break;
                    default:
                        destX = (int)
                          ((Width - (sourceWidth * nPercent)) / 2);
                        break;
                }
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width,
                    Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                    imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
        public static bool ResizeAndSaveImageProporcional(string pathImageTemp, byte[] file, int MaxWidth, int MaxHeight)
        {
            bool objReturn = false;

            try
            {
                MemoryStream imageStream = new MemoryStream(file);
                System.Drawing.Image fullSizeImg = System.Drawing.Image.FromStream(imageStream);
                System.Drawing.Image AdjustedImage = ResizeImageProporcional(fullSizeImg, MaxWidth, MaxHeight);
                System.Drawing.Imaging.ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

                if (AdjustedImage != null)
                {
                    switch (pathImageTemp.Substring(pathImageTemp.Length - 4))
                    {
                        case ".jpg":
                            imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case ".png":
                            imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                            break;
                        case ".gif":
                            imageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                            break;
                        default:
                            imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                    }
                    AdjustedImage.Save(pathImageTemp, imageFormat);
                    AdjustedImage.Dispose();
                    objReturn = true;
                }
                imageStream.Close();
                imageStream.Dispose();
            }
            catch { }
            return objReturn;
        }
    }
}

