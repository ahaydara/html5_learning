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

        private void Click_Refresh(object sender, RoutedEventArgs e)
        {
            LoadAllMovies();
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
