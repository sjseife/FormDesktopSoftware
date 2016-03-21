<?
session_start();
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
										<li><a href="account.php">Account Management</a></li>
								</ul>
	
					 <form method="post" action="login.php" style="position: absolute; top: 0%; right: 0%; width:5%;">
						<input type="submit" class="btn btn-default"  name="logoutSubmit" value="Log out" />
					</form>
				 <div>
					 			<!--		<div style="position: absolute; top: 0%; right: 0%; width:5%;">
					<form method="post" action="login.php">
						<input type="submit"  name="logoutSubmit" value="Log out" />
					</form>
				</div> -->
					<img width="100%" src="http://i.imgur.com/aXIOIvo.jpg">	
		<!--
			<div>
				<table style="width:80%; margin-top: 1.9%; margin-right: auto; margin-left: auto; ">
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="my_forms.php">My Completed Forms</a>
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="saved_forms.php">Saved Progress</a>
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="home.php">Home</a>
				</table>
			</div>
		-->
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