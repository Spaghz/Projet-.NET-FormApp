<?php
		class Rectangle extends Polygon
		{
				public static $type = 3;

				private $p1,$p2,$p3,$p4;

				public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
				}

				public static function createRectangle($name,$parent,$edgeSize,$backgroundColor,$edgeColor,$p1,$p2,$p3,$p4)
				{
					$rectangle = new Rectangle($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
					$rectangle->setP1($p1);
					$rectangle->setP2($p2);
					$rectangle->setP3($p3);
					$rectangle->setP4($p4);
					return $rectangle;
				}

				public function getP1()
				{
					return $this->p1;
				}

				public function setP1($p1)
				{
					$this->p1 = $p1;
				}

				public function getP2()
				{
					return $this->p2;
				}

				public function setP2($p2)
				{
					$this->p2 = $p2;
				}

				public function getP3()
				{
					return $this->p3;
				}

				public function setP3($p3)
				{
					$this->p3 = $p3;
				}		

				public function getP4()
				{
					return $this->p4;
				}

				public function setP4($p4)
				{
					$this->p4 = $p4;
				}	
		}

?>