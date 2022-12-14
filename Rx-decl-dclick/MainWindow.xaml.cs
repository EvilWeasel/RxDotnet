using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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

namespace Rx_decl_dclick
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      Observable.FromEventPattern(searchTextBox, "PreviewMouseDown")
        .Buffer(TimeSpan.FromMilliseconds(350))
        .Where(buffer => buffer.Count == 2)
        .Subscribe(x => MessageBox.Show("DoubleClick!!!"));
    }
  }
}
