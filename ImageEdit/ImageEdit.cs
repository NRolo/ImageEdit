using System.Diagnostics;
using System;
using System.Net.Http;
using System.Web;
using System.IO;
using OutSystems.ExternalLibraries.SDK;

using ImageMagick.Configuration;
using ImageMagick.ImageOptimizers;
using ImageMagick;

namespace ImageEdit
{
    public class ImageEdit : IImageEdit
    {
        /// <summary>
		/// Crops image
		/// </summary>
		/// <param name="SourceContent">The source binary content</param>
		/// <param name="xOffSet">OffSet to the x horizontal axis</param>
		/// <param name="yOffSet">OffSet to the y vertical axis</param>
		/// <param name="Width">Width in number of pixels</param>
		/// <param name="Height">Height in number of pixels</param>
		/// <param name="NewContent">The processed binary content</param>
		public void Crop(byte[] SourceContent, int xOffSet, int yOffSet, int Width, int Height, out byte[] NewContent)
        {
            using (var image = new MagickImage(SourceContent))
            {

                var geometry = new MagickGeometry();
                geometry.Width = (uint)Width;
                geometry.Height = (uint)Height;
                geometry.X = xOffSet;
                geometry.Y = yOffSet;

                image.Crop(geometry);
                NewContent = image.ToByteArray();
            }
        } // MssCrop

        /// <summary>
        /// This action will resize the image maintaining original geometry
        /// </summary>
        /// <param name="SourceContent">The source binary content</param>
        /// <param name="MaxWidth">Maximum Width allowed</param>
        /// <param name="MaxHeight">Maximum Height allowed</param>
        /// <param name="NewContent">The processed binary content</param>
        public void Resize(byte[] SourceContent, int MaxWidth, int MaxHeight, out byte[] NewContent)
        {
            using (var image = new MagickImage(SourceContent))
            {
                var size = new MagickGeometry((uint)MaxWidth, (uint)MaxHeight)
                {
                    // This will resize the image to a fixed size without maintaining the aspect ratio.
                    // Normally an image will be resized to fit inside the specified size.
                    IgnoreAspectRatio = false
                };
                image.Resize(size);
                NewContent = image.ToByteArray();
            }
        }// MssResize

        /// <summary>
        /// Verify image width and height
        /// </summary>
        /// <param name="SourceContent">The source binary content</param>
        /// <param name="Width">Image Width in pixels</param>
        /// <param name="Height">Image Height in pixels</param>
        public void Identify(byte[] SourceContent, out int Width, out int Height)
        {

            var info = new MagickImageInfo(SourceContent);
            Width = (int) info.Width;
            Height = (int) info.Height;


        } // MssIdentify


    }
}