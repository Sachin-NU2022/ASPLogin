using CrudLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CrudLogin.Controllers;
[Authorize]
public class ContactController : Controller
{
    private readonly CrudLoginContext _crudcontext;
    public ContactController(CrudLoginContext context)
    {
        _crudcontext = context;
    }

    public IActionResult Index()
    {
        return View(_crudcontext.Contact.ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _crudcontext.Add(contact);
            _crudcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    [HttpGet]
    public IActionResult Edit(int Id)
    {
        var con = _crudcontext.Contact.Find(Id);
        return View(con);
    }

    [HttpPost]
    public IActionResult Edit(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _crudcontext.Contact.Update(contact);
            _crudcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    public IActionResult Delete(int Id)
    {
        var con = _crudcontext.Contact.Find(Id);
        if (con != null)
        {
            _crudcontext.Contact.Remove(con);
        }
        _crudcontext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Read(int Id)
    {
        var con = _crudcontext.Contact.Find(Id);
        return View(con);
    }

}


