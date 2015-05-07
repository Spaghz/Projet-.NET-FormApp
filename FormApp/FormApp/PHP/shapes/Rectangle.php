<?php
		class Rectangle extends Polygon
		{
				public static $type = 3;

				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,Rectangle::$type);
				}
		}

?>