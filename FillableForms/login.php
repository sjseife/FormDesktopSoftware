<? 	session_start();
/**
 * @author Joseph Schaum, Blake Johnson
 */

		
if(isset($_POST['clear']))
			{
				$_POST['user'] = "";
				$_POST['pw'] = "";
			}
					
	if(isset($_POST['logoutSubmit']))
	{
		//Clears session variables for initial login attempt.
		unset($_POST);
		session_destroy();
  }

	?>
	<!DOCTYPE html>
	<html>
		<head>
		<meta charset = "utf-8">
		<!-- <link href="humanResourcesManager.css" rel="stylesheet" type="text/css"/> -->
			<link rel="shortcut icon" href="http://s27.postimg.org/lc9yxczr3/etsu.png" type="image/x-icon" />
			<link href="loginstyle.css" rel="stylesheet" type="text/css" />
		<title>User Login</title>
		<style>
			
		body 
			{
				width: 100%;
				background-color: #fafafa  ;
			}
		
      
  
	</style>
		</head>
		<body>
				<img width="100%" src="http://i.imgur.com/aXIOIvo.jpg">	
	
	
    <div class="login">
      <h1 style="color:#002e62;">Form Management Login</h1>
      <form method="post" action="home.php">
		  
        <p><input type='text' name='user' placeholder='Username' size='25' value='' required/></p>
        <p><input type="password" name="pw" value="" placeholder="Password"></p>
        
		<p class="reset">
        	<input type="submit" name="loginSubmit" value="Login">
			<input type="submit" name="reset" value="Reset Form" onclick="form.action='<?= $_SERVER['PHP_SELF'] ?>';">
			<br/><br/><input type="submit" name="reset" value="Reset Password" onclick="form.action='ResetPassword.php';">
		<?
		
			
		?>
      </form>
				

			</div>
			</div>
		<br>
		</div>
			</div>
		</body>
	</html>