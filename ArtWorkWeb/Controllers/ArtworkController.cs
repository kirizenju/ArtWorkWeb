using ArtWorkWeb.Service.Interfaces;
using BussinessTier;
using BussinessTier.Constants;
using BussinessTier.Payload;
using BussinessTier.Payload.ArtWork;
using Microsoft.AspNetCore.Mvc;

namespace ArtWorkWeb.Controllers
{
    public class ArtworkController : BaseController<ArtworkController>
    {
          private readonly IArtWorkService _artWorkService;

        public ArtworkController(ILogger<ArtworkController> logger, IArtWorkService artWorkService) : base(logger)
        {
            _artWorkService = artWorkService;
        }

        [HttpPost(ApiEndPointConstant.ArtWork.ArtWorksEndPoint)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateNewArtWork(CreateArtWorkRequest request)
        {
            var response = await _artWorkService.CreateNewArtwork(request);
            return Ok(response);
        }

        [HttpGet(ApiEndPointConstant.ArtWork.ArtWorksEndPoint)]
        [ProducesResponseType(typeof(GetArtWorkResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetArtWorks([FromQuery] ArtWorkFilter filter, [FromQuery] PagingModel pagingModel)
        {
            var response = await _artWorkService.GetArtWorks(filter, pagingModel);
            return Ok(response);
        }

        [HttpGet(ApiEndPointConstant.ArtWork.ArtWorkEndPoint)]
        [ProducesResponseType(typeof(GetArtWorkResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetArtWorkById(int id)
        {
            var response = await _artWorkService.GetArtWrokById(id);
            return Ok(response);
        }

        [HttpPut(ApiEndPointConstant.ArtWork.ArtWorkEndPoint)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateArtWorkInfo(int id, UpdateArtWorkRequest request)
        {
            var isSuccessful = await _artWorkService.UpdateArtWorkInfo(id, request);
            if (!isSuccessful) return Ok(MessageConstant.ArtWork.UpdateStatusFailedMessage);
            return Ok(MessageConstant.ArtWork.UpdateStatusSuccessMessage);
        }

        [HttpDelete(ApiEndPointConstant.ArtWork.ArtWorkEndPoint)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteArtWork(int id)
        {
            var isSuccessful = await _artWorkService.DeleteArtWork(id);
            if (!isSuccessful) return Ok(MessageConstant.ArtWork.UpdateStatusFailedMessage);
            return Ok(MessageConstant.ArtWork.UpdateStatusSuccessMessage);
        }
    }
    }
