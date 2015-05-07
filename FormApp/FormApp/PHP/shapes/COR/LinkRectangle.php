<?php
	class LinkRectangle extends HandlerShapesLink
	{
	    public function isLinkType($form)
	    {
	    	return $form->type == Rectangle::$type;
	    }
	}
?>