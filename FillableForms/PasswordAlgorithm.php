<?

          # connect to mysql database
            $db = new PDO("mysql:host=localhost;dbname=schaum", "schaum", "12345");
            if (!$db) {
                die('Could not connect: Please try again later. ');

            }
            
                        $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            
            # Set variables for use in query
            //$username = clean($_POST['username'], 12);
            
          
            

            # query set, retrieve salt for specific member that is trying to login. Salt is stored in database
           
			$query = "SELECT `salt` FROM `user_accounts` WHERE username = 'schaum';";
            #prepare the query
            $statement = $db->prepare($query);

            # pass data to an array
            $statement->execute(array());
            $db = null;
            while($row = $statement->fetch(PDO::FETCH_BOTH))
            {
                $salt = $row[0];
				
            }
           
            #HASHING ALGORITHM
            if(isset($salt))
            {
			
                $pepper="5hQB6y3uLRmA";#pepper stored serverside in code
                $count=0;
                #hash password with salt and pepper
								$pw = 'pass1!';
                $pw = hash('sha512', $salt . $pw . $pepper);
				
                #Hash is itterated 100,000 times. This is done to drastically reduce the speed at which a brute force attack can be done.
              
                while($count < 100000)
                    {
                        $pw = hash('sha512', $salt . $pw . $pepper);
                        $count++;    
                    }
						}
					echo "TEST TEST TEST";
echo "<br>";
echo $pw;

echo "<br>";
echo $salt . "password" . $pepper;
if($pw == 'd0ebb0575514614d9d4751e9e0d80ed5341c55da391a0a37e10679ff4c3038506d0c55c0ce9c8426dccc35c52c4c545bedfd87fac0868a2c4031aa6356139f23')
{
	echo '<br>';
	echo 'true';
		
}
else
{
	echo "<br>";
	echo 'False';
}
				
				 # connect to mysql database
          /*  $db = new PDO("mysql:host=localhost;dbname=schaum", "schaum", "12345");
            if (!$db) {
                die('Could not connect: Please try again later. ');

            }
            
            $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            
          
          # query set, get username and admin status from DB if username and pw match relevant fields in DB
            
			$query = "SELECT `username` FROM `login` WHERE `username` = '$username' AND `password` = '$pw';";

            #prepare the query
            $statement = $db->prepare($query);

            # Execute the query
            $statement->execute(array());
            $db = null;
            while($row=$statement->fetch(PDO::FETCH_BOTH))
            {   
                if($statement->rowCount($row) == 1)#only allow variables to be set if a single row was returned.
                {
                    
                    $username_returned_from_query = $row[0];
                    
                }
                
               
                
            }
                if(isset($username_returned_from_query)&& count($row) == 1)#if $username_returned_from_query was set and row count == 1
                {
                    if($username_returned_from_query == $username )# is $username_returned_from_query matches username given by user(for this to be true $pw must have also matched)
                        {
                             $_SESSION['logged_in'] = true;
							
                             
                               
                        }
                        
                     */
                


              ?>