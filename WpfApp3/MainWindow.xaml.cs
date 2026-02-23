using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    double _lastNumber = 0;
    string _operator = "";
    bool _isNewEntry = true;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button btn = (Button)sender;
        if (_isNewEntry)
        {
            ResultLabel.Text = btn.Content.ToString();
            _isNewEntry = false;
        }
        else
        {
            ResultLabel.Text += btn.Content.ToString();
        }
    }

    private void DecimalPoint_Click(object sender, RoutedEventArgs e)
    {
        string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        if (_isNewEntry)
        {
            ResultLabel.Text = 0 + decimalSeparator;
            _isNewEntry = true;
        }
        else
        {
            if (!ResultLabel.Text.Contains(decimalSeparator))
            {
                ResultLabel.Text += decimalSeparator;
            }
        }
    }

    private void Operation_Click(object sender, RoutedEventArgs e)
    {
        Button btn = (Button)sender;
        _lastNumber = double.Parse(ResultLabel.Text);
        _operator = btn.Content.ToString();
        _isNewEntry = true;
    }

    private void Equal_Click(object sender, RoutedEventArgs e)
    {
        double newNumber = double.Parse(ResultLabel.Text);
        double result = 0;

        switch (_operator)
        {
            case "+": result = _lastNumber + newNumber; break;
            case "-": result = _lastNumber - newNumber; break;
            case "*": result = _lastNumber * newNumber; break;
            case "/": result = _lastNumber / newNumber; break;
            case "%": result = _lastNumber % newNumber; break;

        }

        if (_operator == "/" && newNumber == 0)
        {
            ResultLabel.Text = "Ошибка: деление на ноль";
            _isNewEntry = true;
            return;
        }

        ResultLabel.Text = result.ToString();
        _isNewEntry = true;


    }

    private void Delete_click(object sender, RoutedEventArgs e)
    {
        Button btn = (Button)sender;
        ResultLabel.Text = 0.ToString();
        if (_isNewEntry)
        {
            ResultLabel.Text = "".ToString();
            _isNewEntry = false;
        }
        else
        {
            ResultLabel.Text += ToString();
        }

    }

}