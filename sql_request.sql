-- Создание таблиц
Create TABLE categories (id int NOT Null IDENTITY(1,1) PRIMARY KEY, 
                      name nvarchar(500) NOT NULL);
                      
Create TABLE products (id int NOT Null IDENTITY(1,1) PRIMARY KEY, 
                      name nvarchar(500) NOT NULL);  
                      
Create Table product_categories (id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                product_id int not null,
                                category_id int not null);

-- Заполнение данными
insert into products (name) values('Prod1'), ('Prod2'), ('Prod3'), ('Prod4'), ('Prod5');
insert into categories (name) values('Cat1'), ('Cat2'), ('Cat3'), ('Cat4'), ('Cat5');
insert into product_categories (product_id, category_id) values(1, 1), (1, 2), (1, 3), (2, 1), (2, 2), (3, 1), (4, 3);

-- запрос

select p.Name as product_name, c.Name as category_name
from products p
LEFT JOIN product_categories pc on pc.product_id = p.id 
LEFT JOIN categories c on pc.category_id = c.id