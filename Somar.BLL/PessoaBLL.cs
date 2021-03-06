﻿using Somar.DAL;
using Somar.DTO;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Somar.BLL
{
    public class PessoaBLL
    {
        public List<PessoaDTO> GetAllData()
        {
            PessoaDAL cmd = new PessoaDAL();
            return cmd.GetDataInDataBase(new PessoaDTO());
        }

        public List<PessoaDTO> GetDataWithParam(PessoaDTO _item)
        {
            PessoaDAL cmd = new PessoaDAL();
            return cmd.GetDataInDataBase(_item);
        }

        public PessoaDTO GetByID(PessoaDTO _pessoa)
        {
            PessoaDAL cmd = new PessoaDAL();

            var result = cmd.GetDataInDataBase(_pessoa);

            if (result.Count > 0)
            {
                if(result[0].idEndereco != 0)
                {
                    EnderecoDAL cmdEndereco = new EnderecoDAL();
                    result[0].endereco = cmdEndereco.GetEndereco(result[0].idEndereco);
                }

                if (result[0].idContato != 0)
                {
                    ContatoDAL cmdContato = new ContatoDAL();
                    result[0].contatos = cmdContato.GetContatos(result[0].idContato);
                }

                DadosVariaveisDAL cmdDados = new DadosVariaveisDAL();
                result[0].dadosVariaveis = cmdDados.GetDadosPorIdPessoa(_pessoa.idPessoa);

                return result.SingleOrDefault();
            }
            else
                throw new Exception("Ocorreu um erro!");
        }

        public int SavePessoa(PessoaDTO item)
        {
            PessoaDAL cmd = new PessoaDAL();
            EnderecoDAL cmdEndereco = new EnderecoDAL();
            ContatoDAL cmdContato = new ContatoDAL();
            DadosVariaveisDAL cmdDado = new DadosVariaveisDAL();

            int result = 0;
            int _idPessoa = 0;

            // *********************************************** //
            // ENDEREÇO
            // *********************************************** //
            if (item.idEndereco == 0)
            {
                result = cmdEndereco.InsertData(item.endereco);

                item.idEndereco = result;
            }
            else
            {
                item.endereco.idEndereco = item.idEndereco;

                result = cmdEndereco.UpdateData(item.endereco);
            }

            // *********************************************** //
            // CONTATO
            // *********************************************** //
            if (item.idContato == 0)
            {
                result = cmdContato.InsertData(item.contatos);

                item.idContato = result;
            }
            else
            {
                item.contatos.idContato = item.idContato;

                result = cmdContato.UpdateData(item.contatos);
            }

            // *********************************************** //
            // PESSOA
            // *********************************************** //
            if (item.idPessoa == 0)
            { 
                result = cmd.InsertData(item);
                _idPessoa = result;
            }
            else
            {
                result = cmd.UpdateData(item);

                if (result != 0)
                {
                    result = item.idPessoa;
                    _idPessoa = result;
                }
            }

            // *********************************************** //
            // DADOS VARIÁVEIS
            // *********************************************** //

            cmdDado.UpdateData(item.dadosVariaveis, _idPessoa);

            return result;
        }

        public int RemoveProject(PessoaDTO _projeto)
        {
            PessoaDAL cmd = new PessoaDAL();

            return cmd.UpdateData(_projeto);
        }

        public List<PessoaDTO> GetPessoasPorTipo(TipoPessoa idTipoPessoa)
        {
            PessoaDAL cmd = new PessoaDAL();
            return cmd.GetPessoasPorTipo(idTipoPessoa);
        }

        public List<PessoaDTO> GetAniversariantes()
        {
            PessoaDAL cmd = new PessoaDAL();
            return cmd.GetAniversariantes(new PessoaDTO());
        }

    }
}
