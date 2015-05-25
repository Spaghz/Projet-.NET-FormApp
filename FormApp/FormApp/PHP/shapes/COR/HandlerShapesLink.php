<?php
	abstract class HandlerShapesLink extends HandlerShapes
	{
		protected 	$shapeType;
		private 	$successor;

	    /*
			 _____                 _                   _             
			/  __ \               | |                 | |            
			| /  \/ ___  _ __  ___| |_ _ __ _   _  ___| |_ ___  _ __ 
			| |    / _ \| '_ \/ __| __| '__| | | |/ __| __/ _ \| '__|
			| \__/\ (_) | | | \__ \ |_| |  | |_| | (__| || (_) | |   
			 \____/\___/|_| |_|___/\__|_|   \__,_|\___|\__\___/|_|   
	     */
	    
	    public function __construct($shapeType,&$successor=NULL)
	    {
	    	$this->successor=$successor;
	    	$this->shapeType = $shapeType;
	    }		

		/*
		______          _     
		| ___ \        | |    
		| |_/ /   _ ___| |__  
		|  __/ | | / __| '_ \ 
		| |  | |_| \__ \ | | |
		\_|   \__,_|___/_| |_|
		                                         
		 */

		public function pushShape(&$shape)
		{
			if ($this->isRightLinkType1($shape))
				return $this->pushShape1($shape);
			else if (!is_null($this->successor))
				return $this->successor->pushShape($shape);
			else
				return NULL;
		}

		abstract public function pushShape1(&$shape);

		/*
		______      _ _ 
		| ___ \    | | |
		| |_/ /   _| | |
		|  __/ | | | | |
		| |  | |_| | | |
		\_|   \__,_|_|_|

		 */
		
		public function pullShape1($pullShapeResponse)
		{
			/*
			var_dump($pullShapeResponse);
			var_dump(get_class($this));
			var_dump($this->shapeType);
			*/
			if ($this->isRightLinkType3($pullShapeResponse))
			{
				return $this->pullShape2($pullShapeResponse);
			}
			else if (!is_null($this->successor))
			{
				return $this->successor->pullShape1($pullShapeResponse);
			}
			else
				return NULL;			
		}

		abstract public function pullShape2($pullShapeResponse);

		/*
		 _____                _       
		/  __ \              | |      
		| /  \/_ __ ___  __ _| |_ ___ 
		| |   | '__/ _ \/ _` | __/ _ \
		| \__/\ | |  __/ (_| | ||  __/
		 \____/_|  \___|\__,_|\__\___|
		                              
		 */
		

		public function createShape1($information)
		{
			if ($this->isRightLinkType2($information))
				return $this->createShape2($information);
			else if (!is_null($this->successor))
				return $this->successor->createShape1($information);
			else
				return NULL;
		}

		abstract public function createShape2($information);


		/*
		 _   _ _   _ _     
		| | | | | (_) |    
		| | | | |_ _| |___ 
		| | | | __| | / __|
		| |_| | |_| | \__ \
		 \___/ \__|_|_|___/

		                   
		 */
		
		private function isRightLinkType1($shape)
		{
			return (strcmp(get_class($shape),substr(get_class($this),4))==0);
		}

		private function isRightLinkType2($information)
		{
			return (intval($information['globalData']['Type']==intval($this->shapeType)));
		}

		private function isRightLinkType3($pullShapeResponse)
		{
			return (intval($pullShapeResponse['typeId']==intval($this->shapeType)));
		}

		protected function setLinkType($shapeType)
		{

		}
	}
?>