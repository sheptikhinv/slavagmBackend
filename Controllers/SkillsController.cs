using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slavagmBackend.Models;
using slavagmBackend.Services;

namespace slavagmBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class SkillsController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetSkills()
    {
        return Ok(await _skillService.GetAllAsync());
    }

    [HttpGet("child/{id:int}")]
    public async Task<IActionResult> GetChild([FromRoute] int id)
    {
        return Ok(await _skillService.GetChildSkillByIdAsync(id));
    }

    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> AddSkill(CreateSkill skill)
    {
        return Ok(await _skillService.AddSkillAsync(skill));
    }

    [HttpPost("addChild")]
    [Authorize]
    public async Task<IActionResult> AddChildSkill(AddChild skill)
    {
        return Ok(await _skillService.AddChildSkillAsync(skill));
    }
}