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
    isActive BOOLEAN DEFAULT False,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS EmployeeShifts(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    shift VARCHAR(50),
    startTime TIME,
    endTime TIME,
    numberOfHrs DECIMAL, -- can be 7.5 hrs
    breakTime TIME,
    breakTimeHrs DECIMAL, -- 1 is hr, 0.5 is 30mins
    isActive BOOLEAN DEFAULT False,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
-- RegularShift, 0830 - 1730, 8, 12:00NN, 1Hr

-- DateTime dt = DateTime.Now;
-- string time = dt.ToString("hh:mm:ss");
INSERT INTO EmployeeShifts (shift, startTime, endTime)
VALUES ("ASDF", "08:30:00", "17:30:00");

SELECT TIME_FORMAT(startTime, "%H") as startDateHrs, TIME_FORMAT(startTime, "%i") as startDateMins, 
	TIME_FORMAT(endTime, "%H") as endDateHrs, TIME_FORMAT(endTime, "%i") as endDateMins
FROM EmployeeShifts;

select * from EmployeeShifts;

CREATE TABLE IF NOT EXISTS Employees(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8) UNIQUE, -- 20210001, 02, 03 (will always change the first 4 numbers, based on current year
	firstName VARCHAR(100),
    lastName VARCHAR(100),
    address VARCHAR(255),
    birthdate DATE,
    mobileNumber VARCHAR(100),
    emailAddress VARCHAR(100),
    branchAssign VARCHAR(255),
    dateHire DATE NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
ALTER TABLE Employees
DROP COLUMN sssNumber;

CREATE TABLE IF NOT EXISTS GovernmentAgencies(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    govtAgency VARCHAR(255),
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;


CREATE TABLE IF NOT EXISTS EmployeeGovtIdCards(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    govtAgencyId INT NOT NULL,
    employeeIdNumber VARCHAR(50) UNIQUE,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(govtAgencyId) REFERENCES GovernmentAgencies(id)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS EmployeeSalaryRate(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    salaryRate DECIMAL(5,2),
    halfMonthRate DECIMAL(5,2),
    dailyRate DECIMAL(5,2),
    increase DECIMAL DEFAULT 0,
    increaseDate DATE,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;


CREATE TABLE IF NOT EXISTS EmployeeShiftSchedules(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    shiftId BIGINT NOT NULL,
    employeeNumber CHAR(8),
    schedDate DATE,
    isPresent BOOLEAN DEFAULT false, -- flag that will update once the employee time in
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(shiftId) REFERENCES EmployeeShifts(id)
)ENGINE=INNODB;
-- SELECT DATE_ADD("2017-06-15", INTERVAL 10 HOUR); 

CREATE TABLE IF NOT EXISTS EmployeeLeaves(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    leaveId BIGINT NOT NULL,
    employeeNumber CHAR(8),
    numberOfDays DECIMAL, -- 1=day, 0.5 = halfday
    remainingDays DECIMAL, -- can leave whole day or halfday
    currentYear INT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (leaveId) REFERENCES LeaveTypes(id)
)ENGINE=INNODB;

-- TODO: for halfday
CREATE TABLE IF NOT EXISTS EmployeeAttendance(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
	workDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    shiftSchedId BIGINT NOT NULL,
    timeIn1 DATETIME,
    timeOut1 DATETIME, -- noon break (matic based on timeout2) , 12:00NN, based on shiftsched:breaktime
    timeIn2 DATETIME, -- noon time-in (matic on timeout2) : 01:00PM, based on shiftsched:breaktime
    timeOut2 DATETIME, -- 
    lateMins DECIMAL, -- number of minutes
    underTimeMins DECIMAL, -- number of minutes
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(shiftSchedId) REFERENCES EmployeeShiftSchedules(id)
)ENGINE=INNODB;


SELECT TIME_FORMAT("08:30:00", "%H") as hrs, TIME_FORMAT("08:30:00", "%i") as mins;
SELECT TIME_FORMAT("17:30:00", "%H.%i");
select TIMESTAMPDIFF(HOUR, '2015-12-16 18:00:00','2015-12-17 06:00:00');

-- Government benefits (employee and employer contributions
CREATE TABLE IF NOT EXISTS EmployeeGovtContributions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    employeeGovtIdCardId BIGINT NOT NULL,
    employeeContribution DECIMAL(5,2),
    employerContribution DECIMAL(5,2),
    totalContribution DECIMAL(5,2),
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(EmployeeGovtIdCardId) REFERENCES EmployeeGovtIdCards(id)
)ENGINE=INNODB;


-- possible enhancement:
-- add employee type that will use to add additional benefits
-- certain employees can have special benefits
CREATE TABLE IF NOT EXISTS EmployeeBenefits(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    benefitTitle VARCHAR(255),
    amount DECIMAL(5,2),
    isEnabled BOOLEAN DEFAULT True,
    paySched CHAR(30), -- MONTHLY (last pay day of the month), YEARLY, PAYDAY, SPECIFIC-MONTH-DAY
    payMonth INT DEFAULT 0, -- nullable or empty, 1-12, only applicable to PER-YEAR and SPECIFIC-MONTH-DAY
    payDay INT DEFAULT 0, -- nullable or empty, 1-31
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
ALTER TABLE EmployeeBenefits
MODIFY COLUMN paysSched CHAR(30);

-- possible enhancement:
-- add employee type that will use to add conditional/special deduction
-- certain employees can have special deduction
CREATE TABLE IF NOT EXISTS EmployeeDeductions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    deductionTitle VARCHAR(255),
    amount DECIMAL(5,2),
    isEnabled BOOLEAN DEFAULT True,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
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
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

-- employee benefits inventory per payday/payslip
CREATE TABLE IF NOT EXISTS EmployeePayslipBenefits(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    payslipId BIGINT,
    employeeNumber CHAR(8),
	benefitTitle VARCHAR(255),
    amount DECIMAL(5,2),
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
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
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(payslipId) REFERENCES EmployeePayslips(Id)
)ENGINE=INNODB;

-- --------------------------------------------------------------------------------------
-- User related tables:
-- --------------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Roles(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    rolekey VARCHAR(50),
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS Users(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8) UNIQUE,
	passwordSha512 VARCHAR(255),
    isActive BOOLEAN DEFAULT True,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS UserRoles(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    userId BIGINT NOT NULL,
    roleId INT NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (userId) REFERENCES Users(id),
    FOREIGN KEY (roleId) REFERENCES Roles(id)
)ENGINE=INNODB;

SELECT *
FROM UserRoles AS UR
JOIN Roles AS R ON R.id = UR.roleId
WHERE UR.isDeleted=False AND UR.userId=1;

-- testing data:
INSERT INTO Roles (rolekey) VALUES ("normal"), ("admin"), ("root");

-- Password: Welcome2021
INSERT INTO Users (employeeNumber, passwordSha512)
VALUES ("20210001", "5511F5AC0EDC25929F8CFE01485FFDEF12A83944BFB4708048C79869C22F17FF4F7CBD168146942F61E67756EB60C1E15DD4CC35596207ED626805199A805328"),
("20210002", "5511F5AC0EDC25929F8CFE01485FFDEF12A83944BFB4708048C79869C22F17FF4F7CBD168146942F61E67756EB60C1E15DD4CC35596207ED626805199A805328"),
("20210003", "5511F5AC0EDC25929F8CFE01485FFDEF12A83944BFB4708048C79869C22F17FF4F7CBD168146942F61E67756EB60C1E15DD4CC35596207ED626805199A805328");
SELECT * FROM Users;

INSERT INTO UserRoles (userId, roleId)
VALUES (1,1), (2,2), (3,3);