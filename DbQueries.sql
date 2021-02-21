CREATE DATABASE ChocolandHilsCafeDb;
USE ChocolandHilsCafeDb;


-- Employee management, attendance and payroll related tables:

CREATE TABLE IF NOT EXISTS LeaveTypes(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    leaveType VARCHAR(50),
    numberOfDays INT,
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
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS Employees(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8) UNIQUE, -- 20210001, 02, 03
	firstName VARCHAR(100),
    lastName VARCHAR(100),
    address VARCHAR(255),
    birthdate DATE,
    mobileNumber VARCHAR(255),
    emailAddress VARCHAR(255),
    branchAssign VARCHAR(255),
    dateHire DATE NOT NULL,
    sssNumber VARCHAR(50),
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
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
    remainingLeave DECIMAL, -- can leave whole day or halfday
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (leaveId) REFERENCES LeaveTypes(id)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS EmployeeAttendance(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
	dateNow DATETIME DEFAULT CURRENT_TIMESTAMP,
    shiftSchedId BIGINT NOT NULL,
    in1 DATETIME,
    out1 DATETIME,
    in2 DATETIME,
    out2 DATETIME,
    late INT, -- minutes, divide to per hr (60),
    ut INT, -- minutes
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(shiftSchedId) REFERENCES EmployeeShiftSchedules(id)
)ENGINE=INNODB;

SELECT TIME_FORMAT("08:30:00", "%H") as hrs, TIME_FORMAT("08:30:00", "%i") as mins;
SELECT TIME_FORMAT("17:30:00", "%H.%i");
select TIMESTAMPDIFF(HOUR, '2015-12-16 18:00:00','2015-12-17 06:00:00');

-- possible enhancement:
-- add employee type that will use to add additional benefits
-- certain employees can have special benefits
CREATE TABLE IF NOT EXISTS EmployeeAdditionalBenefits(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    benefitTitle VARCHAR(255),
    amount DECIMAL(5,2),
    isEnabled BOOLEAN DEFAULT True,
    payType CHAR(10), -- PER-MONTH (last pay day of the month), PER-YEAR, PER-PAYDAY, SPECIFCI-MONTH-DAY
    payMonth INT DEFAULT 0, -- nullable or empty, 1-12, only applicable to PER-YEAR and SPECIFIC-MONTH-DAY
    payDay INT DEFAULT 0, -- nullable or empty, 1-31
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

-- possible enhancement:
-- add employee type that will use to add conditional/special deduction
-- certain employees can have special deduction
CREATE TABLE IF NOT EXISTS EmployeePayslipDeductions(
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
    employeeNumber CHAR(8),
	benefitTitle VARCHAR(255),
    amount DECIMAL(5,2),
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

-- employee deductions inventory per payday/payslip
CREATE TABLE IF NOT EXISTS EmployeePayslipDeductions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
	deductionTitle VARCHAR(255),
    amount DECIMAL(5,2),
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    deleteAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
