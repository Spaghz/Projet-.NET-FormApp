<?php
	class LinkGroup extends HandlerShapesLink
	{
	    public function createShape2()
	    {
	    	if ($this->shapeType==Group::$type)
	    	{
	    		if ($this->groupDataArray==null)
	    			throw new Exception("Invalid group was getting loaded by the COR.");

	    		$forms = array();

	    		foreach($this->groupDataArray as $key => $value)
	    		{
	    			array_push($forms,CORShape::getInstance()->createShape(array($key=>$value)));
	    		}

	    		return Group::createGroup(
	    			$this->name,
	    			$this->parent,
	    			$this->edgeSize,
	    			$this->backgroundColor,
	    			$this->edgeColor,
	    			$forms
	    		);
	    	}
	    	else
	    	{
	    		return null;
	    	}
	    }
	}
?>