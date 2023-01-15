
--UC1_Create Database
CREATE DATABASE Payroll_Service;
USE Payroll_Service;
--UC2_CreateTable
CREATE TABLE Employee_Payroll(
Id int PRIMARY KEY IDENTITY(1,1),
Name varchar(30) NOT NULL,
Salary BIGINT NOT NULL,
Start DATE NOT NULL
);
--UC3_INSERT INTO TABLE
INSERT INTO Employee_Payroll(Name,Salary,Start)VALUES('AKASH',4000,'2000-02-23'),('Vaibhav',5000,'2001-09-22'),('Vishal',7000,'2004-03-12');
--UC4
SELECT * FROM Employee_Payroll;
--UC5
SELECT Salary FROM Employee_Payroll WHERE Name='AKASH';
SELECT * FROM Employee_Payroll WHERE Start BETWEEN CAST('2001-02-23' AS DATE) AND GETDATE();
--UC6
ALTER TABLE Employee_Payroll ADD Gender varchar(10)
UPDATE Employee_Payroll SET Gender='M' WHERE Name='AKASH'
UPDATE Employee_Payroll SET Gender='M' WHERE Name='Vaibhav'
UPDATE Employee_Payroll SET Gender='M' WHERE Name='Vishal'
--UC7
SELECT AVG(Salary)  FROM Employee_Payroll WHERE Gender='M' GROUP BY Gender
SELECT SUM(Salary)  FROM Employee_Payroll WHERE Gender='M' GROUP BY Gender
SELECT MAX(Salary) FROM Employee_Payroll WHERE Gender = 'M' GROUP BY Gender
SELECT MIN(Salary) FROM Employee_Payroll WHERE Gender = 'M' GROUP BY Gender
SELECT COUNT(Gender) FROM Employee_Payroll WHERE Gender = 'M' GROUP BY Gender
--UC8 extend employee_payroll add phone, address and department

ALTER TABlE Employee_Payroll ADD Department varchar(90) NOT NULL DEFAULT 'Engineer';
ALTER TABLE Employee_Payroll ADD Phone_No BIGINT;
ALTER TABLE Employee_Payroll ADD Address varchar(350) DEFAULT 'INDIA';

--UC9 Employee_payroll table to have Basic Pay, Deductions, Taxable Pay, Income Tax, Net Pay
ALTER TABLE Employee_Payroll ADD Basic_Pay FLOAT NOT NULL DEFAULT 20000;
ALTER TABLE Employee_Payroll ADD Deductions FLOAT NOT NULL DEFAULT 2000;
ALTER TABLE Employee_Payroll ADD Taxable_Pay FLOAT NOT NULL DEFAULT 1000;
ALTER TABLE Employee_Payroll ADD Income_Tax FLOAT NOT NULL DEFAULT 100;
ALTER TABLE Employee_Payroll ADD Net_Pay FLOAT NOT NULL DEFAULT 2000;
SELECT * FROM Employee_Payroll;
--UC10
UPDATE Employee_Payroll SET Department = 'SALES' WHERE Name ='Vishal';
INSERT INTO Employee_Payroll VALUES('Akash',3000,'2019-06-07',7864646888,'SRE','Marketing',10,10,10,10,3000);

CREATE TABLE Demo_Table(
Id int PRIMARY KEY IDENTITY(1,1));

--UC11 DELETE
DROP TABLE Demo_Table;
--UC12
DELETE FROM Employee_Payroll WHERE Id =4;
--CURD
--C=CREATE
--U=UPDATE
--R=RETRIVE
--D=DELETE

CREATE PROCEDURE SPRetrieveAllDetails
AS BEGIN 
SELECT * FROM Employee_Payroll
END

CREATE PROCEDURE SPAddNewEmployee(
@EmployeeId INT,
@EmployeeName VARCHAR(40),
@Gender varchar(6),
@PhoneNo varchar(16),
@EmployeeAddress VARCHAR(100),
@StartDate DATE 
)
AS BEGIN
INSERT INTO Employeepayroll VALUES(@EmployeeId,@EmployeeName,@Gender,@PhoneNo,@EmployeeAddress,@StartDate)
END

CREATE TABLE Employeepayroll(EmployeeId INT,
EmployeeName VARCHAR(40),
Gender varchar(6),
PhoneNo varchar(16),
EmployeeAddress VARCHAR(100),
StartDate DATE )
SELECT * FROM Employeepayroll

CREATE PROCEDURE SPUpdateDataInDB(
@Name VARCHAR(30),
@Address VARCHAR(350),
@Phone_No VARCHAR(20)
)
AS BEGIN
UPDATE Employee_Payroll SET Address=@Address,Phone_No=@Phone_No WHERE Name=@Name
END
SELECT * FROM Employee_payroll

CREATE PROCEDURE SPDeleteDataFromDB(
@Name VARCHAR(30)
)
AS BEGIN
DELETE FROM Employee_Payroll WHERE Name=@Name
END
SELECT * FROM Employee_payroll