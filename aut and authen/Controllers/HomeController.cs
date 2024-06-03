using aut_and_authen.AppModels;
using aut_and_authen.AppModels.CRUDOperation.Repository;
using aut_and_authen.Repository;
using Microsoft.AspNetCore.Mvc;

namespace aut_and_authen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly RepClass _configuration;
        public HomeController(RepClass confi)
        {
            _configuration = confi;
        }
        [HttpPost]
        [Route("userlogin")]
        public IActionResult userlogin([FromBody] PropertiesClass anu)
        {
            var recor = RepClass.login(anu);
            if (recor != null)
            {
                var token = _configuration.Getoken(recor);
                return Ok(token);

            }
            else
            {
                return BadRequest("invalids");
            }
        }
        [HttpPost]
        [Route("FileAppload")]
        public IActionResult AppClass([FromForm] iformClass fileModel)
        {
            if (fileModel == null || fileModel.filepath == null || fileModel.filepath.Length == 0)
            {
                return BadRequest("File not selected");
            }
            var filepath = RepositoryClass.Addmodel(fileModel.filepath);
            return Ok(filepath);
        }
        [HttpGet]
        [Route("DownloadFile/{Id}")]
        public IActionResult DownloadFile(int Id)
        {
            var file = RepositoryClass.download(Id);
            if (file == null)
            {
                return NotFound("File not Found");
            }
            var filePath = file.Filepath;
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);
            var ApploadFile = File(fileBytes, "application/octet-stream", fileName);

            return ApploadFile;
        }
        [HttpGet]
        [Route("download/{id}")]
        public IActionResult download(int id)

        {
            var recrd = RepositoryClass.download(id);
            if (recrd == null)
            {
                return NotFound("not foun");
            }
            var filepat = recrd.Filepath;
            var filebytes    =  System.IO.File.ReadAllBytes(filepat);
        }
    }
}
    