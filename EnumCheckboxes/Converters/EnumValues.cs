using System.Globalization;
using System.Windows.Data;

namespace EnumCheckboxes.Converters;

internal class EnumValues : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is Enum myEnum ? (object)Enum.GetValues(myEnum.GetType()) : throw new ArgumentException("Not en Enum!");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
