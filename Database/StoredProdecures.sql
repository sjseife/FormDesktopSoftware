DELIMITER $$
CREATE DEFINER=`schaum`@`%` PROCEDURE `isFormAuthorized`(IN filledFormID INT(11))
BEGIN
DECLARE done INT DEFAULT FALSE;
DECLARE complete boolean;
DECLARE ffID INT(11);
DECLARE wfID INT(11);
DECLARE fulfilled1 TINYINT(1);
DECLARE authorizationCheck_Cursor CURSOR FOR
SELECT  workflow_user_form.filled_form_id, workflow_id, fulfilled FROM schaum.workflow_user_form
		 INNER JOIN user_forms ON schaum.workflow_user_form.filled_form_id = schaum.user_forms.filled_form_id
         WHERE workflow_user_form.filled_form_id = filledFormID;

#declare handler
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

CREATE TABLE IF NOT EXISTS tempTableForisFormAuthorized (filled_form_id INT(11), workflow_id INT(11), fulfilled TINYINT(1));
SET complete = true;
OPEN authorizationCheck_Cursor;
check_auth: LOOP


		FETCH authorizationCheck_Cursor INTO ffID, wfID, fulfilled1;
		IF done THEN
			LEAVE check_auth;
		END IF;
        INSERT INTO tempTableForisFormAuthorized (filled_form_id, workflow_id, fulfilled)
			VALUES(ffID, wfID, fulfilled1);
		
	
	IF fulfilled1 = 0 OR fulfilled1 IS NULL THEN
		set complete = false;
	END IF;
END LOOP check_auth;

IF complete = true THEN
	UPDATE user_forms
		SET authorization_complete = 1
        WHERE filled_form_id = filledFormID;
END IF;
SELECT * FROM tempTableForisFormAuthorized;
CLOSE authorizationCheck_Cursor;

DROP TABLE tempTableForisFormAuthorized;
END$$
DELIMITER ;







DELIMITER $$
CREATE DEFINER=`schaum`@`%` PROCEDURE `UnauthorizedFormsByUsername`(IN UN VARCHAR(20) )
BEGIN
#username passed into process
declare uName VARCHAR(20);
#pk of user accounts table
declare userID INT(11);
#stores user_title from table user_accounts
declare uTitle VARCHAR(45);
#Stores filled_form_id from table: user_forms
declare filledFormID VARCHAR(11);
#creates a variable to store cursor handler
DECLARE done INT DEFAULT FALSE;
#create cursor to retrieve filled_form_id that are relevant to the username passed in
DECLARE getFilledFormId_Cursor CURSOR FOR 
SELECT DISTINCT
    schaum.user_forms.filled_form_id
FROM
    schaum.user_forms
        JOIN
    schaum.workflow_user_form ON (user_forms.filled_form_id)
        JOIN
    schaum.workflow ON (user_forms.filled_form_id)
WHERE
    schaum.workflow.user_title = uTitle
        AND workflow_user_form.fulfilled = 0 #where fulfilled = false
        AND workflow.form_id = user_forms.form_id
										;
#declare handler
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
#create table to store ids returned by cursor for a short time untill passed back
CREATE TABLE IF NOT EXISTS idsForUnauthorizedFormsByUserUsername (id INT(11));
#set uName = to passed in username
set uName = UN;
#find user title based on username
set uTitle = (select schaum.user_accounts.user_title from schaum.user_accounts where schaum.user_accounts.username = uName );
#find user_id based on username
set userID = (select schaum.user_accounts.user_id from schaum.user_accounts where schaum.user_accounts.username = uName );

#open cursor
OPEN getFilledFormId_Cursor;
#create loop to get filled form ids
get_ffIDs:  LOOP
#insert results of cursor into a variable
FETCH getFilledFormId_Cursor INTO filledFormID ;
	#if cursor is finished with rows, leave loop
    IF done THEN
      LEAVE get_ffIDs;
	ELSE #else, insert the returned ID from cursor into the table
		INSERT INTO idsForUnauthorizedFormsByUserUsername(id) VALUES(filledFormID);
    END IF;


END LOOP get_ffIDs;
#close cursor
CLOSE getFilledFormId_Cursor;
#return contents of table holding filled_form_ids
SELECT * FROM idsForUnauthorizedFormsByUserUsername;
#delete table created for this procedure
DROP TABLE idsForUnauthorizedFormsByUserUsername;
END$$
DELIMITER ;







DELIMITER $$
CREATE DEFINER=`schaum`@`%` PROCEDURE `WorkflowAssignment`()
BEGIN
declare FilledFormId INT(11);
#variable to store PK of form
DECLARE formId INT(11);
#variable to hold PK of workflow
DECLARE workflowId INT(11);
#cursor to select workflow ids
DECLARE getWorkflows_cursor CURSOR FOR 
select workflow_id from schaum.workflow where form_id = formId;
#set formID = to the FK form_id in user_forms table where filled_forms_id is equal to parameter FilledFormId
SET formId = (SELECT user_forms.form_id FROM schaum.user_forms WHERE user_forms.filled_form_id = FilledFormId); 
SET FilledFormId = (SELECT filled_form_id from user_accounts WHERE filled_form_id = (select max(filled_form_id) from user_accounts));
 
#initialize cursor
OPEN getWorkflows_cursor;
#create loop
get_flows:  LOOP
#call cursor to get workflow ID and store it into workflowID
FETCH getWorkflows_cursor INTO workflowId;
#insert statement for workflow_user_form
INSERT INTO schaum.workflow_user_form(`filled_form_id`, `workflow_id`, `fulfilled`)
VALUES(FilledFormId, workflowId, 0);
#end loop
END LOOP get_flows;
#close cursor
CLOSE getWorkflows_cursor;

 
#end stored procedure
END$$
DELIMITER ;
