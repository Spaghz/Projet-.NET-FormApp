<?php
	class LinkTriangle extends HandlerShapesLink
	{
	    public function createShape2()
	    {
	    	if ($this->shapeType==Triangle::$type)
	    	{
	    		if (count($this->specificDataArray)!=3)
	    			throw new Exception("Invalid specific data for Triangle!");

	    		$points = array();

	    		foreach($this->specificDataArray as $key => $value)
	    		{
	    			if (count($value)!=2)
	    				throw new Exeption("Invalid point array in LinkTriangle : must contain two values 'X' and 'Y'");

	    			array_push($points,new Point(array_shift($value),array_shift($value)));
	    		}

	    		return Triangle::createTriangle(
	    			$this->name,
	    			$this->parent,
	    			$this->edgeSize,
	    			$this->backgroundColor,
	    			$this->edgeColor,
	    			$points[0],
	    			$points[1],
	    			$points[2]
	    		);
	    	}
	    	else
	    	{
	    		return null;
	    	}
	    }
	}
?>