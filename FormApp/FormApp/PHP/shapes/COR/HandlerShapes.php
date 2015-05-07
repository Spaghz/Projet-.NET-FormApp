<?php
	abstract class HandlerShapes
	{
		abstract public function save($form); 
		abstract public function setSuccessor($nextService);		
	}	
?>