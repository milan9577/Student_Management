-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 10, 2022 at 04:26 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `ID` varchar(20) NOT NULL,
  `fname` varchar(100) NOT NULL,
  `lname` varchar(100) NOT NULL,
  `age` varchar(100) NOT NULL,
  `sex` varchar(100) NOT NULL,
  `Religion` varchar(100) NOT NULL,
  `m_s` varchar(100) NOT NULL,
  `mail` varchar(100) NOT NULL,
  `phn` varchar(100) NOT NULL,
  `dob` varchar(100) NOT NULL,
  `loc` varchar(100) NOT NULL,
  `skill` varchar(100) NOT NULL,
  `pass` varchar(100) NOT NULL,
  `status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`ID`, `fname`, `lname`, `age`, `sex`, `Religion`, `m_s`, `mail`, `phn`, `dob`, `loc`, `skill`, `pass`, `status`) VALUES
('20172010010', 'Afrin', 'Islam', '100', 'Female', 'Muslim', 'Unmerried', 'afrin@gmail.com', '123456', '2/5/2022', 'Jessore,Khulna', 'Developer', '123456', 'True'),
('20162019010', 'Emon', 'Hossein', '26', 'Male', 'Muslim', 'Unmerried', 'mokarom@gmail.com', '12345678910', '2/5/2022', 'Khulna', 'Designer', '123456789', 'True'),
('20191017010', 'Aniruddah', 'Biswas', '23', 'Male', 'Hindu', 'Unmerried', 'antu1@gmail.com', '01777777', '2/8/2022', 'Khulna', 'Designer', '123456', 'True'),
('20192012010', 'Munia', 'Sultana', '23', 'Female', 'Muslim', 'Unmerried', 'munia@gmail.com', '0155555', '2/8/2022', 'Dhaka', 'Designer', '123456', 'True'),
('20192011010', 'Suvrodev', 'Howlader', '23', 'Male', 'Muslim', 'Unmerried', 'suvrodevhowlader@gmail.com', '01732887474', '2/8/2022', 'Khulna', 'Developer Designer', '78876338', 'True'),
('20192020010', 'Hridoy', 'Biswas', '23', 'Male', 'Hindu', 'Unmerried', 'hridoy@gmail.com', '123456789', '2/9/2022', 'Khulna', 'Designer', '123456', 'True'),
('20192021010', 'Dhrubo', 'Biswas', '23', 'Male', 'Hindu', 'Unmerried', 'dhrubo@gmail.com', '578578', '2/9/2022', '785785', 'Premik Purush', '123456', 'True'),
('Bangladesh', 'Bangladesh', 'Bangladesh', 'Bangladesh', 'Male', 'Hindu', 'Merried', 'Bangladesh', 'Bangladesh', '2/9/2022', 'Bangladesh', 'Bangladesh', 'Bangladesh', 'False'),
('India', 'India', 'India', 'India', 'Male', 'Hindu', 'Merried', 'India', 'India', '2/9/2022', 'India', 'India', 'India1', 'True'),
('201920210100', 'Dhrubo', 'Biswas', '23', 'Male', 'Hindu', 'Unmerried', 'dhrubo@gmail.com', '123456789', '2/9/2022', 'Mongla,Khulna', 'Designer', '123456', 'True'),
('20192009010', 'Sajib', 'Roy', '23', 'Male', 'Hindu', 'Unmerried', 'sajib@gmail.com', '123456789', '2/9/2022', 'Khulna', 'Designer', '123456789', 'True');

-- --------------------------------------------------------

--
-- Table structure for table `book`
--

CREATE TABLE `book` (
  `Name` varchar(20) NOT NULL,
  `Author` varchar(20) NOT NULL,
  `Price` double NOT NULL,
  `Review` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`Name`, `Author`, `Price`, `Review`) VALUES
('Java', 'Suvrodev Howlader', 1500, 5),
('C++', 'Saikat', 2500, 5);

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Department` varchar(100) NOT NULL,
  `Semester` varchar(100) NOT NULL,
  `C_Teacher` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`ID`, `Name`, `Department`, `Semester`, `C_Teacher`) VALUES
