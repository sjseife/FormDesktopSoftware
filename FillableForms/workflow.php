<?
session_start();

#supress errors to user
error_reporting(E_ERROR | E_PARSE | E_CORE_ERROR);
date_default_timezone_set("America/New_York");
#echo $_SESSION['form_element_ids'];
#echo "<br> POST:";
#print_r($_POST);
#print_r($_SESSION);
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<title>Workflow Authorization</title>
	
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
                    <li><a href="workflow.php">Workflow Management</a></li>
								</ul>
	
					 <form method="post" action="login.php" style="position: absolute; top: 0%; right: 0%; width:5%;">
						<input type="submit" class="btn btn-default" name="logoutSubmit" value="Log out" />
					</form>
		</div>
				 <div>
				
					<img width="100%" src="http://i.imgur.com/aXIOIvo.jpg">	
  </div>
		
		<? 
		##################AUTHORIZE FORM ON AUTHORIZE BUTTON CLICK #################################
			 
			 if(isset($_POST['Authorize']))
			 {
				 try
				 {
					 	$filled_form_id = $_POST['filled_form_id'];
				 		$workflow_id = $_POST['workflow_id'];
					 $form_id = $_POST['form_id'];
					 					            #Create PDO statement and prepare database connection
            $user="schaum";
            $password="12345";
            $dbname="schaum";
    
            $db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
                if (!$db) {
                    die('Could not connect: Please try again later. ');
    
                }
								


								$db = new PDO("mysql:host=localhost;dbname=$dbname", "$user", "$password");
										if (!$db) {
												die('Could not connect: Please try again later. ');

										}
								
								# get all 
								$query = "UPDATE workflow_user_form
														SET fulfilled = 1
														WHERE filled_form_id = $filled_form_id
														AND workflow_id = $workflow_id;";
								$statement = $db->prepare($query);
								$statement->execute(array());
					 			$query = "call schaum.isFormAuthorized($filled_form_id);";
								$statement2 = $db->prepare($query);
								$statement2->execute(array());
								
					 
				 }
				 catch(Exception $e)
				 {
					 
				 }
				 
				 
				 
			 }
		?>
		
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
								$user_idA = $_POST['user_id'];
								# get all 
								$query = "SELECT element_text, response_text, element_type, form_name FROM schaum.form_response
															JOIN user_forms USING(filled_form_id)
															JOIN form_template USING(form_id)
															JOIN form_element USING(form_element_id)
															WHERE form_element.form_id = '$form_id'
															AND user_id = $user_idA
															ORDER BY form_element.form_element_id ;";
								$statement2 = $db->prepare($query);
								$statement2->execute(array());

								
#############################################################################################################################
#		Dynamically build table to show forms that require this user's authorization with while loop, Loops until no rows remain.														#
#############################################################################################################################
                
								?>
									<div class="well well-sm">
										
					
									<table  class="table">
								<?
									$filled_form_id = $_POST['filled_form_id'];
				 					$workflow_id = $_POST['workflow_id'];
									$form_id = $_POST['form_id'];
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
									<input type="hidden" id="form_id" name="form_id" value ="<?= $form_id?>" />
									<input type="hidden" id="filled_form_id" name="filled_form_id" value ="<?= $filled_form_id?>" />
									<input type="hidden" id="workflow_id" name="workflow_id" value ="<?= $workflow_id ?>" />
                  <input type="submit" class="btn btn-default" class="btn btn-default" name="Authorize" value="Authorize">
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
       
      ###############END OPEN SELECTED FORM #################################
		
			
  	  #DISPLAY UNAUTHORIZED FORMS
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
								  
                $user_title = $_SESSION['user_title'];
    					 $user_id = $_SESSION['user_id'];
                # query set - Select all indicated fields if records match search string
 
                   $query = "SELECT DISTINCT form_name, form_template.form_id, user_id, username, filled_form_id, workflow_id FROM form_element
                      JOIN form_response USING(form_element_id)
                      JOIN form_template USING(form_id)
                      JOIN user_forms USING(filled_form_id)
                      JOIN workflow_user_form USING(filled_form_id)
                      JOIN workflow USING(workflow_id)
                      JOIN user_accounts USING(user_id)
                      WHERE workflow.user_title = '$user_title'
                      AND authorization_complete = 0
                      AND incomplete = 0
                      AND fulfilled = 0
                      AND user_id <> '$user_id';";
                                  #prepare the query
                $statement = $db->prepare($query);
    
                # pass data to an array
                $statement->execute(array());
                
								?>
								<div class="table-responsive">          
  							<table class="table table-hover">
                <tr>
									<th style="text-align: center" colspan="2">
										<h2>
											Forms that require authorization
										</h2>
									</th>
                </tr>
									<tr>
									<th>
                      <h4>
                        Form Name
                      </h4>
										</th>
                    <th>
                      Username
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
                              <?= $row['username'] ?>
                          </td>
													<td>
                            <p>
																	<form method="POST" action="<?= $_SERVER['PHP_SELF']?>">
																		<input type="hidden" id="form_id" name="form_id" value ="<?= $row['form_id'] ?>" />
																		<input type="hidden" id="filled_form_id" name="filled_form_id" value ="<?= $row['filled_form_id'] ?>" />
																		<input type="hidden" id="workflow_id" name="workflow_id" value ="<?= $row['workflow_id'] ?>" />
                                    <input type="hidden" id="user_id" name="user_id" value ="<?= $row['user_id'] ?>" />
																		<button type='submit' class="btn btn-default" name='OpenForm' value='<?= $row['form_id'] ?>'>Open</button>   
																	</form>
														</p>
												</td>
											
                        
                    </tr>          
                    <?
                }//end population of table while loop
                  $db = null;
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
                                

  </body>
  </html>		