
Create Table Users
(
UserID varchar(10) not null primary key,
FullName varchar(30),
UserName varchar(30),
Password varchar(30),
Gender varchar(10),
DateOfBirth date, 
Weight int,
Height int,
PhoneNumber varchar(30), 
Address varchar(50),
Role varchar(20)
);

Select * from Member


Create Table Admin
(
AdminID int not null primary key,
Position varchar(30),
UserID varchar(10) references Users (UserID)
);



Create Table Member
(
MemberID int not null primary key,
MemberFees int,
UserID varchar(10) references Users (UserID)
);
