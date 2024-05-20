CREATE PROCEDURE StoredListar AS
SELECT Nombre, Codigo,a.Descripcion,Precio,i.ImagenUrl,m.Descripcion AS Marca, a.IdCategoria,c.Descripcion AS Categoria,a.IdMarca,a.Id
FROM ARTICULOS a INNER JOIN MARCAS m ON m.Id = a.IdMarca INNER JOIN CATEGORIAS c ON c.Id = a.IdCategoria INNER JOIN IMAGENES i ON i.IdArticulo = a.Id
