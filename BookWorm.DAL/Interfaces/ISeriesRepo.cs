using System.Collections.Generic;
using BookWorm.DTO;

namespace BookWorm.DAL.Interfaces
{
    public interface ISeriesRepo
    {
        SeriesDTO AddSeries(SeriesDTO addSeries);
        List<SeriesDTO> GetAllSeries();
        SeriesDTO GetSeriesById(int seriesId);
        SeriesDTO GetLatestSeries();
        SeriesDTO UpdateSeries(SeriesDTO updateSeries);
    }
}
