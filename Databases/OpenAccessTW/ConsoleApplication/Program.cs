using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public partial class Car
    {
        private int _carID;
        public virtual int CarID
        {
            get
            {
                return this._carID;
            }
            set
            {
                this._carID = value;
            }
        }

        private string _tagNumber;
        public virtual string TagNumber
        {
            get
            {
                return this._tagNumber;
            }
            set
            {
                this._tagNumber = value;
            }
        }

        private string _make;
        public virtual string Make
        {
            get
            {
                return this._make;
            }
            set
            {
                this._make = value;
            }
        }

        private string _model;
        public virtual string Model
        {
            get
            {
                return this._model;
            }
            set
            {
                this._model = value;
            }
        }

        private short? _carYear;
        public virtual short? CarYear
        {
            get
            {
                return this._carYear;
            }
            set
            {
                this._carYear = value;
            }
        }

        private int? _categoryID;
        public virtual int? CategoryID
        {
            get
            {
                return this._categoryID;
            }
            set
            {
                this._categoryID = value;
            }
        }

        private bool? _mp3Player;
        public virtual bool? Mp3Player
        {
            get
            {
                return this._mp3Player;
            }
            set
            {
                this._mp3Player = value;
            }
        }

        private bool? _dVDPlayer;
        public virtual bool? DVDPlayer
        {
            get
            {
                return this._dVDPlayer;
            }
            set
            {
                this._dVDPlayer = value;
            }
        }

        private bool? _airConditioner;
        public virtual bool? AirConditioner
        {
            get
            {
                return this._airConditioner;
            }
            set
            {
                this._airConditioner = value;
            }
        }

        private bool? _aBS;
        public virtual bool? ABS
        {
            get
            {
                return this._aBS;
            }
            set
            {
                this._aBS = value;
            }
        }

        private bool? _aSR;
        public virtual bool? ASR
        {
            get
            {
                return this._aSR;
            }
            set
            {
                this._aSR = value;
            }
        }

        private bool? _navigation;
        public virtual bool? Navigation
        {
            get
            {
                return this._navigation;
            }
            set
            {
                this._navigation = value;
            }
        }

        private bool? _available;
        public virtual bool? Available
        {
            get
            {
                return this._available;
            }
            set
            {
                this._available = value;
            }
        }

        private double? _latitude;
        public virtual double? Latitude
        {
            get
            {
                return this._latitude;
            }
            set
            {
                this._latitude = value;
            }
        }

        private double? _longitude;
        public virtual double? Longitude
        {
            get
            {
                return this._longitude;
            }
            set
            {
                this._longitude = value;
            }
        }

        private string _imageFileName;
        public virtual string ImageFileName
        {
            get
            {
                return this._imageFileName;
            }
            set
            {
                this._imageFileName = value;
            }
        }

        private decimal? _rating;
        public virtual decimal? Rating
        {
            get
            {
                return this._rating;
            }
            set
            {
                this._rating = value;
            }
        }

        private int? _numberOfRatings;
        public virtual int? NumberOfRatings
        {
            get
            {
                return this._numberOfRatings;
            }
            set
            {
                this._numberOfRatings = value;
            }
        }

     

    }

}
