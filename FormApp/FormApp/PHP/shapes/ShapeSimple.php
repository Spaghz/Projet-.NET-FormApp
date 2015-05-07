<?php
		abstract class ShapeSimple extends Shape
		{
				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type);
				}
		}


?>