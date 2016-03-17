<? 	session_start();

if(isset($_POST['remember_me']))
			{
				setcookie('user', "", time()+3600);
			}
		
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
			background-color: #041E42;
		}

		.wrapper 
		{
			width: 80%;
			height: auto;
			margin: 20px auto;
			padding: 20px;
		}

		nav 
		{
			width: 100%;
			text-align: center;
			font-size: 16;
		}
		nav a 
		{
			color: blue;
			text-decoration: none;
		}
		
		.loginWrapper 
		{
			background-color: #FFC72C;
			vertical-align: middle;
			margin: 0 auto;
			width: 500px;
			padding: 10px;
			border: 2px solid black;
			color: #000000;
			position: absolute;
			top: 50%;
			left: 50%;
			margin-right: -50%;
			transform: translate(-50%, -50%);
			text-align: center;
			box-shadow: 9px 9px 9px #000000;
		}		
      
  <? ?>
	</style>
		</head>
		<body>
			<!--<div class="login">
			<div class="wrapper">
			<h2 align='center'>Please use a local account to log in.</h2>

	<form name='login' method='post' action='home.php'>
		Username: 
		<input type='text' name='user'/><br /><br />
		Password: 
		<input type='password' name='pw'/><br /><br />
		<input type='submit' name='loginSubmit' value='Login'/>
		<input type="submit" name="reset" value="Reset Form" onclick="form.action='<? #$_SERVER['PHP_SELF'] ?>';">
    <br><br><input type="submit" name="reset" value="Reset Password" onclick="form.action='RestPassword.php';">
	
	</form>
			
			</div>
		<div id="userbar">
		<input type="checkbox" id="remember_me" name="remember_me"/>
		<label for="remember_me">Remember Me</label>
		<br>
			<div id="rememberme">-->
				
	
	
    <div class="login">
      <h1>Form Managment Login</h1>
      <form method="post" action="home.php"><!-- action redirects to HeritageDB.php -->
		  
        <p><input type='text' name='user' placeholder='Username' size='25' value=''/></p>
        <p><input type="password" name="pw" value="" placeholder="Password"></p>
        
		<p class="reset">
        	<input type="submit" name="loginSubmit" value="Login">
			<input type="submit" name="reset" value="Reset Form" onclick="form.action='<?= $_SERVER['PHP_SELF'] ?>';">
			<br/><br/><input type="submit" name="reset" value="Reset Password" onclick="form.action='RestPassword.php';">
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