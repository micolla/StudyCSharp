Create Database EmployeeCard;
Go
Use EmployeeCard;
go

Create table Documents
(
DocumentId int Primary Key Identity(1,1)
,DocumentTypeId int Not null
,Serial varchar(20)
,Number varchar(20)
);
Create table DocumentTypes
(
DocumentTypeId int Primary Key Identity(1,1)
,DocumentType varchar(100)
);
CREATE TABLE [dbo].Departments
(
	[DeptId] INT NOT NULL PRIMARY KEY Identity(1,1)
	,DepartmentName varchar(255) Not NUll Unique
	,ParentDeptId int
);
CREATE TABLE Roles(
RoleID INT NOT NULL PRIMARY KEY Identity(1,1)
,RoleName varchar(100) Not NULL
);
CREATE TABLE [dbo].[Employees] (
    [EmplId]     INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (60) NOT NULL,
    [SecondName] VARCHAR (60) NOT NULL,
    [BirthDay]   DATE         NOT NULL,
    [DocumentId] INT          NOT NULL,
    [DeptId]     INT          NOT NULL,
	RoleID int NOT NULL,
    PRIMARY KEY CLUSTERED ([EmplId] ASC)
);
Insert into Departments(DepartmentName)
values('Department 1'),('Department 2'),('Department 3'),('Department 4'),
('Department 5'),('Department 6'),('Department 7'),('Department 8'),
('Department 9'),('Department 10'),('Department 11'),('Department 12'),
('Department 13'),('Department 14'),('Department 15'),('Department 16'),
('Department 17'),('Department 18'),('Department 19'),('Department 20');
declare @dept_id int;
select @dept_id=deptId from Departments where DepartmentName='Department 15';
Insert into Departments(DepartmentName,ParentDeptId)
values('Department 28',@dept_id),('Department 29',@dept_id),('Department 30',@dept_id)
,('Department 31',@dept_id),('Department 32',@dept_id),('Department 33',@dept_id)
,('Department 34',@dept_id),('Department 35',@dept_id),('Department 36',@dept_id),
('Department 37',@dept_id),('Department 38',@dept_id),('Department 39',@dept_id),('Department 40',@dept_id),('Department 41',@dept_id),('Department 42',@dept_id),('Department 43',@dept_id),('Department 44',@dept_id),('Department 45',@dept_id),('Department 46',@dept_id),('Department 47',@dept_id),('Department 48',@dept_id),('Department 49',@dept_id),('Department 50',@dept_id),('Department 51',@dept_id),('Department 52',@dept_id),('Department 53',@dept_id),('Department 54',@dept_id),('Department 55',@dept_id),('Department 56',@dept_id),('Department 57',@dept_id),('Department 58',@dept_id),('Department 59',@dept_id),('Department 60',@dept_id),('Department 61',@dept_id),('Department 62',@dept_id),('Department 63',@dept_id),('Department 64',@dept_id),('Department 65',@dept_id),('Department 66',@dept_id),('Department 67',@dept_id),('Department 68',@dept_id),('Department 69',@dept_id),('Department 70',@dept_id),('Department 71',@dept_id),('Department 72',@dept_id),('Department 73',@dept_id),('Department 74',@dept_id),('Department 75',@dept_id),('Department 76',@dept_id),('Department 77',@dept_id),('Department 78',@dept_id),('Department 79',@dept_id),('Department 80',@dept_id),('Department 81',@dept_id),('Department 82',@dept_id),('Department 83',@dept_id),('Department 84',@dept_id),('Department 85',@dept_id),('Department 86',@dept_id),('Department 87',@dept_id),('Department 88',@dept_id),('Department 89',@dept_id),('Department 90',@dept_id),('Department 91',@dept_id),('Department 92',@dept_id),('Department 93',@dept_id),('Department 94',@dept_id),('Department 95',@dept_id),('Department 96',@dept_id),('Department 97',@dept_id),('Department 98',@dept_id),('Department 99',@dept_id),('Department 100',@dept_id),('Department 101',@dept_id),('Department 102',@dept_id),('Department 103',@dept_id),('Department 104',@dept_id),('Department 105',@dept_id),('Department 106',@dept_id),('Department 107',@dept_id)
,('Department 108',@dept_id),('Department 109',@dept_id),('Department 110',@dept_id);

