<?php
	abstract class HandlerShapes
	{
		public function createShape($shapeAsJsonString)
		{
			$shapeAsArray = (is_string($shapeAsJsonString))?json_decode($shapeAsJsonString,true):$shapeAsJsonString;
			return $this->createShapeSpec($shapeAsArray);
		}
		abstract public function pushShape(&$shape);
		
		public function pullShape($code)
		{
			$shape = DAOShapeMySQL::getInstance()->pull($code);
			return (is_null($shape)?NULL:$this->pullShape1($shape));
		}
		abstract protected function pullShape1($code);
		abstract protected function createShapeSpec($shapeAsArray);
	}	
?>