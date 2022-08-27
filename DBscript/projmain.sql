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
insert into doctors values(1006,'Mary','Jane','F','Ortho','06:00','08:00');
insert into doctors values(1007,'Rahul','Gandhi','M','General','02:00','05:00');




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
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-26','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-26','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-26','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-26','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-26','04-05','Available',null);





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
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-27','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-27','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-27','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-27','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-27','04-05','Available',null);


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
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-28','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-28','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-28','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-28','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-28','04-05','Available',null);


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
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-29','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-29','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-29','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-29','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-29','04-05','Available',null);


insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-30','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-30','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-30','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-30','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-30','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-30','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-30','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-30','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-30','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-30','21-22','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-30','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-30','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-30','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-30','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-30','04-05','Available',null);

insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-31','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-08-31','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-31','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-08-31','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-31','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-08-31','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-31','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-08-31','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-31','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-08-31','21-22','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-31','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-08-31','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-31','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-31','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-08-31','04-05','Available',null);

insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-09-01','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-09-01','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-09-01','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-09-01','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-09-01','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-09-01','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-09-01','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-09-01','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-09-01','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-09-01','21-22','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-09-01','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-09-01','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-01','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-01','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-01','04-05','Available',null);


insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-09-02','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-09-02','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-09-02','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-09-02','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-09-02','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-09-02','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-09-02','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-09-02','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-09-02','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-09-02','21-22','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-09-02','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-09-02','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-02','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-02','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-02','04-05','Available',null);

insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-09-03','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1001,'2022-09-03','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-09-03','18-19','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1002,'2022-09-03','19-20','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-09-03','16-17','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1003,'2022-09-03','17-18','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-09-03','10-11','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1004,'2022-09-03','11-12','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-09-03','20-21','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1005,'2022-09-03','21-22','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-09-03','06-07','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1006,'2022-09-03','07-08','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-03','02-03','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-03','03-04','Available',null);
insert into appointments(doctor_id,date_of_visit,timeslot,apt_status,patient_id) values(1007,'2022-09-03','04-05','Available',null);



select * from Appointments;
truncate table appointments;
drop table appointments;
