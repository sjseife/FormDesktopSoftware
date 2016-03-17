<?
session_start();
date_default_timezone_set("America/New_York");
#echo $_SESSION['form_element_ids'];
#echo "<br> POST:";
#print_r($_POST);
	
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
 	?>		<div style="position: absolute; top: 0%; right: 0%; width:5%;">
					<form method="post" action="login.php">
						<input type="submit"  name="logoutSubmit" value="Log out" />
					</form>
				</div>
			<div>
				<table style="width:80%; margin-top: 1.9%; margin-right: auto; margin-left: auto; ">
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="home.php">Home</a>
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="saved_forms.php">Saved Progress</a>
					<th  height="160" style ="width:14%" scope="col"><p><a style="color: black;" href="account.php">Account Management</a>
				</table>
			</div>	
						
			<div>
  <p>
  	<?  #DISPLAY COMPLETED FORMS
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
                $query = "SELECT * from form_template
														JOIN ;";
    
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
			<?
			 ################################################################
			 # 					SUBMISSION HANDLING FOR COMPLETED FORMS							#
			 # make entry into user_forms table for new form								#
			 # call stored procedure to map workflow for new form						#
			 # write all responses to form elements to form_response table	#
			 ################################################################
				if(isset($_POST['submit']))
				{
					

					
					
					
							  $user="schaum";
								$password="12345";
								$dbname="schaum";

								$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
										if (!$db) {
												die('Could not connect: Please try again later. ');
    
                }
								
                $date = date("Y-m-d");
								$user_id = $_SESSION['user_id'];
								$form_id = $_SESSION['form_id'];
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
														0,
														'$date',
														0
													 );";
                #prepare the query
                $statement = $db->prepare($query);
    						#execute query
								$statement->execute(array());
								
								#assign workflows to specific instance of form in database
								$query= "call schaum.WorkflowAssignment();";
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

                
					$filled_form_id = "";
					while($row = $statement->fetch(PDO::FETCH_ASSOC))
					{
						$filled_form_id = $row['filled_form_id'];
					}
					$form_element_ids_holder = $_SESSION['form_element_ids'];
					$form_element_ids = explode(",",$form_element_ids_holder);
					$counter =0;	
					#loop through $_POST for user responses
					foreach($_POST as $key => $response)
						{
							#ignore post variable representing the submit button
							if($response != "Submit")
							{
								#enter responses into form_response table
								$query= "INSERT INTO form_response 
													(`form_element_id`, 
													 `filled_form_id`, 
													 `response_text`)
													 VALUES
													 ('$form_element_ids[$counter]',
													  '$filled_form_id',
														'$response');";
                #prepare the query
                $statement = $db->prepare($query);
    						#execute query
								$statement->execute(array());
								$counter++;
							}
							
						}//end foreach $_POST loop 
								
					
					$db = null;
				}//end if submit was pressed
			 ######### END SUBMISSION HANDLING FOR COMPLETED FORMS ##########
	?>
	<?  } #end if logged in == true
		} #end if logged in insset ?> 
	</div>
                                
<div>
    <p>
     <?
			
			?>
  </p>
</div>
  </body>
  </html>		