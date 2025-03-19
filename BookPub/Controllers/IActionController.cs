using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <include file='Documentation/Controllers/IActionController.xml' path='doc/iactioncontroller/member[@name="T:BookPub.Controllers.IActionController`1"]' />
    public interface IActionController<T>
    {
        /// <include file='Documentation/Controllers/IActionController.xml' path='doc/iactioncontroller/methods/member[@name="M:BookPub.Controllers.IActionController`1.GetAll"]' />
        public IActionResult GetAll();

        /// <include file='Documentation/Controllers/IActionController.xml' path='doc/iactioncontroller/methods/member[@name="M:BookPub.Controllers.IActionController`1.Get(System.Int32)"]' />
        public IActionResult Get(int id);

        /// <include file='Documentation/Controllers/IActionController.xml' path='doc/iactioncontroller/methods/member[@name="M:BookPub.Controllers.IActionController`1.Create(System.Object)"]' />
        public IActionResult Create(object item);

        /// <include file='Documentation/Controllers/IActionController.xml' path='doc/iactioncontroller/methods/member[@name="M:BookPub.Controllers.IActionController`1.Update(System.Int32,System.Object)"]' />
        public IActionResult Update(int id, object item);

        /// <include file='Documentation/Controllers/IActionController.xml' path='doc/iactioncontroller/methods/member[@name="M:BookPub.Controllers.IActionController`1.Delete(System.Int32)"]' />
        public IActionResult Delete(int id);
    }
}
