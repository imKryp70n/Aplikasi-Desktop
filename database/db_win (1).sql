-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jun 24, 2022 at 05:06 PM
-- Server version: 5.7.33
-- PHP Version: 7.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_win`
--

-- --------------------------------------------------------

--
-- Table structure for table `cleaningroom`
--

CREATE TABLE `cleaningroom` (
  `ID` int(11) NOT NULL,
  `Date` date NOT NULL,
  `EmployeeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cleaningroomdetail`
--

CREATE TABLE `cleaningroomdetail` (
  `ID` int(11) NOT NULL,
  `CleaningRoomID` int(11) NOT NULL,
  `RoomID` int(11) NOT NULL,
  `StartDateTime` datetime NOT NULL,
  `FinishDateTime` datetime NOT NULL,
  `Note` text NOT NULL,
  `StatusCleaning` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cleaningroomitem`
--

CREATE TABLE `cleaningroomitem` (
  `ID` int(11) NOT NULL,
  `CleaningRoomDetailID` int(11) NOT NULL,
  `ItemID` int(11) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `NIK` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Gender` char(1) NOT NULL,
  `PhoneNumber` varchar(50) NOT NULL,
  `Age` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`ID`, `Name`, `NIK`, `Email`, `Gender`, `PhoneNumber`, `Age`) VALUES
(1, 'Admin', '', '', '', '3150154615454', 0),
(2, '', '', '', '', '', 0),
(3, '', '', '', '', '', 0),
(4, '', '', '', '', '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `ID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `JobID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`ID`, `Username`, `Password`, `Name`, `Email`, `Address`, `DateOfBirth`, `JobID`) VALUES
(1, 'Admin', '12345', 'Admin', 'Admin@gmail.com', 'Cimahi', '2022-06-16', 1),
(2, 'HouseKeeper', '12345', 'House Keeper', 'housekeeper@gmail.com', 'Cimahi', '2022-06-16', 2),
(3, 'keeper', '12345', 'Keeper', 'keeper@gmail.com', 'Jakarta', '2019-07-25', 3),
(4, 'FrontOffice', '12345', 'Front Office', 'Frontoffice@gmail.com', 'Cimahi', '2022-06-16', 4);

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE `item` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `RequirePrice` int(11) NOT NULL,
  `CompensationFee` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `item`
--

INSERT INTO `item` (`ID`, `Name`, `RequirePrice`, `CompensationFee`) VALUES
(1, 'Kursi', 50000, 60000),
(2, 'Blangket', 50000, 50000),
(6, 'Handuk', 30000, 25000);

-- --------------------------------------------------------

--
-- Table structure for table `itemstatus`
--

CREATE TABLE `itemstatus` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `itemstatus`
--

INSERT INTO `itemstatus` (`ID`, `Name`) VALUES
(1, 'PECAH');

-- --------------------------------------------------------

--
-- Table structure for table `job`
--

CREATE TABLE `job` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `ID` int(11) NOT NULL,
  `DateTime` date NOT NULL,
  `EmployeeID` int(11) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `Code` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reservation`
--

INSERT INTO `reservation` (`ID`, `DateTime`, `EmployeeID`, `CustomerID`, `Code`) VALUES
(1, '2022-06-18', 1, 1, 28136),
(2, '2022-06-18', 1, 2, 39594),
(3, '2022-06-18', 1, 2, 23431),
(4, '2022-06-18', 1, 2, 30322);

-- --------------------------------------------------------

--
-- Table structure for table `reservationcheckout`
--

CREATE TABLE `reservationcheckout` (
  `ID` int(11) NOT NULL,
  `ReservationRoomID` int(11) NOT NULL,
  `ItemID` int(11) NOT NULL,
  `ItemStatusID` int(11) NOT NULL,
  `Qty` int(11) NOT NULL,
  `TotalCharge` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `reservationroom`
--

CREATE TABLE `reservationroom` (
  `ID` int(11) NOT NULL,
  `ReservationID` int(11) NOT NULL,
  `RoomID` int(11) NOT NULL,
  `StartDateTime` date NOT NULL,
  `DurationNight` int(11) NOT NULL,
  `RoomPrice` int(11) NOT NULL,
  `CheckInDateTime` datetime NOT NULL,
  `CheckOutDateTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reservationroom`
--

INSERT INTO `reservationroom` (`ID`, `ReservationID`, `RoomID`, `StartDateTime`, `DurationNight`, `RoomPrice`, `CheckInDateTime`, `CheckOutDateTime`) VALUES
(1, 1, 2, '2022-06-18', 1, 350000, '2022-06-18 00:00:00', NULL),
(2, 1, 1, '2022-06-18', 1, 200000, '2022-06-18 00:00:00', '2022-06-18 00:00:00'),
(3, 2, 1, '2022-06-18', 1, 200000, '2022-06-18 00:00:00', '2022-06-18 00:00:00'),
(4, 3, 2, '2022-06-18', 1, 350000, '2022-06-18 00:00:00', '2022-06-18 00:00:00'),
(5, 4, 2, '2022-06-18', 1, 350000, '2022-06-18 00:00:00', '2022-06-18 00:00:00'),
(6, 4, 1, '2022-06-18', 1, 200000, '2022-06-18 00:00:00', '2022-06-18 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `reservation_request_item`
--

CREATE TABLE `reservation_request_item` (
  `ID` int(11) NOT NULL,
  `ReservationRoomID` int(11) NOT NULL,
  `ItemID` int(11) NOT NULL,
  `Qty` int(11) NOT NULL,
  `TotalPrice` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reservation_request_item`
--

INSERT INTO `reservation_request_item` (`ID`, `ReservationRoomID`, `ItemID`, `Qty`, `TotalPrice`) VALUES
(1, 1, 2, 1, 50000),
(2, 2, 2, 1, 50000),
(3, 3, 1, 1, 50000),
(4, 3, 2, 1, 50000),
(5, 4, 1, 1, 30000),
(6, 4, 2, 1, 30000),
(7, 4, 6, 1, 30000),
(8, 5, 1, 1, 50000),
(9, 5, 2, 1, 50000),
(10, 5, 6, 1, 50000),
(11, 5, 1, 1, 50000),
(12, 6, 1, 1, 50000),
(13, 6, 2, 1, 50000),
(14, 6, 6, 1, 50000),
(15, 6, 1, 1, 50000);

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `ID` int(11) NOT NULL,
  `RoomTypeID` int(10) NOT NULL,
  `RoomNumber` varchar(50) NOT NULL,
  `RoomFloor` varchar(50) NOT NULL,
  `Description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`ID`, `RoomTypeID`, `RoomNumber`, `RoomFloor`, `Description`) VALUES
(1, 1, '1', '1', 'Double bed cover dilengkapi dengan TV 22 Inch'),
(2, 2, '2', '1', 'Double bed cover Super dilengkapi dengan TV 32 Inci');

-- --------------------------------------------------------

--
-- Table structure for table `roomtype`
--

CREATE TABLE `roomtype` (
  `ID` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Capacity` int(11) NOT NULL,
  `RoomPrice` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `roomtype`
--

INSERT INTO `roomtype` (`ID`, `Name`, `Capacity`, `RoomPrice`) VALUES
(1, 'Double bed cover biasa', 3, 200000),
(2, 'Double bed cover Super', 5, 350000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cleaningroom`
--
ALTER TABLE `cleaningroom`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `cleaningroomdetail`
--
ALTER TABLE `cleaningroomdetail`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `cleaningroomitem`
--
ALTER TABLE `cleaningroomitem`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `JobID` (`JobID`);

--
-- Indexes for table `item`
--
ALTER TABLE `item`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `itemstatus`
--
ALTER TABLE `itemstatus`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `job`
--
ALTER TABLE `job`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `CustomerID` (`CustomerID`);

--
-- Indexes for table `reservationcheckout`
--
ALTER TABLE `reservationcheckout`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ItemStatusID` (`ItemStatusID`),
  ADD KEY `ItemID` (`ItemID`),
  ADD KEY `ReservationRoomID` (`ReservationRoomID`);

--
-- Indexes for table `reservationroom`
--
ALTER TABLE `reservationroom`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ReservationID` (`ReservationID`);

--
-- Indexes for table `reservation_request_item`
--
ALTER TABLE `reservation_request_item`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ReservationRoomID` (`ReservationRoomID`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `RoomTypeID` (`RoomTypeID`);

--
-- Indexes for table `roomtype`
--
ALTER TABLE `roomtype`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cleaningroom`
--
ALTER TABLE `cleaningroom`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cleaningroomdetail`
--
ALTER TABLE `cleaningroomdetail`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cleaningroomitem`
--
ALTER TABLE `cleaningroomitem`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `item`
--
ALTER TABLE `item`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `itemstatus`
--
ALTER TABLE `itemstatus`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `job`
--
ALTER TABLE `job`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reservation`
--
ALTER TABLE `reservation`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `reservationcheckout`
--
ALTER TABLE `reservationcheckout`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reservationroom`
--
ALTER TABLE `reservationroom`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `reservation_request_item`
--
ALTER TABLE `reservation_request_item`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `roomtype`
--
ALTER TABLE `roomtype`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `reservationcheckout`
--
ALTER TABLE `reservationcheckout`
  ADD CONSTRAINT `reservationcheckout_ibfk_1` FOREIGN KEY (`ItemStatusID`) REFERENCES `itemstatus` (`ID`),
  ADD CONSTRAINT `reservationcheckout_ibfk_2` FOREIGN KEY (`ItemID`) REFERENCES `item` (`ID`);

--
-- Constraints for table `room`
--
ALTER TABLE `room`
  ADD CONSTRAINT `room_ibfk_1` FOREIGN KEY (`RoomTypeID`) REFERENCES `roomtype` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
