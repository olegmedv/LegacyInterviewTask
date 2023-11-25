using System.IO;
using System.Reflection;
using System.Windows;

namespace AppToRefactoring;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        InitializeComboBoxFormat();
        InitializeTextBoxDirPath();
    }

    private void InitializeComboBoxFormat()
    {
        ComboBoxFileFormat.Items.Add("xml");
        ComboBoxFileFormat.Items.Add("txt");
        ComboBoxFileFormat.Items.Add("csv");

        ComboBoxFileFormat.SelectedIndex = 0;
    }

    private void InitializeTextBoxDirPath()
    {
        var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        TextBoxDirPath.Text = Path.Combine(currentDir!, "Data");
    }

    protected string GetDirPath()
    {
        return TextBoxDirPath.Text;
    }

    protected string GetFileFormat()
    {
        return ComboBoxFileFormat.SelectedItem as string ?? string.Empty;
    }
}