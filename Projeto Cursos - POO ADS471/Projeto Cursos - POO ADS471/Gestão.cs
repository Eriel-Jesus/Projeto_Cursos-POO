using System;
using System.Linq;

namespace Projeto_Cursos___POO_ADS471
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Aluno(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Aluno(int id) : this(id, "") { }

        // Verifica se o aluno já atingiu o limite máximo de 6 disciplinas matriculadas em todos os cursos
        public bool PodeMatricular(Curso[] cursos)
        {
            int totalMatriculas = 0;

            foreach (var curso in cursos)
            {
                if (curso == null) continue;

                foreach (var disciplina in curso.Disciplinas)
                {
                    if (disciplina == null) continue;

                    if (disciplina.Alunos.Any(a => a != null && a.Id == this.Id))
                    {
                        totalMatriculas++;
                    }
                }
            }

            return totalMatriculas < 6;
        }

        public override bool Equals(object obj)
        {
            if (obj is Aluno outro)
                return this.Id == outro.Id;
            return false;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }

    public class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Aluno[] Alunos { get; private set; }

        public Disciplina(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Alunos = new Aluno[15]; // Limite máximo de 15 alunos por disciplina
        }

        public Disciplina(int id) : this(id, "") { }

        public bool MatricularAluno(Aluno aluno)
        {
            // Verifica se o aluno já está matriculado nesta disciplina
            if (Alunos.Any(a => a != null && a.Equals(aluno)))
                return false;

            // Encontra a primeira posição vaga no array
            for (int i = 0; i < Alunos.Length; i++)
            {
                if (Alunos[i] == null)
                {
                    Alunos[i] = aluno;
                    return true;
                }
            }

            return false; // Turma cheia
        }

        public bool DesmatricularAluno(Aluno aluno)
        {
            for (int i = 0; i < Alunos.Length; i++)
            {
                if (Alunos[i] != null && Alunos[i].Equals(aluno))
                {
                    Alunos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Disciplina outra)
                return this.Id == outra.Id;
            return false;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }

    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Disciplina[] Disciplinas { get; private set; }

        public Curso(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Disciplinas = new Disciplina[12]; // Limite máximo de 12 disciplinas por curso
        }

        public Curso(int id) : this(id, "") { }

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            if (PesquisarDisciplina(disciplina) != null)
                return false;

            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] == null)
                {
                    Disciplinas[i] = disciplina;
                    return true;
                }
            }

            return false;
        }

        public Disciplina PesquisarDisciplina(Disciplina disciplina)
        {
            return Disciplinas.FirstOrDefault(d => d != null && d.Equals(disciplina));
        }

        public bool RemoverDisciplina(Disciplina disciplina)
        {
            Disciplina d = PesquisarDisciplina(disciplina);
            if (d == null) return false;

            // Não pode remover se houver alunos matriculados
            if (d.Alunos.Any(a => a != null))
                return false;

            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Equals(disciplina))
                {
                    Disciplinas[i] = null;
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Curso outro)
                return this.Id == outro.Id;
            return false;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }

    public class Escola
    {
        public Curso[] Cursos { get; private set; }

        public Escola()
        {
            Cursos = new Curso[5]; // Limite máximo de 5 cursos
        }

        public bool AdicionarCurso(Curso curso)
        {
            if (PesquisarCurso(curso) != null)
                return false;

            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] == null)
                {
                    Cursos[i] = curso;
                    return true;
                }
            }

            return false;
        }

        public Curso PesquisarCurso(Curso curso)
        {
            return Cursos.FirstOrDefault(c => c != null && c.Equals(curso));
        }

        public bool RemoverCurso(Curso curso)
        {
            Curso c = PesquisarCurso(curso);
            if (c == null) return false;

            // Não pode remover se o curso tiver alguma disciplina cadastrada
            if (c.Disciplinas.Any(d => d != null))
                return false;

            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null && Cursos[i].Equals(curso))
                {
                    Cursos[i] = null;
                    return true;
                }
            }

            return false;
        }
    }
}