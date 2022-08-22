using HttpClientObservableExample;

var x = new HttpClientObservable<Joke>(
  "https://api.chucknorris.io/jokes/random?category=dev")
  .Subscribe(joke => Console.WriteLine(joke.value));

x.Dispose();

Console.ReadLine();