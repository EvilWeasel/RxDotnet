using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSuche.Models
{
  public class MovieRepository
  {
    private readonly IList<Movie> _movieList = new List<Movie>()
    {
      new Movie() { Title = "Star Wars: Episode III"},
      new Movie() { Title = "Star Wars: Episode III"},
      new Movie() { Title = "Megamind"},
      new Movie() { Title = "Terminator"},
      new Movie() { Title = "John Wick"},
      new Movie() { Title = "Inception"},
      new Movie() { Title = "Inception 2"},
      new Movie() { Title = "Die Schlange im Schatten des Adlers"}
    };

    public List<Movie> Find(string title)
    {
      return _movieList.Where(
        x => x.Title.Contains(title, StringComparison.OrdinalIgnoreCase)
          ).ToList();
    }

  }
}
