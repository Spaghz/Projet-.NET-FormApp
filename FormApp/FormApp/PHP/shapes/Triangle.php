<?php
		class Triangle extends Polygon
		{
				public static $type = 1;

				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type);
				}
		}

?>