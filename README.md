# StockSolution
Api con la información de productos en stock

Los siguientes son los scripts para la creación de la base de datos en sqlite:

sqlite3 stock.db

create table products(itemNo int primary key, name varchar(50), amount int, inventoryCode int);
