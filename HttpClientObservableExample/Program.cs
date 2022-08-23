using HttpClientObservableExample;
using HttpClientObservableExample.Models;
using System.Diagnostics;
using System.Reactive;


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

var x = new HttpClientObservable<Joke>(
  "https://api.chucknorris.io/jokes/random?category=fashion")
  
  .Subscribe(z);


// var y = new HttpClientObservable<Dog>(
//   "https://dog.ceo/api/breeds/image/random")
//   .Subscribe(
//     dog => Console.WriteLine(dog.message),
//     error => Debug.WriteLine(error),
//     () => Console.WriteLine("Dog Done!")    
//   );

x.Dispose();
//y.Dispose();

Console.ReadLine();