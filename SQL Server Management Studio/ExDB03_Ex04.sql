CREATE TABLE class_SEMINAR(
	SeminarID	Int		NOT NULL IDENTITY(1,1),
	SeminarDate	Datetime2	NOT NULL,
	Location	NVarChar	NOT NULL,
	SeminarTitle NVarChar	NOT NULL,

	CONSTRAINT	SEMINAR_PK	Primary Key(SeminarID)
);

CREATE TABLE class_ZIP_CITY(
	Zip		Int		NOT NULL,
	City	NVarChar	NOT NULL,
	CONSTRAINT	ZIP_PK Primary Key(Zip)
);

CREATE TABLE class_CUSTOMER(
	CustomerID		Int		NOT NULL IDENTITY(1,1),
	FirstName		NVarChar	NOT NULL,
	LastName		NVarChar	NOT NULL,
	Street			NVarChar	NOT NULL,
	Zip				Int			NOT NULL,

	CONSTRAINT	CUSTOMER_PK		Primary Key(CustomerID),
	CONSTRAINT	CUST_ZIP_FK		Foreign Key(Zip)
				REFERENCES	class_ZIP_CITY(Zip),			
);

CREATE TABLE class_SEMINAR_CUSTOMER(
	SeminarID	Int		NOT NULL,
	CustomerID	Int		NOT NULL,

	CONSTRAINT SEMCUS_PK	Primary Key(SeminarID, CustomerID),
	CONSTRAINT SEMCUS_SEM_FK	Foreign Key(SeminarID)
				REFERENCES class_SEMINAR(SeminarID),
	CONSTRAINT SEMCUS_CUS_FK	Foreign Key(CustomerID)
				REFERENCES class_CUSTOMER(CustomerID)
);