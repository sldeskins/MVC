using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization; 
using Core.Common.Core;

namespace CarRental.Client.Entities
{
    //  [DataContract(Namespace="http://www/sldeskins.com/carrental")] // put in assenble properties to reduce clutter in classes

    [DataContract]
    public class Reservation : TempObjectBase 
    {
        private int _ReservationId;
        public int ReservationId
        {
            get { return _ReservationId; }
            set
            {
                if (_ReservationId != value)
                {
                    _ReservationId = value;
                    OnPropertyChanged(() => ReservationId);
                }
            }
        }

         private int _AccountId;
        public int AccountId
        {
            get { return _AccountId; }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }

        private int _CarId;
        public int CarId
        {
            get { return _CarId; }
            set
            {
                if (_CarId != value)
                {
                    _CarId = value;
                    OnPropertyChanged(() => CarId);
                }
            }
        }

         private DateTime _RentalDate;
        public DateTime RentalDate
        {
            get { return _RentalDate; }
            set
            {
                if (_RentalDate != value)
                {
                    _RentalDate = value;
                    OnPropertyChanged(() => RentalDate);
                }
            }
        }

        private DateTime _ReturnDate;
        public DateTime ReturnDate
        {
            get { return _ReturnDate; }
            set
            {
                if (_ReturnDate != value)
                {
                    _ReturnDate = value;
                    OnPropertyChanged(() => ReturnDate);
                }
            }
        }
 
 
    }
}
