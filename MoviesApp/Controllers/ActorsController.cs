﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApp.Data;
using MoviesApp.Filters;
using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.Services.Dto;
using MoviesApp.ViewModels.Actors;

namespace MoviesApp.Controllers;

public class ActorsController : Controller
{
    private readonly MoviesContext _context;
    private readonly ILogger<HomeController> _logger;
    private readonly IMapper _mapper;
    private readonly IActorService _service;


    public ActorsController(MoviesContext context, ILogger<HomeController> logger, IMapper mapper, IActorService service)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    // GET: Actor
    [HttpGet]
    public IActionResult Index()
    {
        var actors = _mapper.Map<IEnumerable<ActorDto>, IEnumerable<ActorViewModel>>(_service.GetAllActors());
        return View(actors);
    }

    // GET: Actor/Details/5
    [HttpGet]
    public IActionResult Details(int? id)
    {
        if (id == null) return NotFound();

        var viewModel = _mapper.Map<ActorViewModel>(_service.GetActor((int)id));

        if (viewModel == null) return NotFound();

        return View(viewModel);
    }

    // GET: Actor/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [FiltersAge(7, 99)]
    public IActionResult Create([Bind("FirstName, LastName, Birthday")] InputActorViewModel inputModel)
    {
        if (!ModelState.IsValid) return View(inputModel);
        _service.AddActor(_mapper.Map<ActorDto>(inputModel));
        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    // GET: Actor/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null) return NotFound();

        var editModel = _mapper.Map<EditActorViewModel>(_service.GetActor((int)id));

        if (editModel == null) return NotFound();

        return View(editModel);
    }

    // POST: Actor/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [FiltersAge(7, 99)]
    public IActionResult Edit(int id, [Bind("FirstName, LastName, Birthday")] EditActorViewModel editModel)
    {
        if (!ModelState.IsValid) return View(editModel);
        var actor = _mapper.Map<ActorDto>(editModel);
        actor.Id = id;
        var result = _service.UpdateActor(actor);
        if (result == null) return NotFound();
        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    // GET: Actor/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();

        var deleteModel = _mapper.Map<DeleteActorViewModel>(_service.GetActor((int)id));

        if (deleteModel == null) return NotFound();

        return View(deleteModel);
    }

    // POST: Actor/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var actor = _service.DeleteActor(id);
        
        _logger.LogTrace($"Actor with id {id} has been deleted!");
        return RedirectToAction(nameof(Index));
    }
}