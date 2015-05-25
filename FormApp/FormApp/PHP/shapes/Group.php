<?php
	class Group extends Shape
	{
			public static $type = 5;
			private $shapes; 

			public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
			{
				parent::__construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor,Group::$type);
				$this->shapes = array();
			}

			public static function createGroup($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
			{
				return new Group($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
			}

			public function addShape(&$shape)
			{
				if (!is_a($shape,"Shape"))
					throw new Exception("Given parameter is not a point in addPoint.");

				array_push($this->shapes,$shape);
				$shape->setParent($this);
			}

			public function getTypeId()
			{
				return Group::$type;
			}

			public function getShapes()
			{
				return $this->shapes;
			}
	}

?>