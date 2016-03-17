<?
session_start();
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
					$db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
					$query = "SELECT f_name, l_name, user_level, user_id FROM user_accounts WHERE username = :user and password = :pw";
					$statement = $db -> prepare($query);
					$statement -> execute(array(
					'pw' => clean($_POST['pw'], 20),
					'user' => clean($_POST['user'], 20)));
					/*Attempt to return the single record containing user details
					initially stored in the database.
					*/
          $user = clean($_POST['user'], 20);
          $pw = clean($_POST['pw'], 20);
					if ($statement -> rowCount() == 1)
					{
						
						while($row=$statement->fetch(PDO::FETCH_BOTH))
            {
						$_SESSION['user_level'] = $row['user_level'];
						$_SESSION['f_name'] = $row['f_name'];
						$_SESSION['last_name'] = $row['l_name'];
						$_SESSION['connected'] = true;
						$_SESSION['user_id'] = $row['user_id'];
           
							
						}
						
						if((isset($_SESSION['connected']))
						&& ($_SESSION['user_level'] == 0)
						&& isset($_POST['loginSubmit']))
						{
							 #header("Location: default.php");
              $_SESSION['logged_in'] = true;
              
						}	
					}
					else {
						echo("Error: Invalid username or password. Please try again.");	
						$_SESSION['connected'] = false;
					}

					//Close the database connection and statmement
					$statement = null;
					$db = null;
				}
				catch (Exception $e) 
				{
					echo "Error: A problem occured accessing client privileges: ";
				}
		
			} 	


	
	

	?>




	
<html>
	<head>
    
	</head>
	<style>
			.relative1 {
			position: relative;
		}
		.relative2 {
			position: relative;
			top: -20px;
			left: 20px;
			background-color: white;
			width: 500px;
		}

	</style>
	<body>
    
  <div>
    <? ############### IF LOGGED IN CODE TO BE DISPLAYED AND EXECUTED ########################
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
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="saved_forms.php">Saved Progress</a>
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="account.php">Account Management</a>
				</table>
			</div>	
						
						
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
								
								

              
                
    					
                # query set - Select all indicated fields if records match search string
                $query = "SELECT * from form_template;";
    
                #prepare the query
                $statement = $db->prepare($query);
    
                # pass data to an array
                $statement->execute(array());
                $db = null;
								?>
								<div>          
  							<table>
                <tr>
									<th>
										<h2>
											Currently Available Forms
										</h2>
									</th>
                </tr>
									<tr>
									<th>
										<h4>
											Form Name
										</h4>
											
										
									</th>
										<th></th>
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
																		<button type='submit' name='OpenForm' value='<?= $row['form_id'] ?>'>Open</button>   
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

<!--DISPLAY FORM IF OpenForm BUTTON HAS BEEN PRESSED -->						
		
		<?
			if(isset($_POST['OpenForm'] ))
			{
				try
				{
					print_r($_POST);
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
								#add form name to string
								while($row = $statement->fetch(PDO::FETCH_ASSOC))
								{
									$form_name = $row['form_name'];
									$form_string .= '<h1>' . $form_name . '</h1> <form method=post action="my_forms.php"> ';
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
#############################################################################################################################
#		Dynamically build form with while loop, Loops until no rows remain.																											#
#############################################################################################################################
                while($row = $statement2->fetch(PDO::FETCH_ASSOC))
                {
									$element_type = $row['element_type'];
									$form_element_ids .= $row['form_element_id'].',';
									
									if( $element_type == "text")
									{
										$element_text = $row['element_text'];
										$value_name = str_replace(' ', '',$row['element_text']); 
										$form_string .=  $element_text . ': <br> <input type="text" name="' . $value_name . '"><br><br> ';
									}#end if textbox
									elseif( $element_type == "radio")
									{
										$explodedArray = explode(',',$row['element_text']);
										$form_string .= '<fieldset style="display:inline-block">
																			<legend>'. $explodedArray[0] .'</legend>';
										array_shift($explodedArray);
										foreach($explodedArray as $value)
										{
											$form_string .= '<input type="radio" name="radio" value="' . $value . '">' . $value;
										}
										$form_string .= '</fieldset> <br><br>';
										
									}
									elseif( $element_type == "password")
									{
										$form_string .= $element_text . ': <br>
																		<input type="password" name="password"><br><br>';
									}
									elseif( $element_type == "dropdown")
									{
										$explodedArray = explode(',',$row['element_text']);
										$form_string .= '<select name="list">';
										#array_shift($explodedArray);
										foreach($explodedArray as $value)
										{
											$form_string .= '<option value="'. $value .'">'. $value .'</option>';
										}
										$form_string .= '</select> <br><br>';
									}
									elseif( $element_type == "check")
									{
										$explodedArray = explode(',',$row['element_text']);
										$form_string .= '<fieldset style="display:inline-block">
																			<legend>'. $explodedArray[0] .'</legend>';
										array_shift($explodedArray);
										foreach($explodedArray as $value)
										{
											$form_string .= '<input type="checkbox" name="check" value="' . $value . '">' . $value;
										}
										$form_string .= '</fieldset> <br><br>';
									}
								
								}#end form builder loop
							$form_string .= '<br><br>
															<input type=\'submit\' name=\'submit\' value=\'Submit\'>
															<input type = \'reset\' value=\'Reset\' onclick=\'form.action=\'home.php\'>
															<br><br>
															<input type=\'submit\' name=\'SaveProgress\' value=\'Save Progress \' onclick="form.action=\'saved_forms.php\';">
															<br><br>
															<input type=\'submit\' name=\'cancel\' value=\'Cancel\' onclick=\'form.action=\'home.php\'><br><br>
															</form> ';
							#set session variable to hold string
							$_SESSION['form_string'] = $form_string;
							$_SESSION['form_element_ids'] = rtrim($form_element_ids, ",");
					?> 	<div><!--Needs positioned on right side of the screen -->
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
                
                
