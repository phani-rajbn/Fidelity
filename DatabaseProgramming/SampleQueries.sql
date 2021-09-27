--TO create databases:
Use master
Create database FidelityDB -- Only Dbcreator can create a database and he/she will have access to the master database, which is a system database inside SQL server for managing databases in it. 
SELECT name from master.sys.databases order by name--Command for listing all dbs in the SQL server. 
DROP Database if exists FidelityDB;--U cannot drop the Db if U R using it. 
Use FidelityDB; -- Allows to run the commands from now on, on the selected database.
-----------------------------------------------------------------------------------------------
Create table Customer
(
  CustomerID int primary key,
  CustomerName varchar(50) not null,
  VisitTime dateTime, 
  ContactNo BIGint Not Null
)

sp_tables --Lists the tables in the current database. sp_tables is a stored procedure.(Function).
sp_columns @table_name = 'Customer'

alter table Customer
Add City varchar(50) NOT NULL check(City in ('Bangalore','Mysore','Hassan','Dharwad','Mangalore'))
--Expect the data in the City column to be any of the mentioned values. 

alter table customer
drop constraint CK__Customer__City__38996AB5 --If UR Column has some constraints, U must delete the rule before deleting the column

alter table customer
drop column City--U can drop multiple columns seperated by ,

alter table Customer
alter column City varchar(20) NOT NULL
--U can alter only the data type, NOT null and the size of the data

---------------------------------------Data Manipulation Language-------------------------------------------
Insert into Customer values(111, 'Phaniraj', '12-04-2020', 9945205684, 'Bangalore')
Insert into Customer values(112, 'Phaniraj', '12-04-2020', 9945205684, 'Mangalore')
--Insert some 15 rows before U take a break-----------------------------------------------------------------

------------DELETE Syntax-----------------------------
Delete from Customer where CustomerID = 111 -- and City = 'Mangalore' --This query has not deleted any row as one of the conditions is failing. The delete statement when executed, will return the no of rows affected. If the rows affected is 0 it means that no rows were deleted while the statement executed.
---------------------UPDATE Statement is used to modify the data in the database------------------------------
Update Customer set City = 'Dharwad' where CustomerID = '111' --Use update to change the existing data based on a condition. UPDATE must be followed by the table name, then with a set command to set the values of the specified columns each seperated by a ,. Finally U should add the condition of the row to manipulate using where clause.

Update Customer Set VisitTime = GETDATE(); --When U dont specify the where clause, all the rows will be updated. GETDATE is a built in function of SQL server to get the Server date. 

------------------------SELECT Activities of the Application-------------------------------------------------
Select * from Customer  --* is a wild charecter for all
Select * from Customer where City = 'Bangalore' and CustomerName like '%say%' --Contains functionality of C# string. While processing the SELECT statement, it processes the From clause first and then the SELECT clause. 
Select TOP(10) CustomerName, City from Customer -- Use top function to get the first top entries in the table.

Select Top 15 PERCENT  CustomerName from Customer --U can mix TOP with PERCENT to get the Specific count of rows.

select Distinct City from Customer -- Use this for getting unique data from the select

Select Top 20 CustomerName , City from Customer order by City Desc -- DESC means descending order in T-SQL.

Select CustomerName, VisitTime from Customer order by 2 desc, 1 --Sort by Ordinal positions of the selected Columns. However, this is not considered as a good practice.  

Select CustomerID, CustomerName, VisitTime from Customer order by CustomerID Offset 100 ROWS fetch next 20 rows only;--Offset specifies the rows to skip before starting to return the rows from the query. 

Select CustomerName, VisitTime from Customer where VisitTime between '2019-01-01' And GETDATE() 

Select CustomerName, VisitTime from Customer where YEAR(VisitTime)  = 2020 --Get the Year part of the datetime

Select CustomerName,VisitTime from customer where DATEPART(year, VisitTime) = 2020

Select Day(VISITTIME) as Day, MONTH(VISITTIME) as Month , Year(VISITTIME) as Year from Customer

Select Day(VISITTIME) as Day, MONTH(VISITTIME) as Month , Year(VISITTIME) as Year from Customer  where Year(VISITTIME) in (2020, 2015, 2000)
--------------------------------------------------------------------------------------------
Use FidelityDB
create table candidates
(
id int primary key identity,
fullname varchar(100) not null
)

create table employees(
	id int primary key identity,
fullname varchar(100) not null
)

Insert into candidates values('Phaniraj'),('Gopal'),('Rajesh'), ('Suresh'),('Kumar'),('Rajneesh'), ('Sharma'), ('Naresh'),('Venkatesh'), ('Sai'), ('Ramnath'),('Vinod'),('Banu Prakash'),('Murali'), ('Janardhan'),('Srinivas'),('Pavani'),('Pratyusha'),('Sania'),('Kulkarni'), ('Nagesh')

INSERT INTO 
    candidates(fullname)
