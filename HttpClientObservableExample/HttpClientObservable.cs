using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientObservableExample
{
  public class HttpClientObservable<T> : IObservable<T>
  {
    private string _uri = string.Empty;

    public HttpClientObservable(string uri)
    {
      _uri = uri;
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
      var cts = new CancellationTokenSource();
      Task.Run(async () =>
      {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(_uri);
        //var response = httpClient.GetAsync(_uri);
        var data = await response.Content.ReadAsAsync<T>();
        if (response.IsSuccessStatusCode)
        {
          observer.OnNext(data);
          observer.OnCompleted();
        }
        else
        {
          observer.OnError(new Exception("Error with StatusCode: " + response.StatusCode));
        }
      }, cts.Token);
      return Disposable.Create(() =>
      {
        cts.Cancel();
      });
    }
  }


  public class Joke
  {
    public object[] categories { get; set; }
    public string created_at { get; set; }
    public string icon_url { get; set; }
    public string id { get; set; }
    public string updated_at { get; set; }
    public string url { get; set; }
    public string value { get; set; }
  }



}
