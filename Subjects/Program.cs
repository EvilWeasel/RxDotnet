using Subjects;
using System.Diagnostics;
using System.Reactive.Subjects;

//var subject = new Subject<int>();

//subject.OnNext(1);
//subject.Subscribe(count => Console.WriteLine("Observer 1: " + count));
//subject.OnNext(2);
//subject.Subscribe(count => Console.WriteLine("Observer 2: " + count));
//subject.OnNext(3);
//subject.OnNext(4);


var foo = new FooFull();
// foo.Loaded += (data) => Console.WriteLine(data);
// foo.Loaded += (data) => Debug.WriteLine(data);
foo.Loaded.Subscribe((data) => Console.WriteLine(data));
foo.Load();
//foo.Loaded.OnNext("Huch...?!");


//foo.Load();


Console.ReadLine();