using System;
using System.Globalization;
using System.Windows.Data;

namespace Katod
{
 
    /// <summary>
    /// Конвертер для изменения цвета рамки элемента
    /// </summary>
    public class ColorBookGenreConverter : IValueConverter
    {
        /// <inheritdoc/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(bool)value)
            {
                return "SteelBlue";
            }
            return "ForestGreen";
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
