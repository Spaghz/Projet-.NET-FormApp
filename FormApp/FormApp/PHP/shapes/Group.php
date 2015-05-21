<?php
	class Group extends ShapeSimple
	{
			public static $type = 5;
			private $shapes; 

			public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
			{
				parent::__construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
				$this->shapes = array();
			}

			public static function createGroup($name,$parent,$edgeSize,$backgroundColor,$edgeColor,$arrayOfShapes)
			{
				$group = new Group($name,$parent,$edgeSize,$backgroundColor,$edgeColor);

				foreach($arrayOfShapes as $currentShape)
				{
					$group->addForm($currentShape);
				}

				return $group;
			}

			public function addForm($shape)
			{
				if (!is_a($shape,"Shape"))
					throw new Exception("Given parameter is not a point in addPoint.");

				$this->shapes[] = $shape;
			}

			public function getTypeId()
			{
				return Group::$type;
			}
	}

?>