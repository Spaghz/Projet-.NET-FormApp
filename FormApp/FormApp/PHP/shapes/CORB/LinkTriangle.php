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

	    public function pushShape2(&$triangle)
	    {
	    	return (get_class($triangle)=="Triangle")?DAOTriangleMySQL::getInstance()->push($triangle):NULL;	    
	    }

	    public function pullShape2($shape)
	    {
	    	if ((isset($shape['typeId']))&&(intval($shape['typeId'])==Triangle::$type))
	    	{
	    		if (isset($shape['id']))
	    			$points = DAOPointMySQL::getInstance()->pullPoints(intval($shape['id']));
	    		else
	    			throw new Exception("Invalid shape in LinkTriangle for pull operation : element 'id' missing from object retrieved by DAOShapeMySQL.");

	    		$parentId = DAOShapeMySQL::getInstance()->pullParentId($shape['id']);
	    		var_dump($parent = is_null($parentId)?NULL:CORShape::getInstance()->pullShape(intval($parentId)));


	    		// Parent à retrieve
	    		$triangle = Triangle::createTriangle(
	    			$shape['name'],
	    			NULL,	    			
	    			$shape['edgeSize'],
	    			$shape['bgColor'],
	    			$shape['edgeColor'],
	    			new Point($points[0]['x'],$points[0]['y']),
	    			new Point($points[1]['x'],$points[1]['y']),
	    			new Point($points[2]['x'],$points[2]['y'])
	    		);
	    		return $triangle;
	    	}
	    	return NULL;
	    }
	}
?>