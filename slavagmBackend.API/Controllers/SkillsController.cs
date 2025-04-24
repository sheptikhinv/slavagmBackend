using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slavagmBackend.API.DTOs.Skills;
using slavagmBackend.API.Mappers;
using slavagmBackend.Core.Services;

namespace slavagmBackend.API.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillsController(ISkillService skillService) : ControllerBase
{
    private readonly ISkillService _skillService = skillService;

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllSkills()
    {
        var skills = await _skillService.GetTopLevelAsync();
        var result = skills.Select(SkillMapper.ModelToOutputSkill);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSkillById(long id)
    {
        var skill = await _skillService.GetByIdAsync(id);
        var result = SkillMapper.ModelToOutputSkill(skill);
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateSkill([FromBody] CreateSkillDto dto)
    {
        var skill = SkillMapper.CreateSkillToModel(dto);
        await _skillService.AddAsync(skill);
        return Ok(skill);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSkill(long id, [FromBody] UpdateSkillDto dto)
    {
        var skill = SkillMapper.UpdateSkillToModel(id, dto);
        await _skillService.UpdateAsync(skill);
        return Ok(skill);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkill(long id)
    {
        await _skillService.DeleteAsync(id);
        return Ok();
    }
}