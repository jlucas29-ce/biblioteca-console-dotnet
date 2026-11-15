CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;
CREATE TABLE `Livros` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Titulo` longtext NOT NULL,
    `Autor` longtext NOT NULL,
    `NmrPaginas` int NOT NULL,
    `Discriminator` varchar(13) NOT NULL,
    `TamanhoEmMB` double NULL,
    PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20261115185056_TransaçãoParaMySql', '10.0.12');

COMMIT;

