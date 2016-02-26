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
    public partial class MainWindow1 : Window
    {
        MoviesService1 svc = new MoviesService1();
        SynchronizationContext synch = SynchronizationContext.Current;

        public MainWindow1()
        {
            InitializeComponent();
            LoadAllMovies();
            details.DataContext = new Movie();
        }

        void LoadAllMovies()
        {
            status.Content = "Loading All Movies...";
            
            svc.GetAllAsync().ContinueWith(
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

            svc.GetAsync(id).ContinueWith(
                task =>
                {
                    var movie = task.Result;
                    synch.Post(
                        state =>
                        {
                            this.details.DataContext = movie;
                            status.Content = "Loaded Movie ID " + id;
                        },
                        null);
                });
        }

        private void CreateMovie(Movie movie)
        {
            status.Content = "Creating Movie...";
            
            svc.PostAsync(movie).ContinueWith(
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
                                IEnumerable<Movie> movies = this.DataContext as IEnumerable<Movie>;
                                if (movies != null)
                                {
                                    var newMovies = movies.ToList();
                                    newMovies.Add(movie);
                                    this.DataContext = newMovies;
                                }
                                status.Content = "Created Movie ID " + movie.ID;
                            }
                        },
                        null);
                });
        }

        private void UpdateMovie(Movie movie)
        {
            status.Content = "Updating Movie...";

            var synch = SynchronizationContext.Current;
            
            svc.PutAsync(movie).ContinueWith(
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
            
            svc.DeleteAsync(id).ContinueWith(
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
                                IEnumerable<Movie> movies = this.DataContext as IEnumerable<Movie>;
                                if (movies != null)
                                {
                                    movies = movies.Where(x => x.ID != id);
                                    this.DataContext = movies;
                                }
                                status.Content = "Deleted Movie ID " + id;
                            }
                        },
                        null);
                });
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
