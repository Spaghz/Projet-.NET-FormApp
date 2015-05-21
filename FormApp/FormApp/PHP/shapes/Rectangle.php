<?php
		class Rectangle extends Polygon
		{
				public static $type = 3;

				public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
				}

				public static function createRectangle($name,$parent,$edgeSize,$backgroundColor,$edgeColor,$p1,$p2,$p3,$p4)
				{
					$rectangle = new Rectangle($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
					$rectangle->addPoint($p1);
					$rectangle->addPoint($p2);
					$rectangle->addPoint($p3);
					$rectangle->addPoint($p4);
					return $rectangle;
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

				public function getP4()
				{
					return $this->getPoint(3);
				}

				public function setP4($p)
				{
					$this->setPoint(3,$p);
				}

			public function getTypeId()
			{
				return Rectangle::$type;
			}
		}

?>