﻿using MinhaEscolaDigital.Domain.DomainObjects;
using System;
using System.Collections.Generic;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Aluno : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public Aluno()
        {
        }

        public Aluno(string nome, DateTime dataNascimento, string rg, string cpf, string observacao)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg = new Rg(rg);
            Cpf = new Cpf(cpf);
            Observacao = new Observacao(observacao);
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Rg Rg { get; private set; }
        public Cpf Cpf { get; private set; }        

        public Guid TurmaId { get; private set; }
        public Guid EnderecoId { get; private set; }
        public Guid ObservacaoId { get; private set; }

        // EF Relação
        public Turma Turma { get; private set; }
        public Endereco Endereco { get; private set; }
        public Observacao Observacao { get; private set; }
        public List<AlunoResponsavel> AlunosResponsaveis { get; set; }
        public List<ResumoDia> Resumos { get; private set; }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
