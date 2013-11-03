--Task 4
select * from Departments

--Task 5
select Name from Departments

--Task 6
select FirstName,LastName, Salary from Employees

--Task 7
select concat(FirstName,' ',MiddleName, ' ', LastName) as [Full Name] from Employees

--Task 8
select FirstName +'.' + Lastname +'@telerik.com' as [Full Email Addresses] from Employees

--Task 9
select distinct salary from Employees

--Task 10
select * from Employees
where JobTitle = 'Sales Representative'

--Task 11
select FirstName from Employees
where FirstName like 'SA%'

--Task 12
select LastName from Employees
where LastName like '%ei%'

--Task 13
select Salary from Employees
where salary between 20000 and 30000

--Task 14
select FirstName +' ' + LastName as Name, Salary from Employees
where Salary in (25000, 14000, 12500,23600)

--Task 15
select FirstName +' ' + LastName as Name  from Employees
where ManagerID is null

--Task 16
select FirstName +' ' + LastName as Name, Salary  from Employees
where Salary>50000
order by Salary desc

--Task 17
select top 5 FirstName +' ' + LastName as Name, Salary  from Employees
order by Salary desc

--Task 18
select e.FirstName +' ' + e.LastName as Name, a.AddressText
from Employees e 
inner join Addresses a
on e.AddressID = a.AddressID

--Task 19
select e.FirstName +' ' + e.LastName as Name, a.AddressText
from Employees e, Addresses a
where e.AddressID = a.AddressID

--Task 20
select e.FirstName +' ' + e.LastName as Name, a.FirstName +' ' + a.LastName as Manager
from Employees e
join Employees a
on e.ManagerID = a.EmployeeID

--Task 21
select e.FirstName +' ' + e.LastName as Employee, a.FirstName +' ' + a.LastName as Manager, adr.AddressText
from Employees e
left outer join Employees a
on e.ManagerID = a.EmployeeID
join Addresses adr
on e.AddressID = adr.AddressID

--Task 22
select Name from Departments
union
select Name from Towns

--Task 23
select e.FirstName +' ' + e.LastName as Employee, a.FirstName +' ' + a.LastName as Manager
from Employees e
left outer join Employees a
on e.ManagerID = a.EmployeeID

select e.FirstName +' ' + e.LastName as Manager, a.FirstName +' ' + a.LastName as Employee
from Employees e
right outer join Employees a
on e.EmployeeID = a.ManagerID

--Task 24
select FirstName +' ' + LastName as Employee, HireDate
from Employees a, Departments dep
where (a.DepartmentID = dep.DepartmentID and dep.Name in( 'sales', 'Finance')) and (a.HireDate between '1/1/1995' and '12/31/2005')