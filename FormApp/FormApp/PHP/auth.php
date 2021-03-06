<?php
	$GLOBALS['authInfo'] = array(

		/*
		|--------------------------------------------------------------------------
		| PDO Fetch Style
		|--------------------------------------------------------------------------
		*/

		'fetch' => PDO::FETCH_CLASS,

		/*
		|--------------------------------------------------------------------------
		| Default Database Connection Name
		|--------------------------------------------------------------------------
		*/

		'default' => 'mysql',

		/*
		|--------------------------------------------------------------------------
		| Database Connections
		|--------------------------------------------------------------------------
		*/

		'connections' => array(
			'mysql' => array(
				'driver'    => 'mysql',
				'host'      => '127.0.0.1',
				'database'  => 'formapp',
				'username'  => 'root',
				'password'  => '',
				'charset'   => 'utf8',
				'collation' => 'utf8_unicode_ci',
				'prefix'    => '',
				)
			)
		);
?>