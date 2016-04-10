<?
 date_default_timezone_set("EST");
session_start();
#supress errors 
error_reporting(E_ERROR | E_PARSE | E_CORE_ERROR);

/**
 * @author Joseph Schaum
 *
 * Password reset page
 * 
 */

#clean function to make user input html/sql safe
function clean($codeToBeCleaned, $maxlength)
{ 
    $cleanCode = $codeToBeCleaned;
    $cleanCode = substr($cleanCode,0,$maxlength);
    $cleanCode = escapeshellcmd($cleanCode); 
    $cleanCode = htmlspecialchars($cleanCode,ENT_QUOTES); 
    return $cleanCode;
}






 //This runs if the user submits an email address
 if (isset($_POST['submit']))
{
	
	 $email = clean($_POST['remail'], 25);
	 
try
	{
	
	 # Connect to DB
	  $db = new PDO("mysql:host=localhost;dbname=schaum", "schaum", "12345");
            if (!$db) {
                die('Could not connect: Please try again later. ');

            }// end !db
            
            $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	 
	// chechking to see if the email is in use
	 $query = "SELECT `email` FROM `login` WHERE `email` = '$email';";
	 
	 $statement = $db->prepare($query);

            # pass data to an array
            $statement->execute(array());
            
            while($row = $statement->fetch(PDO::FETCH_BOTH))
            {
                $email = $row[0];
				
            }//end while
	 
	 

	// if email exists
	
		 $query = "SELECT `username` FROM `login` WHERE `email` = '$email';";
		 
		  $statement = $db->prepare($query);

            # pass data to an array
            $statement->execute(array());
            
            while($row = $statement->fetch(PDO::FETCH_BOTH))
            {
                $username = $row[0];
				
            }//end while
		 
		
		 
		// creating a random password
		$random = substr(md5(uniqid(rand(),1)),3,10);
		 # query set, retrieve salt for specific member that is trying to login. Salt is stored in database
           
			$query = "SELECT `salt` FROM `login` WHERE `username` = '$username';";
            #prepare the query
            $statement = $db->prepare($query);

            # pass data to an array
            $statement->execute(array());
           
            while($row = $statement->fetch(PDO::FETCH_BOTH))
            {
                $salt = $row[0];
				
            }//end while
           
            #HASHING ALGORITHM
   			if(isset($salt))
            {
				#DO NOT CHANGE $pepper, doing so will result in failure of login system
                $pepper="5hQB6y3uLRmA";#pepper stored serverside in code
                $count=0;
                #hash password with salt and pepper
                
				$pw = hash('sha512', $salt . $random . $pepper);
                #Hash is itterated 100,000 times. This is done to drastically reduce the speed at which a brute force attack can be done.
              
                while($count < 100000)
                    {
                        $pw = hash('sha512', $salt . $pw . $pepper);
                        $count++;    
                    }
		 #new password is stored as $pw
		 
		 
			}//end if salt is set
	
	//update database
	$query = "UPDATE `login` SET `password` ='$pw' WHERE `email` = '$email';";
		 
		 #prepare the query
            $statement = $db->prepare($query);

            # pass data to an array
            $statement->execute(array());
	 		$db = NULL;
	 		#set reset condition to true, password has been reset
	  		$rsent = true;	
		 
	  // send email to user to reset password 
	// uses PHPMailer, creator info can be found in /PHPMailer_5.2.0/aboutus.html	
	require("PHPMailer_5.2.0/PHPMailerAutoload.php");

	$mail = new PHPMailer();

	$mail->IsSMTP();                                      // set mailer to use SMTP
	$mail->Host = "smtp.gmail.com;smtp.gmail.com";  // specify main and backup server
	$mail->SMTPAuth = true;     // turn on SMTP authentication
	$mail->Username = "heritagealliancepw.recovery@gmail.com";  // SMTP username
	$mail->Password = "CSCI3020"; // SMTP password
	$mail->SMTPSecure = 'tls';                            // Enable encryption, 'ssl' also accepted
	$mail->Port = 587;
	$mail->From = "heritagealliancepw.recovery@gmail.com";
	$mail->FromName = "Heritage Aliance DB PW Recovery";// name is optional
	$mail->AddAddress("$email");



	$mail->WordWrap = 50;                                 // set word wrap to 50 characters

	$mail->IsHTML(true);                                  // set email format to HTML

	$mail->Subject = "Password Recovery";
	$mail->Body    = "
	Hello $username ,<br/>You have requested to reset your password. Here is a temporary password: $random .  <br/>Please login and change your password as soon as possible. <br/>Regards, <br/>Heritage Alliance";
	$mail->AltBody = '';

	if(!$mail->Send())
	{
	   echo "Message could not be sent. <p>";
	   echo "Mailer Error: " . $mail->ErrorInfo;
	   exit;
	}

	echo "Message has been sent";
	
}//end try
catch (Exception $e) 
{
 	echo "Something went wrong!!!";	
}// end catch
	

	 
 }//end if submit has been pressed
  



?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
 
  
  <!--[if lt IE 9]><script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
<title>TITLE HERE</title>
<link href="THA.css" rel="stylesheet" type="text/css" />
<link href="loginstyle.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div class="background2" id="apDiv2"> <!--Gray Bar at top -->
  <h3 style="color:white; font-size:32px; margin-top:2%" align="center">INSERT TITLE</h3></div>

<div class="background" id="apDiv1"><!-- Green mid stripe -->

<img class="displayed" src="Images/HA_logo_white_and_trans.png" width="25%" height="100%" alt="HALogo" /><!-- THA logo, white w/ transparent background-->


</div>



<div id="apDiv3" > <section class="container"><!-- Image packground housing Login form -->
<?


	// reset was successful
 if (isset($rsent))
 {
	 ?>
	 <div class="login" style="top:30%">
               
                <p>Please check your email. If the email you entered matches our records you will reveive and email with a new password. Click the link below to return to the login page.</p>
                    <form method="post" action="HeritageHome.php" >
                            <input name="logout" type="submit" value="Login Page" />
                        </form>
                </div>
	<?
	 echo '<p></p>n';
	 
}//end if $rsent is set
else
{
	?>
 <form action="RestPassword.php" method="post"	>
	  <p>
		  Email Address: <input type="text" name="remail" size='50' maxlength="50">
		                <input type="submit" name="submit" value="Reset Password">  
	  </p>
	
	</form>
	<?
}//end else for condition isset($rsent)
?>
</div>



</body>
</html>

