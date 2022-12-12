using System;
using System.Globalization;
using System.Windows.Data;

namespace Katod
{
    /// <summary>
    /// Конвертер для изменения цвета кнопок на элементе 
    /// </summary>
    internal class ColorButtonBookGenreConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(bool)value)
            {
                return "#179099";
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
