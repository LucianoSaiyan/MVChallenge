using Microsoft.Extensions.Logging;
using Project.Abtractions;
using Project.Entities.Model;
using Project.Shared;
//using Project.Application;

namespace Project.Services
{
    public interface IService<T> where T : class
    {
        ResponseService<T> GetResponse();
        ResponseService<List<T>> GetResponseList();
        ResponseService<int> GetResponseUpdateOrDelete();
    }
    public class UsuarioService : IService<Usuarios>
    {
        #region Variables and Properties
        
        //IApplication<Usuarios> _users;
        //IApplication<Pedido> _pedido;
        //private readonly IUsuariosApplication _usuariosapp;
        //private readonly IPedidoApplication _pedidosapp;
        //#endregion

        //#region Constructor

        //public UsuarioService(IApplication<Usuarios> users
        //                            , IApplication<Pedido> pedido
        //                            , IUsuariosApplication usuariosapp,
        //                                IPedidoApplication pedidosapp)
        //{
        //    _users = users;
        //    _pedido = pedido;
        //    _usuariosapp = usuariosapp;
        //    _pedidosapp = pedidosapp;
        //}


        #endregion


        public ResponseService<Usuarios> GetResponse()
        {
            throw new NotImplementedException();
        }

        public ResponseService<List<Usuarios>> GetResponseList()
        {
            throw new NotImplementedException();
        }

        public ResponseService<int> GetResponseUpdateOrDelete()
        {
            throw new NotImplementedException();
        }
    }


    //public class Application<T> : IApplication<T> where T : IEntity
    //{ 
    //}


    public interface IUsuarioService
    {

    }

    public class UsuarioServices
    {
        //public T GetOrSetCache<T>(string key, Func<T> func)
        //{
        //    T ret = default(T);
        //    string cache = Cache.Get(key);
        //    if (string.IsNullOrEmpty(cache))
        //    {
        //        ret = func();
        //        //LogHelper.Instance.Publish(Cache.Set(key, Serializer.SerializeJson(ret), TimeSpan.FromDays(_appSettings.Durability_Cache_Tables_in_Days)) ?
        //        $"Se grabo con exito en cache con la key {key} ---> {DateTime.Now}" :
        //            $"Error al grabar en cache la key {key} ---> {DateTime.Now}");
        //    }
        //    else
        //        ret = "";//Serializer.DeserializeJson<T>(cache);

        //    return ret;
        //}

        //subproductoByIdResultDTO = !string.IsNullOrEmpty(cache) ? GetOrSetCache(subproducto,
        //      () => { return subproductoByIdResultDTO; }) : subproductoByIdResultDTO;


        //public string SetCache(string key, object func)
        //{
        //    string cache = Cache.Get(key);
        //    if (string.IsNullOrEmpty(Cache.Get(key)))
        //    {
        //        LogHelper.Instance.Publish(Cache.Set(key, Serializer.SerializeJson(func), TimeSpan.FromDays(_appSettings.Durability_Cache_Tables_in_Days)) ?
        //            $"Se grabo con exito en cache con la key {key} ---> {DateTime.Now}" :
        //            $"Error al grabar en cache la key {key} ---> {DateTime.Now}");
        //    }

        //    return cache;
        //}

    }
}