using System.Reactive.Linq;

//var fruits = new string[]
//{
//    "old-banana",
//    "apple",
//    "dirty-banana",
//    "apple"
//}.ToObservable();
//fruits
//  // Lösung hier...
//  .Where(x => !x.StartsWith("old-"))
//  .Select(x => x.Replace("dirty-", ""))
//  //.Take(2)
//  .Subscribe(item => Console.WriteLine(item));

// out:
/*
  apple
  banana
 */

//Console.WriteLine("Hello World!".Replace("World!", "Teilnehmer!"));

// Level 11
//var apples = new string[]
//{
//    "apple",
//    "apple",
//    "old-apple",
//    "apple",
//    "old-apple"
//}.ToObservable();

//var bananas = new string[]
//{
//    "banana",
//    "old-banana",
//    "old-banana",
//    "banana",
//    "banana"
//}.ToObservable();

//apples
//  // Lösung
//  .Concat(bananas)
//  .Where(item => !item.StartsWith("old-"))
//  .Subscribe(item => Console.WriteLine(item));


// Level 14
//var apples = new string[] { "apple", "dirty-apple", "apple", "old-apple", "old-apple" }.ToObservable();
//var bananas = new string[] { "old-banana", "old-banana", "dirty-banana", "dirty-banana", "dirty-banana" }.ToObservable();

//var freshApples = apples
//  .SkipLast(2);

//var freshBananas = bananas
//  .Skip(2);


//Observable
//  .Concat(freshApples, freshBananas)
//  .Select(fruit => fruit.Replace("dirty-", ""))
//  .Subscribe(fruit => Console.WriteLine(fruit));


// Level 15
//var apples =  new string[] { "apple", "apple" }.ToObservable();
//var bananas = new string[] { "banana", "banana" }.ToObservable();

//Observable
//  .Zip(apples, bananas)
//  .Do(data => Console.WriteLine(data))
//  .Select(fruits => new string[] { fruits[0], fruits[1] }.ToObservable())
//  .Do(data => Console.WriteLine(data))
//  .Merge()
//  .Do(data => Console.WriteLine(data))
//  .Subscribe(fruit => Console.WriteLine("Ergebnis: " + fruit));


// Level 16 Finale
//var fruits = new string[] { "apple" }.ToObservable();

//Observable
//  .Merge(fruits)
//  .Repeat(3)
//  .Subscribe(fruit => Console.WriteLine(fruit));

var fruits = new string[] { "apple" }.ToObservable();

Observable
  .Merge(fruits)
  .Repeat(3)
  .Subscribe(
    item => Console.WriteLine(item),
    error => Console.WriteLine(error),
    () => Console.WriteLine("Fertig!")
  );



Console.ReadLine();

Console.ReadLine();