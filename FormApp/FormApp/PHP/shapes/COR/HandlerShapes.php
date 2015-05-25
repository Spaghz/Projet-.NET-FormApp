<?php
	abstract class HandlerShapes
	{
		/*
		______          _     
		| ___ \        | |    
		| |_/ /   _ ___| |__  
		|  __/ | | / __| '_ \ 
		| |  | |_| \__ \ | | |
		\_|   \__,_|___/_| |_|
		                                         
		 */

		abstract public function pushShape(&$shape);

		/*
		______      _ _ 
		| ___ \    | | |
		| |_/ /   _| | |
		|  __/ | | | | |
		| |  | |_| | | |
		\_|   \__,_|_|_|
		                                
		 */

		public function pullShape($code)
		{
			$pullShapeStatement = MySQLManager::getInstance()->getPDO()->prepare("SELECT `shape`.*FROM `shape` WHERE `id`=:idShape LIMIT 1;");
			$pullShapeStatement->bindValue(':idShape',$code,PDO::PARAM_INT);
			$pullShapeStatement->execute();
			$pullShapeResponse = $pullShapeStatement->fetch();

			if ($pullShapeResponse===FALSE)
				return NULL;

			return $this->pullShape1($pullShapeResponse);
		}

		abstract public function pullShape1($pullShapeResponse);

		/*
		 _____                _       
		/  __ \              | |      
		| /  \/_ __ ___  __ _| |_ ___ 
		| |   | '__/ _ \/ _` | __/ _ \
		| \__/\ | |  __/ (_| | ||  __/
		 \____/_|  \___|\__,_|\__\___|
		                              
		 */
		
		public function createShape($shapeAsArray)
		{
			$information = array_fill_keys(
				array(
					"isGroup",
					"name",
					"groupData",
					"globalData",
					"specificData",
					),"");

			// Name
			if (!isset(array_keys($shapeAsArray)[0]))
				throw new Exception("Given shape is not a valid shape : missing root tag \"name\".");
			$information['name'] = strval(array_keys($shapeAsArray)[0]);

			// GroupData & SpecificData
			if (!(array_key_exists('specificData', $shapeAsArray[$information['name']])))
			{
				if (!(array_key_exists('groupData', $shapeAsArray[$information['name']])))
					throw new Exception("Given shape is not a valid shape : missing tag \"groupData\"");

				$information['groupData']		= $shapeAsArray[$information['name']]['groupData'];
				$information['specificData'] 	= NULL;
				$information['isGroup']			= FALSE;
			}
			else
			{
				$information['specificData']	 = $shapeAsArray[$information['name']]['specificData'];
				$information['groupData'] 		= NULL;
				$information['isGroup']			= TRUE;
			}			

			// Global Data
			if (!(array_key_exists('globalData', $shapeAsArray[$information['name']])))
				throw new Exception("Given shape is not a valid shape : missing tag \"specificData\"");
			$information['globalData'] = $shapeAsArray[$information['name']]['globalData'];

		
			return $this->createShape1($information);
		}

		abstract public function createShape1($information);
	}	
?>