using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DependencyInjProject.Models;

namespace DependencyInjProject.Controllers;

public class HomeController : Controller
{
    private readonly IGuidGeneratorTransient _guidGeneratorTransient;
    private readonly IGuidGeneratorScoped _guidGeneratorScoped;
    private readonly IGuidGeneratorSingleton _guidGeneratorSingleton;

    public HomeController(IGuidGeneratorTransient guidGeneratorTransient, IGuidGeneratorScoped guidGeneratorScoped, IGuidGeneratorSingleton guidGeneratorSingleton)
    {
        _guidGeneratorTransient = guidGeneratorTransient;
        _guidGeneratorScoped = guidGeneratorScoped;
        _guidGeneratorSingleton = guidGeneratorSingleton;
    }

    public IActionResult Index()
    {
        // Her bir servis için yeni GUID
        var transientGuid = _guidGeneratorTransient.guid;  // Transient her defasında yeni GUID oluşturur
        var scopedGuid = _guidGeneratorScoped.guid;        // Scoped, aynı istek içinde aynı GUID'yi tutar
        var singletonGuid = _guidGeneratorSingleton.guid;  // Singleton, uygulama boyunca sabit kalır

        ViewBag.TransientGuid = transientGuid;
        ViewBag.ScopedGuid = scopedGuid;
        ViewBag.SingletonGuid = singletonGuid;

        return View();
    }


}
