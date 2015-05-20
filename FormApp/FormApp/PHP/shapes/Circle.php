<?php
		class Circle extends Polygon
		{
				public static $type = 6;
				private $radius;

				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,Circle::$type);
				}

				public static function createCircle($name,$parent,$edgeSize,$backgroundColor,$edgeColor,$p1,$p2,$radius)
				{
					$circle = new Circle($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
					$circle->addPoint($p1);
					$circle->addPoint($p2);
					$circle->setRadius($radius);
					return $circle;
				}

				public function getP1()
				{
					return $this->getPoint(0);
				}

				public function setP1($p)
				{
					$this->setPoint(0,$p);
				}


				public function getP2()
				{
					return $this->getPoint(1);
				}

				public function setP2($p)
				{
					$this->setPoint(1,$p);
				}	

				public function getRadius()
				{
					return $this->radius;
				}

				public function setRadius($radius)
				{
					$this->radius = $radius;
				}						
		}

?>