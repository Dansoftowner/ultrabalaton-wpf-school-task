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

namespace Ultrabalaton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string FilePath = "ub2017egyeni.txt";

        private readonly Players players = new Players(FilePath);

        public MainWindow()
        {
            InitializeComponent();
            InitializeDefaulValues();
        }

        private void InitializeDefaulValues()
        {
            PlayersCountLabel.Content = $"{players.PlayersCount} fő";
            CategoryCombo.ItemsSource = players.UniqueCategories;
        }

        private void SearchPlayer(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameField.Text;
            Player foundPlayer = players.GetByName(playerName);
            if (foundPlayer == null)
            {
                SearchResultLabel.Content = "Nincs ilyen nevű sportoló!";
            }
            else
            {
                SearchResultLabel.Content = string.Format(
                    "A sportoló rajtszáma: {0}, ideje: {1}, megtett táv: {2}%",
                    foundPlayer.Number, 
                    foundPlayer.AccomplishedTime,
                    foundPlayer.FinishRate
                );
            }
        }

        private void CategorySelection(object sender, RoutedEventArgs e)
        {
            var category = (string)CategoryCombo.SelectedItem;
            CategoryPlayersListView.ItemsSource = players.GetByCategory(category);
            FinishedPlayerCountLabel.Content = $"Ebből célba érkezett: {players.FinishedCountInCategory(category)} fő.";

            var winner = players.WinnerInCategory(category);
            WinnerPlayerLabel.Content = $"A kategória győztese: {winner.Name}, ideje: {winner.AccomplishedTime}";
        }

        private void WriteToFile(object sender, RoutedEventArgs e)
        {

        }
    }
}
