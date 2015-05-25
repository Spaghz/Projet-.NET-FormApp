<?php
	interface iDAOSegment
	{
		public function pull($code);
		public function push(&$shape);
	}
?>