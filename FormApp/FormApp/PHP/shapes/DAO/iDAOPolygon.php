<?php
	interface iDAOPolygon
	{
		public function pull($code);
		public function push(&$shape);
	}
?>