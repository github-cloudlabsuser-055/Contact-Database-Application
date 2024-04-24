using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            return View(userlist);

            

            
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            for (int i = 0; i < userlist.Count; i++)
            {
                if (userlist.ElementAt(i).Id == id)
                {
                    return View(userlist.ElementAt(i));
                }
            }
            return new HttpNotFoundResult();
        }
 
        // GET: User/Createc
        public ActionResult Create()
        {
            //Implement the Create method here
            User user = new User();
            return View(user);
        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            int greatestId = 0;
            for (int i = 0; i < userlist.Count; i++)
            {
                if (userlist.ElementAt(i).Id > greatestId)
                {
                    greatestId = userlist.ElementAt(i).Id;
                }
            }
            user.Id = greatestId + 1;
            userlist.Add(user);
            return RedirectToAction("Index");
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            for (int i = 0; i < userlist.Count; i++)
            {
                if (userlist.ElementAt(i).Id == id)
                {
                    return View(userlist.ElementAt(i));
                }
            }

            return new HttpNotFoundResult();
        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            for (int i = 0; i < userlist.Count; i++)
            {
                if (userlist.ElementAt(i).Id == id)
                {
                    userlist.ElementAt(i).Name = user.Name;
                    userlist.ElementAt(i).Email = user.Email;
                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();


        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            for (int i = 0; i < userlist.Count; i++)
            {
                if (userlist.ElementAt(i).Id == id)
                {
                    return View(userlist.ElementAt(i));
                }
            }

            return new HttpNotFoundResult();
        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            for (int i = 0; i < userlist.Count; i++)
            {
                if (userlist.ElementAt(i).Id == id)
                {
                    userlist.RemoveAt(i);
                    break;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
