-- kopieren van gegevens van docent2 naar student7
use Student7; -- gebruik je eigen database

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE if exists `OrderItem`;
CREATE TABLE `OrderItem` SELECT * FROM Docent2.`OrderItem`;
DROP TABLE if exists `Order`;
CREATE TABLE `Order` SELECT * FROM Docent2.`Order`;
DROP TABLE if exists `ShippingMethod`;
CREATE TABLE `ShippingMethod` SELECT * FROM Docent2.`ShippingMethod`;
DROP TABLE if exists `OrderStatus`;
CREATE TABLE `OrderStatus` SELECT * FROM Docent2.`OrderStatus`;
DROP TABLE if exists `Customer`;
CREATE TABLE `Customer` SELECT * FROM Docent2.`Customer`;
DROP TABLE if exists `Book`;
CREATE TABLE `Book` SELECT * FROM Docent2.`Book`;

-- add primary keys and constraints to  tables student7
ALTER TABLE Book
ADD PRIMARY KEY (Id),
MODIFY COLUMN `Id` INT NOT NULL UNIQUE AUTO_INCREMENT FIRST;

ALTER TABLE Customer
ADD PRIMARY KEY (Id),
MODIFY COLUMN `Id` INT NOT NULL UNIQUE AUTO_INCREMENT FIRST;

ALTER TABLE OrderStatus
ADD PRIMARY KEY (Id),
MODIFY COLUMN `Id` INT NOT NULL UNIQUE AUTO_INCREMENT FIRST,
MODIFY COLUMN `Name` VARCHAR(255) UNIQUE;

ALTER TABLE ShippingMethod
ADD PRIMARY KEY (Id),
MODIFY COLUMN `Id` INT NOT NULL UNIQUE AUTO_INCREMENT FIRST,
MODIFY COLUMN `Name` VARCHAR(255) UNIQUE;

ALTER TABLE `Order`
ADD PRIMARY KEY (Id),
ADD CONSTRAINT fk_OrderCustomerId FOREIGN KEY (`CustomerId`) REFERENCES `Customer` (`Id`),
ADD CONSTRAINT fk_OrderShippingMethodId FOREIGN KEY (`ShippingMethodId`) REFERENCES `ShippingMethod` (`Id`),
ADD CONSTRAINT fk_OrderStatusId FOREIGN KEY (`StatusId`) REFERENCES `OrderStatus` (`Id`),
MODIFY COLUMN `Id` INT NOT NULL UNIQUE AUTO_INCREMENT FIRST;

ALTER TABLE OrderItem
ADD PRIMARY KEY (Id),
MODIFY COLUMN `Id` INT NOT NULL UNIQUE AUTO_INCREMENT FIRST,
ADD CONSTRAINT fk_OrderItemBookId FOREIGN KEY (`BookID`) REFERENCES `Book` (`Id`),
ADD CONSTRAINT fk_OrderId FOREIGN KEY (`OrderId`) REFERENCES `Order` (`Id`);


SET FOREIGN_KEY_CHECKS = 1;