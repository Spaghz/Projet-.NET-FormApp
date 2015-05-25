<?php
	class DAOPolygonMySQL implements iDAOPolygon 
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOPolygonMySQL();

			return self::$_instance;
		}

		public function push(&$polygon)
		{
			if (!is_a($polygon,'Polygon'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid polygon object!");

			DAOShapeMySQL::getInstance()->push($polygon);

			foreach($polygon->getPoints() as $point)
			{
				DAOPointMySQL::getInstance()->push($point);
				DAOOwnPointMySQL::getInstance()->push($polygon,$point);
			}

			return $polygon;
		}		

		public function pull($code)
		{

		}
	}
?>