select @dept_id=deptId from Departments where DepartmentName='Department 4';
Insert into Departments(DepartmentName,ParentDeptId)
values('Department 111',@dept_id),('Department 112',@dept_id),('Department 113',@dept_id),('Department 114',@dept_id),('Department 115',@dept_id),('Department 116',@dept_id),('Department 117',@dept_id),('Department 118',@dept_id),('Department 119',@dept_id),('Department 120',@dept_id),('Department 121',@dept_id),('Department 122',@dept_id),('Department 123',@dept_id),('Department 124',@dept_id),('Department 125',@dept_id),('Department 126',@dept_id),('Department 127',@dept_id),('Department 128',@dept_id),('Department 129',@dept_id),('Department 130',@dept_id),('Department 131',@dept_id),('Department 132',@dept_id),('Department 133',@dept_id),('Department 134',@dept_id),('Department 135',@dept_id),('Department 136',@dept_id),('Department 137',@dept_id),('Department 138',@dept_id),('Department 139',@dept_id),('Department 140',@dept_id),('Department 141',@dept_id),('Department 142',@dept_id),('Department 143',@dept_id),('Department 144',@dept_id),('Department 145',@dept_id),('Department 146',@dept_id),('Department 147',@dept_id),('Department 148',@dept_id),('Department 149',@dept_id),('Department 150',@dept_id),('Department 151',@dept_id),('Department 152',@dept_id),('Department 153',@dept_id),('Department 154',@dept_id),('Department 155',@dept_id),('Department 156',@dept_id),('Department 157',@dept_id),('Department 158',@dept_id),('Department 159',@dept_id),('Department 160',@dept_id),('Department 161',@dept_id),('Department 162',@dept_id),('Department 163',@dept_id),('Department 164',@dept_id),('Department 165',@dept_id),('Department 166',@dept_id),('Department 167',@dept_id),('Department 168',@dept_id),('Department 169',@dept_id),('Department 170',@dept_id),('Department 171',@dept_id),('Department 172',@dept_id),('Department 173',@dept_id),('Department 174',@dept_id),('Department 175',@dept_id),('Department 176',@dept_id),('Department 177',@dept_id),('Department 178',@dept_id),('Department 179',@dept_id),('Department 180',@dept_id),('Department 181',@dept_id),('Department 182',@dept_id),('Department 183',@dept_id),('Department 184',@dept_id),('Department 185',@dept_id),('Department 186',@dept_id),('Department 187',@dept_id),('Department 188',@dept_id),('Department 189',@dept_id),('Department 190',@dept_id),('Department 191',@dept_id),('Department 192',@dept_id),('Department 193',@dept_id),('Department 194',@dept_id),('Department 195',@dept_id),('Department 196',@dept_id),('Department 197',@dept_id),('Department 198',@dept_id),('Department 199',@dept_id),('Department 200',@dept_id),('Department 201',@dept_id),('Department 202',@dept_id),('Department 203',@dept_id),('Department 204',@dept_id),('Department 205',@dept_id),('Department 206',@dept_id),('Department 207',@dept_id),('Department 208',@dept_id),('Department 209',@dept_id),('Department 210',@dept_id),('Department 211',@dept_id),('Department 212',@dept_id),('Department 213',@dept_id),('Department 214',@dept_id),('Department 215',@dept_id),('Department 216',@dept_id),('Department 217',@dept_id),('Department 218',@dept_id),('Department 219',@dept_id),('Department 220',@dept_id),('Department 221',@dept_id),('Department 222',@dept_id),('Department 223',@dept_id),('Department 224',@dept_id),('Department 225',@dept_id),('Department 226',@dept_id),('Department 227',@dept_id),('Department 228',@dept_id),('Department 229',@dept_id),('Department 230',@dept_id),('Department 231',@dept_id),('Department 232',@dept_id),('Department 233',@dept_id),('Department 234',@dept_id),('Department 235',@dept_id),('Department 236',@dept_id),('Department 237',@dept_id),('Department 238',@dept_id),('Department 239',@dept_id),('Department 240',@dept_id),('Department 241',@dept_id),('Department 242',@dept_id),('Department 243',@dept_id),('Department 244',@dept_id),('Department 245',@dept_id),('Department 246',@dept_id),('Department 247',@dept_id),('Department 248',@dept_id),('Department 249',@dept_id),('Department 250',@dept_id),('Department 251',@dept_id),('Department 252',@dept_id),('Department 253',@dept_id),('Department 254',@dept_id),('Department 255',@dept_id),('Department 256',@dept_id),('Department 257',@dept_id),('Department 258',@dept_id),('Department 259',@dept_id),('Department 260',@dept_id),('Department 261',@dept_id),('Department 262',@dept_id),('Department 263',@dept_id),('Department 264',@dept_id),('Department 265',@dept_id),('Department 266',@dept_id),('Department 267',@dept_id),('Department 268',@dept_id),('Department 269',@dept_id),('Department 270',@dept_id),('Department 271',@dept_id),('Department 272',@dept_id),('Department 273',@dept_id),('Department 274',@dept_id),('Department 275',@dept_id),('Department 276',@dept_id),('Department 277',@dept_id),('Department 278',@dept_id),('Department 279',@dept_id),('Department 280',@dept_id),('Department 281',@dept_id),('Department 282',@dept_id),('Department 283',@dept_id),('Department 284',@dept_id),('Department 285',@dept_id),('Department 286',@dept_id),('Department 287',@dept_id),('Department 288',@dept_id),('Department 289',@dept_id),('Department 290',@dept_id);


