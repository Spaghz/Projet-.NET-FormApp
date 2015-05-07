<?php
		abstract class Polygon extends ShapeSimple
		{
				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type);
				}
		}
?>