CREATE DATABASE ChocolandHilsCafeDb;
USE ChocolandHilsCafeDb;

CREATE DATABASE ChocolandHilsCafeDb2;
USE ChocolandHilsCafeDb2;

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
SELECT * FROM EmployeeSalaryRate;

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

CREATE TABLE IF NOT EXISTS Branches(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	branchName VARCHAR(255),
    tellNo VARCHAR(100),
    address VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM Branches;


CREATE TABLE IF NOT EXISTS EmployeePositions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	title VARCHAR(255),
	salaryRate DECIMAL(9,2),
    halfMonthRate DECIMAL(9,2),
    dailyRate DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM EmployeePositions;


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
    branchId BIGINT,
    positionId BIGINT,
    shiftId BIGINT NOT NULL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (shiftId) REFERENCES EmployeeShifts(id),
    FOREIGN KEY (branchId) REFERENCES Branches(id),
    FOREIGN KEY (positionId) REFERENCES EmployeePositions(id)
)ENGINE=INNODB;
ALTER TABLE Employees 
ADD COLUMN isQuit BOOLEAN DEFAULT False;
ALTER TABLE Employees 
ADD COLUMN quitDate DATE;
ALTER TABLE Employees
ADD COLUMN imageFileName VARCHAR(250);

-- Run this query to add this columns
-- or just drop the whole database to start again, so can set the foreign keys for these ids and ignore below alter queries
ALTER TABLE Employees 
ADD COLUMN branchId BIGINT;
ALTER TABLE Employees 
ADD COLUMN positionId BIGINT;

-- Run these queries to drop these old columns:
ALTER TABLE Employees
DROP COLUMN branchAssign;
ALTER TABLE Employees
DROP COLUMN position;


SELECT * FROM Employees;

UPDATE Employees SET positionId=6 WHERE id > 0 AND isDeleted=false AND positionId IN (1,2,3,4,5);

-- ALTER TABLE Employees
-- DROP FOREIGN KEY employees_ibfk_1;

SELECT * FROM Employees WHERE employeeNumber NOT IN (20190001,
20210007,
20210006,
20210012
);

SELECT COUNT(*) as count FROM Employees 
WHERE isDeleted=false AND empNumYear = '2021';

