<?php
		class Polygon extends ShapeSimple
		{
			public 	static $type = 4;
			private $points;

			public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
			{
				parent::__construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
				$this->points = array();
			}

			public static function createPolygon($name,$parent,$edgeSize,$backgroundColor,$edgeColor,$arrayOfPoints)
			{
				$polygon = new Polygon($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
				foreach($arrayOfPoints as $currentPoint)
				{
					$polygon->addPoint($currentPoint);
				}
				return $polygon;
			}

			public function getPoints()
			{
				return $this->points;
			}

			public function count()
			{
				return count($this->points);
			}

			public function addPoint($point)
			{
				if (!is_a($point,"Point"))
					throw new Exception("Given parameter is not a point in addPoint.");

				$this->points[] = $point;
			}

			public function getPoint($index)
			{
				if ($index>=$this->count())
					throw new Exception("Index is out of bound!");

				if (!is_int($index))
					throw new Exception("Please specifify an integer index in getPoint of Polygon.");

				return ($points[$index]);
			}

			public function setPoint($index,$point)
			{
				if ($index<0||$index>count($this->points))
					throw new Exception("Index out of bound : setPoint in Polygon");
				
				$this->points[$index] = $point;
			}

			public function getTypeId()
			{
				return Polygon::$type;
			}

			protected function push1()
			{
				foreach($this->points as $point)
				{
					$point->push($this);
				}
			}
		}
?>