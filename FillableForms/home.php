<?
session_start();
#remember me cookie
if(isset($_POST['remember_me']))
			{
				setcookie('user', "", time()+3600);
			}
#supress errors to user
error_reporting(E_ERROR | E_PARSE | E_CORE_ERROR);

#set timezone for date dunctions
date_default_timezone_set("America/New_York");

#clean function to make user input html/sql safe
function clean($codeToBeCleaned, $maxlength)
{ 
    $cleanCode = $codeToBeCleaned;
    $cleanCode = substr($cleanCode,0,$maxlength);
    $cleanCode = escapeshellcmd($cleanCode); 
    $cleanCode = htmlspecialchars($cleanCode,ENT_QUOTES); 
    return $cleanCode;
}
#
if(isset($_POST['loginSubmit']))
			{
				try
				{
					$host = 'einstein.etsu.edu';
					$dbname = 'schaum';
					$username = 'schaum';
					$password = '12345';

					$db = new PDO("mysql:host=$host;dbname=$dbname", $username, $password);
				}

				catch (Exception $e)
				{
					die("Connection to database failed: Please try again. ");
				}
				try {  
					$user = clean($_POST['user'], 20);
          $pw = clean($_POST['pw'], 20);

            
                        $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            
            # Set variables for use in query
            //$username = clean($_POST['username'], 12);
            
          
            

            # query set, retrieve salt for specific member that is trying to login. Salt is stored in database

			$query = "SELECT salt FROM user_accounts WHERE username = '$user';";
            #prepare the query
            $statement = $db->prepare($query);

            # pass data to an array
            $statement->execute(array());
            
            while($row = $statement->fetch(PDO::FETCH_BOTH))
            {
                $salt = $row[0];
				
            }

					$db = null;
            #HASHING ALGORITHM
            if(isset($salt))
            {
			
                $pepper="5hQB6y3uLRmA";#pepper stored serverside in code
                $count=0;
                #hash password with salt and pepper
								
                $pw = hash('sha512', $salt . $pw . $pepper);
				
                #Hash is itterated 100,000 times. This is done to drastically reduce the speed at which a brute force attack can be done.
              
                while($count < 100000)
                    {
                        $pw = hash('sha512', $salt . $pw . $pepper);
                        $count++;    
                    }
						}

				 # connect to mysql database
           $db = new PDO("mysql:host=localhost;dbname=schaum", "schaum", "12345");
            if (!$db) {
                die('Could not connect: Please try again later. ');

            }
            
            $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            
          
          # query set, get username and admin status from DB if username and pw match relevant fields in DB
            
			$query = "SELECT `username` FROM `user_accounts` WHERE `username` = '$user' AND `password` = '$pw';";

            #prepare the query
            $statement = $db->prepare($query);

            # Execute the query
            $statement->execute(array());
            
            while($row=$statement->fetch(PDO::FETCH_BOTH))
            {   
                if($statement->rowCount($row) == 1)#only allow variables to be set if a single row was returned.
                {
                    
                    $username_returned_from_query = $row[0];
                    
                }
                
               
                
            }
                if(isset($username_returned_from_query)&& count($row) == 1)#if $username_returned_from_query was set and row count == 1
                {
                    if($username_returned_from_query == $user )# is $username_returned_from_query matches username given by user(for this to be true $pw must have also matched)
                        {
                             $_SESSION['logged_in'] = true;
							 								require_once('History.php');
															
															$query = "SELECT f_name, l_name, user_level, user_id, user_title FROM user_accounts WHERE username = '$user';";
															$statement = $db -> prepare($query);
															$statement -> execute(array(
															'pw' => clean($_POST['pw'], 20),
															'user' => clean($_POST['user'], 20)));
															/*Attempt to return the single record containing user details
															initially stored in the database.
															*/

															

																while($row=$statement->fetch(PDO::FETCH_BOTH))
																{
																$_SESSION['user_level'] = $row['user_level'];
																$_SESSION['f_name'] = $row['f_name'];
																$_SESSION['last_name'] = $row['l_name'];
																$_SESSION['user_id'] = $row['user_id'];
																$_SESSION{'user_title'} = $row['user_title'];
																$_SESSION['connected'] = true;

																

														
															}   	$db = null;   
												}
												else 
												{
													$_SESSION['connected'] = false;
													#logs information about failed login attempts
													require_once('FailedLoginLog.php');
													echo '<script type="text/javascript">'; 
													echo 'alert("Invalid username or password, please try again");'; 
													echo 'window.location.href = "login.php";';
													echo '</script>';		

												}

												//Close the database connection and statmement
												$statement = null;
												$db = null;
								
		
			} 
		}
		catch(Exception $e)
		{
			
		}
}

	?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<title>Home</title>
	<link rel="shortcut icon" href="http://s27.postimg.org/lc9yxczr3/etsu.png" type="image/x-icon" />
 	<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
	</head>
	<style>
	</style>
				
	<body>
    
  <div>
    <? ############### IF LOGGED IN CODE TO BE DISPLAYED AND EXECUTED ########################
	if(isset($_SESSION['logged_in']))
   {
     if($_SESSION['logged_in'] == true)
      {
			 

			 
 	?>			

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
						 				<li><a href="workflow.php">Workflow Management</a></li>
								</ul>
	
					 <form method="post" action="login.php" style="position: absolute; top: 0%; right: 0%; width:5%;">
						<input type="submit" class="btn btn-default"  name="logoutSubmit" value="Log out" />
					</form>
					</div>
				 <div>
					 
					<img width="100%" src="http://i.imgur.com/aXIOIvo.jpg">	
						
					</div>
<!--DISPLAY FORM IF OpenForm BUTTON HAS BEEN PRESSED -->						
		
		<?
			if(isset($_POST['OpenForm'] ))
			{
				try
				{
					
					            #Create PDO statement and prepare database connection
            $user="schaum";
            $password="12345";
            $dbname="schaum";
    
            $db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
                if (!$db) {
                    die('Could not connect: Please try again later. ');
    
                }
								$form_id = $_POST['OpenForm'];
                $_SESSION['form_id'] = $form_id;
								#get information from form templates table to display form name
    						$query= "Select * from form_template WHERE form_id = '$form_id';";
                #prepare the query
                $statement = $db->prepare($query);
    						
                # pass data to an array
               
								$statement->execute(array());
               $db = null;
								#used to hold form string
								$form_string = "";
								#form_string .= '<div><table>';
								#add form name to string
								while($row = $statement->fetch(PDO::FETCH_ASSOC))
								{
									$form_string .= '<div class="well well-sm"><table class="table-condensed"><tr><th colspan="2" >';
									$form_name = $row['form_name'];
									$form_string .= ' <h1>' . $form_name . '</h1> <form method=post action="my_forms.php"> </th></tr>';
									#echo $form_string;
								}//end while loop to add form name to string


								$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
										if (!$db) {
												die('Could not connect: Please try again later. ');

										}
								# get all 
								$query = "SELECT * from form_element 
													WHERE form_id = '$form_id'
													ORDER BY form_element_id;";
								$statement2 = $db->prepare($query);
								$statement2->execute(array());
								#holds a comma delimited list of form_element PKs, used later to link repsponses to form elements.
								$form_element_ids="";
								$counter=0;
#############################################################################################################################
#		Dynamically build form with while loop, Loops until no rows remain.																											#
#############################################################################################################################
                while($row = $statement2->fetch(PDO::FETCH_ASSOC))
                {
									$element_type = $row['element_type'];
									$form_element_ids .= $row['form_element_id'].',';
									$id= $row['form_element_id'];
									$form_string .= '<tr>
																		<th>&nbsp;</th>
																		<th>&nbsp;</th> 
																	</tr>';
									if( $element_type == "text")
									{
										$element_text = $row['element_text'];
										$value_name = str_replace(' ', '',$row['element_text']); 
										$form_string .= '<tr><td>' . $element_text . ': </td><td><input type="text" name="' . $id . '"></td></tr>';
									}#end if textbox
									elseif( $element_type == "radio")
									{
										$explodedArray = explode(',',$row['element_text']);
										$form_string .= '<tr> <td> <fieldset class="radiogroup" "style="display:inline-block">
																			'. $explodedArray[0] .'</td><td>';
										array_shift($explodedArray);
										foreach($explodedArray as $value)
										{
											$form_string .= '&nbsp;' . $value . ' <input type="radio"  name="'. $id .'" value="' . $value . '"> ' ;
										}
										$form_string .= '</fieldset></td></tr>';
										
									}
									elseif( $element_type == "password")
									{
										$element_text = $row['element_text'];
										$form_string .= '<tr> <td>' . $element_text . ':</td>
																		<td><input type="password" name="'. $id .'"></td></tr>';
									}
									elseif( $element_type == "dropdown")
									{
										$explodedArray = explode(',',$row['element_text']);
										$form_string .= '<br><tr><td>'. $explodedArray[0] .'</td> <td> <select name="'. $id .'">';
										array_shift($explodedArray);
										foreach($explodedArray as $value)
										{
											$form_string .= '<option value="'. $value .'">'. $value .'</option>';
										}
										$form_string .= '</select></td></tr>';
									}
									elseif( $element_type == "check")
									{
										$explodedArray = explode(',',$row['element_text']);
										$form_string .= '<tr><td><fieldset style="display:inline-block">
																			'. $explodedArray[0] .'</td><td>';
										array_shift($explodedArray);
										foreach($explodedArray as $value)
										{
											$form_string .= '&nbsp;' . $value . '&nbsp;<input type="checkbox" name="'. $id . '[]" value="' . $value . '">';
										}
										$form_string .= '</fieldset></td></tr>';
									}
									$counter++;
								}#end form builder loop
							$form_string .= '<tr><td>
															<input type=\'submit\' class=\'btn btn-default\' name=\'submit\' value=\'Submit\'>
															
															
															<input type = \'reset\' class=\'btn btn-default\' value=\'Reset\' onclick=\'form.action=\'home.php\'>
														
															
															<input type=\'submit\' class=\'btn btn-default\' name=\'SaveProgress\' value=\'Save Progress \' onclick="form.action=\'saved_forms.php\';">
															
															
															<input type=\'submit\' class=\'btn btn-default\' name=\'cancel\' value=\'Cancel\' onclick="form.action=\'home.php\';">
															</td>
															</tr>
															</form> </table></div>';
							#set session variable to hold string
							#$_SESSION['form_string'] = $form_string;
							#set session variable to hold element ids
							$_SESSION['form_element_ids'] = rtrim($form_element_ids, ",");
					?> 	
				
				<div style="margin-right:10%; margin-left:20%;"><!--Needs positioned on right side of the screen -->
								<?= $form_string ?>
							</div>
					<?
					
					 
				}
				catch(Exception $e)
				{
					echo "Danger Will Robinson, Danger!!!";
				}
			}						
?>						
<div>
  <p>
  	<?  #DISPLAY CURRENTLY AVAILABLE FORMS
					try       
    			{ 
            #Create PDO statement and prepare database connection
            $user="schaum";
            $password="12345";
            $dbname="schaum";
    
            $db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
                if (!$db) {
                    die('Could not connect: Please try again later. ');
    
                }
								
    					$user_id = $_SESSION['user_id'];
                # query set - Select all indicated fields if records match search string
                $query = "SELECT form_name, form_id FROM form_template
															WHERE form_name NOT IN 
																(SELECT form_name FROM form_template
																 	join  user_forms USING(form_id)
																	WHERE user_id = $user_id);";
                #prepare the query
                $statement = $db->prepare($query);
    
                # pass data to an array
                $statement->execute(array());
                $db = null;
								?>
								<div class="table-responsive">          
  							<table class="table table-hover">
                <tr>
									
									<th colspan="2">
										<h2>
											Available Forms
										</h2>
									</th>
									
                </tr>
									<tr>
										
									<th colspan="2" align="center">
										<h4>
											Form Name
										</h4>
											
										
									</th>
										
									</tr>
                <?
						#Dynamically build table with while loop, Loops until no rows remain. This displays all forms available
                while($row = $statement->fetch(PDO::FETCH_ASSOC))
                {
                    ?>
                    <tr>
													
													<td>
														<h4>
															
														
															<?= $row['form_name'] ?>
														</h4>
													</td>
													<td>
                            <p>
																	<form method='post' action="<?= $_SERVER['PHP_SELF']?>">
																		<button type='submit' class="btn btn-default" name='OpenForm' value='<?= $row['form_id'] ?>'>Open</button>   
																	</form>
														</p>
												</td>
											
                        
                    </tr>
				
             
                    <?
								
							
                }//end population of table while loop
								}
								catch(Exception $e)
								{

								}?>
	
					</table><!-- Close data table -->
				</div>



						
	<?  } #end if logged in == true
		} #end if logged in insset 
		else
		{
			echo "Please login to access this page."
	
?>
	
	<form method='post' action="login.php">
		<button type='submit' name='NoAction' value=''>Login</button>  
		
	</form>
<? 
		}?> 
	</div>
                                

  </body>
  </html>	