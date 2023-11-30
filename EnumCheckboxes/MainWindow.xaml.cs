using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using EnumCheckboxes.Converters;

namespace EnumCheckboxes;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();

        AddGeneratorLimitsCheckBoxes();

        CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnClose));
    }

    private void OnClose(object sender, ExecutedRoutedEventArgs e)
    {
        Close();
    }

    private void AddGeneratorLimitsCheckBoxes()
    {
        var converter = new FlagsEnumValueToBoolConverter();
        foreach (SystemFlags flag in Enum.GetValues(typeof(SystemFlags)))
        {
            var binding = new Binding("Flags")
            {
                Converter = converter,
                ConverterParameter = flag
            };

            var checkBox = new CheckBox() { Content = flag.GetDescription() };
            checkBox.SetBinding(CheckBox.IsCheckedProperty, binding);
            // I would like to set the style to MaterialDesignCheckBox but how?
            //checkBox.Style = Application.Current.Resources.MergedDictionaries[2]["MaterialDesignCheckBox"] as Style;
            sp_SystemFlags.Children.Add(checkBox);
        }
    }
}