('CSE-1101', 'Basic in C', 'CSE', '1_1', 'Suvrodev Howlader'),
('CSE-2201', 'Algorithm', 'CSE', '2_2', 'Zahrul Jannat Peya'),
('CSE-1102', 'Computer Basic and Programming Sessional', 'CSE', '1_1', 'Md. Inzamam-Ul-Hossain'),
('Hum-1141', 'History of Emergence of Bangladesh', 'CSE', '1_1', 'Aniruddah Biswas'),
('CSE-1201', 'Object Oriented Programming', 'CSE', '1_2', 'Nagib Mahfuz'),
('CSE-1202', 'Object Oriented Programming Sessional', 'CSE', '1_2', 'Nagib Mahfuz'),
('CSE-1301', 'Digital Logic Design', 'CSE', '1_3', 'Soniya Yeasmin'),
('CSE-1302', 'Digital Logic Design Sessional', 'CSE', '1_3', 'Soniya Yeasmin'),
('CSE-1304', 'Software Development Sessional-i', 'CSE', '1_3', 'Md. Inzamam-Ul-Hossain'),
('CSE-2101', 'Data Structures', 'CSE', '2_1', 'Nagib Mahfuz'),
('CSE-2102', 'Data Structure Sessional', 'CSE', '2_1', 'Nagib Mahfuz'),
('CSE-2202', 'Algorithms Sessional', 'CSE', '2_2', 'Zahrul Jannat Peya'),
('CSE-2205', 'Discrete Mathematics', 'CSE', '2_2', 'Soniya Yeasmin'),
('CSE-2204', 'Software Development Sessional-II', 'CSE', '2_2', 'M. Raihan'),
('CSE-2301', 'Microprocessors and Microcomputers', 'CSE', '2_3', 'Zahrul Jannat Peya'),
('CSE-2302', ' Microprocessors and Microcomputers Sessional', 'CSE', '2_3', 'Zahrul Jannat Peya'),
('CSE-3101 ', 'Applied Probability and Queuing Theory', 'CSE', '3_1', 'Nazia Farah'),
('CSE-3104', 'Internet Programming Sessional', 'CSE', '3_1', 'Md. Inzamam-Ul-Hossain'),
('CSE-3105', 'Database Systems', 'CSE', '3_1', 'Md. Inzamam-Ul-Hossain'),
('CSE-3106', 'Database Systems Sessional', 'CSE', '3_1', 'Md. Inzamam-Ul-Hossain'),
('CSE-2303', 'Numerical Analysis', 'CSE', '2_3', 'Soniya Yeasmin'),
('CSE-3201', 'Systems Programming and Operating System', 'CSE', '3_2', 'Md. Mahedi Hasan'),
('CSE-3202', 'Systems Programming and Operating System Sessional', 'CSE', '3_2', 'Md. Mahedi Hasan'),
('CSE-3204', 'Software Development Sessional-III', 'CSE', '3_2', 'Md. Inzamam-Ul-Hossain'),
('CSE-3205', 'Software Engineering', 'CSE', '3_2', 'Nazia Farah'),
('CSE-3206', 'Software Engineering Sessional', 'CSE', '3_2', 'Soniya Yeasmin'),
('cse-b', 'Bangla', 'CSE', '1_1', '22');

-- --------------------------------------------------------

--
-- Table structure for table `message`
--

