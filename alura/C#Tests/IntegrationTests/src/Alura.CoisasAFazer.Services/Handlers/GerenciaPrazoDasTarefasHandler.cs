﻿using System;
using System.Linq;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;

namespace Alura.CoisasAFazer.Services.Handlers
{
    public class GerenciaPrazoDasTarefasHandler : IHandler
    {
        IRepositorioTarefas _repo;

        public GerenciaPrazoDasTarefasHandler(IRepositorioTarefas repo)
        {
            _repo = repo;
        }

        public ICommandResult Execute(GerenciaPrazoDasTarefas comando)
        {
            var agora = comando.DataHoraAtual;

            try {
                //pegar todas as tarefas não concluídas que passaram do prazo
                var tarefas = _repo
                    .ObtemTarefas(t => t.Prazo <= agora && t.Status != StatusTarefa.Concluida)
                    .ToList();

                //atualizá-las com status Atrasada
                tarefas.ForEach(t => t.Status = StatusTarefa.EmAtraso);

                //salvar tarefas
                _repo.AtualizarTarefas(tarefas.ToArray());
                
                return new CommandResult(true);
            }
            catch (Exception)
            {
                return new CommandResult(false);
            }
        }
    }
}
