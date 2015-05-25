<?php
	class LinkCircle extends HandlerShapesLink
	{
		public function __construct(&$successor=NULL)
		{
			parent::__construct(Circle::$type,$successor);
		}

		/*
		______          _     
		| ___ \        | |    
		| |_/ /   _ ___| |__  
		|  __/ | | / __| '_ \ 
		| |  | |_| \__ \ | | |
		\_|   \__,_|___/_| |_|
		                                         
		 */
		
		public function pushShape1(&$shape)
		{
			return DAOCircleMySQL::getInstance()->push($shape);
		}

		/*
		______      _ _ 
		| ___ \    | | |
		| |_/ /   _| | |
		|  __/ | | | | |
		| |  | |_| | | |
		\_|   \__,_|_|_|
		                                
		 */

		public function pullShape2($pullShapeResponse)
		{
			$points = DAOPointMySQL::getInstance()->pullPoints($pullShapeResponse['id']);
			$circle =  Circle::createCircle(
					$pullShapeResponse['name'],
					NULL,
					$pullShapeResponse['edgeSize'],
					$pullShapeResponse['bgColor'],
					$pullShapeResponse['edgeColor'],
					$points[0],
					$points[1],
					$points[0]->getDistance($points[1])
			);
			$circle->setId($pullShapeResponse['id']);
			return $circle;
		}

		/*
		 _____                _       
		/  __ \              | |      
		| /  \/_ __ ___  __ _| |_ ___ 
		| |   | '__/ _ \/ _` | __/ _ \
		| \__/\ | |  __/ (_| | ||  __/
		 \____/_|  \___|\__,_|\__\___|
		                              
		 */
		

		public function createShape2($information)
		{
    		$points = array();

    		if (count($information['specificData'])!=3)
    			throw new Exception("Error while creating shape from json : Circle must have 2 points (Center & random edge point)! Number of parameters given : ".count($information['specificData']));

			return Circle::createCircle(
					$information['name'],
					NULL,
					$information['globalData']['EdgeSize'],
					$information['globalData']['BackgroundColor'],
					$information['globalData']['EdgeColor'],
					new Point($information['specificData']['Center']['X'],$information['specificData']['Center']['Y']),
					new Point($information['specificData']['DistantEdgePoint']['X'],$information['specificData']['DistantEdgePoint']['Y']),
					$information['specificData']['Radius']
			);
		}
	}

?>