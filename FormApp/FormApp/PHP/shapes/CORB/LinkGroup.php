<?php
	class LinkGroup extends HandlerShapesLink
	{
	    public function createShape2()
	    {
	    	if ($this->shapeType==Group::$type)
	    	{
	    		if ($this->groupDataArray==null)
	    			throw new Exception("Invalid group was getting loaded by the COR.");


	    		$groupToReturn = Group::createGroup(
	    			$this->name,
	    			$this->parent,
	    			$this->edgeSize,
	    			$this->backgroundColor,
	    			$this->edgeColor
	    		);

	    		foreach($this->groupDataArray as $key => $value)
	    		{
	    			$shape = CORShape::getInstance()->createShape((array($key=>$value)));
	    			$groupToReturn->addShape($shape);
	    		}

	    		return $groupToReturn;
	    	}
	    	else
	    	{
	    		return null;
	    	}
	    }

	   	public function pushShape2(&$group)
	    {
	    	if ($this->shapeType==Group::$type)
	    		return DAOGroupMySQL::getInstance()->push($group);
	    	return NULL;
	    }	    

	    public function pullShape2($shape)
	    {
	    	
	    }
	}
?>