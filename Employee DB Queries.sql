create database EmployeeDB 

use EmployeeDB

create table Employee 
(
EmployeelD int primary key identity (1,1),
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Gender nvarchar(6) not null,
HiredDate date not null,
Salary money not null
)

select * from Employee 

go
Create procedure spAddEmployee(    
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@Gender NVARCHAR(6),
@HiredDate DATE,
@Salary MONEY
)
as
Begin
Insert into Employee 
(FirstName,LastName,Gender, HiredDate,Salary) 
Values (@FirstName,@LastName,@Gender, @HiredDate,@Salary)
End

go
Create procedure spUpdateEmployee
(
@EmployeelD INTEGER ,
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@Gender NVARCHAR(6),
@HiredDate DATE,
@Salary MONEY
) 
as
begin
Update Employee
set 
FirstName=@FirstName,
LastName=@LastName,
Gender=@Gender,
HiredDate=@HiredDate,
Salary=@Salary
where EmployeelD=@EmployeelD
End


go
Create procedure spDeleteEmployee 
(
@EmployeelD int
)
as
begin
Delete from Employee where EmployeelD=@EmployeelD
End

go
Create procedure spGetAllEmployees
as
Begin
select * from Employee
order by EmployeelD 
End

