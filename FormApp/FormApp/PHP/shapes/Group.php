<?php
		class Group extends ShapeSimple
		{
				public static $type = 5;

				public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor)
				{
					parent::__construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,Group::$type);
				}
		}

?>