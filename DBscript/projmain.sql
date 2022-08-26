use clinicmanagement;


create table users(username varchar(10) unique CONSTRAINT check_username check(username not LIKE '%[^a-zA-Z0-9]%'),firstname varchar(25),lastname varchar(25),
password varchar(30) CONSTRAINT check_password check(password like '%@%'));

insert into users values('deepak1','deepak','kumar','deepak@12345');
insert into users values('basid2','basid','mohammed','basid@12345');
insert into users values('santo3','santo','brighton','santo@12345');
insert into users values('atul4','atul','lakkapragada','atul@12345');

select * from users;

drop table users;



create table doctors (doctor_id int primary key, firstname varchar(20) constraint check_firstname check(firstname not like '%[^a-zA-Z0-9]%'), 
lastname varchar(20) constraint check_lastname check(lastname not like '%[^a-zA-Z0-9]%'), 
sex varchar(7), specialization varchar(50), visiting_from time ,visiting_to time);

insert into doctors values(1001,'Mohan','Lal','M','Ortho','17:00','19:00');
insert into doctors values(1002,'Kabir','Singh','M','Pediatrics','18:00','20:00');
insert into doctors values(1003,'Rahman','Shah','M','General','16:00','18:00');
insert into doctors values(1004,'Karan','Sharma','M','Internal Medicine','10:00','12:00');
insert into doctors values(1005,'Shardhul','Sinha','M','Opthalmology','20:00','22:00');

--drop table doctors;
select * from doctors;
select DATEDIFF(hour, CONVERT(datetime,visiting_from), CONVERT(datetime,visiting_to)) AS difference
FROM doctors;






create table patients (patient_id int identity(10,1) primary key, firstname varchar(20) constraint check_firstname_patient check(firstname not like '%[^a-zA-Z0-9]%'),
lastname varchar(20) constraint check_lastname_patient check(lastname not like '%[^a-zA-Z0-9]%'), sex varchar(7),
age int constraint check_age_patient check(age between 0 and 120), dob date)


insert into patients values(102,'Raj','Kumar','M',120,'2000/10/11');

truncate table patients;

drop table patients;
select * from patients;
delete from patients where patient_id =13


create table Appointments (aptID int identity(500,1) primary key,doctor_id int foreign key(doctor_id) 
references doctors(doctor_id),Date_of_visit Date,timeslot varchar(30),apt_status varchar(30),patient_id int foreign key references Patients(patient_id));

insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-26','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-26','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-26','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-26','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-26','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-26','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-26','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-26','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-26','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-26','21-22','Available',null);

insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-27','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-27','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-27','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-27','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-27','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-27','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-27','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-27','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-27','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-27','21-22','Available',null);

insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-28','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-28','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-28','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-28','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-28','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-28','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-28','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-28','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-28','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-28','21-22','Available',null);

insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-29','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-29','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-29','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-29','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-29','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-29','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-29','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-29','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-29','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-29','21-22','Available',null);




select * from Appointments;
drop table appointments;
