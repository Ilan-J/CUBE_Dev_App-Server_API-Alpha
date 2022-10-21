CREATE DATABASE IF NOT EXISTS `test_grossiste_vin`;
USE `test_grossiste_vin`;

CREATE TABLE IF NOT EXISTS `supplier` (
    `pk_supplier` INT AUTO_INCREMENT,

    `name` VARCHAR(255) NOT NULL,
    `email` VARCHAR(255) NOT NULL,

    `address` VARCHAR(255),
    `postal_code` VARCHAR(5),
    `town` VARCHAR(255),

    PRIMARY KEY(`pk_supplier`)
);
CREATE TABLE IF NOT EXISTS `client` (
    `pk_client` INT AUTO_INCREMENT,

    `name` VARCHAR(255) NOT NULL,
    `surname` VARCHAR(255),

    `email` VARCHAR(255) NOT NULL,
    `password` VARCHAR(255) NOT NULL,

    `address` VARCHAR(255),
    `postal_code` VARCHAR(5),
    `town` VARCHAR(255),

    PRIMARY KEY(`pk_client`)
);

CREATE TABLE IF NOT EXISTS `wine_family` (
    `pk_wine_family` INT AUTO_INCREMENT,

    `name` VARCHAR(255) NOT NULL,

    PRIMARY KEY(`pk_wine_family`),
    UNIQUE(`name`)
);
CREATE TABLE IF NOT EXISTS `product` (
    `pk_product` INT AUTO_INCREMENT,

    `name` VARCHAR(255) NOT NULL,
    `reference` VARCHAR(255) NOT NULL,

    `price` INT NOT NULL,
    `tva` INT NOT NULL,

    `description` TEXT,
    `wine_date` TIMESTAMP,

    `stock` INT NOT NULL,
    `min_stock` INT,

    `fk_supplier` INT NOT NULL,
    `fk_wine_family` INT NOT NULL,

    PRIMARY KEY(`pk_product`),
    KEY `fk_supplier` (`fk_supplier`),
    KEY `fk_wine_family` (`fk_wine_family`),
    CONSTRAINT `product_ibfk_1` FOREIGN KEY(`fk_supplier`) REFERENCES `supplier` (`pk_supplier`),
    CONSTRAINT `product_ibfk_2` FOREIGN KEY(`fk_wine_family`) REFERENCES `wine_family` (`pk_wine_family`)
);

CREATE TABLE IF NOT EXISTS `supplier_command` (
    `pk_supplier_command` INT AUTO_INCREMENT,

    `buying_date` TIMESTAMP NOT NULL,

    `cost` DECIMAL NOT NULL,
    `transport_cost` DECIMAL,

    `fk_supplier` INT NOT NULL,

    PRIMARY KEY(`pk_supplier_command`),
    KEY `fk_supplier` (`fk_supplier`),
    CONSTRAINT `supplier_command_ibfk_1` FOREIGN KEY(`fk_supplier`) REFERENCES `supplier` (`pk_supplier`)
);
CREATE TABLE IF NOT EXISTS `client_command` (
    `pk_client_command` INT AUTO_INCREMENT,

    `buying_date` TIMESTAMP NOT NULL,

    `address` VARCHAR(255) NOT NULL,
    `postal_code` VARCHAR(5) NOT NULL,
    `town` VARCHAR(255) NOT NULL,

    `cost` DECIMAL NOT NULL,
    `transport_cost` DECIMAL,

    `fk_client` INT NOT NULL,

    PRIMARY KEY(`pk_client_command`),
    KEY `fk_client` (`fk_client`),
    CONSTRAINT `client_command_ibfk_1` FOREIGN KEY(`fk_client`) REFERENCES `client` (`pk_client`)
);

CREATE TABLE IF NOT EXISTS `supply_list` (
    `fk_product` INT NOT NULL,
    `fk_supplier_command` INT NOT NULL,

    `quantity` INT NOT NULL,

    KEY `fk_product` (`fk_product`),
    KEY `fk_supplier_command` (`fk_supplier_command`),
    CONSTRAINT `supply_list_ibfk_1` FOREIGN KEY(`fk_product`) REFERENCES `product` (`pk_product`),
    CONSTRAINT `supply_list_ibfk_2` FOREIGN KEY(`fk_supplier_command`) REFERENCES `supplier_command` (`pk_supplier_command`)
);
CREATE TABLE IF NOT EXISTS `purchase_list` (
    `fk_product` INT NOT NULL,
    `fk_client_command` INT NOT NULL,

    `quantity` INT NOT NULL,

    KEY `fk_product` (`fk_product`),
    KEY `fk_client_command` (`fk_client_command`),
    CONSTRAINT `purchase_list_ibfk_1` FOREIGN KEY (`fk_product`) REFERENCES `product` (`pk_product`),
    CONSTRAINT `purchase_list_ibfk_2` FOREIGN KEY (`fk_client_command`) REFERENCES `client_command` (`pk_client_command`)
);
