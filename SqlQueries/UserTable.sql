CREATE TABLE UserInfo (
    id int IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(255) NOT NULL,
    LastName varchar(255),
    Email varchar(255),
	Password varchar(255),
	PhoneNumber varchar(255)
);
