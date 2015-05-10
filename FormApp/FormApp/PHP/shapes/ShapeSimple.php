<?php
		abstract class ShapeSimple extends Shape
		{
			public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
			{
				parent::__construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor);
			}
		}


?>