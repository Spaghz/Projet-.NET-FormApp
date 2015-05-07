<?php
	abstract class HandlerShapesLink extends HandlerShapes
	{
	    private $successor;

	    public function __construct()
	    {
	    	$this->successor = NULL;
	    }
	 
	 
	    public function setSuccessor($nextService)
	    {
	        $this->successor=$nextService;
	    }
	 
	    public function save ($form)
	    {
	    	if ($this->isLinkType($form))
	    		return saveSpecific($form);
	    	else if ($successor!=NULL)
	    		return $successor->save($form);
	    	else
	    		return FALSE;
	    }

	    abstract protected function isLinkType($form);
	}
?>