VALUES
    ('John Doe'),
    ('Lily Bush'),
    ('Peter Drucker'),
    ('Jane Doe');
Select * from candidates

Insert into employees values('Phaniraj'),('Hanumanth'),('Sudhindra'), ('Raghu'),('Kumar'),('Rajneesh'), ('Sharma'), ('Naresh'),('Venkatesh'), ('Sai'), ('Ramnath'),('Vinod'),('Banu Prakash'),('Murali'), ('Janardhan'),('Micheal'),('Fayaz'),('Syamala'),('Sania'),('Kulkarni'), ('Zaheer')

INSERT INTO 
    employees(fullname)
VALUES
    ('John Doe'),
    ('Jane Doe'),
    ('Michael Scott'),
    ('Jack Sparrow');

-----------to fetch data from 2 or more tables, we use JOIN statement-------------------------------------------
--Inner Join: get the matching data from 2 tables based on the condition.  The tables are called as left table and right table depending on the side of the join the tables are mentioned. 
Select c.id c_id, c.fullname candidate_name, e.id e_id ,e.fullname employee_name from candidates c inner join employees e on e.fullname = c.fullname -- alias are given to the column names when U have records with similar data types and similar content. 
--U get all the things from the left and matching things from the right.
Select c.id c_id, c.fullname candidate_name, e.id e_id ,e.fullname employee_name from candidates c left join employees e on e.fullname = c.fullname where e.id is null -- U get only the data of the left table but not from th right table. 

--The reverse of left join is right join. 
Select c.id c_id, c.fullname candidate_name, e.id e_id ,e.fullname employee_name from candidates c right join employees e on e.fullname = c.fullname
-----------To get data from both the tables, we use Full Join
Select c.id c_id, c.fullname candidate_name, e.id e_id ,e.fullname employee_name from candidates c full join employees e on e.fullname = c.fullname

Select c.id c_id, c.fullname candidate_name, e.id e_id ,e.fullname employee_name from candidates c full join employees e on e.fullname = c.fullname where c.id is null or e.id is null

------------------------------having clause--------------------------------------
Select  City, Count(City) as NoOfPeople from Customer group by City having Count(City) <= 100
--Group the Content and select based on an aggregate value, then having would be needed. Having clause will work in conjunction with the group by clause to filter the groups on a specified list of conditions. 

--------------------------------------Stored Procedures----------------------------------------------
--Prepared Statements that U can save and use it multiple times without a need to parse it when it is executed. Unlike regular statements, the SP is parsed once and only once. This will optimize the performance of the execution for frequently used queries and statements. They internally behave like functions except they cannot be used like expressions. 

Alter table customer
add constraint visitDate
default getDate() for visittime

alter procedure InsertCustomer
@id int, @name varchar(50), @contact bigint, @city varchar(20)
as
Insert into Customer(CustomerID, CustomerName, ContactNo, City) values(@id, @name, @contact, @city)

declare @varTime Datetime = getDate()--declaring variable and using it in Stored Proc....
exec InsertCustomer @id = 557, @name ='Ferdinand', @contact = 234234434, @city = 'Hassan'
select * from Customer where CustomerID = 557
----------------------Functions in SQL SErver-------------
--Functions are one that can be used like expresssions in an SQL Statement. Some of them are aggregate functions,scalar functions, Table value functions. AVG,COUNT, Last, Max, Min, Sum are called aggregate functions. Scalar value functions are those like Upper, Lower, Mid, ROUND, Now and so forth..

SELECT COUNT(DISTINCT CITY) as TotalCities from Customer

SELECT MAX(ContactNo) from Customer

-------------------------For avg functions----------------------------------------
Create table Student
(
Id int primary key identity,
Name varchar(20) not null, 
Marks int not null, 
age int not null
)

Select Avg(Marks) as AvgScore from Student
Select Sum(Marks) as TotalScore from Student
Select Max(Marks) as MaxScore from Student
Select Min(Marks) as MinScore from Student
Select Count(Distinct Age) from Student

Select UPPER(Name) as Student from Student

SELECT CONCAT(Upper(Name), ' is aged ' , age) from student

SELECT Format(ContactNo, '#####-#####') as Phone_No from Customer

Create function GetPhone( @CustomerID int)
RETURNS BigInt
BEGIN
DECLARE @phone bigint
Set @phone = (SELECT CONTactNo from Customer where CustomerID = @CustomerID)
RETURN @phone
END

Select CustomerName, dbo.GetPhone(CustomerID) as PhoneNO from Customer

Create Function CreateDate(@dt int, @mon int, @yr int)
RETURNS DATE
BEGIN
DECLARE @date DATE
Set @date = (SELECT CONVERT(date, CONCAT(@mon,'/',@dt,'/', @yr)))--dd/MM/yyyy
RETURN @date;
END

SELECT dbo.CreateDate(25,12,2019);