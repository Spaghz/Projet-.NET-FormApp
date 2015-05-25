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

	try
	{
		MySQLManager::getInstance()->eraseDataBase();	

		$expectedTriangle 	= CORShape::getInstance()->createShape('{"T1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8}},"globalData":{"Id":-1,"Type":1,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');		
		var_dump(CORShape::getInstance()->pushShape($expectedTriangle));
		var_dump(CORShape::getInstance()->pullShape($expectedTriangle->getId()));


		$expectedRectangle 	= CORShape::getInstance()->createShape('{"R1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8},"P4":{"X":3,"Y":6}},"globalData":{"Id":-1,"Type":3,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		var_dump(CORShape::getInstance()->pushShape($expectedRectangle));
		var_dump(CORShape::getInstance()->pullShape($expectedRectangle->getId()));	

		$expectedSegment	= CORShape::getInstance()->createShape('{"S1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1}},"globalData":{"Id":-1,"Type":2,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		var_dump(CORShape::getInstance()->pushShape($expectedSegment));
		var_dump(CORShape::getInstance()->pullShape($expectedSegment->getId()));			

		$expectedCircle 	= CORShape::getInstance()->createShape('{"C1":{"specificData":{"Center":{"X":0.6,"Y":41},"DistantEdgePoint":{"X":2.6,"Y":41},"Radius":2},"globalData":{"Id":-1,"Type":6,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		var_dump(CORShape::getInstance()->pushShape($expectedCircle));
		var_dump(CORShape::getInstance()->pullShape($expectedCircle->getId()));	
		
	
		$expectedPolygon 	= CORShape::getInstance()->createShape('{"P1":{"specificData":{"P1":{"X":0.6,"Y":41},"P2":{"X":1,"Y":1},"P3":{"X":5.6,"Y":-8},"P4":{"X":3,"Y":6},"P5":{"X":45,"Y":21}},"globalData":{"Id":-1,"Type":4,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		var_dump(CORShape::getInstance()->pushShape($expectedPolygon));
		var_dump(CORShape::getInstance()->pullShape($expectedPolygon->getId()));	
		
		$expectedGroup 		= CORShape::getInstance()->createShape('{"G1":{"groupData":{"C1":{"specificData":{"Center":{"X":0.6,"Y":41},"DistantEdgePoint":{"X":2.6,"Y":41},"Radius":2},"globalData":{"Id":-1,"Type":6,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}},"globalData":{"Id":-1,"Type":5,"BackgroundColor":16777215,"EdgeColor":0,"Parent":null,"EdgeSize":1}}}');
		var_dump(CORShape::getInstance()->pushShape($expectedGroup));
		var_dump(CORShape::getInstance()->pullShape($expectedGroup->getId()));

		/*
		$group 				= Group::createGroup("G1",NULL,1,2,3);
		$group->addShape($expectedTriangle);

		var_dump($group);
		//var_dump(CORShape::getInstance()->pullShape(1));
		var_dump(CORShape::getInstance()->pushShape($group));
		*/
	
		$p1 = new Point(4,5);
		$p2 = new Point(6.4,7,8);
		$p3 = new Point(7.9,5.3);
		$triangle = Triangle::createTriangle('T1',NULL,1,1,1,$p1,$p2,$p3);
		//var_dump($triangle);
//		var_dump(CORShape::getInstance()->pushShape($triangle));
		

		//exit(0);
		/*
		var_dump($expectedTriangle);
		var_dump($expectedRectangle);
		var_dump($expectedPolygon);
		var_dump($expectedCircle);
		*/
		echo("<br/>----- RESULT ----- <br/>");

		
		
		//var_dump(DAOTriangleMySQL::getInstance()->push($expectedTriangle));
		//var_dump(DAOCircleMySQL::getInstance()->push($expectedCircle));
		//var_dump(DAORectangleMySQL::getInstance()->push($expectedRectangle));
	}
	catch (Exception $e)
	{
		echo($e->getMessage());
	}	

	connect();
?>