<?php
	require_once('./functions.php');
	require_once('./utils/Point.php');
	require_once('./shapes/Shape.php');
	require_once('./shapes/ShapeSimple.php');
	require_once('./shapes/Polygon.php');
	require_once('./shapes/Circle.php');
	require_once('./shapes/Rectangle.php');
	require_once('./shapes/Segment.php');
	require_once('./shapes/Triangle.php');
	require_once('./shapes/Group.php');

	require_once('./shapes/COR/CORShape.php');
	require_once('./shapes/COR/HandlerShapes.php');
	require_once('./shapes/COR/HandlerShapesLink.php');
	require_once('./shapes/COR/LinkTriangle.php');
	require_once('./shapes/COR/LinkRectangle.php');
	require_once('./shapes/COR/LinkCircle.php');	
	require_once('./shapes/COR/LinkSegment.php');
	require_once('./shapes/COR/LinkPolygon.php');
	require_once('./shapes/COR/LinkGroup.php');

	require_once('./shapes/DAO/MySQLManager.php');
	require_once('./shapes/DAO/iDAOShape.php');
	require_once('./shapes/DAO/iDAOPoint.php');
	require_once('./shapes/DAO/iDAOTriangle.php');
	require_once('./shapes/DAO/iDAOOwnPoint.php');
	require_once('./shapes/DAO/iDAOOwnShape.php');
	require_once('./shapes/DAO/iDAOCircle.php');
	require_once('./shapes/DAO/iDAOGroup.php');
	require_once('./shapes/DAO/iDAOPolygon.php');
	require_once('./shapes/DAO/iDAORectangle.php');
	require_once('./shapes/DAO/iDAOSegment.php');
	require_once('./shapes/DAO/DAOMySQL/DAOShapeMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOPointMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOOwnPointMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOOwnShapeMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOTriangleMYSQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOSegmentMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOCircleMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOPolygonMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAORectangleMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOGroupMySQL.php');
	header('Content-Type: text/html; charset=utf-8');

	$shape;

	// Module can be :
	// - push (uploading a shape to the database)
	// - pull (downloading a shape from the database)
	$module = filter_input(INPUT_GET,
		'module',
		FILTER_VALIDATE_REGEXP,
		array('options'=>array('regexp'=>"#(^push$)|(^pull$)#"))
		);

	try
	{
		if ($module==false)
			throw new Exception("specify a 'module' in the address of the webservice (either 'push' or 'pull') through GET parameters<br/>Exemple : http://address.php?module=push");

		if ($module=='push')
		{
			if ( $_SERVER['REQUEST_METHOD'] === 'POST' )
			{
				// Check if the webservice received any POST data from the application
				// If not : throw an exception
			    $postData = file_get_contents('php://input');  
			    if (strlen($postData)==0)
			    	throw new Exception("the webservice retrieved an empty string in POST arguments, no data transmitted to the webservice.");

			    $shape = CORShape::getInstance()->createShape($postData);

			    if ($shape==NULL)
			    	throw new Exception("invalid shape data : the webservice could not create a shape with such json.");

			    $shape = CORShape::getInstance()->pushShape($shape);

			    if ($shape==NULL)
			    	throw new Exception("an error occured while pushing shape into database.");
			
			    echo($shape->getId());
			}				
		}

		if ($module=='pull')
		{
			$shapeId = filter_input(INPUT_GET,'id',FILTER_VALIDATE_INT);

			if ($shapeId==FALSE)
				throw new Exception("invalid id while pulling shape.");

			$shape = CORShape::getInstance()->pullShape($shapeId);

			if ($shape==NULL)
				throw new Exception("no matching shape was found with such id : ".$shapeId);

			echo($shape->serialize());
		}

	}
	catch (Exception $e)
	{
		echo("Error : ".$e->getMessage());
	}

	
?>