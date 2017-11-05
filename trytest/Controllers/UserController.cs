using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trytest.Models;

namespace trytest.Controllers
{
    public class UserController : Controller
    {
        private Dbtest db = new Dbtest();

        //
        // GET: /User/
        public ActionResult Login(User user)
        {
            var urole = from u in db.UserRoleTable where u.UserRoleID == 1 select u;

            if (urole.Count() == 0)
            {
                UserRole userrole1 = new UserRole();
                userrole1.UserRoleID = 1;
                userrole1.UserRoleName = "Admin";
                UserRole userrole2 = new UserRole();
                userrole2.UserRoleID = 2;
                userrole2.UserRoleName = "WebAdmin";
                UserRole userrole3 = new UserRole();
                userrole3.UserRoleID = 3;
                userrole3.UserRoleName = "User";
                               
                db.UserRoleTable.Add(userrole1);
                db.UserRoleTable.Add(userrole2);
                db.UserRoleTable.Add(userrole3);
                db.SaveChanges();
            }

            var adm = from ad in db.UserTable where ad.UserRoleID == 1 select ad;
            if (adm.Count() == 0)
            {
                User admin = new User();
                admin.UserID = 1;
                admin.UserAge = 23;
                admin.UserEmail = "boss@supinfo.com";
                admin.UserRoleID = 1;
                admin.UserNickname = "boss";
                admin.UserPassword = "boss";
                admin.UserSex = "male";
                admin.UserName = "Alex";
                db.UserTable.Add(admin);
                db.SaveChanges();
                
            }

            if (ModelState.IsValid)
            {
                var judgeuser = from u in db.UserTable where u.UserName == user.UserName && u.UserPassword == user.UserPassword select u;
                if (judgeuser.Count() == 1)
                {

                    Session["SessionID"] = judgeuser.First().UserID;
                    Session["SessionName"] = judgeuser.First().UserName;
                    // Session["Admin"] = judgeperson.First().PersonRole.Role;
                    Session["UserRole"] = judgeuser.First().userrole.UserRoleID;
                    return RedirectToAction("Navigate", "User");
                }
                else { ModelState.AddModelError("", "The user login or password provided is incorrect."); }

            }
            return View(user);
        }

      //  public ActionResult FindFriend(User user)
      //  {
      //      ViewData["name"] = Request.Form["name"];
       //     string str = ViewData["name"].ToString();
        //    var certainfriend = from f in db.FriendTable
         //               where f.FriendName == str
        //                select f;
          
            
            
         //   return View(certainfriend.ToList());
        
       // }
        public ActionResult FindFriend()
        { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindFriend(User user)
        {
            if (ModelState.IsValid)
            {
                Session["inputname"] = user.UserName;
                return RedirectToAction("ShowCertainUser", "User");
            }
            else { ModelState.AddModelError("", "Please input again"); }
            return View(user);

            //if(ModelState.IsValid)
           // {
            //    string searchname = user.UserName;
            //    RedirectToAction("ShowCertainUser", "User", new { searchname });
            //}

           // return View(user);
        }
        public ActionResult ShowCertainUser()
        {
            string AcceptName=Session["inputname"].ToString();
            var certainuser = from u in db.UserTable
                                where u.UserName == AcceptName
                                select u;

            return View(certainuser.ToList());
        }

        public ActionResult Navigate()
        {
            return View();
        }

        public ActionResult AddFriend(int id = 0)
        {
            User user = db.UserTable.Find(id);
            if (ModelState.IsValid)
            {
                Friend friend = new Friend();
                friend.FriendID = user.UserID;
                friend.FriendName = user.UserName;
                friend.FriendNickname = user.UserNickname;
                friend.FriendPassword = user.UserPassword;
                friend.FriendSex = user.UserSex;
                friend.FriendEmail = user.UserEmail;
                friend.FriendAge = user.UserAge;
                //friend.friendrole.FriendRoleID = null;
             //   friend.friendrole.FriendRoleName = "User";
               


                db.FriendTable.Add(friend);
            


               db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        public ActionResult Index()
        {
            return View(db.UserTable.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.UserTable.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {

            Session["SessionID"] = user.UserID;
            Session["SessionName"] = user.UserName;
            if (ModelState.IsValid)
            {
                user.UserRoleID = 3;
                //user.userrole.UserRoleID = 3;
                //user.userrole.UserRoleName = "User";
                db.UserTable.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
              }
             else { ModelState.AddModelError("", "The user login or password provided is incorrect."); }

           

            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.UserTable.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                int userrolenum = int.Parse(Session["UserRole"].ToString());
                if (userrolenum != 1 && userrolenum != 2)
                {
                    user.UserRoleID = 3;
                    //user.userrole.UserRoleName = "User";
                }
                if (userrolenum != 1 && userrolenum != 3)
                {
                    user.UserRoleID = 2;
                    //  user.userrole.UserRoleName = "WebAdmin";
                }
       
                db.Entry(user).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.UserTable.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.UserTable.Find(id);
            db.UserTable.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}