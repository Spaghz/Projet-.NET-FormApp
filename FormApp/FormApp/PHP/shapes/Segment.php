<?php
		class Segment extends Polygon
		{
				public static $type = 2;
				private $p1,$p2;

				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,Segment::$type);
				}

				public static function createSegment($name,$parent,$edgeSize,$backgroundColor,$edgeColor,$p1,$p2)
				{
					$segment = new Segment($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
					$segment->setP1($p1);
					$segment->setP2($p2);
					return $segment;
				}

				public function getP1()
				{
					return $this->p1;
				}

				public function setP1($p)
				{
					$this->setPoint(0,$p);
				}


				public function getP2()
				{
					return $this->p2;
				}

				public function setP2($p)
				{
					$this->setPoint(1,$p);
				}
		}

?>