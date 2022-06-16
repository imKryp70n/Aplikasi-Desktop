-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jun 16, 2022 at 03:08 PM
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
(3, 'keeper', '12345', 'Keeper', 'keeper@gmail.com', 'Jakarta', '2022-06-16', 3),
(4, 'Keeper1', '12345', 'Keeper1', '@gmail.com', 'Cimahi', '2022-06-08', 3);

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

-- --------------------------------------------------------

--
-- Table structure for table `itemstatus`
--

CREATE TABLE `itemstatus` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  `CheckOutDateTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `ID` int(11) NOT NULL,
  `RoomTypeID` int(11) NOT NULL,
  `RoomNumber` varchar(50) NOT NULL,
  `RoomFloor` varchar(50) NOT NULL,
  `Description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `roomtype`
--

CREATE TABLE `roomtype` (
  `ID` int(11) NOT NULL,
  `Name` int(11) NOT NULL,
  `Capacity` int(11) NOT NULL,
  `RoomPrice` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `item`
--
ALTER TABLE `item`
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
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `reservationcheckout`
--
ALTER TABLE `reservationcheckout`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `reservationroom`
--
ALTER TABLE `reservationroom`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `reservation_request_item`
--
ALTER TABLE `reservation_request_item`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`ID`);

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
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `item`
--
ALTER TABLE `item`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `job`
--
ALTER TABLE `job`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reservation`
--
ALTER TABLE `reservation`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reservationcheckout`
--
ALTER TABLE `reservationcheckout`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reservationroom`
--
ALTER TABLE `reservationroom`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reservation_request_item`
--
ALTER TABLE `reservation_request_item`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `roomtype`
--
ALTER TABLE `roomtype`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
