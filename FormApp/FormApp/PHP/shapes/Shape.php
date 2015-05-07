<?php
	abstract class Shape
	{
			private $id = -1;
			private $parent = null;
			private $edgeSize = 1;
			private $backgroundColor;// = hexdec("000000");
			private $edgeColor;// = hexdec("FFFFFF");
			private $type;

			public function __construct($id,$parent,$edgeSize,$backgroundColor,$edgeColor,$type)
			{
					$this->id = $id;
					$this->parent = $parent;
					$this->edgeSize = $edgeSize;
					$this->backgroundColor = $backgroundColor;
					$this->edgeColor = $edgeColor;
					$this->type = $type;
			}
	}
?>