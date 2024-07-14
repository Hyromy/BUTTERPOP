using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BUTTERPOP.utils
{
    public static class ImageResourceExtension
    {
        public static class ImageHelper
        {
            public static byte[] ConvertImageToByteArray(ImageSource imageSource)
            {
                if (imageSource == null) return null;

                var streamImageSource = (StreamImageSource)imageSource;
                using (var stream = streamImageSource.Stream(CancellationToken.None).Result)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
            }

            public static ImageSource ConvertByteArrayToImage(byte[] imageData)
            {
                if (imageData == null || imageData.Length == 0)
                    return null;

                return ImageSource.FromStream(() => new MemoryStream(imageData));
            }
        }
    }
}


