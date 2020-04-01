using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Q3_WPFBooks.Models;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #3 - WPF Books + Context
/// ** Date (MM/dd/yyy) : 03/12/2020
/// </summary>
namespace Q3_WPFBooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ** DBContext for Books
        BooksContext _context = new BooksContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        // ** Query 1: All Titles and its Authors, Sort Title
        private void AllTitlesButton_Click(object sender, RoutedEventArgs e)
        {
            // ** Get a list of all the titles and the authors who wrote them. 
            //    Sort the results by title
            var list = from t in this._context.Titles
                       join x in this._context.AuthorIsbn on t.Isbn equals x.Isbn
                       join y in this._context.Authors on x.AuthorId equals y.AuthorId
                       orderby t.Title
                       select new { t.Title, AuthorName = y.FirstName + " " + y.LastName };
            var results = list.ToList();
            this.BooksDataGrid.ItemsSource = results;
        }

        // ** Query 2: All Titles and its Authors, Sort Title, Last Name and First Name
        private void AllTitlesByLastNameFirstNameButton_Click(object sender, RoutedEventArgs e)
        {
            // ** Get a list of all the titles and the authors who wrote them. 
            //    Sort the results by title.  
            //    Each title sort the authors alphabetically by last name, then first name
            var list = from t in this._context.Titles
                       join x in this._context.AuthorIsbn on t.Isbn equals x.Isbn
                       join y in this._context.Authors on x.AuthorId equals y.AuthorId
                       orderby t.Title, y.LastName, y.FirstName
                       select new { t.Title, AuthorName = y.LastName + ", " + y.FirstName };
            var results = list.ToList();
            this.BooksDataGrid.ItemsSource = results;
        }

        // ** Query 3: All Authors group by Title, Sort Title, Last Name and First Name
        private void AllAuthorsGroupBy_Click(object sender, RoutedEventArgs e)
        {
            // ** Get a list of all the authors grouped by title, sorted by title; 
            //    for a given title sort the author names alphabetically by last name then first name.
            var list = from a in this._context.Authors
                       join x in this._context.AuthorIsbn on a.AuthorId equals x.AuthorId
                       join y in this._context.Titles on x.Isbn equals y.Isbn
                       group y by new { y.Title, AuthorName = a.LastName + ", " + a.FirstName } into AuthorGroup
                       orderby AuthorGroup.Key.Title, AuthorGroup.Key.AuthorName
                       select new { AuthorName = AuthorGroup.Key.AuthorName, Title = AuthorGroup.Key.Title };
            var results = list.ToList();
            this.BooksDataGrid.ItemsSource = results;
        }
    }
}
