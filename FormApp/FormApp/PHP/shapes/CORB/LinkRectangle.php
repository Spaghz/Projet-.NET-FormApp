<?php
	class LinkRectangle extends HandlerShapesLink
	{
	    public function createShape2()
	    {
	    	if ($this->shapeType==Rectangle::$type)
	    	{
	    		if (count($this->specificDataArray)!=4)
	    			throw new Exception("Invalid specific data for Rectangle!");

	    		$points = array();

	    		foreach($this->specificDataArray as $key => $value)
	    		{
	    			if (count($value)!=2)
	    				throw new Exeption("Invalid point array in LinkRectangle : must contain two values 'X' and 'Y'");

	    			array_push($points,new Point(array_shift($value),array_shift($value)));
	    		}

	    		return Rectangle::createRectangle(
	    			$this->name,
	    			$this->parent,
	    			$this->edgeSize,
	    			$this->backgroundColor,
	    			$this->edgeColor,
	    			$points[0],
	    			$points[1],
	    			$points[2],
	    			$points[3]
	    		);
	    	}
	    	else
	    	{
	    		return null;
	    	}
	    }

	   	public function pushShape2(&$rectangle)
	    {
	    	if ($this->shapeType==Rectangle::$type)
	    		return DAOPolygonMySQL::getInstance()->push($rectangle);
	    	return NULL;
	    }

	    public function pullShape2($shape)
	    {
	    	
	    }
	}
?>