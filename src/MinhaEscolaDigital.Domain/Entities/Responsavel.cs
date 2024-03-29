﻿using MinhaEscolaDigital.Domain.DomainObjects;
using MinhaEscolaDigital.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Responsavel : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public Responsavel()
        {
        }

        public Responsavel(string nome, DateTime dataNascimento, string rg, string cpf, string telefone, string celular, string email, string observacao)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg = new Rg(rg);
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            Telefone = new Telefone(telefone);
            Celular = new Telefone(celular);
            Observacao = new Observacao(observacao);
            AlunosResponsaveis = new List<AlunoResponsavel>();
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Rg Rg { get; private set; }
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public Telefone Celular { get; private set; }

        public Guid? ObservacaoId { get; private set; }

        public List<AlunoResponsavel> AlunosResponsaveis { get; set; }

        // EF Relação
        public Observacao Observacao { get; private set; }

        public void AtribuirAlunos(List<AlunoResponsavel> alunos)
        {
            AlunosResponsaveis = alunos;
        }

        public void Atualizar(string nome, DateTime dataNascimento, string rg, string cpf, string telefone, string celular, string email, string observacao)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg.Atualizar(rg);
            Cpf.Atualizar(cpf);
            Telefone.Atualizar(telefone);
            Celular.Atualizar(celular);
            Email.Atualizar(email);
            Observacao.Atualizar(observacao);
        }
    }
}
