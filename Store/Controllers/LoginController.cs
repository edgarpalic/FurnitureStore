using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Store.Models;

namespace Store.Controllers
{
    public class LoginController : Controller
    {

        public List<Furniture> Fur = Furniture.GetData(); 
        public UserData userdata;

        public ActionResult Clear() //A simple code to clear the purchase list when you finish your shopping.
        {
            userdata = UserData.GetUserData((int)Session["UserId"]);
                userdata.PurchaseList.Clear();
                UserData.SaveUserData(userdata);
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Buy(int id,string Page) //The main code in the shop which allows us to fill the shopping cart and save.
        {
            foreach (Furniture fur in Fur)
            {
                if (fur.Id == id)
                {
                    fur.BuyCount++; //Every purchase increases the buy count so that we can use it in the algorithm.
                    Furniture.SaveData(Fur);
                    userdata = UserData.GetUserData((int)Session["UserId"]);

                    if (userdata == null) userdata = UserData.UserList[(int)Session["UserId"]-1];

                    if (userdata.PurchaseList == null)//Make the shopping list.
                    {
                        userdata.PurchaseList = new List<UserData.Cart>();
                    }

                    userdata.PurchaseList.Add(new UserData.Cart { Id = fur.Id, Name = fur.Name, Price = fur.Price });//Fill the shopping list.
                    UserData.SaveUserData(userdata);
                }
            }
            return RedirectToAction(Page, "Home");
        }
        // GET: Login
        public ActionResult Index() //The log-in code. 
        {
            UserData CurrentUser = null; 
            if (Session["UserId"] != null)
            {
                CurrentUser = UserData.GetUserData((int)Session["UserId"]);
            }
            if (HttpContext.Request.RequestType == "POST")
            {
                var Email = Request.Form["email"];
                var Password = Request.Form["password"];

                CurrentUser = UserData.GetUserData(Email);
                if (CurrentUser != null && CurrentUser.Password == Password) //if username and password are correct we log in.
                {
                    Session["UserId"] = CurrentUser.userId;
                }
            }
            return View(CurrentUser);
        }

        public ActionResult Login() //This will keep us logged in
        {
            UserData CurrentUser;

            if (Session["UserId"] is int)
            {
                CurrentUser = UserData.GetUserData((int)Session["UserId"]);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return View(CurrentUser);
        }
    }
}