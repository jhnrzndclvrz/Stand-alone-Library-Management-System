-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 22, 2023 at 09:09 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `library`
--

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
CREATE TABLE `books` (
  `Book_Title` varchar(50) NOT NULL,
  `Book_Author` varchar(50) NOT NULL,
  `Book_Publisher` varchar(50) NOT NULL,
  `Book_PublicationYear` int(50) NOT NULL,
  `Book_Shelf` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`Book_Title`, `Book_Author`, `Book_Publisher`, `Book_PublicationYear`, `Book_Shelf`) VALUES
('Precalculus', 'Teresita F. Religioso', 'Sibs Publishing House Inc.', 2016, 'S-23'),
('Integral calculus', 'Joseph edwards', 'A.I.T.B.S', 2004, 'S-23'),
('Elementary Integral calculus', 'A.K Sharma', 'Discovery Publishing House', 2005, 'S-23'),
('Introduction to Analytic Geometry and Calculus', 'Melecio C. Deauna', 'Sibs Publishing House Inc.', 1999, 'S-23'),
('Economics for the Consumer', 'Bernardo M. Villegas', 'Sinag-Tala Publishers', 1992, 'S-24'),
('The evolving global economy', 'Kenichi Ohmae', 'Harvard Business Review', 1985, 'S-24'),
('Economics an introduction', 'Bernardo M. Villegas', 'Sinag-Tala Publishers', 1992, 'S-24'),
('Introductory microeconomics', 'Cristobal M. Pagoso et.al', 'Rex Book Store', 1999, 'S-24'),
('Guide to economics for filipinos', 'Bernardo M. Villegas', 'Sinag-Tala Publishers', 1972, 'S-24'),
('Foundation of education', 'Doris D. Tulio ', 'National Bookstore', 2005, 'S-25'),
('Mastering school reform', 'George A. Goens', 'A Division of simon and schuster inc.', 1991, 'S-25'),
('Educational measurement and evaluation', 'Asuncion C. Mercado-del rosario', 'Asuncion C. Mercado-del rosario', 2001, 'S-25'),
('The law on obligations and contracts', 'Hector S. De leon', 'Rex book store inc.', 2003, 'S-29'),
('The Constitution of the republic of the Philippine', 'Jose N. Nolledo', 'National Bookstore', 1997, 'S-29'),
('Rules and regulations implementing', 'Arnell B. Bautista', 'National Bookstore', 1993, 'S-29'),
('Breaking laws of the Philippines', 'CBSI EDITIORIAL STAFF', 'Central book supply inc.', 1998, 'S-29'),
('Barangay its operations and organization', 'F.G Ayson', 'National Bookstore', 1985, 'S-29'),
('Next generation math', 'Clarissa Ullero-Collado', 'Diwa learning inc.', 2011, 'S-32'),
('Synergy for success in mathematics', 'Singapore asia ', 'Singapore asia publisher ', 2014, 'S-32'),
('College mathematics', 'Lorina G. Salamat', 'National Bookstore', 1988, 'S-32'),
('Principles and practices in arithmetic teaching', 'Julia anghileri', 'Open university press', 2001, 'S-32'),
('Fundamentals of investment mathematics', 'Anita C. Ong', 'Island publishing house', 1994, 'S-32'),
('The Philippines: Continuing past', 'Renato constantino', 'The foundation for nationalist studies', 1978, 'S-35'),
('Heroes and villains', 'Carmen guerrero nakpil', 'Cruz publishing', 2011, 'S-35'),
('College physics part 1', 'Ricardo C. Asin', 'Tru-copy publishing', 1997, 'S-35'),
('Mathematical physics', 'P.K Chattopadhyay', 'New age international limited publisher', 1990, 'S-35'),
('Mathematical physics part 1', 'P.K Chattopadhyay', 'New age international limited publisher', 2005, 'S-35'),
('Thou shall not kill', 'Arnel C. Rival', 'Philippine human rights information cente', 1999, 'S-35'),
('Project and circuits', 'Electronic enthusiasts', 'Electronic hobbyists publishing house', 1988, 'S-17'),
('Electronic projects', 'Ramesh Chopra', 'EFY Enterprises', 1989, 'S-17'),
('Intro to control engineering', 'Ajit K. Mandal', 'New age international limited publishers', 2006, 'S-35'),
('Practical electronics', 'Marconi S. Pagarigan', 'Department of education', 1995, 'S-35'),
('Simplified basic electronics ', 'Juanito S. Faina', 'National Bookstore', 1989, 'S-17'),
('College algebra third edition', 'Lorina G. Salamat', 'National bookstore', 1988, 'S-17'),
('1988', 'Feliciano and Uy', 'Merriam webster bookstore', 1991, 'S-17'),
('The accounting process', 'Erlinda C. Pefianco', 'JMC press inc', 1996, 'S-17'),
('Basic accounting volume two', 'G.V Lising', 'Monarch books corporation', 1995, 'S-17'),
('Basic accounting volume one ', 'G.V Lising', 'Monarch books corporation', 1995, 'S-17'),
('Qualitative analysis', 'E.S Gilreath', 'Ken Incorporated', 1964, 'S-25'),
('Assessment of learning 1', 'Mercedes A. Macarandang', 'Books atbp. Publishing Corp.', 2009, 'S-25'),
('Biochemiy for students', 'V.K Malhotra', 'Jaypee Brothers', 2003, 'S-23');

-- --------------------------------------------------------

--
-- Table structure for table `borrow_log`
--

DROP TABLE IF EXISTS `borrow_log`;
CREATE TABLE `borrow_log` (
  `Book_Title` varchar(50) NOT NULL,
  `Book_Author` varchar(50) NOT NULL,
  `Book_Publisher` varchar(50) NOT NULL,
  `Book_PublicationYear` int(50) NOT NULL,
  `Book_Shelf` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `student_log`
--

DROP TABLE IF EXISTS `student_log`;
CREATE TABLE `student_log` (
  `FirstName` varchar(50) NOT NULL,
  `MiddleInitial` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `YearLevel_Course` varchar(50) NOT NULL,
  `DateAndTime` date NOT NULL,
  `Category` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `student_log`
--

INSERT INTO `student_log` (`FirstName`, `MiddleInitial`, `LastName`, `YearLevel_Course`, `DateAndTime`, `Category`) VALUES
('Jarod Peter', 'B.', 'Ong', '3rd Yr BSIT', '2023-01-22', 'Student'),
('JB', 'A.', 'Llona', '3rd yr BSIT', '2023-01-22', 'Student'),
('Johnny', 'N.', 'Bravo', 'Grade 12 ABM', '2022-12-25', 'Student'),
('Michael', 'C.', 'Bermillo', '', '2023-01-22', 'Teacher'),
('JP', 'C.', 'Chicano', '', '2023-01-22', 'Teacher'),
('Kuya', '', 'Guard', '', '2023-01-22', 'Staff'),
('Ma\'am', '', 'Registrar', '', '2023-01-22', 'Staff'),
('Ate', 'sa', 'Canteen', '', '2023-01-22', 'Staff');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Username`, `Password`) VALUES
('librarian', '123');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
