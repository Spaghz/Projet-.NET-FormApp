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
		$linkTriangle 	= new LinkTriangle();
		$linkRectangle 	= new LinkRectangle();
		$linkPolygon 	= new LinkPolygon();
		$linkSegment 	= new LinkSegment();
		$linkCircle 	= new LinkCircle();

		$linkSegment->setSuccessor($linkCircle);
		$linkPolygon->setSuccessor($linkSegment);
		$linkRectangle->setSuccessor($linkPolygon);
		$linkTriangle->setSuccessor($linkRectangle);
		$handler = $linkTriangle;

		var_dump($handler);

		$expectedTriangle = $handler->createShape('{"T1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8}},"globalData":{"Id":-1,"Type":1,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		$expectedRectangle = $handler->createShape('{"R1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8},"P4":{"X":3,"Y":6}},"globalData":{"Id":-1,"Type":3,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		$expectedPolygon = $handler->createShape('{"P1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8},"P4":{"X":3,"Y":6},"P5":{"X":45,"Y":21}},"globalData":{"Id":-1,"Type":4,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		$expectedCircle = $handler->createShape('{"C1":{"specificData":{"Center":{"X":0.6,"Y":41},"DistantEdgePoint":{"X":2.6,"Y":41},"Radius":2},"globalData":{"Id":-1,"Type":6,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		var_dump($expectedTriangle);
		var_dump($expectedRectangle);
		var_dump($expectedPolygon);
		var_dump($expectedCircle);

	}
	catch (Exception $e)
	{
		echo($e->getMessage());
	}	

	connect();
?>