﻿using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ITituloService
    {
        Task<DBEntity> Create(TitulosEntity entity);
        Task<DBEntity> Delete(TitulosEntity entity);
        Task<IEnumerable<TitulosEntity>> Get();
        Task<TitulosEntity> GetById(TitulosEntity entity);
        Task<DBEntity> Update(TitulosEntity entity);
    }

    public class TituloService : ITituloService
    {
        private readonly IDataAccess sql;

        public TituloService(IDataAccess _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<TitulosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<TitulosEntity>("TituloObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<TitulosEntity> GetById(TitulosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<TitulosEntity>("TituloObtener", new
                {
                    entity.Id_Titulo
                }
                );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Create(TitulosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TituloInsertar", new
                {
                    entity.Descripcion,
                    entity.Estado
                }
                );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Update(TitulosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TituloActualizar", new
                {
                    entity.Id_Titulo,
                    entity.Descripcion,
                    entity.Estado
                }
                );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Delete(TitulosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TituloEliminar", new
                {
                    entity.Id_Titulo
                }
                );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
