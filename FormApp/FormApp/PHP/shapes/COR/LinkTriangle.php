<?php
	class LinkTriangle extends HandlerShapesLink
	{
	    public function isLinkType($form)
	    {
	    	return $form->type == Triangle::$type;
	    }
	}
?>