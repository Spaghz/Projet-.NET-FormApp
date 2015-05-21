<?php
	interface iDAOShape
	{
		public function pull($code);
		public function push(&$shape);
	}
?>