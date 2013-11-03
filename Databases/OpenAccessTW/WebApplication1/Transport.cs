#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using OpenAccessModel9;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApplication1.Dto
{
	public interface IDtoWithKey
	{
		string DtoKey { get; set; }
	}
	
	[DataContract(IsReference = true)]
	[KnownType(typeof(CategoryDto))]
	public partial class RentalRateDto : IDtoWithKey
	{
		public RentalRateDto()
		{
		}
		
		public RentalRateDto(int _rentalRateID, int? _categoryID, decimal? _daily, decimal? _weekly, decimal? _monthly, CategoryDto _category)
		{
			this.RentalRateID = _rentalRateID;
			this.CategoryID = _categoryID;
			this.Daily = _daily;
			this.Weekly = _weekly;
			this.Monthly = _monthly;
			this.Category = _category;
		}
		
		[DataMember]
		public virtual string DtoKey { get; set; }
		
		[DataMember]
		public virtual int RentalRateID { get;set; }

		[DataMember]
		public virtual int? CategoryID { get;set; }

		[DataMember]
		public virtual decimal? Daily { get;set; }

		[DataMember]
		public virtual decimal? Weekly { get;set; }

		[DataMember]
		public virtual decimal? Monthly { get;set; }

		[DataMember]
		public virtual CategoryDto Category { get;set; }

	}
	
	[DataContract(IsReference = true)]
	[KnownType(typeof(CarDto))]
	[KnownType(typeof(CustomerDto))]
	[KnownType(typeof(EmployeeDto))]
	public partial class RentalOrderDto : IDtoWithKey
	{
		public RentalOrderDto()
		{
		}
		
		public RentalOrderDto(int _rentalOrderID, DateTime? _dateProcessed, int _employeeID, int _customerID, int _carID, string _tankLevel, int? _mileageStart, int? _mileageEnd, DateTime _rentStartDate, DateTime _rentEndDate, int? _days, decimal? _rateApplied, decimal? _orderTotal, string _orderStatus, CarDto _car, CustomerDto _customer, EmployeeDto _employee)
		{
			this.RentalOrderID = _rentalOrderID;
			this.DateProcessed = _dateProcessed;
			this.EmployeeID = _employeeID;
			this.CustomerID = _customerID;
			this.CarID = _carID;
			this.TankLevel = _tankLevel;
			this.MileageStart = _mileageStart;
			this.MileageEnd = _mileageEnd;
			this.RentStartDate = _rentStartDate;
			this.RentEndDate = _rentEndDate;
			this.Days = _days;
			this.RateApplied = _rateApplied;
			this.OrderTotal = _orderTotal;
			this.OrderStatus = _orderStatus;
			this.Car = _car;
			this.Customer = _customer;
			this.Employee = _employee;
		}
		
		[DataMember]
		public virtual string DtoKey { get; set; }
		
		[DataMember]
		public virtual int RentalOrderID { get;set; }

		[DataMember]
		public virtual DateTime? DateProcessed { get;set; }

		[DataMember]
		public virtual int EmployeeID { get;set; }

		[DataMember]
		public virtual int CustomerID { get;set; }

		[DataMember]
		public virtual int CarID { get;set; }

		[DataMember]
		public virtual string TankLevel { get;set; }

		[DataMember]
		public virtual int? MileageStart { get;set; }

		[DataMember]
		public virtual int? MileageEnd { get;set; }

		[DataMember]
		public virtual DateTime RentStartDate { get;set; }

		[DataMember]
		public virtual DateTime RentEndDate { get;set; }

		[DataMember]
		public virtual int? Days { get;set; }

		[DataMember]
		public virtual decimal? RateApplied { get;set; }

		[DataMember]
		public virtual decimal? OrderTotal { get;set; }

		[DataMember]
		public virtual string OrderStatus { get;set; }

		[DataMember]
		public virtual CarDto Car { get;set; }

		[DataMember]
		public virtual CustomerDto Customer { get;set; }

		[DataMember]
		public virtual EmployeeDto Employee { get;set; }

	}
	
	[DataContract(IsReference = true)]
	[KnownType(typeof(RentalOrderDto))]
	public partial class EmployeeDto : IDtoWithKey
	{
		public EmployeeDto()
		{
		}
		
		public EmployeeDto(int _employeeID, string _employeeNumber, string _firstName, string _lastName, string _fullName, string _title, decimal? _hourlySalary, IList<RentalOrderDto> _rentalOrders)
		{
			this.EmployeeID = _employeeID;
			this.EmployeeNumber = _employeeNumber;
			this.FirstName = _firstName;
			this.LastName = _lastName;
			this.FullName = _fullName;
			this.Title = _title;
			this.HourlySalary = _hourlySalary;
			this.RentalOrders = _rentalOrders;
		}
		
		[DataMember]
		public virtual string DtoKey { get; set; }
		
		[DataMember]
		public virtual int EmployeeID { get;set; }

		[DataMember]
		public virtual string EmployeeNumber { get;set; }

		[DataMember]
		public virtual string FirstName { get;set; }

		[DataMember]
		public virtual string LastName { get;set; }

		[DataMember]
		public virtual string FullName { get;set; }

		[DataMember]
		public virtual string Title { get;set; }

		[DataMember]
		public virtual decimal? HourlySalary { get;set; }

		[DataMember]
		public virtual IList<RentalOrderDto> RentalOrders { get;set; }

	}
	
	[DataContract(IsReference = true)]
	[KnownType(typeof(RentalOrderDto))]
	public partial class CustomerDto : IDtoWithKey
	{
		public CustomerDto()
		{
		}
		
		public CustomerDto(int _customerID, string _drvLicNumber, string _fullName, string _address, string _country, string _city, string _state, string _zIPCode, IList<RentalOrderDto> _rentalOrders)
		{
			this.CustomerID = _customerID;
			this.DrvLicNumber = _drvLicNumber;
			this.FullName = _fullName;
			this.Address = _address;
			this.Country = _country;
			this.City = _city;
			this.State = _state;
			this.ZIPCode = _zIPCode;
			this.RentalOrders = _rentalOrders;
		}
		
		[DataMember]
		public virtual string DtoKey { get; set; }
		
		[DataMember]
		public virtual int CustomerID { get;set; }

		[DataMember]
		public virtual string DrvLicNumber { get;set; }

		[DataMember]
		public virtual string FullName { get;set; }

		[DataMember]
		public virtual string Address { get;set; }

		[DataMember]
		public virtual string Country { get;set; }

		[DataMember]
		public virtual string City { get;set; }

		[DataMember]
		public virtual string State { get;set; }

		[DataMember]
		public virtual string ZIPCode { get;set; }

		[DataMember]
		public virtual IList<RentalOrderDto> RentalOrders { get;set; }

	}
	
	[DataContract(IsReference = true)]
	[KnownType(typeof(RentalRateDto))]
	[KnownType(typeof(CarDto))]
	public partial class CategoryDto : IDtoWithKey
	{
		public CategoryDto()
		{
		}
		
		public CategoryDto(int _categoryID, string _categoryName, string _imageFileName, IList<RentalRateDto> _rentalRates, IList<CarDto> _cars)
		{
			this.CategoryID = _categoryID;
			this.CategoryName = _categoryName;
			this.ImageFileName = _imageFileName;
			this.RentalRates = _rentalRates;
			this.Cars = _cars;
		}
		
		[DataMember]
		public virtual string DtoKey { get; set; }
		
		[DataMember]
		public virtual int CategoryID { get;set; }

		[DataMember]
		public virtual string CategoryName { get;set; }

		[DataMember]
		public virtual string ImageFileName { get;set; }

		[DataMember]
		public virtual IList<RentalRateDto> RentalRates { get;set; }

		[DataMember]
		public virtual IList<CarDto> Cars { get;set; }

	}
	
	[DataContract(IsReference = true)]
	[KnownType(typeof(CategoryDto))]
	[KnownType(typeof(RentalOrderDto))]
	public partial class CarDto : IDtoWithKey
	{
		public CarDto()
		{
		}
		
		public CarDto(int _carID, string _tagNumber, string _make, string _model, short? _carYear, int? _categoryID, bool? _mp3Player, bool? _dVDPlayer, bool? _airConditioner, bool? _aBS, bool? _aSR, bool? _navigation, bool? _available, double? _latitude, double? _longitude, string _imageFileName, decimal? _rating, int? _numberOfRatings, CategoryDto _category, IList<RentalOrderDto> _rentalOrders)
		{
			this.CarID = _carID;
			this.TagNumber = _tagNumber;
			this.Make = _make;
			this.Model = _model;
			this.CarYear = _carYear;
			this.CategoryID = _categoryID;
			this.Mp3Player = _mp3Player;
			this.DVDPlayer = _dVDPlayer;
			this.AirConditioner = _airConditioner;
			this.ABS = _aBS;
			this.ASR = _aSR;
			this.Navigation = _navigation;
			this.Available = _available;
			this.Latitude = _latitude;
			this.Longitude = _longitude;
			this.ImageFileName = _imageFileName;
			this.Rating = _rating;
			this.NumberOfRatings = _numberOfRatings;
			this.Category = _category;
			this.RentalOrders = _rentalOrders;
		}
		
		[DataMember]
		public virtual string DtoKey { get; set; }
		
		[DataMember]
		public virtual int CarID { get;set; }

		[DataMember]
		public virtual string TagNumber { get;set; }

		[DataMember]
		public virtual string Make { get;set; }

		[DataMember]
		public virtual string Model { get;set; }

		[DataMember]
		public virtual short? CarYear { get;set; }

		[DataMember]
		public virtual int? CategoryID { get;set; }

		[DataMember]
		public virtual bool? Mp3Player { get;set; }

		[DataMember]
		public virtual bool? DVDPlayer { get;set; }

		[DataMember]
		public virtual bool? AirConditioner { get;set; }

		[DataMember]
		public virtual bool? ABS { get;set; }

		[DataMember]
		public virtual bool? ASR { get;set; }

		[DataMember]
		public virtual bool? Navigation { get;set; }

		[DataMember]
		public virtual bool? Available { get;set; }

		[DataMember]
		public virtual double? Latitude { get;set; }

		[DataMember]
		public virtual double? Longitude { get;set; }

		[DataMember]
		public virtual string ImageFileName { get;set; }

		[DataMember]
		public virtual decimal? Rating { get;set; }

		[DataMember]
		public virtual int? NumberOfRatings { get;set; }

		[DataMember]
		public virtual CategoryDto Category { get;set; }

		[DataMember]
		public virtual IList<RentalOrderDto> RentalOrders { get;set; }

	}
	
}
#pragma warning restore 1591