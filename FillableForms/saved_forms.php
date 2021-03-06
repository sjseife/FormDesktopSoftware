<?
session_start();
#supress errors to user
error_reporting(E_ERROR | E_PARSE | E_CORE_ERROR);
date_default_timezone_set("America/New_York");
/**
 * @author Joseph Schaum, Blake Johnson
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
?>
<html>
	<head>
    
	</head>
	<meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<title>Saved Forms</title>
	<link rel="shortcut icon" href="http://s27.postimg.org/lc9yxczr3/etsu.png" type="image/x-icon" />
	<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
	<style>
  
	</style>
	<body>
    
  <div>
    <?
#############################################################################################################################
#								BEGIN Display web page if user is logged in																																	#
#############################################################################################################################		
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
						 				<li><a href="workflow.php">Workflow Management</a></li>
										<li><a href="account.php">Account Management</a></li>
								</ul>
	
					 <form method="post" action="login.php" style="position: absolute; top: 0%; right: 0%; width:5%;">
						<input type="submit" class="btn btn-default" name="logoutSubmit" value="Log out" />
					</form>
						</div>
				 <div>

					<img width="100%" src="http://i.imgur.com/aXIOIvo.jpg">	
						</div>
					 
					 
				<?	 
#############################################################################################################################
#		Dynamically build form with while loop, Loops until no rows remain.																											#
#############################################################################################################################			 
			 		if(isset($_POST['OpenForm']))
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
								$form_id = clean($_POST['OpenForm'], 12);
                $_SESSION['form_id'] = $form_id;
								$user_id = clean($_SESSION['user_id'], 12);
								#get information from form templates table to display form name
    						$query= "Select * from form_template 
													join user_forms USING(form_id)
													WHERE form_id = $form_id
													AND user_id = $user_id;";
                #prepare the query
                $statement = $db->prepare($query);
    						
                # pass data to an array
               
								$statement->execute(array());
               	$db = null;

								#used to hold form string
								$form_string = "";
								
								#add form name to string that holds HTML for form
								while($row = $statement->fetch(PDO::FETCH_ASSOC))
								{
									$form_string .= '<div class="well well-sm"><table class="table-condensed"><tr><th align="center" colspan="2" >';
									$form_name = $row['form_name'];
									$form_string .= '<h1>' . $form_name . '</h1> <form method=post action="my_forms.php" id="userForm"> </th></tr>';
									#echo $form_string;
								}//end while loop to add form name to string


								$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
										if (!$db) {
												die('Could not connect: Please try again later. ');

										}
								# get all 
							
							
			$query = "SELECT * FROM form_response
									JOIN user_forms USING(filled_form_id)
									WHERE user_id = $user_id
									AND form_id = $form_id
									ORDER BY form_element_id;";
								$statement2 = $db->prepare($query);
								$statement2->execute(array());
								$form_response = array();
								
								#create an array where the array key is the form_element_id and the value is the user response.
								while($row = $statement2->fetch(PDO::FETCH_ASSOC))
								{
									$form_response += array( $row['form_element_id'] => $row['response_text']);
									
								}
							
							$query = "SELECT * FROM form_element WHERE form_id = $form_id
												ORDER BY form_element_id;";
								
								$statement2 = $db->prepare($query);
								$statement2->execute(array());
						#holds a comma delimited list of form_element PKs, used later to link repsponses to form elements.
								$form_element_ids="";

              #print_r($form_response);
								$counter=0;
								while($row = $statement2->fetch(PDO::FETCH_ASSOC))
                {
									#used to determine element type
									$element_type = $row['element_type'];
									$id= $row['form_element_id'];
									#used to insert responses later
									$form_element_ids .= $row['form_element_id'].',';
									
									$form_string .= '<tr>
																		<th>&nbsp;</th>
																		<th>&nbsp;</th> 
																	</tr>';
									if( $element_type == "text")
									{
										$element_text = $row['element_text'];
										$value_name = str_replace(' ', '',$row['element_text']); 
										$form_string .= '<tr><td>' . $element_text . ': </td><td><input type="text" name="' . $id . '"'; 
																		 if($form_response[$row['form_element_id']]!= null || $form_response[$row['form_element_id']] != "")
																		 {
																			 $form_string .= 'value="' . $form_response[$row['form_element_id']] . '"';
																		 } 
																			$form_string .= '></td></tr>';
									}#end if textbox
									elseif( $element_type == "radio")
									{
										$explodedArray = explode(',',$row['element_text']);
										$form_string .= '<tr> <td> <fieldset style="display:inline-block">
																			'. $explodedArray[0] .'</td><td>';
										array_shift($explodedArray);
										foreach($explodedArray as $value)
										{
											
											$form_string .= '&nbsp;' . $value . ' <input type="radio" name="'. $id .'" value="' . $value . '"';
																	
																		
																				 if($form_response[$row['form_element_id']] == $value)
																				 {
																					 $form_string .= 'checked ';
																				 } 
																	
											$form_string.= '> ' ;
										}
										$form_string .= '</fieldset></td></tr>';
										
									}
									elseif( $element_type == "password")
									{
										$element_text = $row['element_text'];
										$form_string .= '<tr> <td>' . $element_text . ':</td>
																		<td><input type="password" name="'. $id .'"';
																
										 if($form_response[$counter]!= null || $form_response[$row['form_element_id']] != "")
											 {
												 $form_string .= 'value="' . $form_response[$row['form_element_id']]. '"';
											 } 							
										$form_string.='></td></tr>';
									}
									elseif( $element_type == "dropdown")
									{
										$explodedArray = explode(',',$row['element_text']);
										$form_string .= '<br><tr><td>'. $explodedArray[0] .'</td> <td> <select name="'. $id .'">';
										array_shift($explodedArray);
										foreach($explodedArray as $value)
										{
											$form_string .= '<option value="'. $value .'"';
												if($form_response[$row['form_element_id']] == $value)
													{
														$form_string .= 'selected="selected"; ';
													} 
												$form_string.= ' >'. $value .'</option>';
										}
										$form_string .= '</select></td></tr>';
									}
									elseif( $element_type == "check")
									{
										$explodedArray = explode(',',$row['element_text']);#turns csv element text into an array
										$form_string .= '<tr><td><fieldset style="display:inline-block">
																			'. $explodedArray[0] .'</td><td>';
										array_shift($explodedArray);
										
										
												 $explodedResponse = explode(',',$form_response[$row['form_element_id']]);
													
										
											 
										
										
										foreach($explodedArray as $value)
										{
											$form_string .= '&nbsp;' . $value . '&nbsp;<input type="checkbox" name="' . $id . '[]" value="' . $value . '"';
													 				
																	
																	if(isset($explodedResponse))
																	{
																		foreach($explodedResponse as $value2)
																		{
																			if($value2 == $value)
																				{
																					$form_string .= 'checked ';
																				}
																		}
																	}
																
																			
														
											$form_string.= '>';
										}
										$form_string .= '</fieldset></td></tr>';
									}
									elseif( $element_type == "multiLineText")
									{
										$element_text = $row['element_text'];
										$value_name = str_replace(' ', '',$row['element_text']); 
										$form_string .= '<tr><td>' . $element_text . ': </td><td><textarea name="' . $id . '" form="userForm">'; 
																		 if($form_response[$row['form_element_id']]!= null || $form_response[$row['form_element_id']] != "")
																		 {
																			 
																			 $response =  $form_response[$row['form_element_id']];
																			 $form_string .= $response;
																		 } 
																			$form_string .= '</textarea></td></tr>';
									}#end if textarea
									elseif ($element_type == "date")
									{
										$element_text = $row['element_text'];
										$value_name = str_replace(' ', '',$row['element_text']); 
										$form_string .= '<tr><td>' . $element_text . ': </td><td><input type="date" name="' . $id . '"'; 
																		 if($form_response[$row['form_element_id']]!= null || $form_response[$row['form_element_id']] != "")
																		 {
																			 $form_string .= 'value="' . $form_response[$row['form_element_id']] . '"';
																		 } 
																			$form_string .= '></td></tr>';
									}
																		elseif($element_type == "header")
									{
										$element_text = $row['element_text'];
										$form_string .= '<tr><td><h1>'. $element_text .'</h1></td></tr>';
									}
									$counter++;
								}#end form builder loop
							$form_string .= '<tr><td>
															<input type=\'submit\' class=\'btn btn-default\' name=\'submit2\' value=\'Submit\'>
															
															
															
														
															
															<input type=\'submit\' class=\'btn btn-default\' name=\'SaveProgress2\' value=\'Save Progress \' onclick="form.action=\'saved_forms.php\';">
															
															
															<input type=\'submit\' class=\'btn btn-default\' name=\'cancel\' value=\'Cancel\' onclick="form.action=\'home.php\';">
															</td>
															</tr>
															</form> </table></div>';
							
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
			}	//end if isset OpenForm
#############################################################################################################################
#																				END Dynamic form builder																														#
#############################################################################################################################
						
					
			 			 ################################################################
						 # 					SUBMISSION HANDLING FOR COMPLETED FORMS							#
						 # make entry into user_forms table for new form								#
						 # call stored procedure to map workflow for new form						#
						 # write all responses to form elements to form_response table	#
						 ################################################################
					
			 		if(isset($_POST['SaveProgress']) || isset($_POST['SaveProgress2']))
					{
						
						if(isset($_POST['SaveProgress2']))
						{
								$user="schaum";
								$password="12345";
								$dbname="schaum";

								$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
										if (!$db) {
												die('Could not connect: Please try again later. ');
    
                }
								$filled_form_id = clean($_SESSION['filled_form_id'], 12);
								#delete old response entries and overwrite with new
								$query= "DELETE FROM form_response WHERE filled_form_id = $filled_form_id";
                #prepare the query
                $statement = $db->prepare($query);
    						#execute query
								$statement->execute(array());
																
								#delete old response entries and overwrite with new
								$query= "DELETE FROM user_forms WHERE filled_form_id = $filled_form_id";
                #prepare the query
                $statement = $db->prepare($query);
    						#execute query
								$statement->execute(array());
						}

			
					

					
					
					
							  $user="schaum";
								$password="12345";
								$dbname="schaum";

								$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
										if (!$db) {
												die('Could not connect: Please try again later. ');
    
                }
								
                $date = date("Y-m-d");
								$user_id = clean($_SESSION['user_id'], 12);
								$form_id = clean($_SESSION['form_id'], 12);
								#Insert user and form information into user_forms table
    						$query= "INSERT INTO user_forms 
													(`user_id`,
													 `form_id`,
													 `incomplete`,
													 `date_of_completion`,
													 `authorization_complete`)
													 VALUES
													 ('$user_id',
													  '$form_id',
														1,
														'$date',
														0
													 );";
                #prepare the query
                $statement = $db->prepare($query);
    						#execute query
								$statement->execute(array());
								

								
								#get filled_form_id for use in form_response INSERT statements below
								$query= "SELECT MAX(filled_form_id) as filled_form_id  FROM user_forms;";
                #prepare the query
                $statement = $db->prepare($query);
    						#execute query
								$statement->execute(array());
						


                
					
					while($row = $statement->fetch(PDO::FETCH_ASSOC))
					{
						$filled_form_id = $row['filled_form_id'];
					}
						$_SESSION['filled_form_id'] = $filled_form_id;

					#$form_element_ids_holder = $_SESSION['form_element_ids'];
					#$form_element_ids = explode(",",$form_element_ids_holder);
					$counter =0;	
					#loop through $_POST for user responses
					foreach($_POST as $key => $response)
						{
							#ignore post variable representing the submit button
							if($response != "Submit" && $response != null && $response != "Save Progress ")
							{
								if(gettype($response)== "array")
								{
									$formattedResponse = "";
									foreach($response as $value)
									{
										$formattedResponse .= clean($value, 500) . ",";
									}
									$formattedResponse =  rtrim($formattedResponse, ",");
								}
								else
								{
									$formattedResponse = clean($response, 500);
								}
								#enter responses into form_response table
								
										$query= "INSERT INTO form_response 
														(`form_element_id`, 
														 `filled_form_id`, 
														 `response_text`)
														 VALUES
														 ('$key',
															'$filled_form_id',
															'$formattedResponse');";
									#prepare the query
									$statement = $db->prepare($query);
									#execute query
									$statement->execute(array());
								
								
								
							}
							$counter++;
						}//end foreach $_POST loop 
								
					
					$db = null;
				
			 
					}//end if SaveProgress is set
					 
			 			 ################################################################
						 # 					END SUBMISSION HANDLING FOR COMPLETED FORMS					#
						 ################################################################
			 
			 
			 			 ################################################################
						 # 			BEGIN DISPLAY INCOMPLETE FORMS AS A LIST FOR USER				#
						 ################################################################
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
								
								

              
                
    					 $user_id = clean($_SESSION['user_id'], 12);
                # query set - Select all indicated fields if records match search string
                $query = "SELECT DISTINCT form_name, form_template.form_id FROM form_response
														JOIN form_element USING(form_element_id)
														JOIN form_template USING(form_id)
														JOIN user_forms USING(filled_form_id)
														WHERE incomplete = 1
														AND user_id = '$user_id';";
    
                #prepare the query
                $statement = $db->prepare($query);
    
                # pass data to an array
                $statement->execute(array());
                $db = null;
								?>
								<div class="table-responsive">          
  							<table class="table table-hover">
                <tr>
									<th>
										<h2>
											Saved Forms
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
									echo "Danger Will Robinson, Danger!";
								}?>
					</table><!-- Close data table -->
				</div>			
					 
					 
					 <?		
			 			 ################################################################
						 # 			BEGIN DISPLAY INCOMPLETE FORMS AS A LIST FOR USER				#
						 ################################################################			 
					 ?>
					 
					 
					 
					 
	<? 	}//end if logged_in == true 
		 } #end if logged in isset
#############################################################################################################################
#																				END Display web page if user is logged in																						#
#############################################################################################################################
		 ?> 

  </body>
  </html>		