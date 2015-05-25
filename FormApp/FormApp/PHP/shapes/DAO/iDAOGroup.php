<?php
	interface iDAOGroup
	{
		public function pull($code);
		public function push(&$shape);
	}
?>