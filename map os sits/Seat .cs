using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_os_sits
{
    public enum SeatStatus
    {
        Available,
        Selected,
        Occupied
    }
    public class Seat : INotifyPropertyChanged
    {
        public int Number { get; set; }

        private SeatStatus _status;
        public SeatStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
   
}
