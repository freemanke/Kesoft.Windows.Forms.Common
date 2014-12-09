using System;
using System.Drawing;
using NUnit.Framework;

namespace Kesoft.Windows.Forms.Common.Tests.Helpers
{
    [TestFixture]
    class ImageHelperTest
    {
        [Test]
        public void ToBase64String()
        {
            Assert.Throws<ArgumentNullException>(() => ImageHelper.ToBase64String(null));
            var image = Properties.Resources.Smile;
            var base64 = ImageHelper.ToBase64String(image);
            Assert.IsNotNull(base64);
            Console.WriteLine(@"Base64 length: {0}",base64.Length);
        }

        [Test]
        public void FromBase64String()
        {
            var image = Properties.Resources.Smile;
            var base64 = ImageHelper.ToBase64String(image);
            Assert.IsNotNull(base64);

            var newImage = ImageHelper.FromBase64String(base64);
            Assert.IsNotNull(newImage);
            Assert.AreEqual(image.Height, newImage.Height);
            Assert.AreEqual(image.Width, newImage.Width);
            Assert.Throws<ArgumentNullException>(() => newImage = ImageHelper.FromBase64String(""));
            Assert.Throws<ArgumentNullException>(() => newImage = ImageHelper.FromBase64String(null));
        }
    }
}
