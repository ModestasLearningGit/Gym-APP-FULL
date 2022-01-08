create Database GymFull;
use GymFull;

create table MemberInfo
(
	MID  int NOT NULL IDENTITY(1,1) primary key,
	ImageName varchar(250) NOT NULL,
	Fname varchar(50) NOT NULL,
	Lname varchar(50) NOT NULL,
	Gender varchar(20) NOT NULL,
	Email varchar(150) UNIQUE NOT NULL,
	Dob varchar(100) NOT NULL,
	mAddress  varchar(250) NOT NULL,
	Mobile varchar(150) NOT NULL,
	JoinDate varchar(100) NOT NULL,
	TimeValid varchar(100) NOT NULL,
	TimeLeft varchar(50) NOT NULL
);

create table AdminInfo
(
	AID int NOT NULL IDENTITY(10000,1) primary key,
	ImageName varchar(250)  NOT NULL,
	Username varchar(50) UNIQUE NOT NULL,
	UserPassword varchar(50) NOT NULL,
	AdminStatus int NOT NULL,
	Comment varchar (350)
)


create table Logs(
LogID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
AddedBy int FOREIGN KEY  REFERENCES AdminInfo(AID),
TimeAdded varchar(250) NOT NULL,
Info varchar(400) NOT NULL
)
DROP TABLE Logs;
SELECT * FROM Logs;

insert into AdminInfo VALUES('no-image.jpg', 'Admin', 'Admin', 1, 'MAIN ADMIND ACCOOUNT, CANT BE DELETED');
insert into AdminInfo VALUES('no-image.jpg', 'Test', 'Test', 0, 'TEST ACCOUNT, NOT ADMIN');

select * from AdminInfo