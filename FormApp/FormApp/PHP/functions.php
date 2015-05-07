<?php
	// Configuration files
	require_once("./config/auth.php");

	function connect()
	{
		return new PDO('mysql:host='.$GLOBALS['authInfo']['connections']['mysql']['host'].';dbname='.$GLOBALS['authInfo']['connections']['mysql']['database'],
			$GLOBALS['authInfo']['connections']['mysql']['username'],
			$GLOBALS['authInfo']['connections']['mysql']['password']);
	}

	function save($jsonFormBytes)
	{
		// Database connection
		$PDO_Handler = connect();

		// Decoding byte array
		return $jsonFormBytes;
	}
?>