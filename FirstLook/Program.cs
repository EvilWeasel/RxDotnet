using System.Reactive.Linq;

var fruits = new string[]
{
    "old-banana",
    "apple",
    "dirty-banana",
    "apple"
}.ToObservable();
fruits
  // Lösung hier...
  .Where(x => !x.StartsWith("old-"))
  .Select(x => x.Replace("dirty-", ""))
  //.Take(2)
  .Subscribe(item => Console.WriteLine(item));

// out:
/*
  apple
  banana
 */

//Console.WriteLine("Hello World!".Replace("World!", "Teilnehmer!"));
Console.ReadLine();
