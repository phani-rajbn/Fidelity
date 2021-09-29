using System;
using System.Collections.Generic;


namespace SampleFrameworkApp.Day10
{
    class Movie : IComparable<Movie>
    {
        public Movie()
        {
            MovieID = ++MovieCount;
        }
        private static int MovieCount = 0;
        public int MovieID { get; private set; }
        public string MovieTitle { get; set; }
        public string Director { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Duration { get; set; }

        public int CompareTo(Movie other)
        {
            if (this.Rating > other.Rating)
                return -1;
            else if (this.Rating < other.Rating)
                return 1;
            else return 0;
        }
    }
    delegate void OnChange(string arg);

    interface IMovieDatabase
    {
        void AddNewMovieToDatabase(Movie movie);
        Movie this[int index] { get; }
        int MovieCount { get; }
        List<Movie> FindMoviesByDirector(string name);
        List<Movie> FindMoviesByName(string name);
        List<Movie> GetTopRatedMovies(int year);
    }

    class MovieDatabase : IMovieDatabase
    {
        public OnChange OnModified = null;
        private List<Movie> _movies = new List<Movie>();

        public Movie this[int index] => _movies[index];

        public int MovieCount => _movies.Count;

        public void AddNewMovieToDatabase(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException("Movie cannot be null");
            _movies.Add(movie);
            OnModified("Movie added to the database");
        }

        public List<Movie> FindMoviesByDirector(string name)
        {
            return _movies.FindAll(delegate(Movie movie) {
                return movie.Director == name;
            });//Anonymous methods....
        }

        public List<Movie> FindMoviesByName(string name)
        {
            return _movies.FindAll((movie) => movie.MovieTitle.Contains(name));
        }

        public List<Movie> GetTopRatedMovies(int year)
        {
            var list = _movies.FindAll((m) => m.ReleaseDate.Year == year);
            list.Sort();//default sort based on the IComparable<Movie>
            return list;
        }
    }
    class MovieApp
    {
        static void messageFromServer(string msg) => Console.WriteLine(msg);

        static void Main(string[] args)
        {
            MovieDatabase db = new MovieDatabase();
            db.OnModified = messageFromServer;//Delegate instantiation
            db.AddNewMovieToDatabase(new Movie { Director = "Steven Spielberg", Duration = 1.45, MovieTitle = "Jurasic Park", Rating = 8, ReleaseDate = DateTime.Parse("12/08/1995") });
            db.AddNewMovieToDatabase(new Movie { Director = "V. Ravichandran", Duration = 2.30, MovieTitle = "Prema Loka", Rating = 7, ReleaseDate = DateTime.Parse("12/06/1988") });
            db.AddNewMovieToDatabase(new Movie { Director = "Manirathnam", Duration = 2.45, MovieTitle = "Agni Natcharam", Rating = 9, ReleaseDate = DateTime.Parse("12/08/1995") });
            db.AddNewMovieToDatabase(new Movie { Director = "Manirathnam", Duration = 2.45, MovieTitle = "Roja", Rating = 8, ReleaseDate = DateTime.Parse("12/08/1992") });
            db.AddNewMovieToDatabase(new Movie { Director = "Steven Spielberg", Duration = 1.45, MovieTitle = "The Lost World", Rating = 8, ReleaseDate = DateTime.Parse("12/08/1995") });
            db.AddNewMovieToDatabase(new Movie { Director = "Steven Spielberg", Duration = 1.45, MovieTitle = "A Bridge of Spies", Rating = 7, ReleaseDate = DateTime.Parse("12/08/1995") });

            for (int i = 0; i < db.MovieCount; i++)
            {
                Console.WriteLine(db[i].MovieTitle);
            }
            Console.WriteLine("-------------After sorting------------");
            var list = db.GetTopRatedMovies(1995);
            foreach (var movie in list) Console.WriteLine($"{movie.MovieTitle} Rating: {movie.Rating}");
        }
    }
}
