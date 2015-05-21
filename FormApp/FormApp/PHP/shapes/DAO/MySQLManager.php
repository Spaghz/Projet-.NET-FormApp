<?php
	class MySQLManager
	{
		private static $_instance = null;
		private $pdo;
		private $pushShapeStatement;
		private $pushPointStatement;
		private $pushOwnPointStatement;

		private function __construct() 
		{  
			$this->pdo = new PDO('mysql:host='.$GLOBALS['authInfo']['connections']['mysql']['host'].';dbname='.$GLOBALS['authInfo']['connections']['mysql']['database'],
			$GLOBALS['authInfo']['connections']['mysql']['username'],
			$GLOBALS['authInfo']['connections']['mysql']['password']);

			$this->pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);


			$this->pushPointStatement = $this->pdo->prepare("INSERT INTO point 
			(x,y)
			VALUES 
			(:x,:y)");

			$this->pushOwnPointStatement = $this->pdo->prepare("INSERT INTO 'ownpoint'
			(idShape,idPoint)
			VALUES
			(:idShape,:idPoint)");
		}

		public static function getInstance() 
		{
			if(is_null(self::$_instance)) 
				self::$_instance = new MySQLManager();  

			return self::$_instance;		
		}

		public function getPDO()
		{
			return $this->pdo;
		}

		public function getPushShapeStatement()
		{
			return $this->pushShapeStatement;
		}

		public function getPushPointStatement()
		{
			return $this->pushPointStatement;
		}

		public function getPushOwnPointStatement()
		{
			return $this->$pushOwnPointStatement;
		}

		public function eraseDataBase()
		{
			$this->pdo->exec("TRUNCATE TABLE ownpoint;");
			$this->pdo->exec("ALTER TABLE ownpoint AUTO_INCREMENT = 0;");
			$this->pdo->exec("TRUNCATE TABLE point;");
			$this->pdo->exec("ALTER TABLE point AUTO_INCREMENT = 0;");
			$this->pdo->exec("TRUNCATE TABLE ownshape;");
			$this->pdo->exec("ALTER TABLE ownshape AUTO_INCREMENT = 0;");
			$this->pdo->exec("TRUNCATE TABLE shape;");
			$this->pdo->exec("ALTER TABLE shape AUTO_INCREMENT = 0;");
		}
	}
?>