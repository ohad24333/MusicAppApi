using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllPublishersAsync();
            if (publishers != null && publishers.Count > 0)
            {
                return Ok(publishers);
            }
            return NotFound();
        }


        [HttpGet("{publishername}")]
        public async Task<IActionResult> GetPublisher([FromRoute] string publishername)
        {
            var publisher = await _publisherRepository.GetPublisherAsync(publishername);
            if (publisher != null)
            {
                return Ok(publisher);
            }
            return NotFound();
        }
    }
}
