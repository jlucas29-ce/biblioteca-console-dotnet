-- Dados migrados do SQLite (biblioteca.db) para MySQL
-- Execute DEPOIS de aplicar as migrações (dotnet ef database update).
USE biblioteca;

INSERT INTO Livros (Id, Titulo, Autor, NmrPaginas, Discriminator, TamanhoEmMB) VALUES
(1, 'Clean Code', 'Robert C. Martin', 464, 'LivroFisico', NULL),
(2, 'Entendendo Algoritmos', 'Aditya Y. Bhargava', 256, 'Ebook', 1.8),
(3, 'Padrões de Projeto', 'Erich Gamma', 448, 'Ebook', 4.2),
(4, 'Domain-Driven Design', 'Eric Evans', 560, 'Ebook', 3.0),
(5, 'A Hora da Estrela', 'Clarice Lispector', 88, 'Ebook', 1.2),
(6, 'Memórias Póstumas de Brás Cubas', 'Machado de Assis', 208, 'Ebook', 2.5),
(7, 'O Alquimista', 'Paulo Coelho', 208, 'Ebook', 3.1),
(8, 'Triste Fim de Policarpo Quaresma', 'Lima Barreto', 240, 'Ebook', 1.9),
(9, 'Macunaíma', 'Mário de Andrade', 192, 'Ebook', 4.0),
(10, 'O Codificador Limpo', 'Robert C. Martin', 240, 'LivroFisico', NULL),
(11, 'Arquitetura Limpa', 'Robert C. Martin', 432, 'LivroFisico', NULL),
(12, 'Refatoração', 'Martin Fowler', 456, 'LivroFisico', NULL),
(13, 'Dom Casmurro', 'Machado de Assis', 256, 'LivroFisico', NULL),
(14, 'Grande Sertão: Veredas', 'João Guimarães Rosa', 600, 'LivroFisico', NULL),
(15, 'Vidas Secas', 'Graciliano Ramos', 176, 'LivroFisico', NULL),
(16, 'Capitães da Areia', 'Jorge Amado', 280, 'LivroFisico', NULL),
(17, 'O Cortiço', 'Aluísio Azevedo', 232, 'LivroFisico', NULL),
(18, 'As Cronicas do Orangotango Kershek', 'João Lucas Saraiva Farias', 400, 'LivroFisico', NULL),
(70, 'Mago Maneiro', 'Henry Kershek', 80, 'LivroFisico', NULL),
(71, 'Como o nazismo de consolidou', 'Mc PP da VS', 300, 'Ebook', 50.0),
(72, 'Diario de um canabico', 'Babizinha de mel', 30, 'Ebook', 40.0);

SELECT COUNT(*) AS total FROM Livros;
