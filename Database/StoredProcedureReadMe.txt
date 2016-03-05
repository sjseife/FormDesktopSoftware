 _____  _____  _____ ______  _____ ______  ______ ______  _____  _____  _____ ______  _   _ ______  _____  _____  
/  ___||_   _||  _  || ___ \|  ___||  _  \ | ___ \| ___ \|  _  |/  __ \|  ___||  _  \| | | || ___ \|  ___|/  ___| 
\ `--.   | |  | | | || |_/ /| |__  | | | | | |_/ /| |_/ /| | | || /  \/| |__  | | | || | | || |_/ /| |__  \ `--.  
 `--. \  | |  | | | ||    / |  __| | | | | |  __/ |    / | | | || |    |  __| | | | || | | ||    / |  __|  `--. \ 
/\__/ /  | |  \ \_/ /| |\ \ | |___ | |/ /  | |    | |\ \ \ \_/ /| \__/\| |___ | |/ / | |_| || |\ \ | |___ /\__/ / 
\____/   \_/   \___/ \_| \_|\____/ |___/   \_|    \_| \_| \___/  \____/\____/ |___/   \___/ \_| \_|\____/ \____/  
                                                                                                                  
###########################################################################################################################
NAME : UnauthorizedFormsByUsername

Purpose : Returns the filled_form_id (primary key of user_forms table) of all forms that currently require the  authorization of the user associated with the USERNAME supplied.

Call command: call schaum.UnauthorizedFormsByUsername('<USERNAME>');

Example : I want to see all forms that require user: Jessica1984's authorization, but have not yet been authorized.
	call schaum.UnauthorizedFormsByUsername('Jessica1984'); would replace your normal select statement.

What is returned can be handled the same as if you were to query a table with a single column and multiple rows.

###########################################################################################################################       Name: WorkflowAssignment
NAME: WorkflowAssignment

Purpose: Automatically creates the individual relations between user_forms entry and Workflow entries.There is no need
to enter a parameter, but the query MUST be run imediately after the insert statement for user_forms table.

Call command : call schaum.WorkflowAssignment();

Proper use: Run this as you would a select statment after any INSERT statement that creates a new entry into user_forms table.
THIS IS NOT OPTIONAL!!!!!! Failure to run this command after every insert of user_forms table will result in an inability to 
link a workflow to a user form and thus failure of our system.

###########################################################################################################################

NAME: isFormAuthorized

Purpose: Pass in a filled_form_id and the method will then check each workflow for completion. If all workflows have been
completed, the authorization_complete field of user_forms table will be set to true ( this field is by default false).
This procedure also returns all rows from the workflow_user_form table that are associated with the filled_form_id 
The includes: workflow_id (primary key of workflow table), filled_form_id(primary key of user_forms) and 
fulfilled( true or false indicating if that workflow has been authorized for the specific user form).
You can determine completeness of the form by either parsing results passed back by query, or running a select on
the user_forms entry associated with the filled_form_id that was passed into the method.

Call Command: call schaum.isFormAuthorized(<filled_form_id>);  

Proper use: run this command when you want to A) update the authorization status of a user_form entry, or B) when you would like to access all workflow_user_form table entries associated with a filled_form_id.

###########################################################################################################################                                                