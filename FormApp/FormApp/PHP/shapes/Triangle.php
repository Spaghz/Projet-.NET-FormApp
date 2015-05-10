<?php
		class Triangle extends Polygon
		{
				public 	static $type = 1;
				private $p1,$p2,$p3;

				public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
				}

				public static function createTriangle($name,$parent,$edgeSize,$backgroundColor,$edgeColor,$p1,$p2,$p3)
				{
					$triangle = new Triangle($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
					$triangle->setP1($p1);
					$triangle->setP2($p2);
					$triangle->setP3($p3);
					return $triangle;
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
		}

?>