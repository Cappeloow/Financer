using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _comment;

        public CommentController(ICommentRepository commentRepo)
        {
            _comment = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var comments = await _comment.GetAllAsync();
            var commentDto = comments.Select(x => x.ToCommentDto());
            return Ok(commentDto);
        }
    }
}