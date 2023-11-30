using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace EnumCheckboxes.Converters;

internal class EnumDescription : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Enum myEnum && myEnum.GetType().GetCustomAttribute(typeof(FlagsAttribute)) != null)
        {
            FieldInfo? fi = myEnum.GetType().GetField(myEnum.ToString());
            DescriptionAttribute[]? attributes = (DescriptionAttribute[]?)fi?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
        }

        throw new ArgumentException("The object passed to the converter is not of type Enum or it does not have the attribute Flags!");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
