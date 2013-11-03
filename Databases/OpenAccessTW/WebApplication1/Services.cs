#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace WebApplication1.Services
{
	using Telerik.OpenAccess;
	using System.Linq.Dynamic;
	using OpenAccessModel9;
	using WebApplication1.Dto;
	using WebApplication1.Assemblers;
	using WebApplication1.Repositories;
	using WebApplication1.Converters;
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	
	public partial interface IService<TDto, TEntity>
	    where TEntity : class
		where TDto : IDtoWithKey
	{
	    IAssembler<TDto, TEntity> Assembler { get; }
	    IRepository<TEntity> Repository { get; }
	
	    IEnumerable<TDto> Find(Expression<Func<TEntity, bool>> filter);
	    IEnumerable<TDto> GetAll();
		
		IEnumerable<TDto> Find(int startRowIndex, int maximumRows);
	    IEnumerable<TDto> Find(string sortExpression, string filterExpression);
	    IEnumerable<TDto> Find(int? startRowIndex, int? maximumRows, string sortExpression, string filterExpression);
	    
		int Count();
	    int Count(string filterExpression);
		
		TDto GetByKey(string dtoKey);
	    string Add(TDto dto);
		void Update(TDto dto);
	    void Delete(TDto dto);	
	}
	
	public abstract partial class Service<TDto, TEntity> : IService<TDto, TEntity>
	    where TEntity : class
		where TDto : IDtoWithKey
	{
	    IAssembler<TDto, TEntity> assembler;
	    IRepository<TEntity> repository;
	
	    public Service(IAssembler<TDto, TEntity> assembler,
	        IRepository<TEntity> repository)
	    {
	        this.assembler = assembler;
	        this.repository = repository;
	    }
	
	    public IAssembler<TDto, TEntity> Assembler 
	    { 
	        get 
	        {
	            return this.assembler; 
	        } 
	    }
	
	    public IRepository<TEntity> Repository 
	    { 
	        get 
	        {
	            return this.repository; 
	        }
	    }
		
		public virtual IEnumerable<TDto> GetAll()
	    {
	        return this.assembler.Assemble(this.Repository.GetAll());
	    }
	
	    public virtual IEnumerable<TDto> Find(Expression<Func<TEntity, bool>> filter)
	    {
	        return this.Assembler.Assemble(this.Repository.Find(filter));
	    }
	
	    public virtual IEnumerable<TDto> Find(int startRowIndex, int maximumRows)
	    {
	        return this.Find(startRowIndex, maximumRows, null, null);
	    }
	
	    public virtual IEnumerable<TDto> Find(string sortExpression, string filterExpression)
	    {
	        return this.Find(null, null, sortExpression, filterExpression);
	    }
	
	    public virtual IEnumerable<TDto> Find(int? startRowIndex, int? maximumRows, string sortExpression, string filterExpression)
	    {
	        IQueryable<TEntity> query = this.Repository.GetAll();
	
	        if (!string.IsNullOrEmpty(filterExpression))
	        {
	            query = query.Where(filterExpression);
	        }
	        if (!string.IsNullOrEmpty(sortExpression))
	        {
	            query = query.OrderBy(sortExpression);
	        }
	        if (startRowIndex.HasValue)
	        {
	            query = query.Skip(startRowIndex.Value);
	        }
	        if (maximumRows.HasValue)
	        {
	            query = query.Take(maximumRows.Value);
	        }
	
	        return this.Assembler.Assemble(query);
	    }
	
	    public virtual int Count()
	    {
	        return this.Count(string.Empty);
	    }
	
	    public virtual int Count(string filterExpression)
	    {
	        IQueryable<TEntity> query = this.Repository.GetAll();
	
	        if (!string.IsNullOrEmpty(filterExpression))
	        {
	            query = query.Where(filterExpression);    
	        }
	
	        return query.Count();
	    }
	
	    
	    public virtual TDto GetByKey(string dtoKey)
	    {
	        ObjectKey key = KeyUtility.Instance.Convert<TEntity>(dtoKey);
			
	        return this.assembler.Assemble(this.Repository.Get(key));
	    }
	
	    public virtual string Add(TDto dto)
	    {
	        TEntity entity = this.assembler.Assemble(null, dto);
	
	        this.repository.Add(entity);
	
	        ObjectKey key = KeyUtility.Instance.Create(entity);
	
	        return KeyUtility.Instance.Convert(key);
	    }
	
	    public virtual void Update(TDto dto)
	    {
	        ObjectKey key = KeyUtility.Instance.Convert<TEntity>(dto.DtoKey);
	        TEntity entity = this.repository.Get(key);
	
	        this.assembler.Assemble(entity, dto);
	    }
	
	    public virtual void Delete(TDto dto)
	    {
			ObjectKey key = KeyUtility.Instance.Convert<TEntity>(dto.DtoKey);
	        TEntity entity = this.repository.Get(key);
	
	        this.Repository.Remove(entity);
	    }
	}
	
	public partial interface IRentalRateService : IService<RentalRateDto, RentalRate>
	{
	
	}
	
	public partial class RentalRateService : Service<RentalRateDto, RentalRate>, IRentalRateService
	{
	    public RentalRateService(IRentalRateAssembler assembler, IRentalRateRepository repository)
	        : base(assembler, repository)
	    {
	
	    }
	}
	
	public partial interface IRentalOrderService : IService<RentalOrderDto, RentalOrder>
	{
	
	}
	
	public partial class RentalOrderService : Service<RentalOrderDto, RentalOrder>, IRentalOrderService
	{
	    public RentalOrderService(IRentalOrderAssembler assembler, IRentalOrderRepository repository)
	        : base(assembler, repository)
	    {
	
	    }
	}
	
	public partial interface IEmployeeService : IService<EmployeeDto, Employee>
	{
	
	}
	
	public partial class EmployeeService : Service<EmployeeDto, Employee>, IEmployeeService
	{
	    public EmployeeService(IEmployeeAssembler assembler, IEmployeeRepository repository)
	        : base(assembler, repository)
	    {
	
	    }
	}
	
	public partial interface ICustomerService : IService<CustomerDto, Customer>
	{
	
	}
	
	public partial class CustomerService : Service<CustomerDto, Customer>, ICustomerService
	{
	    public CustomerService(ICustomerAssembler assembler, ICustomerRepository repository)
	        : base(assembler, repository)
	    {
	
	    }
	}
	
	public partial interface ICategoryService : IService<CategoryDto, Category>
	{
	
	}
	
	public partial class CategoryService : Service<CategoryDto, Category>, ICategoryService
	{
	    public CategoryService(ICategoryAssembler assembler, ICategoryRepository repository)
	        : base(assembler, repository)
	    {
	
	    }
	}
	
	public partial interface ICarService : IService<CarDto, Car>
	{
	
	}
	
	public partial class CarService : Service<CarDto, Car>, ICarService
	{
	    public CarService(ICarAssembler assembler, ICarRepository repository)
	        : base(assembler, repository)
	    {
	
	    }
	}
}
#pragma warning restore 1591
