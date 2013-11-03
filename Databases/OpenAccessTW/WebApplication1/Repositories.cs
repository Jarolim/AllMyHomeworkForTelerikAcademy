#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace WebApplication1.Repositories
{
	using Telerik.OpenAccess;
	using OpenAccessModel9;
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	
	public partial interface IRepository<TEntity>
	{
	    void Add(TEntity entity);
	    void Remove(TEntity entity);
	
	    TEntity Get(ObjectKey objectKey);
	    
	    IQueryable<TEntity> GetAll();
	
	    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
	}
	
	public partial class Repository<TEntity> : IRepository<TEntity>
	        where TEntity : class
	{
	    protected IUnitOfWork unitOfWork;
	
	    public Repository(IUnitOfWork unitOfWork)
	    {
	        this.unitOfWork = unitOfWork;
	    }
	
	    public void Add(TEntity entity)
	    {
			this.unitOfWork.Add(entity);
	    }
	
	    public void Remove(TEntity entity)
	    {
	        this.unitOfWork.Delete(entity);
	    }
	
	    public IQueryable<TEntity> GetAll()
	    {
	        return this.unitOfWork.GetAll<TEntity>();
	    }
	
	    public TEntity Get(ObjectKey objectKey)
	    {
	        return this.unitOfWork.GetObjectByKey<TEntity>(objectKey);
	    }
	
	    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
	    {
	        return this.unitOfWork.GetAll<TEntity>().Where(predicate);
	    }
	}
	
	public partial interface IRentalRateRepository : IRepository<RentalRate>
	{ 
	
	}
	
	public partial class RentalRateRepository : Repository<RentalRate>, IRentalRateRepository
	{
	    public RentalRateRepository(IEntitiesModelUnitOfWork unitOfWork)
	        : base(unitOfWork)
	    {
	    }
	}
	
	public partial interface IRentalOrderRepository : IRepository<RentalOrder>
	{ 
	
	}
	
	public partial class RentalOrderRepository : Repository<RentalOrder>, IRentalOrderRepository
	{
	    public RentalOrderRepository(IEntitiesModelUnitOfWork unitOfWork)
	        : base(unitOfWork)
	    {
	    }
	}
	
	public partial interface IEmployeeRepository : IRepository<Employee>
	{ 
	
	}
	
	public partial class EmployeeRepository : Repository<Employee>, IEmployeeRepository
	{
	    public EmployeeRepository(IEntitiesModelUnitOfWork unitOfWork)
	        : base(unitOfWork)
	    {
	    }
	}
	
	public partial interface ICustomerRepository : IRepository<Customer>
	{ 
	
	}
	
	public partial class CustomerRepository : Repository<Customer>, ICustomerRepository
	{
	    public CustomerRepository(IEntitiesModelUnitOfWork unitOfWork)
	        : base(unitOfWork)
	    {
	    }
	}
	
	public partial interface ICategoryRepository : IRepository<Category>
	{ 
	
	}
	
	public partial class CategoryRepository : Repository<Category>, ICategoryRepository
	{
	    public CategoryRepository(IEntitiesModelUnitOfWork unitOfWork)
	        : base(unitOfWork)
	    {
	    }
	}
	
	public partial interface ICarRepository : IRepository<Car>
	{ 
	
	}
	
	public partial class CarRepository : Repository<Car>, ICarRepository
	{
	    public CarRepository(IEntitiesModelUnitOfWork unitOfWork)
	        : base(unitOfWork)
	    {
	    }
	}
}
#pragma warning restore 1591
