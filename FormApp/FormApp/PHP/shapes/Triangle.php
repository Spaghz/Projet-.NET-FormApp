<?php
		class Triangle extends Polygon
		{
				public 	static $type = 1;

				public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
				}

				public static function createTriangle($name,$parent,$edgeSize,$backgroundColor,$edgeColor,$p1,$p2,$p3)
				{
					$triangle = new Triangle($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
					$triangle->addPoint($p1);
					$triangle->addPoint($p2);
					$triangle->addPoint($p3);
					return $triangle;
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

				public function getP3()
				{
					return $this->getPoint(2);
				}

				public function setP3($p)
				{
					$this->setPoint(2,$p);
				}			
		}

?>