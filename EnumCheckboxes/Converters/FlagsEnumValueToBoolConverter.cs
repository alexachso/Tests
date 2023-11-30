using System.Globalization;
using System.Windows.Data;

namespace EnumCheckboxes.Converters;

public class FlagsEnumValueToBoolConverter : IValueConverter
{
    private uint targetValue;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        uint mask = (uint)parameter;
        targetValue = (uint)value;

        return ((mask & targetValue) != 0);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        targetValue ^= (uint)parameter;
        return Enum.Parse(targetType, targetValue.ToString());
    }
}
