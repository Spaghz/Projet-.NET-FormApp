<?php
	class LinkRectangle extends HandlerShapesLink
	{
		public function __construct(&$successor=NULL)
		{
			parent::__construct(Rectangle::$type,$successor);
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
			return DAORectangleMySQL::getInstance()->push($shape);
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
			$rectangle =  Rectangle::createRectangle(
					$pullShapeResponse['name'],
					NULL,
					$pullShapeResponse['edgeSize'],
					$pullShapeResponse['bgColor'],
					$pullShapeResponse['edgeColor'],
					$points[0],
					$points[1],
					$points[2],
					$points[3]
			);
			$rectangle->setId($pullShapeResponse['id']);
			return $rectangle;
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

    		if (count($information['specificData'])!=4)
    			throw new Exception("Error while creating shape from json : Rectangle must have 4 points! Number of parameters given : ".count($information['specificData']));

    		foreach($information['specificData'] as $value)
    		{
    			if (count($value)!=2)
    				throw new Exeption("Invalid point array in LinkRectangle : must contain two values 'X' and 'Y'");
    			array_push($points,new Point(array_shift($value),array_shift($value)));
    		}		

			return Rectangle::createRectangle(
					$information['name'],
					NULL,
					$information['globalData']['EdgeSize'],
					$information['globalData']['BackgroundColor'],
					$information['globalData']['EdgeColor'],
					$points[0],
					$points[1],
					$points[2],
					$points[3]
			);
		}
	}

?>