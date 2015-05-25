<?php
	class DAORectangleMySQL implements iDAORectangle 
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAORectangleMySQL();

			return self::$_instance;
		}

		public function push(&$rectangle)
		{
			if (!is_a($rectangle,'rectangle'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid rectangle object!");

			DAOShapeMySQL::getInstance()->push($rectangle);

			foreach($rectangle->getPoints() as $point)
			{
				DAOPointMySQL::getInstance()->push($point);
				DAOOwnPointMySQL::getInstance()->push($rectangle,$point);
			}

			return $rectangle;
		}		

		public function pull($code)
		{

		}
	}
?>