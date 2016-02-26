using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoviesClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MoviesService svc = new MoviesService();
        SynchronizationContext synch = SynchronizationContext.Current;

        public MainWindow()
        {
            InitializeComponent();
            LoadAllMovies();
            details.DataContext = new Movie();
        }

        void LoadAllMovies()
        {
            status.Content = "Loading All Movies...";
            
            var call = svc.GetAllAsync();
            if (call == null)
            {
                status.Content = "GetAll not yet implemented";
                return;
            }
            call.ContinueWith(
                task =>
                {
                    var movies = task.Result;
                    synch.Post(
                        state =>
                        {
                            this.DataContext = movies;
                            status.Content = "Movies Loaded";
                        },
                        null);
                });
        }

        void LoadMovie(int id)
        {
            status.Content = "Loading Movie...";

            var call = svc.GetAsync(id);
            if (call == null)
            {
                status.Content = "Get not yet implemented";
                return;
            }
            call.ContinueWith(
                task =>
                {
                    var result = task.Result;
                    synch.Post(
                        state =>
                        {
                            if (result != null && result.Error != null)
                            {
                                status.Content = "Error: " + result.Error;
                            }
                            else if (result != null && result.Movie != null)
                            {
                                this.details.DataContext = result.Movie;
                                status.Content = "Loaded Movie ID " + id;
                            }
                            else
                            {
                                status.Content = "Error: Missing results";
                            }
                        },
                        null);
                });
        }

        private void CreateMovie(Movie movie)
        {
            status.Content = "Creating Movie...";
            
            var call = svc.PostAsync(movie);
            if (call == null)
            {
                status.Content = "Post not yet implemented";
                return;
            }
            call.ContinueWith(
                task =>
                {
                    var result = task.Result;
                    synch.Post(
                        state =>
                        {
                            if (result != null && result.Error != null)
                            {
                                status.Content = "Error: " + result.Error;
                            }
                            else if (result != null && result.Movie != null)
                            {
                                AddToGrid(result.Movie);
                                status.Content = "Created Movie ID " + result.Movie.ID;
                            }
                            else
                            {
                                status.Content = "Error: Missing results";
                            }
                        },
                        null);
                    });
        }

        private void UpdateMovie(Movie movie)
        {
            status.Content = "Updating Movie...";

            var synch = SynchronizationContext.Current;
            
            var call = svc.PutAsync(movie);
            if (call == null)
            {
                status.Content = "Put not yet implemented";
                return;
            }
            call.ContinueWith(
                task =>
                {
                    var result = task.Result;
                    synch.Post(
                        state =>
                        {
                            if (result != null && result.Error != null)
                            {
                                status.Content = "Error: " + result.Error;
                            }
                            else
                            {
                                UpdateInGrid(movie);
                                status.Content = "Updated Movie ID " + movie.ID;
                            }
                        },
                        null);
                });
        }

        private void DeleteMovie(int id)
        {
            status.Content = "Deleting Movie...";

            var synch = SynchronizationContext.Current;
            
            var call = svc.DeleteAsync(id);
            if (call == null)
            {
                status.Content = "Delete not yet implemented";
                return;
            }
            call.ContinueWith(
                task =>
                {
                    var result = task.Result;
                    synch.Post(
                        state =>
                        {
                            if (result != null && result.Error != null)
                            {
                                status.Content = "Error: " + result.Error;
                            }
                            else
                            {
                                RemoveFromGrid(id);
                                status.Content = "Deleted Movie ID " + id;
                            }
                        },
                        null);
                });
        }

        void AddToGrid(Movie movie)
        {
            IEnumerable<Movie> movies = this.DataContext as IEnumerable<Movie>;
            if (movies != null)
            {
                var newMovies = movies.ToList();
                newMovies.Add(movie);
                this.DataContext = newMovies;
            }
        }
        void UpdateInGrid(Movie movie)
        {
            IEnumerable<Movie> movies = this.DataContext as IEnumerable<Movie>;
            if (movies != null)
            {
                var newMovies = movies.Where(x=>x.ID != movie.ID).ToList();
                newMovies.Add(movie);
                this.DataContext = newMovies;
            }
        }
        void RemoveFromGrid(int id)
        {
            IEnumerable<Movie> movies = this.DataContext as IEnumerable<Movie>;
            if (movies != null)
            {
                movies = movies.Where(x => x.ID != id);
                this.DataContext = movies;
            }
        }

        private void Click_Refresh(object sender, RoutedEventArgs e)
        {
            LoadAllMovies();
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            var movie = this.dataGrid.SelectedItem as Movie;
            if (movie != null)
            {
                DeleteMovie(movie.ID);
            }
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            var movie = this.details.DataContext as Movie;
            if (movie != null)
            {
                CreateMovie(movie);
            }
        }

        private void Click_Update(object sender, RoutedEventArgs e)
        {
            var movie = this.details.DataContext as Movie;
            if (movie != null)
            {
                UpdateMovie(movie);
            }
        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var movie = this.dataGrid.SelectedItem as Movie;
            if (movie != null)
            {
                LoadMovie(movie.ID);
            }
        }
    }
}
