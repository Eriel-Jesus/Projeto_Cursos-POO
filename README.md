# Sistema de Gestão Escolar - POO

Um projeto de sistema de gerenciamento escolar desenvolvido em **C#** utilizando conceitos de **Programação Orientada a Objetos (POO)**. O sistema permite o cadastro, edição, pesquisa e remoção de cursos, disciplinas e alunos através de um menu interativo em linha de comando.

## 📋 Sobre o Projeto

Este é um projeto acadêmico (ADS471) que implementa um sistema completo de gestão escolar com validações e regras de negócio para manter a integridade dos dados.

## 🎯 Funcionalidades

### Gerenciamento de Cursos
- ✅ Adicionar novo curso
- ✅ Pesquisar curso (com visualização das disciplinas associadas)
- ✅ Remover curso (apenas se não houver disciplinas associadas)

### Gerenciamento de Disciplinas
- ✅ Adicionar disciplina em um curso
- ✅ Pesquisar disciplina (com visualização dos alunos matriculados)
- ✅ Remover disciplina (apenas se não houver alunos matriculados)

### Gerenciamento de Alunos
- ✅ Matricular aluno em uma disciplina
- ✅ Desmatricular aluno de uma disciplina
- ✅ Pesquisar aluno (com visualização de todas as disciplinas matriculadas)

## 🏗️ Arquitetura e Estrutura do Projeto

### Classe `Escola`
- Gerenciador central do sistema
- Armazena até 5 cursos

### Classe `Curso`
- Representa um curso
- Pode conter até 12 disciplinas

### Classe `Disciplina`
- Representa uma disciplina de um curso
- Pode ter até 15 alunos matriculados

### Classe `Aluno`
- Representa um estudante
- Pode estar matriculado em até 6 disciplinas no total (em qualquer curso)

## 📊 Limites do Sistema

| Entidade | Limite Máximo |
|----------|---------------|
| Cursos por escola | 5 |
| Disciplinas por curso | 12 |
| Alunos por disciplina | 15 |
| Disciplinas por aluno | 6 |

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET)
- **Padrão:** Console Application
- **Conceitos:** Programação Orientada a Objetos

## 📁 Estrutura de Arquivos

```
Projeto Cursos - POO ADS471/
├── Program.cs              # Menu principal e interface de usuário
├── Gestão.cs              # Classes do modelo (Escola, Curso, Disciplina, Aluno)
├── App.config             # Configurações da aplicação
└── Properties/            # Metadados do projeto
```

## 🚀 Como Usar

1. **Compilar o projeto**
   - Abra o arquivo `.sln` no Visual Studio
   - Compile a solução

2. **Executar a aplicação**
   - Execute o programa
   - Um menu interativo será exibido no console

3. **Navegar pelo menu**
   - Digite o número da opção desejada (0-9)
   - Siga as instruções na tela

### Exemplo de Fluxo

```
1. Adicionar um curso
2. Pesquisar o curso criado
3. Adicionar uma disciplina ao curso
4. Matricular alunos na disciplina
5. Pesquisar alunos para verificar suas inscrições
```

## ✨ Características de Validação

- **Prevenção de IDs duplicados:** Não permite cursos ou disciplinas com IDs repetidos
- **Integridade referencial:** Não permite remover cursos com disciplinas ou disciplinas com alunos
- **Limite de matrículas:** Alunos não podem se matricular em mais de 6 disciplinas
- **Limite de turma:** Disciplinas têm capacidade máxima de 15 alunos
- **Verificação de duplicatas:** Alunos não podem se matricular duas vezes na mesma disciplina

## 📝 Notas de Desenvolvimento

- O sistema utiliza arrays de tamanho fixo para armazenar entidades
- A busca de entidades é feita pelo ID
- O programa valida todas as operações antes de confirmar

## 👨‍💻 Autor

**Eriel Jesus**

---

**Última atualização:** Agosto 2026
