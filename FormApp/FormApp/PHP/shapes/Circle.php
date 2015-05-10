<?php
		class Circle extends Polygon
		{
				public static $type = 6;

				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,Circle::$type);
				}
		}

?>