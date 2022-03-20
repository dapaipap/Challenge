-- DROP DATABASE IF EXISTS `sql_dbpreguntas`;
-- CREATE DATABASE `sql_dbpreguntas`; 
USE `bdpreguntas`;

SET NAMES utf8;
SET character_set_client = utf8mb4;

CREATE TABLE `PreguntasND1`(
`Pregunta` varchar(50) NOT NULL,
`Respuesta` varchar(50) NOT NULL, 
PRIMARY KEY (`Pregunta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
INSERT INTO `PreguntasND1` VALUES ('Pregunta 1', 'Respuesta 1');
INSERT INTO `PreguntasND1` VALUES ('Pregunta 2', 'Respuesta 2');
INSERT INTO `PreguntasND1` VALUES ('Pregunta 3', 'Respuesta 3');
INSERT INTO `PreguntasND1` VALUES ('Pregunta 4', 'Respuesta 4');
INSERT INTO `PreguntasND1` VALUES ('Pregunta 5', 'Respuesta 5');

CREATE TABLE `PreguntasND2`(
`Pregunta` varchar(50) NOT NULL,
`Respuesta` varchar(50) NOT NULL, 
PRIMARY KEY (`Pregunta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
INSERT INTO `PreguntasND2` VALUES ('Pregunta 1', 'Respuesta 1');
INSERT INTO `PreguntasND2` VALUES ('Pregunta 2', 'Respuesta 2');
INSERT INTO `PreguntasND2` VALUES ('Pregunta 3', 'Respuesta 3');
INSERT INTO `PreguntasND2` VALUES ('Pregunta 4', 'Respuesta 4');
INSERT INTO `PreguntasND2` VALUES ('Pregunta 5', 'Respuesta 5');

CREATE TABLE `PreguntasND3`(
`Pregunta` varchar(50) NOT NULL,
`Respuesta` varchar(50) NOT NULL, 
PRIMARY KEY (`Pregunta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
INSERT INTO `PreguntasND3` VALUES ('Pregunta 1', 'Respuesta 1');
INSERT INTO `PreguntasND3` VALUES ('Pregunta 2', 'Respuesta 2');
INSERT INTO `PreguntasND3` VALUES ('Pregunta 3', 'Respuesta 3');
INSERT INTO `PreguntasND3` VALUES ('Pregunta 4', 'Respuesta 4');
INSERT INTO `PreguntasND3` VALUES ('Pregunta 5', 'Respuesta 5');

CREATE TABLE `PreguntasND4`(
`Pregunta` varchar(50) NOT NULL,
`Respuesta` varchar(50) NOT NULL, 
PRIMARY KEY (`Pregunta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
INSERT INTO `PreguntasND4` VALUES ('Pregunta 1', 'Respuesta 1');
INSERT INTO `PreguntasND4` VALUES ('Pregunta 2', 'Respuesta 2');
INSERT INTO `PreguntasND4` VALUES ('Pregunta 3', 'Respuesta 3');
INSERT INTO `PreguntasND4` VALUES ('Pregunta 4', 'Respuesta 4');
INSERT INTO `PreguntasND4` VALUES ('Pregunta 5', 'Respuesta 5');

CREATE TABLE `PreguntasND5`(
`Pregunta` varchar(50) NOT NULL,
`Respuesta` varchar(50) NOT NULL, 
PRIMARY KEY (`Pregunta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
INSERT INTO `PreguntasND5` VALUES ('Pregunta 1', 'Respuesta 1');
INSERT INTO `PreguntasND5` VALUES ('Pregunta 2', 'Respuesta 2');
INSERT INTO `PreguntasND5` VALUES ('Pregunta 3', 'Respuesta 3');
INSERT INTO `PreguntasND5` VALUES ('Pregunta 4', 'Respuesta 4');
INSERT INTO `PreguntasND5` VALUES ('Pregunta 5', 'Respuesta 5');


