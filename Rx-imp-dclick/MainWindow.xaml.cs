using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Rx_imp_dclick
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public int _count = 0;
    private readonly DispatcherTimer _timer = new();
    public MainWindow()
    {
      InitializeComponent();
      _timer.Interval = TimeSpan.FromMilliseconds(350);
      _timer.Tick += (s, e) =>
      {
        _count = 0;
        _timer.Stop();
      };
    }
    private void searchTextBox_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if(_count == 0)
      {
        _timer.Start();
        _count++;
      }
      else if(_count == 1)
      {
        MessageBox.Show("DoubleClick!!!");
      }
    }
  }
}
