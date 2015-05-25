<?php
	class CORShape
	{
		private static $_instance = null;
		private $handler;

		private function __construct()
		{
			$linkTriangle 	= new LinkTriangle();
			$linkRectangle 	= new LinkRectangle();
			$linkPolygon 	= new LinkPolygon();
			$linkSegment 	= new LinkSegment();
			$linkCircle 	= new LinkCircle();
			$linkGroup		= new linkGroup();

			$linkCircle->setSuccessor($linkGroup);
			$linkSegment->setSuccessor($linkCircle);
			$linkPolygon->setSuccessor($linkSegment);
			$linkRectangle->setSuccessor($linkPolygon);
			$linkTriangle->setSuccessor($linkRectangle);

			$this->handler = $linkTriangle;
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new CORShape();

			return self::$_instance;
		}

		public function createShape($shape)
		{
			return $this->handler->createShape($shape);
		}

		public function pushShape(&$shape)
		{
			return $this->handler->pushShape($shape);
		}

		public function pullShape($code)
		{
			if (!filter_var($code, FILTER_VALIDATE_INT))
				throw new Exception("Supplied code must be a valid integer number to pull a shape.");

			return $this->handler->pullShape($code);			
		}
	}
?>