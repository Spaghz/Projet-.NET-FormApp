<?php
	class DAOPointMySQL implements iDAOPoint
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOPointMySQL();

			return self::$_instance;
		}

		public function push(&$point)
		{
			if (!is_a($point,'Point'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid shape object!");

			MySQLManager::getInstance()->getPushPointStatement()->bindParam(':x',$point->x);
			MySQLManager::getInstance()->getPushPointStatement()->bindParam(':y',$point->y);
			MySQLManager::getInstance()->getPushPointStatement()->execute();

			$point->setId(MySQLManager::getInstance()->getPDO()->lastInsertId());

			return $point;
		}

		public function pullPoints($shapeId)
		{
			if (!filter_var($shapeId, FILTER_VALIDATE_INT))
				throw new Exception("Supplied code must be a valid integer number to pull a shape.");

			$pullPointsStatement = MySQLManager::getInstance()->getPDO()->prepare("SELECT * FROM `point` WHERE `idPoint`IN (SELECT `idPoint` FROM `ownpoint` WHERE `idShape`=:idShape)");
			$pullPointsStatement->bindParam('idShape',$shapeId);
			$pullPointsStatement->execute();
			$pointsArray = $pullPointsStatement->fetchAll();
			$points = array();

			foreach($pointsArray as $value)
				array_push($points,new Point($value['x'],$value['y'],$value['idPoint']));
			
			return $points;
		}
	}
?>