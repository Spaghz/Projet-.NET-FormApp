<?php
	class DAOOwnPointMySQL implements iDAOOwnPoint
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOOwnPointMySQL();

			return self::$_instance;
		}

		public function push($shape,$point)
		{
			if (!is_a($shape,'Shape'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid shape object!");
			if (!is_a($point,'Point'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid shape object!");
			if ($shape->getId()==-1)
				throw new Exception("It is not possible to save a shape <-> point relation without saving the shape first.");
			if ($point->getId()==-1)
				throw new Exception("It is not possible to save a shape <-> point relation without saving the point first.");

			$pushStatement = MySQLManager::getInstance()->getPDO()->prepare("INSERT INTO ownpoint 
			(idShape,idPoint) 
			VALUES 
			(:idShape,:idPoint)");

			$pushStatement->execute(array(
	            "idShape" 		=> $shape->getId(), 
	            "idPoint" 		=> $point->getId(),
            ));
		}
	}
?>