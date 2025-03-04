using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    public interface IActionController<T>
    {
        public IActionResult GetAll();
        public Task<IActionResult> Get(int id);
        public IActionResult Create(object item);
        public IActionResult Update(int id, object item);
        public IActionResult Delete(int id);
    }
}
