using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ObservablesExamples
{
  internal class Program
  {
    static void Main(string[] args)
    {

      var source = new string[] { "apple", "bannana", "pineapple", "grape", "strawberry" };

      var fruits = source.ToObservable();

      fruits.Subscribe(fruit => Console.WriteLine(fruit));

      // Next

      Observable.Range(0, 100)
        .Subscribe(
          number => Console.WriteLine(number),
          error => Console.WriteLine("Fehler: " + error.Message),
          () => Console.WriteLine("Done")
        );



    }
  }

  public class NumberObservable : IObservable<int>
  {
    public IDisposable Subscribe(IObserver<int> observer)
    {
      for (int i = 0; i < 100; i++)
      {
        observer.OnNext(i);
      }
      observer.OnCompleted();

      return Disposable.Empty;
    }
  }
}

