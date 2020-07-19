using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Taxi.instruments
{
    static class Converter
    {
        public static int ToInt(this string str)
        {
            
            return Convert.ToInt32(str);
        }

        public static long ToLong(this string str)
        {
            return Convert.ToInt64(str);
        }
        public static decimal ToDecimal(this string str)
        {
            return Convert.ToDecimal(str);
        }

        public static BitmapImage ByteToImage(byte[] array)
        {
            using (MemoryStream ms = new MemoryStream(array, 0, array.Length))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}
