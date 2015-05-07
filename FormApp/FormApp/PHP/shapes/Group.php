<?php
		class Group extends ShapeSimple
		{
				public static $type = 5;

				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type);
				}
		}

?>