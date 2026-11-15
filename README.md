# 📚 Estudos Biblioteca

Sistema de gerenciamento de biblioteca em **console (C# / .NET 10)**, criado para praticar lógica de programação, orientação a objetos e acesso a dados com **Entity Framework Core + SQLite**.

O usuário cadastra livros físicos e e-books, consulta o acervo e aplica filtros por meio de um menu interativo no terminal. Os dados ficam salvos em um banco SQLite local (`biblioteca.db`).

---

## ✨ Funcionalidades

- **Cadastro de livros** de dois tipos:
  - 📖 **Livro físico**: título, autor e número de páginas.
  - 📱 **E-book**: os mesmos dados, mais o tamanho do arquivo em MB.
- **Listagem do acervo** completo, com cada livro exibindo seus detalhes do seu próprio jeito.
- **Filtros**:
  - Busca por autor (sem diferenciar maiúsculas de minúsculas).
  - Livros longos (mais de 350 páginas).
- **Persistência** em SQLite via Entity Framework Core.
- **Notificação por evento** quando um livro é adicionado.
- **Validação** do número de páginas (valores menores ou iguais a zero são rejeitados).

---

## 🧰 Tecnologias

| Tecnologia | Uso |
|---|---|
| C# / .NET 10 | Linguagem e plataforma |
| Entity Framework Core 10 | ORM e migrações |
| SQLite | Banco de dados local em arquivo |
| LINQ | Consultas e filtros |

---

## 🧠 Conceitos praticados

- **Abstração e herança**: `Livro` é uma classe abstrata; `LivroFisico` e `Ebook` herdam dela.
- **Polimorfismo**: `ExibirDetalhes()` e `CalcularPreco()` são implementados de forma diferente em cada tipo de livro.
- **Interfaces**: `IBiblioteca` (contrato do serviço) e `IPromocional` (comportamento de cupom, usado pelo `Ebook`).
- **Injeção de dependência pelo construtor**: os menus recebem `IBiblioteca`, sem depender da implementação concreta.
- **Encapsulamento**: `NmrPaginas` tem validação no `set`.
- **Delegates e eventos**: `LivroAdicionadoHandler` e `OnLivroAdicionado`, com `Notificacao` como assinante.
- **Programação assíncrona**: `async`/`await` com `Task` (simulação de carregamento dos dados).
- **LINQ**: `Where`, `ToList` e comparações de texto.
- **Entity Framework Core**:
  - `DbContext` e `DbSet`.
  - Herança mapeada em **uma única tabela** (TPH), com a coluna `Discriminator`.
  - Migrações (`CriacaoInicial`).
- **Membros `required`** e `[SetsRequiredMembers]` para garantir objetos válidos com *nullable reference types* ativado.

---

## 🗂️ Estrutura do projeto

```
EstudosBiblioteca/
├── Program.cs               # Ponto de entrada
├── Menu.cs                  # Menu principal
├── MenuCadastro.cs          # Submenu de cadastro (físico / e-book)
├── MenuFiltro.cs            # Submenu de filtros (autor / livros longos)
├── Livro.cs                 # Classe abstrata base
├── LivroFisico.cs           # Livro físico (+ R$ 15,00 de frete no preço)
├── Ebook.cs                 # E-book (10% de desconto no preço)
├── IBiblioteca.cs           # Contrato do serviço da biblioteca
├── IPromocao.cs             # Interface IPromocional (cupom)
├── Biblioteca.cs            # Implementação do serviço + evento
├── Notificacao.cs           # Assinante do evento OnLivroAdicionado
├── BibliotecaContext.cs     # DbContext do EF Core (SQLite)
├── Migrations/              # Migrações do banco
├── Estudos.csproj           # Projeto .NET
└── biblioteca.db            # Banco SQLite
```

---

## 🗄️ Modelo de dados

A herança é salva em uma única tabela `Livros`:

| Coluna | Tipo | Observação |
|---|---|---|
| `Id` | INTEGER | Chave primária, autoincremento |
| `Titulo` | TEXT | Obrigatório |
| `Autor` | TEXT | Obrigatório |
| `NmrPaginas` | INTEGER | Obrigatório, maior que zero |
| `Discriminator` | TEXT | `LivroFisico` ou `Ebook` |
| `TamanhoEmMB` | REAL | Preenchido apenas para `Ebook` |

---

## ▶️ Como executar

### Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- (Opcional) Ferramenta do EF Core, para recriar o banco: `dotnet tool install --global dotnet-ef`

### Passo a passo

```bash
# 1. Clone o repositório
git clone <url-do-repositorio>
cd EstudosBiblioteca

# 2. Restaure as dependências
dotnet restore

# 3. Crie/atualize o banco (só é necessário se o biblioteca.db não existir)
dotnet ef database update

# 4. Execute
dotnet run
```

> O arquivo `biblioteca.db` é criado/lido na pasta onde o comando é executado, então rode `dotnet run` dentro da pasta do projeto.

No **Visual Studio**, basta abrir a solução e pressionar `F5` (ou `Ctrl+F5` para rodar sem depuração).

---

## 🖥️ Como usar

Ao iniciar, o menu principal é exibido:

```
=== MENU PRINCIPAL ===
1 - Cadastrar novo livro
2 - Filtar livros
3 - Verificar biblioteca
0 - Sair
======================
```

- **1 - Cadastrar novo livro**: escolha entre livro físico ou e-book e responda às perguntas.
- **2 - Filtrar livros**: busque por autor ou veja apenas os livros com mais de 350 páginas.
- **3 - Verificar biblioteca**: exibe todo o acervo cadastrado.
- **0 - Sair**: encerra o programa.

---

## 🚧 Próximos passos

Ideias de evolução para o projeto:

- [ ] Usar `CalcularPreco()` no sistema (hoje o cálculo existe, mas não aparece no menu).
- [ ] Implementar de fato o `AplicarCupom()` do e-book.
- [ ] Adicionar remoção e edição de livros.
- [ ] Validar entradas no cadastro (título/autor vazios, páginas inválidas).
- [ ] Incluir testes automatizados com xUnit.
- [ ] Injetar o `DbContext` de forma consistente em todo o serviço (hoje há mais de uma forma de acesso).
- [ ] Controle de empréstimos e usuários.
- [ ] Migrar para injeção de dependência com `Microsoft.Extensions.DependencyInjection`.

---

## 👤 Autor

**João Lucas Saraiva Farias**
Estudante de Engenharia de Software, em transição para o desenvolvimento back-end com .NET.

[GitHub](https://github.com/jlucas29-ce)
