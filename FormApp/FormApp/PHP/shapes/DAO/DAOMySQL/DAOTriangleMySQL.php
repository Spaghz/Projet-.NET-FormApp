<?php
	class DAOTriangleMySQL implements iDAOTriangle 
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOTriangleMySQL();

			return self::$_instance;
		}

		public function push(&$triangle)
		{
			if (!is_a($triangle,'Triangle'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid triangle object!");

			DAOShapeMySQL::getInstance()->push($triangle);

			foreach($triangle->getPoints() as $point)
			{
				DAOPointMySQL::getInstance()->push($point);
				DAOOwnPointMySQL::getInstance()->push($triangle,$point);
			}
			return $triangle;
		}		

		public function pull($code)
		{

		}
	}
?>