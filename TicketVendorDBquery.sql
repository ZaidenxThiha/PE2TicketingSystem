create database TicketVendorDB;

use TicketVendorDB;

CREATE TABLE Destinations (
    DestinationID INT PRIMARY KEY IDENTITY(1,1),
    DestinationName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);

CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    PaymentMethod NVARCHAR(50) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    TransactionDate DATETIME NOT NULL,
    Status NVARCHAR(20) NOT NULL
);

CREATE TABLE Tickets (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    DestinationID INT NOT NULL,
    IssueDate DATETIME NOT NULL,
    Barcode NVARCHAR(50) NOT NULL,
    PaymentID INT NOT NULL,
    FOREIGN KEY (DestinationID) REFERENCES Destinations(DestinationID),
    FOREIGN KEY (PaymentID) REFERENCES Payments(PaymentID)
);

-- Sample Data
INSERT INTO Destinations (DestinationName, Price) VALUES ('Ben Thanh Station', 15000.00);
INSERT INTO Destinations (DestinationName, Price) VALUES ('Opera House', 20000.00);
INSERT INTO Destinations (DestinationName, Price) VALUES ('Thu Duc', 20000.00);