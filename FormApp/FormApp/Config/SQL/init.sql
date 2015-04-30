-- phpMyAdmin SQL Dump
-- version 3.1.5
-- http://www.phpmyadmin.net
--
-- Serveur: jonhcassi.sql.free.fr
-- Généré le : Jeu 30 Avril 2015 à 14:00
-- Version du serveur: 5.0.83
-- Version de PHP: 5.3.9

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
-- Base de données: `jonhcassi`
--

-- --------------------------------------------------------

--
-- Structure de la table `color`
--

CREATE TABLE IF NOT EXISTS `color` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(64) collate latin1_general_ci NOT NULL,
  `colorCode` int(11) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci AUTO_INCREMENT=1 ;

--
-- Contenu de la table `color`
--


-- --------------------------------------------------------

--
-- Structure de la table `form`
--

CREATE TABLE IF NOT EXISTS `form` (
  `id` int(11) NOT NULL auto_increment,
  `typeId` int(11) NOT NULL,
  `bgColorId` int(11) NOT NULL,
  `edgeColorId` int(11) NOT NULL,
  `edgeSize` tinyint(4) NOT NULL,
  `edgeType` tinyint(4) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Contenu de la table `form`
--


-- --------------------------------------------------------

--
-- Structure de la table `formType`
--

CREATE TABLE IF NOT EXISTS `formType` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(64) collate latin1_general_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci AUTO_INCREMENT=1 ;

--
-- Contenu de la table `formType`
--


-- --------------------------------------------------------

--
-- Structure de la table `own`
--

CREATE TABLE IF NOT EXISTS `own` (
  `idFather` int(11) NOT NULL,
  `idSon` int(11) NOT NULL,
  PRIMARY KEY  (`idFather`,`idSon`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Contenu de la table `own`
--

