<?
date_default_timezone_set("EST");
session_start();

#suppress errors
error_reporting(E_ERROR | E_PARSE | E_CORE_ERROR);
/*
* @author Joseph Schaum, Blake Johnson
*/
function clean($codeToBeCleaned, $maxlength)
{ 
    $cleanCode = $codeToBeCleaned;
    $cleanCode = substr($cleanCode,0,$maxlength);
    $cleanCode = escapeshellcmd($cleanCode); 
    $cleanCode = htmlspecialchars($cleanCode,ENT_QUOTES); 
    return $cleanCode;
}

//Checks if the user submits email address
if(isset($_POST['submit']))
{
  	 $email = clean($_POST['remail'], 50);
  
try
{
  
   # Connect to DB
	  $db = new PDO("mysql:host=localhost;dbname=schaum", "schaum", "12345");
            if (!$db) {
                die('Could not connect: Please try again later. ');

            }// end !db
            $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
  
  //check to see if the email is being used
  $query = "SELECT email FROM user_accounts WHERE email = '$email';";
  $statement = $db->prepare($query);
    $statement->execute(array());
      while($row = $statement->fetch(PDO::FETCH_BOTH))
      {
          $email = $row[0];
      } //end while
    
  	//if the email exists
		 $query = "SELECT username FROM user_accounts WHERE email = '$email';";
		 $statement = $db->prepare($query);
       $statement->execute(array());
            while($row = $statement->fetch(PDO::FETCH_BOTH))
            {
                $username = $row[0];
				
            }//end while
  
  
      //create a random password
    
  $random = substr(md5(uniqid(rand(),1)),3,10);
  #retrieve salt for specific user id trying to log in
  	$query = "SELECT salt FROM user_accounts WHERE email = '$email';";
    #prepare the query
    $statement = $db->prepare($query);

    #pass data to an array
    $statement->execute(array());
    while($row = $statement->fetch(PDO::FETCH_BOTH))
    {
       $salt = $row[0];
		}//end while
  
    ## Hashing Algorithm ##
    if(isset($salt))
    {
       #DO NOT CHANGE $pepper, doing so will result in failure of login system
       $pepper="5hQB6y3uLRmA"; #pepper stored serverside in code
       $count=0;
      
       #hash password with salt and pepperw
       $pw = hash('sha512', $salt . $random . $pepper);

      while($count < 100000)
      {
          $pw = hash('sha512', $salt . $pw . $pepper);
          $count++;
      }//end while                              
      
    }//end if isset salt

    #update the database with the newly resetted password
    $query = "UPDATE `user_accounts` SET `password` ='$pw' WHERE `email` = '$email';";
    
    #prepare the query
    $statement = $db->prepare($query);

    # pass data to an array
    $statement->execute(array());
	  $db = NULL;
	 	#set reset condition to true, password has been reset
	  

    ###########################################################
    #                   Begin PHPMailer                       #
    #            Info: /PHPMailer_5.2.0/aboutus.html	        #
    ###########################################################

    require("PHPMailer_5.2.0/PHPMailerAutoload.php");
    $mail = new PHPMailer();
  
    $mail->IsSMTP();
    $mail->Host = "smtp.gmail.com;smtp.gmail.com";
    $mail->SMTPAuth = true;
    $mail->Username = "fillableformspw.recovery@gmail.com";
    $mail->Password = "Brogrammers";
	  $mail->SMTPSecure = 'tls';                            // Enable encryption, 'ssl' also accepted
	  $mail->Port = 587;
	  $mail->From = "fillableformspw.recovery@gmail.com";
	  $mail->FromName = "Fillable Forms PW Recovery";// name is optional
	  $mail->AddAddress("$email");

    $mail->WordWrap = 50;                                 // set word wrap to 50 characters

	  $mail->IsHTML(true);                                  // set email format to HTML

	  $mail->Subject = "Password Recovery";
	  $mail->Body    = "
	  Hello $username ,<br/>You have requested to reset your password. Here is a temporary password: $random.  <br/>Please login and change your password as soon as possible. <br/>Regards, <br />The Brogrammers.";
	  $mail->AltBody = '';
    
    if(!$mail->Send())
	  { 
          echo "Message could not be sent. <p>";
	        echo "Mailer Error: " . $mail->ErrorInfo;
          exit;
    }//end if
	$rsent = true;	
	
}//end try
catch(Exception $e)
{
  echo "Error: Connection to database failed.";
}//end catch


}//end if submit button has been pressed to reset password



?>
<!--- Main Password Reset Page -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<title>Reset Password</title>
	<link rel="shortcut icon" href="http://s27.postimg.org/lc9yxczr3/etsu.png" type="image/x-icon" />
 	<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
	</head>
	<style>
	</style>	
	<body>
  <div>
				<nav class="navbar navbar-default">
				 <div class="container-fluid">
					 <div class="navbar-header">
						 <a class="navbar-brand" href="#">Fillable Forms Application</a>
					 </div>

				 <div>
					<img width="100%" src="http://i.imgur.com/aXIOIvo.jpg">	
					</div>
    </nav>
    </div>
    <div>
      <h2>Reset Password</h2><br />
    </div>
    
<?
	// reset was successful
 if (isset($rsent))
 {
	 ?>
	 <div class="login" style="top:30%">
               <div class="alert alert-success fade in">
									<h4>Please check your email. If the email you entered matches our records you will receive an email with a new password. Click the link below to return to the login page.</h4>
								</div>
                
                    <form method="post" action="login.php" >
                            <input name="logout" class="btn btn-default" type="submit" value="Login Page" />
                        </form>
                </div>
	<?
	 
}//end if $rsent is set
else
{
	?>
 <form action="ResetPassword.php" method="post"	>
    <br><br>
    Please enter the email address associated with your account to reset your password.
    <br><br>
	  <p>
		  Email Address: <input type="text" name="remail" size='50' maxlength="50"><br /><br />
		                <input type="submit" class="btn btn-default" name="submit" value="Reset Password">
                    <input type="submit" class="btn btn-default" name="cancel" id="cancel" value="Cancel" class=btn onclick="form.action='login.php'">
	  </p>
	
	</form>
       
	<?
}//end else for condition isset($rsent)
?>
        
</body>
</html>