using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace map_os_sits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Seat> Seats = new();

        public MainWindow()
        {
            InitializeComponent();
            InitSeats();
            UpdateAvailableCount();
        }

        private void InitSeats()
        {
            var rnd = new Random();

            for (int i = 1; i <= 50; i++)
            {
                var seat = new Seat
                {
                    Number = i,
                    Status = rnd.NextDouble() < 0.2 ? SeatStatus.Occupied : SeatStatus.Available
                };

                Seats.Add(seat);

                var control = new SeatControl(seat);
                SeatsPanel.Children.Add(control);
            }
        }

        private void ConfirmSelection_Click(object sender, RoutedEventArgs e)
        {
            foreach (var seat in Seats.Where(s => s.Status == SeatStatus.Selected))
            {
                seat.Status = SeatStatus.Occupied;
            }

            UpdateAvailableCount();
        }

        private void UpdateAvailableCount()
        {
            int available = Seats.Count(s => s.Status == SeatStatus.Available);
            AvailableCountText.Text = "מקומות פנויים: {available}";
        }
    }

}