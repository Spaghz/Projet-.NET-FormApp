<?php
	class CORShape
	{
		private static $_instance = null;
		private $handler;

		private function __construct()
		{
			$linkTriangle 	= new LinkTriangle();
			$linkRectangle 	= new LinkRectangle($linkTriangle);
			$linkCircle 	= new LinkCircle($linkRectangle);
			$linkSegment 	= new LinkSegment($linkCircle);
			$linkPolygon 	= new LinkPolygon($linkSegment);
			$linkGroup		= new linkGroup($linkPolygon);
			$this->handler = $linkGroup;
		}

		public static function getInstance()
		{
			if (is_null(self::$_instance))
				self::$_instance = new CORShape();

			return self::$_instance;
		}

		public function pushShape(&$shape)
		{
			return $this->handler->pushShape($shape);
		}				

		public function createShape($shapeAsJsonString)
		{
			$shapeAsArray = (is_string($shapeAsJsonString))?json_decode($shapeAsJsonString,true):$shapeAsJsonString;
			return $this->handler->createShape($shapeAsArray);
		}

		public function pullShape($code)
		{
			$code = filter_var($code, FILTER_VALIDATE_INT);

			if ($code===FALSE)
				throw new Exception("Supplied code must be a valid integer number to pull a shape.");

			return $this->handler->pullShape($code);			
		}				
	}
?>