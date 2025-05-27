create Database SchoolDb;
Go
Use SchoolDb;
Go
create table students(
 studentId int primary key identity(1,1),
 FullName Nvarchar(100) not null,
 Age int,
 email Nvarchar(100) not null unique,
 Gender char(1),
);

create table courses(
 courseId int primary key identity(1,1),
 CourseName Nvarchar(100) not null,
 CreditsHours int not null
);

create table enrollments(
 enrollmentId int primary key identity(1,1),
 studentId int not null,
 courseId int not null,
 EnrollmentDate date not null,
 foreign key (studentId) references students(studentId),
 foreign key (courseId) references courses(courseId)
);

insert into students (FullName,Age,email, Gender) values ('Chigozie ajarah', 17, 'joho@gmail.com', 'M');
insert into students (FullName, Age, email, Gender) values ('bright ben',16,'ben@gmail.com', 'M');

insert into courses (CourseName, CreditsHours) values ('Mathematics', 3);
insert into courses (CourseName, CreditsHours) values ('English', 3);
insert into courses (CourseName, CreditsHours) values ('Biology', 3);

select * from students;
select * from courses;
update students set Age =19 where studentId=1;
select fullname,Age,Gender from students where Age > 17;

insert into enrollments (studentId, courseId, EnrollmentDate) values (1, 1, '2025-05-27');
insert into enrollments (studentId, courseId, EnrollmentDate) values (2, 2, '2025-05-27');

select * from enrollments;

--------- there for we are going to implement inner join statement ------------------
select s.FullName, s.email, s.Age, c.CourseName from enrollments e 
join students s on e.studentId = s.studentId
join courses c on e.courseId = c.courseId;

-- there for we are going to implement right join statement

select s.FullName, s.email, s.Age, c.CourseName from students  s
LEFT join enrollments e on s.studentId = e.studentId
left join courses c on e.courseId = c.courseId;

select count(*) as TotalStudents from students;
select AVG(Age) as AverageAge from students;