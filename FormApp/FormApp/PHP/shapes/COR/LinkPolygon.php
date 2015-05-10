<?php
	class LinkPolygon extends HandlerShapesLink
	{
	    public function createShape2()
	    {
	    		    	echo("LINKPOOLYGION<br/>");

	    	if ($this->shapeType==Polygon::$type)
	    	{
	    		if (count($this->specificDataArray)<2)
	    			throw new Exception("Invalid specific data for Polygon : must contain at least 3 points!");

	    		$points = array();

	    		foreach($this->specificDataArray as $key => $value)
	    		{
	    			if (count($value)!=2)
	    				throw new Exeption("Invalid point array in LinkPolygon : must contain two values 'X' and 'Y'");

	    			array_push($points,new Point(array_shift($value),array_shift($value)));
	    		}

	    		return Polygon::createPolygon(
	    			$this->name,
	    			$this->parent,
	    			$this->edgeSize,
	    			$this->backgroundColor,
	    			$this->edgeColor,
	    			$points
	    		);
	    	}
	    	else
	    	{
	    		return null;
	    	}
	    }
	}
?>