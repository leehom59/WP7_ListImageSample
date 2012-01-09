using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Data;

namespace WindowsPhoneApplication1.Converters
{
    /*
     * Bitmap Convert for Image Control
     */
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                BitmapImage bi = new BitmapImage();
                bi.UriSource = new Uri((string)value);
                
                // Creation Options
                bi.CreateOptions = BitmapCreateOptions.DelayCreation;
                //bi.CreateOptions = BitmapCreateOptions.None;
                //bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;

                //When the image is loaded failed
                bi.ImageFailed += (sender, e) => {
                    BitmapImage eBi = (BitmapImage)sender;
                    eBi.UriSource = new Uri("/teyou02.jpg", UriKind.Relative);
                };

                //When the image is loaded success
                bi.ImageOpened += (sender, e) => {
                };
                return bi;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}