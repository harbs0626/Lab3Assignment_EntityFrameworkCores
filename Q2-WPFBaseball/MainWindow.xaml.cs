using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using Q2_WPFBaseball.Models;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #3 - WPF Baseball + Context
/// ** Date (MM/dd/yyy) : 03/12/2020
/// </summary>
namespace Q2_WPFBaseball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ** DBContext for Books
        BaseballContext _context = new BaseballContext();

        public MainWindow()
        {
            InitializeComponent();
            this.PrepareData();
        }

        // ** Prepare initial baseball data
        public void PrepareData()
        {
            var list = this._context.Players
                    .OrderBy(p => p.PlayerId)
                    .ToList();
            this.PlayersDataGrid.ItemsSource = list;
        }

        // ** Search for a baseball player by Last Name
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SearchTextBox.Text != string.Empty || 
                this.SearchTextBox.Text != "")
            {
                var list = this._context.Players
                        .Where(p => p.LastName.Contains(this.SearchTextBox.Text))
                        .ToList();
                MessageBox.Show($"{list.Count()} record(s) found for Last Name: {this.SearchTextBox.Text}");
                this.PlayersDataGrid.ItemsSource = list;
            }
            else
            {
                MessageBox.Show($"No Record(s) found for Last Name: {this.SearchTextBox.Text}");
            }
        }

        // ** View All players
        private void ViewAllPlayersButton_Click(object sender, RoutedEventArgs e)
        {
            this.PrepareData();
        }

        // ** Add new players
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (this._context.Players.Any(p => p.FirstName == this.FirstNameTextBox.Text && 
                p.LastName == this.LastNameTextBox.Text))
            {
                MessageBox.Show($"{this.FirstNameTextBox.Text} already exists");
            }
            else
            {
                try
                {
                    this._context.Players.AddRange(
                        new Players
                        {
                            FirstName = this.FirstNameTextBox.Text,
                            LastName = this.LastNameTextBox.Text,
                            BattingAverage = Convert.ToDecimal(String.Format("{0:0.000}", this.BattingAverageTextBox.Text))
                        }
                    );

                    this._context.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }

            this.PrepareData();
        }

        // ** Clear fields
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.SearchTextBox.Clear();
            this.FirstNameTextBox.Clear();
            this.LastNameTextBox.Clear();
            this.BattingAverageTextBox.Clear();
            this.ViewAllPlayersButton_Click(sender, e);
        }
    }
}
