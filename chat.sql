-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 06, 2017 at 11:48 AM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `chat`
--

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE `messages` (
  `id` int(11) NOT NULL,
  `idS` int(11) NOT NULL,
  `idR` int(11) NOT NULL,
  `message` varchar(1000) NOT NULL,
  `seen` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `messages`
--

INSERT INTO `messages` (`id`, `idS`, `idR`, `message`, `seen`) VALUES
(1, 2, 4, 'salut', 1),
(2, 4, 2, 'hei', 1),
(3, 32, 21, 'dsadsa', 1),
(4, 5, 6, 'hei 3', 1),
(5, 6, 5, 'hei4', 1),
(6, 5, 6, 'dasds', 1),
(7, 5, 6, 'dasdsfsdfds', 1),
(8, 5, 6, 'fdssdf', 1),
(9, 6, 5, 'dasasd', 1),
(10, 6, 5, 'fdss', 1),
(11, 7, 8, 'salut', 1),
(12, 8, 7, 'salutt', 1),
(13, 7, 8, 'heei', 1),
(14, 7, 8, 'dasa', 1),
(15, 2, 4, 'ce faci?', 1),
(16, 4, 2, 'cf?', 1),
(17, 4, 2, 'fsafsa', 1),
(18, 4, 2, 'fsafasfsa', 1),
(19, 2, 4, 'fsafsasfa', 1),
(20, 2, 4, 'sasfa', 1),
(21, 2, 4, 'gfdgff', 1),
(22, 4, 2, 'dasdsasa', 1),
(23, 2, 4, 'dsadsasadaaaaaaaaa', 1),
(24, 6, 5, 'dassad', 1),
(25, 5, 6, 'dsdfsd', 1),
(26, 6, 2, 'fsadas', 1),
(27, 8, 2, 'dsadas', 1),
(28, 8, 2, 'dasfsa', 1),
(29, 2, 9, 'aa', 1),
(30, 2, 9, 'das', 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `userName` varchar(32) NOT NULL,
  `password` varchar(1000) NOT NULL,
  `isOnline` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `userName`, `password`, `isOnline`) VALUES
(2, 'user1', 'B3DAA77B4C04A9551B8781D03191FE098F325E67', 0),
(4, 'user2', 'A1881C06EEC96DB9901C7BBFE41C42A3F08E9CB4', 0),
(5, 'user3', '0B7F849446D3383546D15A480966084442CD2193', 0),
(6, 'user4', '06E6EEF6ADF2E5F54EA6C43C376D6D36605F810E', 0),
(7, 'user6', '312A46DC52117EFA4E3096EDA510370F01C83B27', 0),
(8, 'user5', '7D112681B8DD80723871A87FF506286613FA9CF6', 0),
(9, 'user9', '86F28434210631FA6BDA6DB990ABA7391F512774', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
