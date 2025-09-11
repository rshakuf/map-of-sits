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

namespace map_os_sits
{
    /// <summary>
    /// Interaction logic for SeatControl.xaml
    /// </summary>
    public partial class SeatControl : UserControl
    {
        public Seat Seat { get; private set; }

        public SeatControl(Seat seat)
        {
            InitializeComponent();
            Seat = seat;
            DataContext = seat;

            seat.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Seat.Status))
                    UpdateColor();
            };

            UpdateColor();

            MouseDoubleClick += (s, e) =>
            {
                if (Seat.Status == SeatStatus.Available)
                    Seat.Status = SeatStatus.Selected;
            };
        }

        private void UpdateColor()
        {
            switch (Seat.Status)
            {
                case SeatStatus.Available:
                    SeatRectangle.Fill = Brushes.Green;
                    break;
                case SeatStatus.Selected:
                    SeatRectangle.Fill = Brushes.Orange;
                    break;
                case SeatStatus.Occupied:
                    SeatRectangle.Fill = Brushes.Red;
                    break;
            }
        }
        public SeatControl()
        {
            InitializeComponent();
        }
    }
}
