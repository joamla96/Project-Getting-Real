CREATE TABLE class_PET_OWNER (
	OwnerID			Int			PRIMARY KEY,
	OwnerLastName	Char(25)	NOT NULL,
	OwnerFirstName	Char(25)	NOT NULL,
	OwnerPhone		Char(15)	NULL,
	OwnerEmail		Varchar		NOT NULL UNIQUE
);

CREATE TABLE class_PET (
	PetID			Int			PRIMARY KEY,
	PetName			Char(25)	NOT NULL,
	PetType			Char(25)	NOT NULL,
	PetBreed		Char(25)	NOT NULL,
	PetDOB			Date		NULL,
	PetWeight		Float		NOT NULL,
	OwnerID			Int			NOT NULL
	CONSTRAINT		PET_POWNER_FK	FOREIGN KEY(OwnerID)
					REFERENCES class_PET_OWNER(OwnerID)
);