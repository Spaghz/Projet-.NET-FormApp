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
		}
	}
?>