<?php
	class DAOShapeMySQL implements iDAOShape
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOShapeMySQL();

			return self::$_instance;
		}

		public function push(&$shape)
		{
			if (!is_a($shape,'Shape'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid shape object!");

			$pushStatement = MySQLManager::getInstance()->getPDO()->prepare("INSERT INTO shape 
			(name,typeId,bgColor,edgeColor,edgeSize,edgeType) 
			VALUES 
			(:name,:typeId,:bgColor,:edgeColor,:edgeSize,:edgeType)");

			$pushStatement->execute(array(
	            "name" 		=> $shape->getName(), 
	            "typeId" 	=> $shape->getTypeId(),
	            "bgColor" 	=> $shape->getBackgroundColor(),
	            "edgeColor" => $shape->getEdgeColor(),
	            "edgeSize" 	=> $shape->getEdgeSize(),
	            "edgeType" 	=> $shape->getEdgeType()
            ));

            $shape->setId(MySQLManager::getInstance()->getPDO()->lastInsertId());

            return $shape;
		}

		public function pull($code)
		{
			$countStatement = MySQLManager::getInstance()->getPDO()->prepare("SELECT * FROM shape WHERE id=:lookupId");
			$countStatement->bindParam('lookupId',$code);
			$countStatement->execute();
			if($countStatement->rowCount()==1);
				return $countStatement->fetch();
			return NULL;
		}

		public function pullParentId($code)
		{
			$countStatement = MySQLManager::getInstance()->getPDO()->prepare("SELECT `idFather` FROM `ownshape` WHERE `idSon`=:lookupId");
			$countStatement->bindParam('lookupId',$code);
			$countStatement->execute();
			$res = $countStatement->fetch();
			return ($res==false)?NULL:$res;
		}
	}
?>