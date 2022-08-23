using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Subjects
{
  public class Foo
  {
    public event Action<string> Loaded;
    public void Load()
    {
      // ...Generiert Daten
      Loaded?.Invoke("Daten...");
    }
  }

  public class FooSub
  {
    public ISubject<string> Loaded = new Subject<string>();

    public void Load()
    {
      Loaded.OnNext("Data...");
    }
  }

  public class FooFull
  {
    public IObservable<string> Loaded => loadedSubject.AsObservable();
    private ISubject<string> loadedSubject = new Subject<string>();

    public void Load()
    {
      loadedSubject.OnNext("Data...");
    }
  }
}
