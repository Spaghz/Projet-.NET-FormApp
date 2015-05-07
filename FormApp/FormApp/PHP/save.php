<?php
	require_once('./functions.php');

	if ( $_SERVER['REQUEST_METHOD'] === 'POST' )
	{
	    $postData = file_get_contents('php://input');
	    
	    var_dump(json_decode($postData));
	}

?>