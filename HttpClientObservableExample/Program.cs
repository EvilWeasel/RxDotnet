using HttpClientObservableExample;
using HttpClientObservableExample.Models;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;

var z = Observer.Create<Joke>(
  joke => Console.WriteLine(joke.value),
  error => Debug.WriteLine(error),
  () => Console.WriteLine("Joke Done!")
  );

/*
  Schreiben Sie den Code unterhalb so um, sodass von jeder verfügbaren Kategorie
  ein Witz ausgegeben wird.
  GET: https://api.chucknorris.io/jokes/categories
*/

var x = new HttpClientObservable<string[]>("https://api.chucknorris.io/jokes/categories")
  .SelectMany(categories => categories)
  .SelectMany(category => new HttpClientObservable<Joke>($"https://api.chucknorris.io/jokes/random?category={category}"))
  //.Merge()
  .Subscribe(result => Console.WriteLine(result.value));

//new HttpClientObservable<Joke>("https://api.chucknorris.io/jokes/random?category=fashion")

// var y = new HttpClientObservable<Dog>(
//   "https://dog.ceo/api/breeds/image/random")
//   .Subscribe(
//     dog => Console.WriteLine(dog.message),
//     error => Debug.WriteLine(error),
//     () => Console.WriteLine("Dog Done!")    
//   );

//x.Dispose();
//y.Dispose();

Console.ReadLine();

public class ResponseObserver : IObserver<Joke>
{
  public void OnCompleted()
  {
    Console.WriteLine("Done");
  }

  public void OnError(Exception error)
  {
    throw new Exception("Error: No data recieved or wrong response-type");
  }

  public void OnNext(Joke joke)
  {
    Console.WriteLine(joke.value);
  }
}
