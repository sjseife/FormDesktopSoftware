# Create Table Workflow_user_form

CREATE TABLE `workflow_user_form` (
  `filled_form_id` int(11) NOT NULL,
  `workflow_id` int(11) NOT NULL,
  `fulfilled` tinyint(1) NOT NULL,
  PRIMARY KEY (`filled_form_id`,`workflow_id`),
  KEY `workflow_id_idx` (`workflow_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Create Table workflow
CREATE TABLE `workflow` (
  `workflow_id` int(11) NOT NULL AUTO_INCREMENT,
  `form_id` int(11) NOT NULL,
  `authorizing_user_id` int(11) NOT NULL,
  `user_title` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`workflow_id`),
  KEY `form_id_idx` (`form_id`),
  KEY `user_id_idx` (`authorizing_user_id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

# Create Table user_forms
CREATE TABLE `user_forms` (
  `filled_form_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `form_id` int(11) NOT NULL,
  `filled_form_file` blob NOT NULL,
  `incomplete` tinyint(1) NOT NULL,
  `date_of_completion` date DEFAULT NULL,
  `authorization_complete` tinyint(1) NOT NULL,
  PRIMARY KEY (`filled_form_id`),
  KEY `user_id_idx` (`user_id`),
  KEY `form_id_idx` (`form_id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

# Create Table user_accounts
CREATE TABLE `user_accounts` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `email` varchar(45) NOT NULL,
  `password` varchar(512) NOT NULL,
  `salt` varchar(15) DEFAULT NULL,
  `pw_reset_flag` tinyint(1) DEFAULT NULL,
  `f_name` varchar(45) NOT NULL,
  `l_name` varchar(45) NOT NULL,
  `address_street` varchar(45) NOT NULL,
  `address_number` varchar(45) NOT NULL,
  `address_city` varchar(50) NOT NULL,
  `address_state` varchar(2) NOT NULL,
  `address_zip` varchar(12) NOT NULL,
  `primary_phone` varchar(15) NOT NULL,
  `user_title` varchar(45) DEFAULT NULL,
  `user_level` int(1) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_id_UNIQUE` (`user_id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `salt_UNIQUE` (`salt`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

# Create Table form_template
CREATE TABLE `form_template` (
  `form_id` int(11) NOT NULL AUTO_INCREMENT,
  `form_name` varchar(45) NOT NULL,
  `form_file` blob NOT NULL,
  `form_creation_date` date DEFAULT NULL,
  PRIMARY KEY (`form_id`),
  UNIQUE KEY `form_name_UNIQUE` (`form_name`)
) ENGINE=MyISAM AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;


