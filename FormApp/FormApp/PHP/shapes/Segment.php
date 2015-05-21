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
					$segment->addPoint($p1);
					$segment->addPoint($p2);
					return $segment;
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

				public function getTypeId()
				{
					return Segment::$type;
				}
		}

?>