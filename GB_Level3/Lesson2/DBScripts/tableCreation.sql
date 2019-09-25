If object_id('Server_smtp') is not null
	drop table Server_smtp;
create table Server_smtp
(server_id  int Primary Key identity(1,1)
,address varchar(25) not null
,port int not null);

go
If object_id('Sender') is not null
	drop table Sender;
create table Sender
(sender_id int Primary Key identity(1,1)
,login varchar(50) not null
,password varchar(100) not null
,email varchar(255)
,server_server_id int);

go
If object_id('Recipient') is not null
	drop table Recipient;
create table Recipient
(recipient_id int Primary Key identity(1,1)
,name varchar(255) not null
,email varchar(255) not null
,description varchar(255));

go
If object_id('RecipientsList') is not null
	drop table RecipientsList;
create table RecipientsList
(list_id int Primary Key identity(1,1)
,name varchar(60) not null
,description varchar(255));

go
If object_id('ListComposition') is not null
	drop table ListComposition;
create table ListComposition
(list_list_id int not null
,recipient_recipient_id int not null)

go
If object_id('Schedule') is not null
	drop table Schedule;
create table Schedule
(shedule_id int Primary Key identity(1,1)
,shedule_datetime datetime)

go
If object_id('Task') is not null
	drop table Task;
create table Task
(task_id int Primary Key identity(1,1)
,name varchar(60)
,sender_sender_id int 
,list_list_id int
,shdedule_shedule_id int
);

go
if OBJECT_ID('v_sender') is not null
	drop view v_sender;
Go
create view v_sender as
select
	s.*
	,serv.address smtp_address
	,serv.port smtp_port
from sender s
join Server_smtp serv
	on serv.server_id=s.server_server_id;