<?php
	// Useful includes
	require_once "lib/nusoap.php";
 	require_once "functions.php";

 /*
function getProd($category) {
    if ($category == "books") {
        return join(",", array(
            "The WordPress Anthology",
            "PHP Master: Write Cutting Edge Code",
            "Build Your Own Website the Right Way"));
    }
    else {
            return "No products listed under that category";
    }
}
*/
 	// Server instanciation
	$server = new soap_server();

	// Functions registration
	$server->register("save");

	//$server->register("getProd");
	$server->service($HTTP_RAW_POST_DATA);
?>