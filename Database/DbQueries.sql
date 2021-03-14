CREATE DATABASE ChocolandHilsCafeDb;
USE ChocolandHilsCafeDb;

-- https://www.khanacademy.org/math/cc-third-grade-math/imp-measurement-and-data/imp-mass/v/intuition-for-grams#:~:text=.%20...%E2%80%9D-,To%20convert%20grams%20to%20kilograms%2C%20divide%20by%201%2C000.,30%2C000%20grams%20is%2030%20kilograms.

-- Employee management, attendance and payroll related tables:

-- if the employer decided to change/increase or decrease days on specific leave
-- just add new entry to retain the current records and deactivate the old one
CREATE TABLE IF NOT EXISTS LeaveTypes(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY, -- change to INT
    leaveType VARCHAR(50),
    numberOfDays INT,
    isActive BOOLEAN DEFAULT True,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM LeaveTypes;

SELECT * FROM LeaveTypes WHERE isDeleted=False AND isActive=true;

CREATE TABLE IF NOT EXISTS EmployeeShifts(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    shift VARCHAR(50),
    startTime DATETIME, -- we only need the time (ignore the date)
    endTime DATETIME, -- same with this column
    numberOfHrs DECIMAL(5,2), -- can be 7.5 hrs
    breakTime DATETIME,
    breakTimeHrs DECIMAL(5,2), -- 1 is hr, 0.5 is 30mins
    isActive BOOLEAN DEFAULT True,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
alter table EmployeeShifts
add column earlyTimeOut DATETIME; -- half day for first 4 or 6 hrs
alter table EmployeeShifts
add column lateTimeIn DATETIME; -- half day for last 4 or 6 hrs

SELECT * FROM EmployeeShifts;

-- ADD SHIFT DAYS
-- Late Time allowance
-- maximum hrs for overtime
-- overtime rate

-- RegularShift, 0830 - 1730, 8, 12:00NN, 1Hr

-- DateTime dt = DateTime.Now;
-- string time = dt.ToString("hh:mm:ss");
INSERT INTO EmployeeShifts (shift, startTime, endTime)
VALUES ("ASDF", "08:30:00", "17:30:00");

SELECT TIME_FORMAT(startTime, "%H") as startDateHrs, TIME_FORMAT(startTime, "%i") as startDateMins, 
	TIME_FORMAT(endTime, "%H") as endDateHrs, TIME_FORMAT(endTime, "%i") as endDateMins
FROM EmployeeShifts;

select * from EmployeeShifts;

-- for improvement on the future
    -- get the number of hrs from EmployeeShifts table
    -- the user can edit hrs for specific day
    
CREATE TABLE IF NOT EXISTS EmployeeShiftDays(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    shiftId BIGINT NOT NULL,
    dayName CHAR(3),
    orderNum INT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (shiftId) REFERENCES EmployeeShifts (id)
)ENGINE=INNODB;

SELECT * FROM EmployeeShiftDays;

CREATE TABLE IF NOT EXISTS Holidays(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    holiday VARCHAR(255),
    dayNum INT,
    monthAbbr CHAR(3),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM Holidays;

CREATE TABLE IF NOT EXISTS Employees(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8) UNIQUE, -- 20210001, 02, 03 (will always change the first 4 numbers, based on current year
	firstName VARCHAR(100),
    lastName VARCHAR(100),
    middleName VARCHAR(100),
    address VARCHAR(255),
    birthdate DATE,
    mobileNumber VARCHAR(100),
    emailAddress VARCHAR(100),
    branchAssign VARCHAR(255),
    dateHire DATE NOT NULL,
    empNumYear CHAR(4),
    position VARCHAR(50),
    shiftId BIGINT NOT NULL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (shiftId) REFERENCES EmployeeShifts(id)
)ENGINE=INNODB;
ALTER TABLE Employees 
ADD CONSTRAINT employees_ibfk_1 
FOREIGN KEY (shiftId) REFERENCES EmployeeShifts(id);

ALTER TABLE Employees
ADD COLUMN imageFileName VARCHAR(500);

-- ALTER TABLE Employees
-- DROP FOREIGN KEY employees_ibfk_1;

SELECT * FROM Employees;

SELECT COUNT(*) as count FROM Employees 
WHERE isDeleted=false AND empNumYear = '2021';

CREATE TABLE IF NOT EXISTS GovernmentAgencies(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    govtAgency VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM GovernmentAgencies;

CREATE TABLE IF NOT EXISTS EmployeeGovtIdCards(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    govtAgencyId INT NOT NULL,
    employeeIdNumber VARCHAR(50) UNIQUE,
    employeeContribution DECIMAL(5,2),
    employerContribution DECIMAL(5,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(govtAgencyId) REFERENCES GovernmentAgencies(id)
)ENGINE=INNODB;

SELECT * FROM EmployeeGovtIdCards;

CREATE TABLE IF NOT EXISTS EmployeeSalaryRate(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    salaryRate DECIMAL(9,2),
    halfMonthRate DECIMAL(9,2),
    dailyRate DECIMAL(9,2),
    increase DECIMAL DEFAULT 0,
    increaseDate DATE,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM EmployeeSalaryRate;

SELECT * FROM EmployeeSalaryRate
WHERE isDeleted=false AND employeeNumber='20190001'
ORDER BY id DESC LIMIT 1;

-- CREATE TABLE IF NOT EXISTS EmployeeShiftSchedules(
-- 	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
--     shiftId BIGINT NOT NULL,
--     employeeNumber CHAR(8),
--     startSchedDate DATE,
--     endSchedDate DATE,
--     isDone BOOLEAN DEFAULT False,
--     createdAt DATETIME DEFAULT NOW(),
--     updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
--     deletedAt DATETIME,
--     isDeleted BOOLEAN DEFAULT False,
--     FOREIGN KEY(shiftId) REFERENCES EmployeeShifts(id)
-- )ENGINE=INNODB;

-- SELECT * FROM EmployeeShiftSchedules;

-- select * from EmployeeShiftSchedules
-- where isDeleted=false and isDone=false and employeeNumber='20190001' and 
-- startSchedDate <= '2021-01-01' and endSchedDate >= '2024-03-03';

-- select * from EmployeeShiftSchedules
-- where isDeleted=false and isDone=false and employeeNumber=@EmployeeNumber and 
-- startSchedDate <= @SchedDate and endSchedDate >= @SchedDate

-- SELECT DATE_ADD("2017-06-15", INTERVAL 10 HOUR); 

CREATE TABLE IF NOT EXISTS EmployeeLeaves(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    leaveId BIGINT NOT NULL,
    employeeNumber CHAR(8),
    reason TEXT,
    startDate DATE,
    endDate DATE,
    numberOfDays DECIMAL, -- 1=day, 0.5 = halfday
    remainingDays DECIMAL, -- can leave whole day or halfday
    currentYear INT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (leaveId) REFERENCES LeaveTypes(id)
)ENGINE=INNODB;


-- TODO: for halfday
CREATE TABLE IF NOT EXISTS EmployeeAttendance(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    shiftId BIGINT NOT NULL,
	workDate DATE NOT NULL,
    firstTimeIn DATETIME,
    firstTimeOut DATETIME,
    firstHalfHrs DECIMAL,-- in minutes
    firstHalfLateMins DECIMAL, -- put value upon time-in
    firstHalfUnderTimeMins DECIMAL, -- put value upon time-out
    secondTimeIn DATETIME,
    secondTimeOut DATETIME,
    secondHalfHrs DECIMAL, -- in minutes
    secondHalfLateMins DECIMAL,
    secondHalfUnderTimeMins DECIMAL,
    overTimeMins DECIMAL,
    isTimeOutProvided BOOLEAN DEFAULT false,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(shiftId) REFERENCES EmployeeShifts(id)
)ENGINE=INNODB;

SELECT * 
FROM EmployeeAttendance AS EA
JOIN EmployeeShifts AS ES ON EA.shiftId=ES.id
JOIN Employees AS E ON EA.employeeNumber=E.employeeNumber
WHERE workDate='2021-03-13';

SELECT * FROM Employees WHERE isDeleted=false;
SELECT * FROM EmployeeAttendance;

SELECT * FROM EmployeeAttendance 
WHERE employeeNumber='20190001' AND workDate='2021-03-13';

SELECT TIME_FORMAT("08:30:00", "%H") as hrs, TIME_FORMAT("08:30:00", "%i") as mins;
SELECT TIME_FORMAT("17:30:00", "%H.%i");
select TIMESTAMPDIFF(HOUR, '2015-12-16 18:00:00','2015-12-17 06:00:00');



-- possible enhancement:
-- add employee type that will use to add additional benefits
-- certain employees can have special benefits
CREATE TABLE IF NOT EXISTS EmployeeBenefits(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    benefitTitle VARCHAR(255),
    amount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM EmployeeBenefits;

-- possible enhancement:
-- add employee type that will use to add conditional/special deduction
-- certain employees can have special deduction
CREATE TABLE IF NOT EXISTS EmployeeDeductions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    deductionTitle VARCHAR(255),
    amount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;


CREATE TABLE IF NOT EXISTS EmployeePayslips(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
	startShiftDate DATE,
    endShiftDate DATE,
    payDate DATE,
    NetBasicSalary DECIMAL(5,2), -- kinsenas
    benefitsTotal DECIMAL(5,2),
    deducationTotal DECIMAL(5,2),
    totalIncome DECIMAL(5,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

-- employee benefits inventory per payday/payslip
CREATE TABLE IF NOT EXISTS EmployeePayslipBenefits(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    payslipId BIGINT,
    employeeNumber CHAR(8),
	benefitTitle VARCHAR(255),
    amount DECIMAL(5,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(payslipId) REFERENCES EmployeePayslips(Id)
)ENGINE=INNODB;

-- employee deductions inventory per payday/payslip
-- leave and absenses(Calculated from attendance) can be added on this
-- government contributions
CREATE TABLE IF NOT EXISTS EmployeePayslipDeductions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    payslipId BIGINT,
    employeeNumber CHAR(8),
	deductionTitle VARCHAR(255),
    amount DECIMAL(5,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(payslipId) REFERENCES EmployeePayslips(Id)
)ENGINE=INNODB;

-- --------------------------------------------------------------------------------------
-- User related tables:
-- --------------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Roles(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    rolekey VARCHAR(50),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM Roles;

CREATE TABLE IF NOT EXISTS Users(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    userName CHAR(20) UNIQUE,
    fullName VARCHAR(50),
	passwordSha512 VARCHAR(255),
    isActive BOOLEAN DEFAULT True,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS UserActivityLog(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    userName CHAR(20),
    activity VARCHAR(255),
    createdAt DATETIME DEFAULT NOW()
)ENGINE=INNODB;

SELECT * FROM Users;

CREATE TABLE IF NOT EXISTS UserRoles(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    userId BIGINT NOT NULL,
    roleId INT NOT NULL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (userId) REFERENCES Users(id),
    FOREIGN KEY (roleId) REFERENCES Roles(id)
)ENGINE=INNODB;

SELECT * FROM UserRoles;


SELECT *
FROM UserRoles AS UR
JOIN Roles AS R ON R.id = UR.roleId
WHERE UR.isDeleted=False AND UR.userId=1;

-- testing data:
INSERT INTO Roles (rolekey) VALUES ("normal"), ("admin");

-- Password: Welcome2021
INSERT INTO Users (userName, fullName, passwordSha512)
VALUES ("20210001", "Testing1", "5511F5AC0EDC25929F8CFE01485FFDEF12A83944BFB4708048C79869C22F17FF4F7CBD168146942F61E67756EB60C1E15DD4CC35596207ED626805199A805328"),
("20210002", "Testing2", "5511F5AC0EDC25929F8CFE01485FFDEF12A83944BFB4708048C79869C22F17FF4F7CBD168146942F61E67756EB60C1E15DD4CC35596207ED626805199A805328"),
("20210003", "Testing3", "5511F5AC0EDC25929F8CFE01485FFDEF12A83944BFB4708048C79869C22F17FF4F7CBD168146942F61E67756EB60C1E15DD4CC35596207ED626805199A805328");
SELECT * FROM Users;

INSERT INTO UserRoles (userId, roleId)
VALUES (1,1), (2,2);