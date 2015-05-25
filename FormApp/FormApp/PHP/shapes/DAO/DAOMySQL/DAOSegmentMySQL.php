<?php
	class DAOSegmentMySQL implements iDAOSegment 
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOSegmentMySQL();

			return self::$_instance;
		}

		public function push(&$segment)
		{
			if (!is_a($segment,'Segment'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid segment object!");

			DAOShapeMySQL::getInstance()->push($segment);

			foreach($segment->getPoints() as $point)
			{
				DAOPointMySQL::getInstance()->push($point);
				DAOOwnPointMySQL::getInstance()->push($segment,$point);
			}

			return $segment;
		}		

		public function pull($code)
		{

		}
	}
?>