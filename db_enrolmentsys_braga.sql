-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 12, 2023 at 03:15 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_enrolmentsys_braga`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_level`
--

CREATE TABLE `tbl_level` (
  `LevelID` int(10) NOT NULL,
  `LevelDesc` varchar(100) NOT NULL,
  `IsActive` varchar(5) NOT NULL DEFAULT 'Yes'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_level`
--

INSERT INTO `tbl_level` (`LevelID`, `LevelDesc`, `IsActive`) VALUES
(1, 'Kinder', 'Yes'),
(2, 'Grade 1', 'Yes');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_student`
--

CREATE TABLE `tbl_student` (
  `StudentID` int(10) NOT NULL,
  `StudentNumber` varchar(50) NOT NULL,
  `StudentFirstname` varchar(50) NOT NULL,
  `StudentLastname` varchar(50) NOT NULL,
  `StudentStudentMiddlename` varchar(50) NOT NULL,
  `StudentBirthdate` varchar(50) NOT NULL,
  `StudentGender` varchar(50) NOT NULL,
  `StudentContactNumber` varchar(50) NOT NULL,
  `StudentAddress` varchar(100) NOT NULL,
  `StudentCity` varchar(100) NOT NULL,
  `StudentZip` varchar(20) NOT NULL,
  `StudentParentName` varchar(100) NOT NULL,
  `StudentParentRelationship` varchar(100) NOT NULL,
  `StudentParentContactNumber` varchar(50) NOT NULL,
  `LevelID` int(10) NOT NULL,
  `IsActive` varchar(10) NOT NULL DEFAULT 'Yes'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_student`
--

INSERT INTO `tbl_student` (`StudentID`, `StudentNumber`, `StudentFirstname`, `StudentLastname`, `StudentStudentMiddlename`, `StudentBirthdate`, `StudentGender`, `StudentContactNumber`, `StudentAddress`, `StudentCity`, `StudentZip`, `StudentParentName`, `StudentParentRelationship`, `StudentParentContactNumber`, `LevelID`, `IsActive`) VALUES
(1, '2020-0001', 'MJ', 'Aborde', '', 'January 1, 2000', 'Male', '12345678911', 'Davao City', 'Davao City', '8000', 'Parent', 'Parent', '012345467891', 1, 'Yes'),
(2, '2020-0002', 'Charisse', 'Barbosa', '', 'July 17, 2003', 'Female', '98765432101', 'Address', 'Davao City', '8000', 'Charisse Parent', 'Parent', '99999999999', 2, 'Yes');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_level`
--
ALTER TABLE `tbl_level`
  ADD PRIMARY KEY (`LevelID`);

--
-- Indexes for table `tbl_student`
--
ALTER TABLE `tbl_student`
  ADD PRIMARY KEY (`StudentID`),
  ADD KEY `LevelID` (`LevelID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_level`
--
ALTER TABLE `tbl_level`
  MODIFY `LevelID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tbl_student`
--
ALTER TABLE `tbl_student`
  MODIFY `StudentID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_student`
--
ALTER TABLE `tbl_student`
  ADD CONSTRAINT `tbl_student_ibfk_1` FOREIGN KEY (`LevelID`) REFERENCES `tbl_level` (`LevelID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
