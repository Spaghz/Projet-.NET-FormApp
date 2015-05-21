<?php
	abstract class HandlerShapesLink extends HandlerShapes
	{
		/*
			___  ___               _                   
			|  \/  |              | |                  
			| .  . | ___ _ __ ___ | |__   ___ _ __ ___ 
			| |\/| |/ _ \ '_ ` _ \| '_ \ / _ \ '__/ __|
			| |  | |  __/ | | | | | |_) |  __/ |  \__ \
			\_|  |_/\___|_| |_| |_|_.__/ \___|_|  |___/

		 */
		
	    private 	$successor;

	    protected 	$shapeType;
	    protected	$name;
	    protected	$id;
	    protected	$parent;
	    protected	$specificDataArray;
	    protected	$groupDataArray;
	    protected	$edgeColor;
	    protected	$backgroundColor;
	    protected	$edgeSize;

	    /*
			 _____                 _                   _             
			/  __ \               | |                 | |            
			| /  \/ ___  _ __  ___| |_ _ __ _   _  ___| |_ ___  _ __ 
			| |    / _ \| '_ \/ __| __| '__| | | |/ __| __/ _ \| '__|
			| \__/\ (_) | | | \__ \ |_| |  | |_| | (__| || (_) | |   
			 \____/\___/|_| |_|___/\__|_|   \__,_|\___|\__\___/|_|   
	     */

	    public function __construct()
	    {
	    	$this->successor = NULL;
	    }

	    /*
			 _____      _              _____      _   
			|  __ \    | |     ___    /  ___|    | |  
			| |  \/ ___| |_   ( _ )   \ `--.  ___| |_ 
			| | __ / _ \ __|  / _ \/\  `--. \/ _ \ __|
			| |_\ \  __/ |_  | (_>  < /\__/ /  __/ |_ 
			 \____/\___|\__|  \___/\/ \____/ \___|\__|
	     */
	 
	 
	    public function setSuccessor(&$nextService)
	    {
	        $this->successor=$nextService;
	    }

		/*
			___  ___     _   _               _     
			|  \/  |    | | | |             | |    
			| .  . | ___| |_| |__   ___   __| |___ 
			| |\/| |/ _ \ __| '_ \ / _ \ / _` / __|
			| |  | |  __/ |_| | | | (_) | (_| \__ \
			\_|  |_/\___|\__|_| |_|\___/ \__,_|___/
		 */	    

		public function createShape($shape)
		{
			// Shape must be either a string or an array (converted by json_decode)
			$shapeAsArray = (is_string($shape))?json_decode($shape,true):$shape;

			//echo("Je suis le maillon ".get_class($this)."<br/>");

			$currentLinkShape = $this->createShape1($shapeAsArray);

			if ($currentLinkShape != null)
				return $currentLinkShape;
			else
			{
				//echo("mon successeur est ".get_class($this->successor)."<br/>");
				if ($this->successor!=null)
					return $this->successor->createShape($shapeAsArray);
				else
					return null;
			}
		}

	    protected function checkShape($shapeAsArray)
	    {
	    	// This function checks if the given array '$shape' is a valid shape => meaning that it's got every tags it should
	    	// (Amongst them 'globalData' and 'specificData' for instance)
	    	// Throws exception if an error occurs
	    	
			// Name (Root of the shape)
			if (!isset(array_keys($shapeAsArray)[0]))
				throw new Exception("Given shape is not a valid shape : missing root tag \"name\".");
			$this->name = strval(array_keys($shapeAsArray)[0]);

			//echOArray(array_keys($shapeAsArray[$this->name]));

			// Check if it contains specificData (or GroupData) & globalData
			if (!(array_key_exists('specificData', $shapeAsArray[$this->name])))
			{
				if (!(array_key_exists('groupData', $shapeAsArray[$this->name])))
					throw new Exception("Given shape is not a valid shape : missing tag \"groupData\"");

				$this->groupDataArray 		= $shapeAsArray[$this->name]['groupData'];
				$this->specificDataArray 	= NULL;
			}
			else
			{
				$this->specificDataArray 	= $shapeAsArray[$this->name]['specificData'];
				$this->groupDataArray 		= NULL;
			}

			if (!(array_key_exists('globalData', $shapeAsArray[$this->name])))
				throw new Exception("Given shape is not a valid shape : missing tag \"specificData\"");

			$globalDataArray 			= $shapeAsArray[$this->name]['globalData'];

			// Id
			if (!isset($shapeAsArray[$this->name]['globalData']['Id']))
				throw new Exception("Given shape is not a valid shape : missing tag \"Id\".");
			$this->id = intval($globalDataArray['Id']);


			// Parent
			if (!array_key_exists('Parent',$globalDataArray))
				throw new Exception("Given shape is not a valid shape : missing tag \"parent\".");
			else if (strlen(strval($globalDataArray['Parent']))==0)
					$this->parent = null;
			else
					$this->parent = intval($shapeAsArray[$this->name]['globalData']['Parent']);		

			// Type
			if (!isset($globalDataArray['Type']))
				throw new Exception("Given shape is not a valid shape : missing tag \"Type\".");
			$this->shapeType = 	intval($globalDataArray['Type']);

			// EdgeColor
			if (!isset($globalDataArray['EdgeColor']))
				throw new Exception("Given shape is not a valid shape : missing tag \"EdgeColor\".");
			$this->edgeColor = 	intval($globalDataArray['EdgeColor']);	

			// BackgroundColor
			if (!isset($globalDataArray['BackgroundColor']))
				throw new Exception("Given shape is not a valid shape : missing tag \"EdgeColor\".");
			$this->backgroundColor = 	intval($globalDataArray['BackgroundColor']);

			// edgeSize
			if (!isset($globalDataArray['EdgeSize']))
				throw new Exception("Given shape is not a valid shape : missing tag \"EdgeColor\".");
			$this->edgeSize = 	intval($globalDataArray['EdgeSize']);
	    }

	    public function createShape1($shapeAsArray)
	    {
	    	$this->checkShape($shapeAsArray);

	    	return $this->createShape2($shapeAsArray);
	    }

	    abstract public function createShape2();
	}
?>