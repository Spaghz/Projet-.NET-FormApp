<?php
	class Point
	{
		public $x;
		public $y;
		private $code = -1;

		public function __construct($x,$y)
		{
			$this->x = $x;
			$this->y = $y;
		}

		public function getId()
		{
			return $this->code;
		}

		public function setId($code)
		{
			$this->code = $code;
		}
	}
?>