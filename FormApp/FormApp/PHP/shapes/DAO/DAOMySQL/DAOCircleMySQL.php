<?php
	class DAOCircleMySQL implements iDAOCircle 
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOCircleMySQL();

			return self::$_instance;
		}

		public function push(&$circle)
		{
			if (!is_a($circle,'Circle'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid circle object!");

			DAOShapeMySQL::getInstance()->push($circle);

			foreach($circle->getPoints() as $point)
			{
				DAOPointMySQL::getInstance()->push($point);
				DAOOwnPointMySQL::getInstance()->push($circle,$point);
			}

			return $circle;
		}		

		public function pull($code)
		{

		}
	}
?>