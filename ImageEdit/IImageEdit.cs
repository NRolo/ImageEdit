using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutSystems.ExternalLibraries.SDK;

namespace ImageEdit
{
    /// <summary>
    /// Utilities to crop, identify, and resize images. This library uses ImageMagick for .Net.
    /// </summary>
    [OSInterface(Description = "Utilities to crop, identify, and resize images. This library uses ImageMagick for .Net.", IconResourceName = "ImageEdit.resources.ImageMagick_logo.png")]
    public interface IImageEdit
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
        [OSAction(Description = "Crops the image", IconResourceName = "ImageEdit.resources.ImageMagick_logo.png")]
        public void Crop([OSParameter(DataType = OSDataType.BinaryData, Description = "The source binary content")] byte[] SourceContent, [OSParameter(DataType = OSDataType.Integer, Description = "Offset to the x horizontal axis")] int xOffSet, [OSParameter(DataType = OSDataType.Integer, Description = "Offset to the y vertical axis")] int yOffSet, [OSParameter(DataType = OSDataType.Integer, Description = "Width in number of pixels")] int Width, [OSParameter(DataType = OSDataType.Integer, Description = "Height in number of pixels")] int Height, [OSParameter(DataType = OSDataType.BinaryData, Description = "The processed binary content")] out byte[] NewContent);

        /// <summary>
        /// This action will resize the image maintaining original geometry
        /// </summary>
        /// <param name="SourceContent">The source binary content</param>
        /// <param name="MaxWidth">Maximum Width allowed</param>
        /// <param name="MaxHeight">Maximum Height allowed</param>
        /// <param name="NewContent">The processed binary content</param>
        [OSAction(Description = "This action will resize the image maintaining original geometry", IconResourceName = "ImageEdit.resources.ImageMagick_logo.png")]
        public void Resize([OSParameter(DataType = OSDataType.BinaryData, Description = "The source binary content")] byte[] SourceContent, [OSParameter(DataType = OSDataType.Integer, Description = "Maximum width allowed")] int MaxWidth, [OSParameter(DataType = OSDataType.Integer, Description = "Maximum height allowed")] int MaxHeight, [OSParameter(DataType = OSDataType.BinaryData, Description = "The processed binary content")] out byte[] NewContent);

        /// <summary>
        /// Verify image width and height
        /// </summary>
        /// <param name="SourceContent">The source binary content</param>
        /// <param name="Width">Image Width in pixels</param>
        /// <param name="Height">Image Height in pixels</param>
        [OSAction(Description = "Verify image width and height", IconResourceName = "ImageEdit.resources.ImageMagick_logo.png")]
        public void Identify([OSParameter(DataType = OSDataType.BinaryData, Description = "The source binary content")] byte[] SourceContent, [OSParameter(DataType = OSDataType.Integer, Description = "Image width in pixels")] out int Width, [OSParameter(DataType = OSDataType.Integer, Description = "Image height in pixels")] out int Height);
    }
}
