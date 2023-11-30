using System.Globalization;
using System.Windows.Data;

namespace EnumCheckboxes.Converters;

internal class FlagsEnumValueToBoolMultiConverter : IMultiValueConverter
{
    uint targetValueCache;
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        //if (values is [uint targetValue, uint mask])
        //{
        targetValueCache = (uint)values[0];
        uint mask = (uint)values[1];
        return ((mask & targetValueCache) != 0);
        //}
        throw new NotImplementedException();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        if (value is bool)
        {
            return [Enum.Parse(targetTypes[0], targetValueCache.ToString()), value];
        }
        throw new NotImplementedException();
    }
}
