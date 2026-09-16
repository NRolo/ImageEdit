using ImageMagick;

namespace ImageEdit.UnitTests;

public class ImageEditTests
{
    [Fact]
    public void Crop_ReturnsImageWithRequestedDimensions()
    {
        var source = CreatePng(100, 50);
        var imageEdit = new global::ImageEdit.ImageEdit();

        imageEdit.Crop(source, 10, 5, 30, 20, out var result);

        AssertDimensions(result, 30, 20);
    }

    [Fact]
    public void Resize_ReturnsImageFittedWithinMaximumDimensions()
    {
        var source = CreatePng(100, 50);
        var imageEdit = new global::ImageEdit.ImageEdit();

        imageEdit.Resize(source, 40, 40, out var result);

        AssertDimensions(result, 40, 20);
    }

    [Fact]
    public void Identify_ReturnsImageDimensions()
    {
        var source = CreatePng(100, 50);
        var imageEdit = new global::ImageEdit.ImageEdit();

        imageEdit.Identify(source, out var width, out var height);

        Assert.Equal(100, width);
        Assert.Equal(50, height);
    }

    private static byte[] CreatePng(uint width, uint height)
    {
        using var image = new MagickImage(MagickColors.Red, width, height)
        {
            Format = MagickFormat.Png
        };

        return image.ToByteArray();
    }

    private static void AssertDimensions(byte[] content, uint expectedWidth, uint expectedHeight)
    {
        using var image = new MagickImage(content);

        Assert.Equal(expectedWidth, image.Width);
        Assert.Equal(expectedHeight, image.Height);
    }
}