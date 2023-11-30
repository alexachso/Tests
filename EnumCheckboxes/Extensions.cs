using System.ComponentModel;
using System.Reflection;

namespace EnumCheckboxes;

public static class EnumExtensions
{
    public static IEnumerable<Enum> GetFlags(this Enum value)
    {
        return GetFlags(value, Enum.GetValues(value.GetType()).Cast<Enum>().ToArray());
    }

    public static IEnumerable<Enum> GetIndividualFlags(this Enum value)
    {
        return GetFlags(value, GetFlagValues(value.GetType()).ToArray());
    }

    public static string GetDescription(this Enum value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());

        // In case fi is null, do not search attributes below : will get exception since fi null
        if (fi == null)
        {
            return "Description non existent";
        }

        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return value.ToString();
        }
    }

    public static List<string> GetEnumDescriptions(this Enum e)
    {
        List<string> list = [];
        foreach (Enum enu in Enum.GetValues(e.GetType()))
        {
            FieldInfo? fi = enu.GetType().GetField(enu.ToString());
            DescriptionAttribute[]? attributes = (DescriptionAttribute[]?)fi?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                list.Add(attributes[0].Description);
            }
        }
        return list;
    }

    public static List<string> GetEnumDescriptionsFromType(Type type)
    {
        List<string> list = [];
        foreach (Enum enu in Enum.GetValues(type))
        {
            FieldInfo? fi = enu.GetType().GetField(enu.ToString());
            DescriptionAttribute[]? attributes = (DescriptionAttribute[]?)fi?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                list.Add(attributes[0].Description);
            }
        }
        return list;
    }

    public static List<string> GetActiveFlagsDescriptions(this Enum e)
    {
        List<string> list = [];
        foreach (Enum enu in Enum.GetValues(e.GetType()))
        {
            if (e.HasFlag(enu))
            {
                FieldInfo? fi = enu.GetType().GetField(enu.ToString());
                DescriptionAttribute[]? attributes = (DescriptionAttribute[]?)fi?.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    list.Add(attributes[0].Description);
                }
                else
                {
                    list.Add(enu.ToString());
                }
            }
        }
        return list;
    }

    private static IEnumerable<Enum> GetFlags(Enum value, Enum[] values)
    {
        ulong bits = Convert.ToUInt64(value);
        List<Enum> results = [];
        for (int i = values.Length - 1; i >= 0; i--)
        {
            ulong mask = Convert.ToUInt64(values[i]);
            if (i == 0 && mask == 0L)
                break;
            if ((bits & mask) == mask)
            {
                results.Add(values[i]);
                bits -= mask;
            }
        }
        if (bits != 0L)
            return Enumerable.Empty<Enum>();
        if (Convert.ToUInt64(value) != 0L)
            return results.Reverse<Enum>();
        if (bits == Convert.ToUInt64(value) && values.Length > 0 && Convert.ToUInt64(values[0]) == 0L)
            return values.Take(1);
        return Enumerable.Empty<Enum>();
    }

    private static IEnumerable<Enum> GetFlagValues(Type enumType)
    {
        ulong flag = 0x1;
        foreach (var value in Enum.GetValues(enumType).Cast<Enum>())
        {
            ulong bits = Convert.ToUInt64(value);
            if (bits == 0L)
                //yield return value;
                continue; // skip the zero value
            while (flag < bits) flag <<= 1;
            if (flag == bits)
                yield return value;
        }
    }
}