CREATE TABLE IF NOT EXISTS GovernmentAgencies(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
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
    govtAgencyId BIGINT NOT NULL,
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

-- DROP THIS TABLE, WE DON'T NEED THIS ANYMORE <----------------------------------------------------------------
drop table EmployeeSalaryRate;
-- CREATE TABLE IF NOT EXISTS EmployeeSalaryRate(
-- 	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
--     employeeNumber CHAR(8),
--     salaryRate DECIMAL(9,2),
--     halfMonthRate DECIMAL(9,2),
--     dailyRate DECIMAL(9,2),
--     increase DECIMAL DEFAULT 0,
--     increaseDate DATE,
--     createdAt DATETIME DEFAULT NOW(),
--     updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
--     deletedAt DATETIME,
--     isDeleted BOOLEAN DEFAULT False
-- )ENGINE=INNODB;



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
ALTER TABLE EmployeeLeaves
ADD COLUMN isPaid BOOLEAN DEFAULT false;
ALTER TABLE EmployeeLeaves
ADD COLUMN payslipId BIGINT DEFAULT 0; -- for easy retrieval of payslip data

SELECT * FROM EmployeeLeaves;

SELECT * 
FROM EmployeeLeaves
WHERE startDate BETWEEN '2021-03-15' AND '2021-03-30'
and endDate BETWEEN '2021-03-15' AND '2021-03-30';

CREATE TABLE IF NOT EXISTS WorkforceSchedules(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
	workDate DATE,
    isDone BOOLEAN DEFAULT False,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM WorkforceSchedules 
WHERE employeeNumber='20190001' AND workDate='2021-03-18';

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
ALTER TABLE EmployeeAttendance
ADD COLUMN lateTotalDeduction DECIMAL(9,2);
ALTER TABLE EmployeeAttendance
ADD COLUMN underTimeTotalDeduction DECIMAL(9,2);
ALTER TABLE EmployeeAttendance
ADD COLUMN overTimeTotalDeduction DECIMAL(9,2); -- need to rename this
ALTER TABLE EmployeeAttendance
ADD COLUMN totalDailySalary DECIMAL(9,2);
ALTER TABLE EmployeeAttendance
ADD COLUMN isPaid BOOLEAN DEFAULT false;
ALTER TABLE EmployeeAttendance
ADD COLUMN payslipId BIGINT DEFAULT 0; -- for easy retrieval of payslip data

SELECT * FROM EmployeeAttendance where workDate='2021-03-13';

SELECT * FROM WorkforceSchedules 
WHERE employeeNumber='20190001' AND isDeleted=false AND workDate BETWEEN '2021-03-17' AND '2021-04-08';

SELECT * FROM EmployeeAttendance where employeeNumber='20190001';
SELECT * FROM EmployeeLeaves;

SELECT * 
FROM EmployeeAttendance AS EA
JOIN EmployeeShifts AS ES ON EA.shiftId=ES.id
JOIN Employees AS E ON EA.employeeNumber=E.employeeNumber
WHERE EA.employeeNumber='20190001' AND EA.workDate BETWEEN '2021-01-01' AND '2021-04-09'
ORDER BY EA.id DESC;

SELECT * FROM EmployeeShifts;

SELECT * FROM EmployeeLeaves;

SELECT * 
FROM EmployeeAttendance AS EA
JOIN EmployeeShifts AS ES ON EA.shiftId=ES.id
JOIN Employees AS E ON EA.employeeNumber=E.employeeNumber
WHERE EA.workDate BETWEEN '2021-03-13' AND '2021-03-23'
ORDER BY EA.id DESC;

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

SELECT * FROM EmployeeDeductions;

-- Payroll generation:
-- Employee daily salary * number of days duty (display days, leave, absent)
-- Compute Deductions (deductions list, late, government contribution)
-- Compute Benefits (benefits list and bonus, employer government contribution)
-- 

-- CREATE TABLE IF NOT EXISTS PayrollHistory(
-- 	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
--     startDate DATE,
--     endDate DATE,
--     payDate DATE,
--     totalPayment DECIMAL(9,2),
--     createdAt DATETIME DEFAULT NOW(),
--     updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
--     deletedAt DATETIME,
--     isDeleted BOOLEAN DEFAULT False
-- )ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS EmployeePayslips(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
	startShiftDate DATE,
    endShiftDate DATE,
    payDate DATE,
    salaryRate DECIMAL(9,2),
    halfMonthRate DECIMAL(9,2),
    dailyRate DECIMAL(9,2),
    numOfDays INT,
    late VARCHAR(50),
    lateTotalDeduction DECIMAL(9,2),
    underTime VARCHAR(50),
    underTimeTotalDeduction DECIMAL(9,2),
    overTime VARCHAR(50),
    overTimeTotalRate DECIMAL(9,2),
    netBasicSalary DECIMAL(9,2),
    benefitsTotal DECIMAL(9,2),
    totalIncome DECIMAL(9,2),
    deductionTotal DECIMAL(9,2),
    netTakeHomePay DECIMAL (9,2),
    paydaySequence INT NOT NULL, -- 1 and 2 
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
ALTER TABLE EmployeePayslips
ADD COLUMN isCancel BOOLEAN DEFAULT False;
ALTER TABLE EmployeePayslips
ADD COLUMN employerGovtContributionTotal DECIMAL(9,2) DEFAULT 0;


SELECT * FROM EmployeePayslips;
SELECT * FROM EmployeeAttendance;
SELECT * FROM EmployeeLeaves;

SELECT * FROM EmployeePayslips WHERE isDeleted=false AND payDate = '2021-03-24';

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

select * from EmployeePayslipBenefits;

-- employee deductions inventory per payday/payslip
-- leave and absenses(Calculated from attendance) can be added on this
-- government contributions
CREATE TABLE IF NOT EXISTS EmployeePayslipDeductions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    payslipId BIGINT,
    employeeNumber CHAR(8),
	deductionTitle VARCHAR(255),
    amount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(payslipId) REFERENCES EmployeePayslips(Id)
)ENGINE=INNODB;
ALTER TABLE EmployeePayslipDeductions
ADD COLUMN employerGovtContributionAmount DECIMAL(9,2) DEFAULT 0;

SELECT * FROM EmployeePayslipDeductions;
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

-- you can store employee number as userName
CREATE TABLE IF NOT EXISTS Users(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
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
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    userId INT NOT NULL,
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

-- --------------------------------------------------------------------------------------
-- Inventory and POS related tables:
-- --------------------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS IngredientCategories(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	category VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM IngredientCategories;

CREATE TABLE IF NOT EXISTS Ingredients(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    categoryId BIGINT NOT NULL,
	ingName VARCHAR(255),
    uom CHAR(3), -- kg(gram), L(ml), pcs(pc)
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(categoryId) REFERENCES IngredientCategories(id)
)ENGINE=INNODB;

SELECT * FROM Ingredients;

CREATE TABLE IF NOT EXISTS IngredientInventory(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	ingredientId BIGINT NOT NULL,
    initialQtyValue DECIMAL, -- in grams, ml, or pcs
    remainingQtyValue DECIMAL,
    unitCost DECIMAL(9,2), -- unit cost based on unit of measurement
    expirationDate DATE,
    isSoldOut BOOLEAN DEFAULT False,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(ingredientId) REFERENCES Ingredients(id)
)ENGINE=INNODB;

SELECT * FROM IngredientInventory WHERE ingredientId=10 AND isDeleted=false;


CREATE TABLE IF NOT EXISTS IngInventoryTransactions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	ingredientId BIGINT NOT NULL,
    transType INT, -- See StaticData.cs file under EntitiesShared Project
    qtyVal DECIMAL,
    unitCost DECIMAL(9,2),
    expirationDate DATE,
    userId INT NOT NULL,
    remarks VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(ingredientId) REFERENCES Ingredients(id),
    FOREIGN KEY(userId) REFERENCES Users(id)
)ENGINE=INNODB;

SELECT * FROM IngInventoryTransactions;
SELECT * FROM Users;

CREATE TABLE IF NOT EXISTS ProductCategories(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	prodCategory VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM ProductCategories;

CREATE TABLE IF NOT EXISTS Products(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    categoryId BIGINT NOT NULL,
	prodName VARCHAR(255),
    pricePerOrder DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(categoryId) REFERENCES ProductCategories(id)
)ENGINE=INNODB;
ALTER TABLE Products
DROP COLUMN estimatedNumOrders; -- If you have this column in your table, just run this query to remove
ALTER TABLE Products
ADD COLUMN imageFileName VARCHAR(250);
ALTER TABLE Products
ADD COLUMN barcodeLbl VARCHAR(250);


SELECT * FROM Products;


SELECT * FROM Employees;

SELECT *
FROM Products AS P
JOIN ProductCategories AS PC ON P.categoryId = PC.id
WHERE P.isDeleted=false;

-- Per order
CREATE TABLE IF NOT EXISTS ProductIngredients(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	productId BIGINT NOT NULL,
    ingredientId BIGINT NOT NULL,
    uom INT,
    qtyValue DECIMAL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(productId) REFERENCES Products(id),
    FOREIGN KEY(ingredientId) REFERENCES Ingredients(id)
)ENGINE=INNODB;


SELECT * FROM Ingredients;


CREATE TABLE IF NOT EXISTS ComboMeals(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	title VARCHAR(255),
    price DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
ALTER TABLE ComboMeals
ADD COLUMN barcodeLbl VARCHAR(250);
ALTER TABLE ComboMeals
ADD COLUMN imageFileName VARCHAR(250);

SELECT * FROM ComboMeals;


CREATE TABLE IF NOT EXISTS ComboMealProducts(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	comboMealId BIGINT NOT NULL,
    productId BIGINT NOT NULL,
    quantity INT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(comboMealId) REFERENCES ComboMeals(id),
    FOREIGN KEY(productId) REFERENCES Products(id)
)ENGINE=INNODB;

select * from ComboMealProducts;


-- Point of sale tables:

CREATE TABLE IF NOT EXISTS SalesTransactions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	receptNumber VARCHAR(100),
    currentUser VARCHAR(255),
    totalAmount DECIMAL(9,2),
    customerName VARCHAR(255),
    customerCash DECIMAL(9,2),
    customerChange DECIMAL(9,2),
    customerDue DECIMAL(9,2),
    tableNumber INT,
    discount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS SalesTransactionProducts(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    salesTransId BIGINT NOT NULL,
	productId BIGINT NOT NULL,
    productCurrentPrice DECIMAL(9,2),
    qty INT,
    totalAmount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (salesTransId) REFERENCES SalesTransactions(id),
    FOREIGN KEY (productId) REFERENCES Products (id)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS SalesTransactionComboMeals(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    salesTransId BIGINT NOT NULL,
	comboMealId BIGINT NOT NULL,
    comboMealCurrentPrice DECIMAL(9,2),
    qty INT,
    totalAmount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (salesTransId) REFERENCES SalesTransactions(id),
    FOREIGN KEY (comboMealId) REFERENCES ComboMeals (id)
)ENGINE=INNODB;
