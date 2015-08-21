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
    public class Rental : TempObjectBase
    {
        private int _RentalId;
        public int RentalId
        {
            get { return _RentalId; }
            set
            {
                if (_RentalId != value)
                {
                    _RentalId = value;
                    OnPropertyChanged(() => RentalId);
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

        public DateTime _DateRented;
        public DateTime DateRented
        {
            get { return _DateRented; }
            set
            {
                if (_DateRented != value)
                {
                    _DateRented = value;
                    OnPropertyChanged(() => DateRented);
                }
            }
        }

        private DateTime _DateDue;
        public DateTime DateDue
        {
            get { return _DateDue; }
            set
            {
                if (_DateDue != value)
                {
                    _DateDue = value;
                    OnPropertyChanged(() => DateDue);
                }
            }
        }

        private DateTime? _DateReturned;
        public DateTime? DateReturned
        {
            get { return _DateReturned; }
            set
            {
                if (_DateReturned != value)
                {
                    _DateReturned = value;
                    OnPropertyChanged(() => DateReturned);
                }
            }
        }
        private int _EntityId;
        public int EntityId
        {

            get { return _EntityId; }
            set
            {
                if (_EntityId != value)
                {
                    _EntityId = value;
                    OnPropertyChanged(() => EntityId);
                }
            }
        }


    }
}