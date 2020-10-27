Create table tblEmployee(
employeeId int IDENTITY(1,1) PRIMARY KEY,  
firstName varchar(250) not null,
lastName varchar(100) not null,
jobTitle varchar(100),
yearsAtCompany int,
nickName varchar(100),
Active bit not null
)

create table tblServiceOrder(
serviceOrderId int IDENTITY(1,1) PRIMARY KEY,
title varchar(250) not null,
serviceDescription varchar(1000),
dueDate datetime not null,
dateAssigned datetime not null,
Active bit not null,
employeeId int FOREIGN KEY REFERENCES tblEmployee(employeeId)
)

