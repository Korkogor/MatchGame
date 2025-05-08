using System.Windows;
using System.Windows.Controls;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();

        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🦊", "🦊",
                "🐸", "🐸",
                "🦐", "🦐",
                "🦄", "🦄",
                "🕷", "🕷",
                "🐺", "🐺",
                "🐳", "🐳",
                "🐧", "🐧",
            };

            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }
        
        /*Если щелчок сделан на первом животном в паре, сохранить информацию о том, на каком элементе TextBlock щёлкнул пользователь, и убрать животное с экрана. 
        Если это второе животное в паре, либо убрать его с экрана (если животные составляют пару), либо вернуть на экран первое животное (если животные разные) */
        
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock; 
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }

        }

    }
}