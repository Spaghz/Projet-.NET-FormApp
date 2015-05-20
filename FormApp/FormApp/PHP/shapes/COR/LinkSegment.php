<?php
	class LinkSegment extends HandlerShapesLink
	{
	    public function createShape2()
	    {
	    	if ($this->shapeType==Segment::$type)
	    	{
	    		if (count($this->specificDataArray)!=2)
	    			throw new Exception("Invalid specific data for Segment!");

	    		$points = array();

	    		foreach($this->specificDataArray as $key => $value)
	    		{
	    			if (count($value)!=2)
	    				throw new Exeption("Invalid point array in LinkSegment : must contain two values 'X' and 'Y'");

	    			array_push($points,new Point(array_shift($value),array_shift($value)));
	    		}

	    		return Segment::createSegment(
	    			$this->name,
	    			$this->parent,
	    			$this->edgeSize,
	    			$this->backgroundColor,
	    			$this->edgeColor,
	    			$points[0],
	    			$points[1]
	    		);
	    	}
	    	else
	    	{
	    		return null;
	    	}
	    }
	}
?>