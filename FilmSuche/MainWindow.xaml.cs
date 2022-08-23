using FilmSuche.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
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

namespace FilmSuche
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly MovieRepository _movieRepository = new();
    public MainWindow()
    {
      InitializeComponent();
      Observable.FromEventPattern(searchTextBox, "TextChanged")
        .Select(eventArgs => ((TextBox)eventArgs.Sender).Text)
        //.Where(text => text.Length >= 2)
        .Throttle(TimeSpan.FromMilliseconds(500))
        .DistinctUntilChanged()
        .ObserveOn(SynchronizationContext.Current)
        .Subscribe(text =>
        {
          //Debug.WriteLine(text);
          var movies = _movieRepository.Find(text);
          moviesListView.ItemsSource = movies;
        });
    }
  }
}
