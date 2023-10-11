using Project.Shared;

namespace Project.Service
{
    public interface IService<T> where T : class
    {
        Task<ResponseService<List<T>>> HttpGet();
        Task<ResponseService<T>> HttpGetId(int id);        
        Task<ResponseService<T>> HttpPost(T entityDTO);
        Task<ResponseService<T>> HttpPut(T entityDTO);
        Task<ResponseService<int>> HttpDelete(int id);
    }
}