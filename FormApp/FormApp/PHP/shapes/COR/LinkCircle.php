<?php
	class LinkCircle extends HandlerShapesLink
	{
	    public function createShape2()
	    {
	    	if ($this->shapeType==Circle::$type)
	    	{
	    		$radius = null;

	    		if (count($this->specificDataArray)!=3)
	    			throw new Exception("Invalid specific data for Circle!");

	    		$points = array();

	    		foreach($this->specificDataArray as $key => $value)
	    		{
	    			if (count($value)==2)
	    				array_push($points,new Point(array_shift($value),array_shift($value)));
	    			else if ($key=="Radius")
	    				$radius = $value;
	    		}

	    		if ($radius==null)
	    			throw new Exception("Invalid specific data for Circle, radius is missing from json!");

	    		return Circle::createCircle(
	    			$this->name,
	    			$this->parent,
	    			$this->edgeSize,
	    			$this->backgroundColor,
	    			$this->edgeColor,
	    			$points[0],
	    			$points[1],
	    			$radius
	    		);
	    	}
	    	else
	    	{
	    		return null;
	    	}
	    }
	}
?>