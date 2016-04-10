<?php
/**
 * @author Joseph Schaum
 * Creates a log with IP address,time stamp, file accessed, and client info of any logins
 */
date_default_timezone_set('UTC');

$document = new DOMDocument;

$rootElement = $document -> createElement("fileaccesses");
$document -> appendChild($rootElement);

$timeStamp = $document -> createElement("dateaccessed",date("F j, y, H:i:s A"));
$rootElement -> appendChild($timeStamp);

$fileaccessed = $document -> createElement("fileaccessed", $_SERVER['PHP_SELF']);
$rootElement -> appendChild($fileaccessed);

$client = $document -> createElement("client");
$rootElement -> appendChild($client);

$clientaddress = $document -> createElement("clientaddress",$_SERVER['REMOTE_ADDR'] );
$client -> appendChild($clientaddress);

$browser = $document -> createElement("browser",$_SERVER['HTTP_USER_AGENT']);
$client -> appendChild($browser);


$filename= uniqid();

$document->save("MemberHistory/$filename.xml");
	

?>
