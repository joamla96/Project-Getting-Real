DROP TABLE Schedule_Employees;
DROP TABLE Task;
DROP TABLE Schedule;
DROP TABLE Customer;
DROP TABLE Employee;

CREATE TABLE Employee (
	ID				INT				NOT NULL IDENTITY (1,1),
	Firstname		NVARCHAR(MAX)	NOT NULL,
	Lastname		NVARCHAR(MAX)	NOT NULL,
	Password		NVARCHAR(MAX)	NOT NULL,
	Email			NVARCHAR(MAX)	NOT NULL,
	Phone			NVARCHAR(15)	NOT NULL,
	Permission		INT				NOT NULL,
	HouseNo			INT				NOT NULL,
	FloorNo			INT				NULL,
	Entrance		NVARCHAR(12)	NULL,
	Streetname		NVARCHAR(MAX)	NOT NULL,
	City			NVARCHAR(MAX)	NOT NULL,
	PostCode		INT				NOT NULL,
CONSTRAINT Employee_PK PRIMARY KEY (ID)
);

CREATE TABLE Customer (
	ID				INT				NOT NULL IDENTITY (1,1),
	Firstname		NVARCHAR(MAX)	NOT NULL,
	Lastname		NVARCHAR(MAX)	NOT NULL,
	Password		NVARCHAR(MAX)	NOT NULL,
	Email			NVARCHAR(MAX)	NOT NULL,
	Phone			NVARCHAR(15)	NOT NULL,
	HouseNo			INT				NOT NULL,
	FloorNo			INT				NULL,
	Entrance		NVARCHAR(12)	NULL,
	Streetname		NVARCHAR(MAX)	NOT NULL,
	City			NVARCHAR(MAX)	NOT NULL,
	PostCode		INT				NOT NULL,
CONSTRAINT Customer_PK PRIMARY KEY (ID)
);


CREATE TABLE Schedule (
	ID				INT				NOT NULL IDENTITY (1,1),
	StartDate		DATETIME2		NOT NULL,
	FinishDate		DATETIME2		NOT NULL,
	CustomerID		INT				NOT NULL,				
CONSTRAINT	schedule_PK PRIMARY KEY (ID),
CONSTRAINT	scheCust_FK	FOREIGN KEY (CustomerID)
			REFERENCES Customer(ID)
);

CREATE TABLE Task (
	ID				INT				NOT NULL IDENTITY (1,1),
	ScheduleID		INT				NOT NULL,
	Description		NVARCHAR(MAX)	NOT NULL,
CONSTRAINT Task_PK PRIMARY KEY (ID),
CONSTRAINT TskSch_FK FOREIGN KEY (ScheduleID)
			REFERENCES Schedule(ID)
);

CREATE TABLE Schedule_Employees (
	ScheduleID		INT		NOT NULL,
	EmployeeID		INT		NOT NULL,
CONSTRAINT schemp_PK		PRIMARY KEY(ScheduleID, EmployeeID),
CONSTRAINT schemp_sch_FK	FOREIGN KEY(ScheduleID)
			REFERENCES Schedule(ID),
CONSTRAINT schemp_emp_FK	FOREIGN KEY(EmployeeID)
			REFERENCES Employee(ID)
);
