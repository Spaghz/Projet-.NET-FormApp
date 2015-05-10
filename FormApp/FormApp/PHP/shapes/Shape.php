<?php
	 abstract class Shape
	{
		protected $id = -1;
		protected $name;
		protected $parent;
		protected $edgeSize;
		protected $backgroundColor;
		protected $edgeColor;

		public function __construct($name,$parent,$edgeSize,$backgroundColor,$edgeColor)
		{
			$this->name = $name;
			$this->parent = $parent;
			$this->edgeSize = $edgeSize;
			$this->backgroundColor = $backgroundColor;
			$this->edgeColor = $edgeColor;
		}

		public function getId()
		{
			return $this->id;
		}

		public function setId($id)
		{
			$this->id = $id;
		}

		public function getName()
		{
			return $this->name;
		}

		public function setName($name)
		{
			$this->name = $name;
		}

		public function getEdgeSize()
		{
			return $this->edgeSize;
		}

		public function setEdgeSize($edgeSize)
		{
			$this->edgeSize = $edgeSize;
		}

		public function getBackgroundColor()
		{
			return $this->backgroundColor;
		}

		public function setBackgroundColor($backgroundColor)
		{
			$this->backgroundColor = $backgroundColor;
		}

		public function getEdgeColor()
		{
			return $this->edgeColor;
		}

		public function setEdgeColor($edgeColor)
		{
			$this->edgeColor = $edgeColor;
		}				
	}
?>