CREATE TABLE `message` (
  `ID` varchar(1000) NOT NULL,
  `T_N` varchar(1000) NOT NULL,
  `1_1` varchar(1000) NOT NULL,
  `1_2` varchar(1000) NOT NULL,
  `1_3` varchar(1000) NOT NULL,
  `2_1` varchar(1000) NOT NULL,
  `2_2` varchar(1000) NOT NULL,
  `2_3` varchar(1000) NOT NULL,
  `3_1` varchar(1000) NOT NULL,
  `3_2` varchar(1000) NOT NULL,
  `3_3` varchar(1000) NOT NULL,
  `4_1` varchar(1000) NOT NULL,
  `4_2` varchar(1000) NOT NULL,
  `4_3` varchar(1000) NOT NULL,
  `Admin` varchar(1000) NOT NULL,
  `Teacher` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `message`
--

INSERT INTO `message` (`ID`, `T_N`, `1_1`, `1_2`, `1_3`, `2_1`, `2_2`, `2_3`, `3_1`, `3_2`, `3_3`, `4_1`, `4_2`, `4_3`, `Admin`, `Teacher`) VALUES
('20192011010', 'Suvrodev Howlader', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('20191017010', 'Aniruddah Biswas', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('20192018010', 'Munia Sultana', '', '', '', '', '', '', '', 'Hey AMi tomader Sahopathi', '', '', '', '', '', ''),
('1', 'Md. Inzamam-Ul-Hossain', '1_1 CR?', '', '', '', '', '', '', 'Suvrodev', '', '', '', '', '', ''),
('2', 'Tajul Islam', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('3', 'Zahrul Jannat Peya', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('4', 'Soniya Yeasmin', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('5', 'M. Raihan', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('6', 'Nagib Mahfuz', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('7', 'Nazia Farah', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('8', 'Md. Mahedi Hasan', '', '', '', '', '', '', '', 'OS', '', '', '', '', '', ''),
('dean', '', '', '', '', '', '', '', '', 'Are You 3_2?', '', '', '', '', 'Hi Admin', 'Teacher'),
('22', '22', '', '', '', '', '', '', '', '', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `result`
--

CREATE TABLE `result` (
  `ID` varchar(100) NOT NULL,
  `S_N` varchar(100) NOT NULL,
  `1_1` float NOT NULL,
  `1_2` float NOT NULL,
  `1_3` float NOT NULL,
  `2_1` float NOT NULL,
  `2_2` float NOT NULL,
  `2_3` float NOT NULL,
  `3_1` float NOT NULL,
  `3_2` float NOT NULL,
  `3_3` float NOT NULL,
  `4_1` float NOT NULL,
  `4_2` float NOT NULL,
  `4_3` float NOT NULL,
  `Payment` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `result`
--

INSERT INTO `result` (`ID`, `S_N`, `1_1`, `1_2`, `1_3`, `2_1`, `2_2`, `2_3`, `3_1`, `3_2`, `3_3`, `4_1`, `4_2`, `4_3`, `Payment`) VALUES
('20192011010', 'Suvrodev', 4, 0, 0, 0, 0, 0, 0, 3.51, 0, 0, 0, 0, 'Paid'),
('20191017010', 'Aniruddah', 0, 0, 0, 0, 0, 0, 0, 3.35, 0, 0, 0, 0, 'Paid'),
('20192002010', 'Al', 0, 0, 0, 0, 0, 0, 0, 3.42, 0, 0, 0, 0, 'Paid'),
('20192012010', 'Munia', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ''),
('20172010010', 'Afrin', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 'Paid'),
('20192001010', 'Sanjana', 0, 0, 0, 0, 0, 3.45, 0, 0, 0, 0, 0, 0, ''),
('1', '1', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'Paid');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `ID` varchar(100) NOT NULL,
  `fname` varchar(100) NOT NULL,
  `lname` varchar(100) NOT NULL,
  `age` varchar(100) NOT NULL,
  `sex` varchar(100) NOT NULL,
  `religion` varchar(100) NOT NULL,
  `Department` varchar(100) NOT NULL,
  `Semester` varchar(100) NOT NULL,
  `Section` varchar(100) NOT NULL,
  `cgpa` varchar(100) NOT NULL,
  `phn` varchar(100) NOT NULL,
  `mail` varchar(100) NOT NULL,
  `dob` varchar(100) NOT NULL,
  `location` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `Blood_Donate` varchar(100) NOT NULL,
  `Vaccinated` varchar(100) NOT NULL,
  `Blood_Group` varchar(100) NOT NULL,
  `Last_Donate` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`ID`, `fname`, `lname`, `age`, `sex`, `religion`, `Department`, `Semester`, `Section`, `cgpa`, `phn`, `mail`, `dob`, `location`, `password`, `Blood_Donate`, `Vaccinated`, `Blood_Group`, `Last_Donate`) VALUES
('20192011010', 'Suvrodev', 'Howlader', '23', 'Male', 'Hindu', 'CSE', '3_2', 'A', '3.51', '01609593186', 'suvrodevhowlader1408@gmail.com', '2/2/2022', 'Khulna', '123456', 'Yes', 'No', 'B+', '27/02/2022'),
('20191017010', 'Aniruddah', 'Biswas', '22', 'Male', 'Hindu', 'CSE', '3_2', 'A', '3.35', '', 'aniruddahbiswas01@gmail.com', '2/2/2022', '', '121212', 'Yes', 'Yes', 'A+', ''),
('20192002010', 'Al', 'Zahur', '22', 'Male', 'Muslim', 'CSE', '3_2', 'A', '3.42', '01752331122', 'zahur@gmail.com', '2/3/2022', 'Digraj,Khulna', '12345', '', '', '', ''),
('20192012010', 'Munia', 'Sultana', '22', 'Female', 'Muslim', 'CSE', '3_2', 'A', '3.88', '01951235689', 'munia@gmail.com', '2/3/2022', 'Dhaka', '123456', '', '', '', ''),
('20172010010', 'Afrin', 'Islam', '', 'Female', 'Muslim', 'CSE', '4_3', 'A', '4.00', '5555555555', 'af@gmail.com', '2/5/2022', 'Jessore', '112233', 'Yes', 'Yes', 'B+', '01/01/2022'),
('20192001010', 'Sanjana', 'Wusan', '23', 'Female', 'Hindu', 'CSE', '2_3', 'A', '3.45', 'aergswrgh', 'sdftryhsrt', '2/9/2022', 'aergtserg', '123456', '', '', '', ''),
('1', '1', '1', '1', '', 'Muslim', 'CSE', '1_1', 'A', '1', '1', '1', '2/9/2022', '123456', '123456', 'Yes', 'Yes', 'A+', '');

-- --------------------------------------------------------

--
-- Table structure for table `teacher`
--

CREATE TABLE `teacher` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Age` varchar(100) NOT NULL,
  `Sex` varchar(100) NOT NULL,
  `Religion` varchar(100) NOT NULL,
  `Department` varchar(100) NOT NULL,
  `M_S` varchar(100) NOT NULL,
  `Phone` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `DOB` varchar(100) NOT NULL,
  `Location` varchar(100) NOT NULL,
  `Pass` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `teacher`
--

INSERT INTO `teacher` (`ID`, `Name`, `Age`, `Sex`, `Religion`, `Department`, `M_S`, `Phone`, `Email`, `DOB`, `Location`, `Pass`) VALUES
('20192011010', 'Suvrodev Howlader', '23', 'Male', 'Hindu', 'CSE', 'Unmerried', '01732887474', 'suvrodev@gmail.com', '2/4/2022', 'Mongla,Khulna', '78876338'),
('20191017010', 'Aniruddah Biswas', '22', 'Male', 'Hindu', 'CSE', 'Merried', '7777777', 'antu01@gmail.com', '2/4/2022', 'Rampal,Khulna', 'antu12'),
('20192018010', 'Munia Sultana', '22', 'Female', 'Muslim', 'CSE', 'Unmerried', '0174185296', 'munia@gmail.com', '2/4/2022', 'Dhaka', '123456'),
('1', 'Md. Inzamam-Ul-Hossain', '', 'Male', 'Muslim', 'CSE', 'Merried', '01920887766', 'cse.inzamam@yahoo.com', '2/5/2022', 'Khulna', '123456'),
('2', 'Tajul Islam', '', 'Male', 'Muslim', 'CSE', 'Merried', ' +880-1952303940', 'tajulkuet09@gmail.com', '2/5/2022', 'Khulna', '123456t'),
('3', 'Zahrul Jannat Peya', '', 'Female', 'Muslim', 'CSE', 'Merried', ' +880-1745885080', 'jannat.ruet@yahoo.com ', '2/5/2022', 'Khulna', '123456j'),
('4', 'Soniya Yeasmin', '', 'Female', 'Muslim', 'CSE', 'Merried', '+880-1683371171', 'soniya.cse08@gmail.com', '2/5/2022', 'Khulna', '123456j'),
('5', 'M. Raihan', '', 'Male', 'Muslim', 'CSE', 'Merried', '+880-1714070902', 'rianku11@gmail.com', '2/5/2022', 'Khulna', '123456j'),
('6', 'Nagib Mahfuz', '', 'Male', 'Muslim', 'CSE', 'Merried', '+880-2477-730596', 'ren3336@gmail.com', '2/5/2022', 'Khulna', '123456n'),
('7', 'Nazia Farah', '', 'Female', 'Muslim', 'CSE', 'Merried', '+880-2477-730596', 'ren3336@gmail.com', '2/5/2022', 'Khulna', '123456n'),
('8', 'Md. Mahedi Hasan', '', 'Male', 'Muslim', 'CSE', 'Merried', '+880-1714615916', 'mdmahedihasan76@gmail.com', '2/5/2022', 'Khulna', '123456m'),
('22', '22', '22', 'Male', 'Hindu', 'CSE', 'Merried', '22', '22', '2/9/2022', '22', '123456');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
