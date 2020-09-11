using System;
using System.Collections.Generic;
using System.Text;
using BookWorm.DTO;

namespace BookWorm.DAL.Interfaces
{
    public interface ISeriesRepo
    {
        SeriesDTO AddSeries(SeriesDTO addSeries);
        int DeleteSeries(int seriesId);
        List<SeriesDTO> GetAllSeries();
        SeriesDTO GetSeriesById(int seriesId);
        SeriesDTO GetSeriesByName(string seriesName);
        SeriesDTO GetLatestSeries();
        int UpdateSeries(SeriesDTO updateSeries);
    }
}
