using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPF.FileApp
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (DirectoryItemType)value;
            var image = string.Empty;

            switch (type)
            {
                case DirectoryItemType.Drive:
                    image = "drive.png";
                    break;

                case DirectoryItemType.Folder:
                    image = "folder-closed.png";
                    break;

                case DirectoryItemType.File:
                    image = "file.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/Images/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}