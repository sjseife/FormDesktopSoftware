<?
session_start();
#supress errors to user
error_reporting(E_ERROR | E_PARSE | E_CORE_ERROR);
date_default_timezone_set("America/New_York");
#echo $_SESSION['form_element_ids'];
#echo "<br> POST:";
#print_r($_POST);
#print_r($_SESSION);
#Blake can you see this ?
#Yes
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<title>My Forms</title>
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
 	?>							<nav class="navbar navbar-default">
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
						<input type="submit" class="btn btn-default" name="logoutSubmit" value="Log out" />
					</form>
				 <div>
					 			<!--		<div style="position: absolute; top: 0%; right: 0%; width:5%;">
					<form method="post" action="login.php">
						<input type="submit"  name="logoutSubmit" value="Log out" />
					</form>
				</div> -->
					<img width="100%" src="http://i.imgur.com/aXIOIvo.jpg">	
  
		
		
		
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


								$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
										if (!$db) {
												die('Could not connect: Please try again later. ');

										}
								$user_id = $_SESSION['user_id'];
								# get all 
								$query = "SELECT element_text, response_text, element_type, form_name FROM schaum.form_response
															JOIN user_forms USING(filled_form_id)
															JOIN form_template USING(form_id)
															JOIN form_element USING(form_element_id)
															WHERE form_element.form_id = '$form_id'
															AND user_id = $user_id
															ORDER BY form_element.form_element_id ;";
								$statement2 = $db->prepare($query);
								$statement2->execute(array());
								
								
#############################################################################################################################
#		Dynamically build table to show COMPLETED forms with while loop, Loops until no rows remain.														#
#############################################################################################################################
                
								?>
									<div class="well well-sm">
										
					
									<table  class="table">
								<?
								while($row = $statement2->fetch(PDO::FETCH_ASSOC))
                {
									if(!(isset($form_name)))
									{
										$form_name = $row['form_name'];
										?>
										<tr>
											
											
											<th text-align="right" colspan="2">
												<h1>
													<?=$form_name ?>
												</h1>
											</th>
										
										</tr>
										<?
									}
									if($row['element_type'] != "text" || $row['element_type'] != "password")
									{
										$explodedArray = explode(',',$row['element_text']);
										$element_title = $explodedArray[0];
									}
									else
									{
										$element_title = $row{'element_text'};
									}
									
									
									
									?>
										<tr>
										
											
											<th width="15%" text-align="right">
												<?= $element_title?>
											</th>
											<td>
												<?=$row['response_text'] ?>
											</td>
											
										</tr>
									<?
								
								}#end form builder loop
							?>
						<tr>
							
							<th text-align="right">
								<form action="<?=$_SERVER['PHP_SELF'] ?>" method="post">
									<input type="submit" class="btn btn-default" class="btn btn-default" name="noaction" value="Close">
								</form>
							</th>
							<th></th>
						
						</tr>
						</table>
					</div>
					<?
					
					 
				}
				catch(Exception $e)
				{
					echo "Danger Will Robinson, Danger!!!";
				}
			}							
		
			 ################################################################
			 # 					SUBMISSION HANDLING FOR COMPLETED FORMS							#
			 # make entry into user_forms table for new form								#
			 # call stored procedure to map workflow for new form						#
			 # write all responses to form elements to form_response table	#
			 ################################################################
				if(isset($_POST['submit']) || isset($_POST['submit2']))
				{
						
					
						#Delete any past entry of the same form
						#This is used when a partially filled form from Saved forms page
						# is submitted as completed.
						if(isset($_POST['submit2']))
						{
						
								$user="schaum";
								$password="12345";
								$dbname="schaum";

								$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
										if (!$db) {
												die('Could not connect: Please try again later. ');
    
                }
								$filled_form_id = $_SESSION['filled_form_id'];
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
  	  #DISPLAY COMPLETED FORMS
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
                $query = "SELECT form_name, form_id from form_template
														JOIN user_forms USING(form_id)
														WHERE user_id = '$user_id'
														AND incomplete = 0;";
    
                #prepare the query
                $statement = $db->prepare($query);
    
                # pass data to an array
                $statement->execute(array());
                $db = null;
								?>
								<div class="table-responsive">          
  							<table class="table table-hover">
                <tr>
									<th text-align="center" colspan="2">
										<h2>
											Completed Forms
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

								}?>
					</table><!-- Close data table -->
				</div>			
			<?
		
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