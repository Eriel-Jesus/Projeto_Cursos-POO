using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cursos___POO_ADS471
{
    class Program
    {
        static Escola escola = new Escola();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTÃO ESCOLAR ===");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso (mostrar inclusive as disciplinas associadas)");
                Console.WriteLine("3. Remover curso (não pode ter nenhuma disciplina associada)");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina (mostrar inclusive os alunos matriculados)");
                Console.WriteLine("6. Remover disciplina do curso (não pode ter nenhum aluno matriculado)");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno da disciplina");
                Console.WriteLine("9. Pesquisar aluno (informar seu nome e em quais disciplinas ele está matriculado)");
                Console.Write("\nEscolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                    opcao = -1;

                Console.WriteLine();
                ProcessarOpcao(opcao);

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        static void ProcessarOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1: AdicionarCurso(); break;
                case 2: PesquisarCurso(); break;
                case 3: RemoverCurso(); break;
                case 4: AdicionarDisciplina(); break;
                case 5: PesquisarDisciplina(); break;
                case 6: RemoverDisciplina(); break;
                case 7: MatricularAluno(); break;
                case 8: DesmatricularAluno(); break;
                case 9: PesquisarAluno(); break;
                case 0: Console.WriteLine("Encerrando programa..."); break;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        }

        static void AdicionarCurso()
        {
            Console.Write("ID do Curso: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Descrição do Curso: ");
            string desc = Console.ReadLine();

            if (escola.AdicionarCurso(new Curso(id, desc)))
                Console.WriteLine("Curso adicionado com sucesso!");
            else
                Console.WriteLine("Não foi possível adicionar o curso (limite atingido ou ID duplicado).");
        }

        static void PesquisarCurso()
        {
            Console.Write("ID do Curso a pesquisar: ");
            int id = int.Parse(Console.ReadLine());

            Curso c = escola.PesquisarCurso(new Curso(id));
            if (c != null)
            {
                Console.WriteLine($"\nCurso: [{c.Id}] {c.Descricao}");
                Console.WriteLine("Disciplinas:");
                bool possuiDisciplinas = false;
                foreach (var d in c.Disciplinas)
                {
                    if (d != null)
                    {
                        Console.WriteLine($"  - [{d.Id}] {d.Descricao}");
                        possuiDisciplinas = true;
                    }
                }
                if (!possuiDisciplinas) Console.WriteLine("  (Nenhuma disciplina cadastrada)");
            }
            else
            {
                Console.WriteLine("Curso não encontrado.");
            }
        }

        static void RemoverCurso()
        {
            Console.Write("ID do Curso a remover: ");
            int id = int.Parse(Console.ReadLine());

            if (escola.RemoverCurso(new Curso(id)))
                Console.WriteLine("Curso removido com sucesso!");
            else
                Console.WriteLine("Falha ao remover curso (curso inexistente ou contém disciplinas associadas).");
        }

        static void AdicionarDisciplina()
        {
            Console.Write("ID do Curso onde deseja adicionar a disciplina: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso c = escola.PesquisarCurso(new Curso(idCurso));

            if (c == null)
            {
                Console.WriteLine("Curso não encontrado!");
                return;
            }

            Console.Write("ID da Disciplina: ");
            int idDisc = int.Parse(Console.ReadLine());
            Console.Write("Descrição da Disciplina: ");
            string desc = Console.ReadLine();

            if (c.AdicionarDisciplina(new Disciplina(idDisc, desc)))
                Console.WriteLine("Disciplina adicionada com sucesso!");
            else
                Console.WriteLine("Não foi possível adicionar a disciplina (limite atingido ou ID duplicado no curso).");
        }

        static void PesquisarDisciplina()
        {
            Console.Write("ID da Disciplina a pesquisar: ");
            int idDisc = int.Parse(Console.ReadLine());

            foreach (var curso in escola.Cursos)
            {
                if (curso == null) continue;
                Disciplina d = curso.PesquisarDisciplina(new Disciplina(idDisc));
                if (d != null)
                {
                    Console.WriteLine($"\nDisciplina: [{d.Id}] {d.Descricao} (Curso: {curso.Descricao})");
                    Console.WriteLine("Alunos Matriculados:");
                    bool possuiAlunos = false;
                    foreach (var aluno in d.Alunos)
                    {
                        if (aluno != null)
                        {
                            Console.WriteLine($"  - [{aluno.Id}] {aluno.Nome}");
                            possuiAlunos = true;
                        }
                    }
                    if (!possuiAlunos) Console.WriteLine("  (Nenhum aluno matriculado)");
                    return;
                }
            }

            Console.WriteLine("Disciplina não encontrada em nenhum curso.");
        }

        static void RemoverDisciplina()
        {
            Console.Write("ID do Curso: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso c = escola.PesquisarCurso(new Curso(idCurso));

            if (c == null)
            {
                Console.WriteLine("Curso não encontrado!");
                return;
            }

            Console.Write("ID da Disciplina a remover: ");
            int idDisc = int.Parse(Console.ReadLine());

            if (c.RemoverDisciplina(new Disciplina(idDisc)))
                Console.WriteLine("Disciplina removida com sucesso!");
            else
                Console.WriteLine("Falha ao remover (disciplina não encontrada ou contém alunos matriculados).");
        }

        static void MatricularAluno()
        {
            Console.Write("ID da Disciplina em que deseja matricular o aluno: ");
            int idDisc = int.Parse(Console.ReadLine());

            Disciplina disciplinaEncontrada = null;
            foreach (var curso in escola.Cursos)
            {
                if (curso == null) continue;
                disciplinaEncontrada = curso.PesquisarDisciplina(new Disciplina(idDisc));
                if (disciplinaEncontrada != null) break;
            }

            if (disciplinaEncontrada == null)
            {
                Console.WriteLine("Disciplina não encontrada.");
                return;
            }

            Console.Write("ID do Aluno: ");
            int idAluno = int.Parse(Console.ReadLine());
            Console.Write("Nome do Aluno: ");
            string nome = Console.ReadLine();

            Aluno aluno = new Aluno(idAluno, nome);

            if (!aluno.PodeMatricular(escola.Cursos))
            {
                Console.WriteLine("Matrícula recusada: O aluno já atingiu o limite de 6 disciplinas matriculadas.");
                return;
            }

            if (disciplinaEncontrada.MatricularAluno(aluno))
                Console.WriteLine("Aluno matriculado com sucesso!");
            else
                Console.WriteLine("Falha ao matricular (turma cheia ou aluno já cadastrado na disciplina).");
        }

        static void DesmatricularAluno()
        {
            Console.Write("ID da Disciplina: ");
            int idDisc = int.Parse(Console.ReadLine());

            Disciplina disciplinaEncontrada = null;
            foreach (var curso in escola.Cursos)
            {
                if (curso == null) continue;
                disciplinaEncontrada = curso.PesquisarDisciplina(new Disciplina(idDisc));
                if (disciplinaEncontrada != null) break;
            }

            if (disciplinaEncontrada == null)
            {
                Console.WriteLine("Disciplina não encontrada.");
                return;
            }

            Console.Write("ID do Aluno a remover: ");
            int idAluno = int.Parse(Console.ReadLine());

            if (disciplinaEncontrada.DesmatricularAluno(new Aluno(idAluno)))
                Console.WriteLine("Aluno desmatriculado com sucesso!");
            else
                Console.WriteLine("Aluno não encontrado nesta disciplina.");
        }

        static void PesquisarAluno()
        {
            Console.Write("ID do Aluno a pesquisar: ");
            int idAluno = int.Parse(Console.ReadLine());

            string nomeAluno = null;
            bool matriculadoEmAlguma = false;

            foreach (var curso in escola.Cursos)
            {
                if (curso == null) continue;
                foreach (var d in curso.Disciplinas)
                {
                    if (d == null) continue;
                    foreach (var a in d.Alunos)
                    {
                        if (a != null && a.Id == idAluno)
                        {
                            if (nomeAluno == null)
                            {
                                nomeAluno = a.Nome;
                                Console.WriteLine($"\nAluno: [{a.Id}] {a.Nome}");
                                Console.WriteLine("Matriculado nas disciplinas:");
                            }
                            Console.WriteLine($"  - [{d.Id}] {d.Descricao} (Curso: {curso.Descricao})");
                            matriculadoEmAlguma = true;
                        }
                    }
                }
            }

            if (!matriculadoEmAlguma)
                Console.WriteLine("Aluno não encontrado ou não matriculado em nenhuma disciplina.");
        }
    }
}
