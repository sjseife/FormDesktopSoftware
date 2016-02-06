CREATE TABLE `user_accounts` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT, #auto incrementing auser ID as primary key
  `username` varchar(20) NOT NULL,			# username not null, unique
  `password` varchar(512) NOT NULL,			# password, to be stored hashed
  `salt` varchar(15) NOT NULL,				# salt not null, unique	
  `pw_reset_flag` tinyint(1) DEFAULT NULL,  # pw_reset_flag - to support password reset function if we decide to make a password change mandatory after a reset (boolean)
  `f_name` varchar(45) NOT NULL,			# user first name 
  `l_name` varchar(45) NOT NULL,			# user last name
  `address_street` varchar(45) NOT NULL,	# street address
  `address_number` varchar(45) NOT NULL,	# street number
  `address_city` varchar(50) NOT NULL,		# city
  `address_state` varchar(2) NOT NULL,		# state
  `address_zip` varchar(12) NOT NULL,		#zip code
  `primary_phone` varchar(15) NOT NULL,		#user phone number
  `user_title` varchar(45) DEFAULT NULL,	# user job title (if we decide to use this) nullable
  `user_level` tinyint(1) NOT NULL,			# user level, used to set admin privledges, 1 = non admin 2 = admin 3= super admin
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_id_UNIQUE` (`user_id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  UNIQUE KEY `salt_UNIQUE` (`salt`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;


ALTER TABLE `schaum`.`user_accounts` 
ADD COLUMN `email` VARCHAR(45) NOT NULL  AFTER `username`,
ADD UNIQUE INDEX `email_UNIQUE` (`email` ASC)  ;
