<?
session_start();
?>
<html>
	<head>
    
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
			<div>
				<table style="width:80%; margin-top: 1.9%; margin-right: auto; margin-left: auto; ">
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="my_forms.php">My Completed Forms</a>
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="home.php">Home</a>
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="account.php">Account Management</a>
				</table>
			</div>			
	<?  } #end if logged in == true
		} #end if logged in insset ?> 
	</div>
                                
<div>
    <p>
      INSERT CONTENT HERE  
  </p>
</div>
  </body>
  </html>		