INSERT INTO DocumentTypes(DocumentType)
values('Passport'),('Driver License');
INSERT INTO Roles(RoleName)
values('Специалист'),('Ведущий специалист'),('Начальник');

INSERT INTO Documents(DocumentTypeId,Serial,Number)
values(1,'2333','32EE22222'),(1,'2333','32EE22223'),(1,'2334','32EE22224'),(2,'2333','32EE22225'),(1,'2333','32EE22226'),(1,'2333','32EE22227'),(2,'2333','32EE22228'),(1,'2333','32EE22229'),(1,'2353','32EE22230'),(1,'2333','32EE22231'),(1,'2333','32EE22232'),(1,'2333','32EE22233'),(2,'23RR','32EE22234'),(1,'2343','32EE22235'),(1,'2333','32EE22236'),(1,'2333','32EE22237'),(1,'2333','32EE22238'),(1,'2333','32EE22239'),(2,'3322','32EE22240'),(1,'2335','32EE22241');

insert into Employees(FirstName,SecondName,BirthDay,DeptId,DocumentId,RoleID)
values('Name 1','SecondName 1','1990-12-22',27,1,1)
,('Name 2','SecondName 2','1990-12-22',27,2,1)
,('Name 3','SecondName 3','1990-12-22',27,3,1)
,('Name 4','SecondName 4','1990-12-22',27,4,2)
,('Name 5','SecondName 5','1990-12-22',27,5,2)
,('Name 6','SecondName 6','1990-12-22',27,6,1)
,('Name 7','SecondName 7','1990-12-22',27,7,1)
,('Name 8','SecondName 8','1990-12-22',27,8,3)
,('Name 9','SecondName 9','1990-12-22',27,9,1)
,('Name 10','SecondName 10','1990-12-22',138,10,1)
,('Name 11','SecondName 11','1990-12-22',138,11,2)
,('Name 12','SecondName 12','1990-12-22',138,12,3);
