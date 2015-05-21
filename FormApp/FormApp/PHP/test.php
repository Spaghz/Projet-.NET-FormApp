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

	require_once('./shapes/COR/HandlerShapes.php');
	require_once('./shapes/COR/HandlerShapesLink.php');
	require_once('./shapes/COR/LinkTriangle.php');
	require_once('./shapes/COR/LinkRectangle.php');
	require_once('./shapes/COR/LinkPolygon.php');
	require_once('./shapes/COR/LinkSegment.php');
	require_once('./shapes/COR/LinkCircle.php');
	require_once('./shapes/COR/LinkGroup.php');
	require_once('./shapes/COR/CORShape.php');

	require_once('./shapes/DAO/MySQLManager.php');
	require_once('./shapes/DAO/iDAOShape.php');
	require_once('./shapes/DAO/iDAOPoint.php');
	require_once('./shapes/DAO/iDAOTriangle.php');
	require_once('./shapes/DAO/iDAOOwnPoint.php');
	require_once('./shapes/DAO/DAOMySQL/DAOShapeMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOPointMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOOwnPointMySQL.php');
	require_once('./shapes/DAO/DAOMySQL/DAOTriangleMYSQL.php');
/*
	$handler = new LinkTriangle();
	$handler->setSuccessor(new LinkRectangle());
	$handler->save('{"T1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8}},"globalData":{"Type":4,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');

	try
	{
		$shape = new Shape('{"T1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8}},"globalData":{"id":-1,"Type":4,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
	}
	catch (Exception $e)
	{
		echo($e->getMessage());
	}
*/
	try
	{
		
		$expectedTriangle 	= CORShape::getInstance()->createShape('{"T1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8}},"globalData":{"Id":-1,"Type":1,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		$expectedRectangle 	= CORShape::getInstance()->createShape('{"R1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8},"P4":{"X":3,"Y":6}},"globalData":{"Id":-1,"Type":3,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		$expectedPolygon 	= CORShape::getInstance()->createShape('{"P1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8},"P4":{"X":3,"Y":6},"P5":{"X":45,"Y":21}},"globalData":{"Id":-1,"Type":4,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		$expectedCircle 	= CORShape::getInstance()->createShape('{"C1":{"specificData":{"Center":{"X":0.6,"Y":41},"DistantEdgePoint":{"X":2.6,"Y":41},"Radius":2},"globalData":{"Id":-1,"Type":6,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		$expectedGroup 		= CORShape::getInstance()->createShape('{"G2":{"groupData":{"G1":{"groupData":{"C1":{"specificData":{"Center":{"X":0.6,"Y":41},"DistantEdgePoint":{"X":2.6,"Y":41},"Radius":2},"globalData":{"Id":-1,"Type":6,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}},"globalData":{"Id":-1,"Type":5,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}},"T1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8}},"globalData":{"Id":-1,"Type":1,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}},"globalData":{"Id":-1,"Type":5,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		/*
		var_dump($expectedTriangle);
		var_dump($expectedRectangle);
		var_dump($expectedPolygon);
		var_dump($expectedCircle);
		*/
		echo("<br/>----- RESULT ----- <br/>");
		var_dump($expectedGroup);

		MySQLManager::getInstance()->eraseDataBase();
		DAOTriangleMySQL::getInstance()->push($expectedTriangle);


	}
	catch (Exception $e)
	{
		echo($e->getMessage());
	}	

	connect();
?>