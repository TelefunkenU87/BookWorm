using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BookWorm.DTO;
using BookWorm.DAL.Interfaces;

namespace BookWorm.DAL.Repositories
{
    public class SeriesRepo : ISeriesRepo
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public SeriesRepo(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }
        public SeriesDTO AddSeries(SeriesDTO addSeries)
        {
            var procedure = "spAddSeries";
            var parameters = new
            {
                @SeriesName = addSeries.SeriesName
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addSeries;
        }

        public int DeleteSeries(int seriesId)
        {
            throw new NotImplementedException();
        }

        public List<SeriesDTO> GetAllSeries()
        {
            var procedure = "spGetAllSeries";
            var series = new List<SeriesDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                series = conn.Query<SeriesDTO>(procedure).ToList();
            }
            return series;
        }

        public SeriesDTO GetLatestSeries()
        {
            var procedure = "spGetLatestSeries";
            var series = new SeriesDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                series = conn.QueryFirstOrDefault<SeriesDTO>(procedure, commandType: CommandType.StoredProcedure);
            }
            return series;
        }

        public SeriesDTO GetSeriesById(int seriesId)
        {
            var procedure = "spGetSeriesById";
            var parameters = new { @SeriesId = seriesId };
            var series = new SeriesDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                series = conn.QueryFirstOrDefault<SeriesDTO>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return series;
        }

        public SeriesDTO GetSeriesByName(string seriesName)
        {
            throw new NotImplementedException();
        }

        public SeriesDTO UpdateSeries(SeriesDTO updateSeries)
        {
            var procedure = "spUpdateSeries";
            var parameters = new
            {
                @Id = updateSeries.Id,
                @SeriesName = updateSeries.SeriesName
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updateSeries;
        }
    }
}
