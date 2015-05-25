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

	    public function pushShape2(&$circle)
	    {
	    	if ($this->shapeType==Circle::$type)
	    		return DAOCircleMySQL::getInstance()->push($circle);
	    	return NULL;
	    }

	    public function pullShape2($shape)
	    {
	    	if ((isset($shape['typeId']))&&(intval($shape['typeId'])==Circle::$type))
	    	{
	    		if (isset($shape['id']))
	    			$points = DAOPointMySQL::getInstance()->pullPoints(intval($shape['id']));
	    		else
	    			throw new Exception("Invalid shape in LinkCircle for pull operation : element 'id' missing from object retrieved by DAOShapeMySQL.");

	    		// Parent à retrieve
	    		$circle = Circle::createCircle(
	    			$shape['name'],
	    			NULL,
	    			$shape['edgeSize'],
	    			$shape['bgColor'],
	    			$shape['edgeColor'],
	    			new Point($points[0]['x'],$points[0]['y']),
	    			new Point($points[1]['x'],$points[1]['y'])
	    		);
	    		return $circle;
	    	}
	    	return NULL;
	    }
	}
?>