<?php
	class DAOGroupMySQL implements iDAOGroup 
	{
		private static $_instance = null;

		private function __construct()
		{
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new DAOGroupMySQL();

			return self::$_instance;
		}

		public function push(&$group)
		{
			if (!is_a($group,'Group'))
				throw new Exception("Error while pushing shape into database : parameter is not a valid group object!");
			
			DAOShapeMySQL::getInstance()->push($group);


			foreach($group->getShapes() as $key => &$shape)
			{
				CORShape::getInstance()->pushShape($shape);
				DAOOwnShapeMySQL::getInstance()->push($group,$shape);
			}
			
			return $group;
		}		

		public function pull($code)
		{

		}

		private function CORPushShape(&$shape)
		{
			return CORShape::getInstance()->pushShape($shape);
		}
	}
?>