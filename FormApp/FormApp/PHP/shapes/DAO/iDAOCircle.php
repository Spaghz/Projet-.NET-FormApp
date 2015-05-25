<?php
	interface iDAOCircle
	{
		public function pull($code);
		public function push(&$shape);
	}
?>