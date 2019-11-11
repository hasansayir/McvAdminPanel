using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoApp303.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace ToDoApp303.Controllers
{
    public class TodoItemsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: TodoItems
        public async Task<ActionResult> Index()
        {
            var todoItems = db.TodoItems.Include(t => t.Category).Include(t => t.Customer).Include(t => t.Department).Include(t => t.Manager).Include(t => t.Organizator).Include(t => t.Side);
            return View(await todoItems.ToListAsync());
        }

        // GET: TodoItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }

        // GET: TodoItems/Create
        public ActionResult Create()
        {
            var todoItem = new TodoItem();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FiratName");
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FiratName");
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name");
            return View(todoItem);
        }

        // POST: TodoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Status,CategoryId,Attachment,DepartmentId,SideId,CustomerId,ManagerId,OrganizatorId,MeetingDate,PlannedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MaillingSubjects,PosterSubject,PosterCount,Elearning,TypeOfScans,AsoCountInScans,TypesOfOrganization,AsoCountInOrganizations,TypeOfVaccinationOrganizaition,AsoCountInVaccinationOrganization,AmountOfCompansationForPoster,CorporateProductivityReport,CreatData,CreatedBy,UpdateDate,UpdatedBy")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                todoItem.CreatData = DateTime.Now;
                todoItem.CreatedBy = User.Identity.Name;
                todoItem.UpdateDate = DateTime.Now;
                todoItem.UpdatedBy = User.Identity.Name;
                db.TodoItems.Add(todoItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FiratName", todoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FiratName", todoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoItem.SideId);
            return View(todoItem);
        }

        // GET: TodoItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FiratName", todoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FiratName", todoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoItem.SideId);
            return View(todoItem);
        }

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Status,CategoryId,Attachment,DepartmentId,SideId,CustomerId,ManagerId,OrganizatorId,MeetingDate,PlannedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MaillingSubjects,PosterSubject,PosterCount,Elearning,TypeOfScans,AsoCountInScans,TypesOfOrganization,AsoCountInOrganizations,TypeOfVaccinationOrganizaition,AsoCountInVaccinationOrganization,AmountOfCompansationForPoster,CorporateProductivityReport,CreatData,CreatedBy,UpdateDate,UpdatedBy")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                todoItem.CreatData = DateTime.Now;
                todoItem.CreatedBy = User.Identity.Name;
                todoItem.UpdateDate = DateTime.Now;
                todoItem.UpdatedBy = User.Identity.Name;
                db.Entry(todoItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoItem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoItem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoItem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FiratName", todoItem.ManagerId);
            ViewBag.OrganizatorId = new SelectList(db.Contacts, "Id", "FiratName", todoItem.OrganizatorId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoItem.SideId);
            return View(todoItem);
        }

        // GET: TodoItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            db.TodoItems.Remove(todoItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public void ExportToExcel()
        {
            var grid = new GridView();
            grid.DataSource = from s in db.TodoItems.ToList()
                              select new
                              {
                                  Baslik = s.Title,
                                  Aciklama = s.Description,
                                  Kategori = s.Category.Name,
                                  DosyaEki = s.Attachment,
                                  Departman = s.Department.Name,
                                  Taraf = s.Side.Name,
                                  Musteri = s.Customer.Name,
                                  Yonetici=s.Manager.FiratName+' '+s.Manager.LastName,
                                  Organizator=s.Organizator.FiratName+' '+s.Organizator.LastName,
                                  Durum=s.Status,
                                  ToplantiTarihi=s.MeetingDate,
                                  PlanlananTarih=s.PlannedDate,
                                  BitirilmeTarihi=s.FinishDate,
                                  RevizeTarihi=s.ReviseDate,
                                  GorusmeKonusu=s.ConversationSubject,
                                  DestekleyenFirma=s.SupporterCompany,
                                  DestekleyenHekim=s.SupporterDoctor,
                                  GorusmeKatilimciSayisi=s.ConversationAttendeeCount,
                                  PlanananOrganizasyonTarihi=s.ScheduledOrganizationDate,
                                  MailKonulari=s.MaillingSubjects,
                                  AfisKonusu=s.PosterSubject,
                                  AfisSayisi=s.PosterCount,
                                  UzaktanEgitim=s.Elearning,
                                  YapilanTaramalarınTurleri=s.TypeOfScans,
                                  YapilanTaramalardakiAsoSayisi=s.AsoCountInScans,
                                  OrganizasyonTuleri=s.TypesOfOrganization,
                                  OrganizasyondakiAsoSayisi=s.AsoCountInOrganizations,
                                  AsiOrganizasyonTurleri=s.TypeOfVaccinationOrganizaition,
                                  AsiOrgazasyonundakiAsoSayisi=s.AsoCountInVaccinationOrganization,
                                  AfisIcinTazminatMiktari=s.AmountOfCompansationForPoster,
                                  KurumsalVerimlilikRaporu=s.CorporateProductivityReport,
                                  OlusturulmaTarihi=s.CreatData,
                                  OlusturanKullanici=s.CreatedBy,
                                  GuncellemeTarihi=s.UpdateDate,
                                  GuncelleyenKullanici=s.UpdatedBy
                              };
            grid.DataBind();
            Response.Clear();
            var sure = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString()+ DateTime.Now.Year.ToString();
            Response.AddHeader("content-disposition",$"attachment;filename=yapilacaklar{sure}.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
