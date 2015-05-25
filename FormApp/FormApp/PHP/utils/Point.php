<?php
	class Point
	{
		public $x;
		public $y;
		private $code = -1;

		public function __construct($x,$y,$id=-1)
		{
			$this->x = $x;
			$this->y = $y;
			$this->code=$id;
		}

		public function getId()
		{
			return $this->code;
		}

		public function setId($code)
		{
			$this->code = $code;
		}

		public function getDistance($p2)
		{
			return sqrt(
				(pow($p2->x,2) + pow($this->x,2))
				+
				(pow($p2->y,2) + pow($this->y,2)));
		}
	}
?>