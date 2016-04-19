<?
session_start();
/*
* @author Stan Seiferth, Blake Johnson
*/
?>

<html>
	<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<title>Account Management</title>
	<link rel="shortcut icon" href="http://s27.postimg.org/lc9yxczr3/etsu.png" type="image/x-icon" />
	<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script> 
	</head>
	<style>
	</style>
	<body> 
  <div>
    <? ############### Link table at top of page for navigation ########################
	if(isset($_SESSION['logged_in']))
   {
     if($_SESSION['logged_in'] == true)
      {
 	?>			<div style="position: absolute; top: 0%; right: 0%; width:5%;">
					<form method="post" action="login.php">
						<input type="submit"  name="logoutSubmit" value="Log out" />
					</form>
				</div>
		
				<nav class="navbar navbar-default">
				 <div class="container-fluid">
					 <div class="navbar-header">
						 <a class="navbar-brand" href="#">Fillable Forms Application</a>
					 </div>
					 <ul class="nav navbar-nav">
						 <li><a href="home.php">Home</a></li>
										<li><a href="my_forms.php">Completed Forms</a></li>
										<li><a href="saved_forms.php">Saved Forms</a></li>
						 				<li><a href="workflow.php">Workflow Management</a></li>
										<li><a href="account.php">Account Management</a></li>
								</ul>	
					 <form method="post" action="login.php" style="position: absolute; top: 0%; right: 0%; width:5%;">
						<input type="submit" class="btn btn-default"  name="logoutSubmit" value="Log out" />
					</form>
				 <div>
					<img width="100%" src="http://i.imgur.com/aXIOIvo.jpg">	
                                
<div>
	<h2>Account Management</h2>
</div>
<?
########################################################################
#							Begin User Account Management Form											 #	
########################################################################	
?>

<?  
	 function clean($codeToBeCleaned, $maxlength, $key)
		{ 
		 	if($codeToBeCleaned == null)
				$cleanCode = $_SESSION['results'][$key];
		 	else
				$cleanCode = $codeToBeCleaned;
		 
			$cleanCode = substr($cleanCode,0,$maxlength);
			$cleanCode = escapeshellcmd($cleanCode); 
			$cleanCode = htmlspecialchars($cleanCode,ENT_QUOTES); 
			return $cleanCode;
		}
					 
	 #For use with PDO statement 
		$user="schaum";
		$password="12345";
		$dbname="schaum";
		$update = false;			 
					 
	  $user_id = $_SESSION['user_id'];
    $query = ""; 
    $columns = array("username","email","f_name",
                     "l_name", "address_street",
                     "address_number", "address_city", "address_state",
                     "address_zip", "primary_phone");
    $fields = array("Username: ","Email: ","First Name: ",
                     "Last Name: ", "Address: ",
                     "City: ", "State: ", "Zip: ", "Phone Number: ");
	 $fieldNames = array("username","email","f_name",
                     "l_name", "address",
										"address_city", "address_state",
                     "address_zip", "primary_phone");
		
	  if ($_SERVER['REQUEST_METHOD'] == 'POST')
		{
			$streetAddress = explode(' ', $_POST['address'], 2);
			
			if (count($streetAddress) < 2) # prevents off set error if address field is blank or all one word
				$streetAddress = array(null, null);
			
			#check for change to personal information before deciding to update
			foreach ($fieldNames as $key => $element)
				{
					if($key < 4)
					{
						if ($_SESSION['results'][$key] != $_POST[$element])
							{
								$update = true;
							}
					}
					else if ($key == 4)
					{
						if(($_SESSION['results'][4] != $streetAddress[1]) || ($_SESSION['results'][5] != $streetAddress[0]))
						{
							$update = true;
						}
					}
					else if($key > 4)
					{
						if ($_SESSION['results'][$key + 1] != $_POST[$element])
							{
								$update = true;
							}
					}
				}//foreach
			
###########################################################
#								Change Personal Information								#	
###########################################################
			
			#if change occured to personal information update to database
			if ($update)
			{
				$query = "UPDATE user_accounts SET ";

				#build statement for update of information to database
				foreach ($fieldNames as $key => $element)
				{
					if ($element === end($fieldNames))
						$query .= "" . $columns[$key + 1] ." = '" . clean($_POST[$element], 30, $key + 1) . "'";
					else if ($key == 4)
					{
						$query .= "$columns[4] = '" . clean($streetAddress[1], 30, 4) . "', ";
						$query .= "$columns[5] = '" . clean($streetAddress[0], 30, 5) . "', ";
					}
					else if($key > 4)
						$query .= "" . $columns[$key + 1] ." = '" . clean($_POST[$element], 30, $key + 1) . "', ";
					else
						$query .= "$columns[$key] = '" . clean($_POST[$element], 30, $key) . "', ";
				}
				$query .= " WHERE user_id = $user_id;";

				try
				{

				$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
						if (!$db) {
								die('Could not connect: Please try again later. ');
					}
					#prepare the query
					$statement = $db->prepare($query);
					# pass data to an array
					$statement->execute(array());
					echo ('<div class="alert alert-success fade in">
							<h4>Your Information was Updated Successfully!</h4>
						</div>'); 
				}
				catch(exception $e)
				{
					echo 'Caught exception: ',  $e->getMessage(), "\n";
				}
			}
		}
					 
###########################################################
#										Change  Password											#	
###########################################################	
			 
	if(isset($_POST['update']))
	{
		if(($_POST['oldpw'] != "") && ($_POST['newpw'] != "") && ($_POST['confirmpw'] != ""))
		{	
			$newPassword1 = $_POST['newpw'];
			$newPassword2 = $_POST['confirmpw'];
			$oldPw = $_POST['oldpw'];
			if($newPassword1 == $newPassword2)// <-- this checks for matching, if they match, it is then safe to query DB to check if oldPW matches the stored pw for the user.
			{
				try
   		 	{

					$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
							if (!$db) {
									die('Could not connect: Please try again later. ');
							}
          
				 	$db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
					$query = "SELECT password, salt FROM user_accounts WHERE user_id = $user_id";
					$pw_fields = $db->query($query)->fetchAll(PDO::FETCH_NUM);
		 			$db = null;
					$currentPw = $pw_fields[0][0];
					$salt = $pw_fields[0][1];
				}
				catch(exception $e)
				{
					echo 'Caught exception: ',  $e->getMessage(), "\n";
				}
				
				 #HASHING ALGORITHM
				if(isset($salt))
				{

					$pepper="5hQB6y3uLRmA";#pepper stored serverside in code
					$count=0;
					#hash password with salt and pepper
					$oldPw = hash('sha512', $salt . $oldPw . $pepper);

					#Hash is itterated 100,000 times. This is done to drastically reduce the speed at which a brute force attack can be done.

					while($count < 100000)
							{
									$oldPw = hash('sha512', $salt . $oldPw . $pepper);
									$count++;    
							}
					if($oldPw == $currentPw)
					{
						$count=0;
						$newPw = hash('sha512', $salt . $newPassword1 . $pepper);
						while($count < 100000)
						{
							$newPw = hash('sha512', $salt . $newPw . $pepper);
							$count++;    
						}
						try
   		 			{
							$query = "UPDATE user_accounts SET password = '" . $newPw . "' where user_id = $user_id;";
							$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
								if (!$db) {
									die('Could not connect: Please try again later. ');
							}
							#prepare the query
							$statement = $db->prepare($query);
							# pass data to an array
							$statement->execute(array());
							echo ('<div class="alert alert-success fade in">
									<h4>Your Password was Updated Successfully!</h4>
								</div>');	 
						}
						catch(exception $e)
						{
							echo 'Caught exception: ',  $e->getMessage(), "\n";
						}
					}//if old password matches current password
					else 
					{
						echo ('<div class="alert alert-warning fade in">
  					<strong>Warning!</strong> Entered Password Does Not Match Your Current Password.
						</div>');
					}
				}
			}//if new passwords match
			else
			{
				echo('<div class="alert alert-warning fade in">
  					<strong>Warning!</strong> Your New Passwords Do Not Match!</div>');
			}
		}//if isset password fields
	}
			
###########################################################
#								Populate Personal Information							#	
###########################################################
					 
    try
    {

      $db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
          if (!$db) {
              die('Could not connect: Please try again later. ');
          }
          
       $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
       $query = "SELECT "; 
      #build query based on columns array
       foreach($columns as $column)
       {
         if ($column === end($columns))
            $query .= "$column  ";
         else
            $query .= "$column, ";
       }
      $query .= "FROM user_accounts WHERE user_id = $user_id";
       
		 	$results = $db->query($query)->fetchAll(PDO::FETCH_NUM);
		 	$db = null;

     
      $formattedResults = array();
			
			#stores previous entries to session variable in case of empty form value
			$_SESSION['results'] = $results[0];

			#formats results of query to be used with form element values. 
      foreach($_SESSION['results'] as $key => $element)
      {
        if($key == 4)
          continue;
        if($key == 5)
          $formattedResults[] = $_SESSION['results'][5] . " " . $_SESSION['results'][4];
        else
          $formattedResults[] = $element;
      }

      }
      catch(exception $e)
      {
          echo 'Caught exception: ',  $e->getMessage(), "\n";
      }
?>

	
<form action="account.php" method="post">
  <br><br>
   Please edit your details below to update your account information.
  <br><br>
  <form method="post" action="account.php" name="manageAccount" id="manageAccount">
    <table lass="table-condensed" width=700px border=0 cellspacing=10><tr><td valign=top><table lass="table-condensed" border=0>
		<b>Account Information:</b><br><br>
		
		<tr><td>  
		<label>Username:</label>
		</td><td>
		<input type="text" name="username" id="username" value="<?= $formattedResults[0] ?>">
		</td></tr><tr><td>
		
    <label>Email:</label>
		</td><td>
    <input type="text" name="email" id="email" value="<?= $formattedResults[1] ?>">
		</td></tr><tr><td>
		
		<br><b>Change Password:</b><br><br>
		
		</td></tr><tr><td>
		<label>Old Password:</label>
		</td><td>
    <input type="password" name="oldpw" id="oldpw" value="">
		</td></tr><tr><td>
		
		<label>New Password:</label>
		</td><td>
    <input type="password" name="newpw" id="newpw" value="">
		</td></tr><tr><td>
	
		<label>Confirm Password:</label>
		</td><td>
    <input type="password" name="confirmpw" id="confirmpw" value="">
		</td></tr></table></td><td valign=top>
		
		<table border=0>
		<b>Personal Information:</b><br><br>
	
<? 	foreach($fields as $key => $element)
		{ 
			if ($key == 0 || $key == 1)
				continue;
?>
			<tr><td>
			<label><?= $element ?></label>
			</td><td>
			<input type="text" name="<?= $fieldNames[$key] ?>" id="<?= $fieldNames[$key] ?>" value="<?= $formattedResults[$key] ?>">
			</td></tr>
<?	}
?>
			<tr><td>
			
</table> </td></tr> </table>
				<br />
        <input type="submit" class="btn btn-default" name="update" id="update" value="Update" class=btn />
				<input type="submit" class="btn btn-default" name="cancel" id="cancel" value="Cancel" class=btn onclick="form.action='home.php'">
    </form>  
	
</form>
	<?  } #end if logged in == true
		} #end if logged in insset
		else
		{
			echo "Please login to access this page.";
		?>
		<form method='post' action="login.php">
			<button type='submit' class="btn btn-default" name='NoAction' value=''>Login</button>  		
		</form>
					 
	</div>
			<? } ?>		 	 
  </body>
  </html>		