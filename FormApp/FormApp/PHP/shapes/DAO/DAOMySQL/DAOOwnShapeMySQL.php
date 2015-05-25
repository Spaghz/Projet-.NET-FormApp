<?php
	class DAOOwnShapeMySQL implements iDAOOwnShape
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOOwnShapeMySQL
			();

			return self::$_instance;
		}

		public function push($fatherShape,$sonShape)
		{
			if (!is_a($fatherShape,'Shape'))
				throw new Exception("Error while pushing shape into database : 'father' shape is not a valid shape object!");
			if (!is_a($sonShape,'Shape'))
				throw new Exception("Error while pushing shape into database : 'son' shape is not a valid shape object!");
			if ($fatherShape->getId()==-1)
				throw new Exception("Error : father shape needs to be saved first.");
			if ($sonShape->getId()==-1)
				throw new Exception("Error : son shape needs to be saved first.");

			$pushStatement = MySQLManager::getInstance()->getPDO()->prepare("INSERT INTO ownshape 
			(idFather,idSon) 
			VALUES 
			(:idFather,:idSon)");

			$pushStatement->execute(array(
	            "idFather" 		=> $fatherShape->getId(), 
	            "idSon" 		=> $sonShape->getId(),
            ));
		}

		public function getSonIds($fatherId)
		{
			if (!filter_var($fatherId, FILTER_VALIDATE_INT))
				throw new Exception("Supplied code must be a valid integer number to pull a shape.");

			$pullSonsIds = MySQLManager::getInstance()->getPDO()->prepare("SELECT `id` FROM `shape` WHERE `id` IN (SELECT `idSon` FROM `ownshape` WHERE `idFather`=:idFather)");
			$pullSonsIds->bindParam('idFather',$fatherId);
			$pullSonsIds->execute();
			$shapesArray = $pullSonsIds->fetchAll();
			$shapesIds = array();

			foreach($shapesArray as $value){
				array_push($shapesIds,$value['id']);
			}
			
			return $shapesIds;
		}
	}
?>