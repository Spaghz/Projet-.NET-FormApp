<?php
		class Segment extends Polygon
		{
				public static $type = 2;

				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type);
				}
		}

?>