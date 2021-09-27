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


