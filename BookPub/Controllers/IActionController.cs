using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// <c>IActionController</c> provides access to the general http requests for dependency injection purposes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IActionController<T>
    {
        public IActionResult GetAll();
        public Task<IActionResult> Get(int id);
        public IActionResult Create(object item);
        public IActionResult Update(int id, object item);
        public IActionResult Delete(int id);
    }
}
