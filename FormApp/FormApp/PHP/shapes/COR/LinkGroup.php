<?php
	class LinkGroup extends HandlerShapesLink
	{
		public function __construct(&$successor=NULL)
		{
			parent::__construct(Group::$type,$successor);
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
			return DAOGroupMySQL::getInstance()->push($shape);
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

			$group =  Group::createGroup(
					$pullShapeResponse['name'],
					NULL,
					$pullShapeResponse['edgeSize'],
					$pullShapeResponse['bgColor'],
					$pullShapeResponse['edgeColor']
			);
			$group->setId($pullShapeResponse['id']);

			$sonIds = DAOOwnShapeMySQL::getInstance()->getSonIds($group->getId());

			foreach($sonIds as $sonId)
			{
				$currentForm = CORShape::getInstance()->pullShape($sonId);
				$group->addShape($currentForm);
			}

			return $group;
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
    		$shapes = array();

			$group = Group::createGroup(
					$information['name'],
					NULL,
					$information['globalData']['EdgeSize'],
					$information['globalData']['BackgroundColor'],
					$information['globalData']['EdgeColor']
			);

    		foreach($information['groupData'] as $key => $value)
    		{
    			$currentForm = CORShape::getInstance()->createShape(array($key=>$value));
    			$group->addShape($currentForm);
    		}		

    		return $group;
		}
	}

?>