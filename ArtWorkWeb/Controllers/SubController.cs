using ArtWorkWeb.Service.Interfaces;
using BussinessTier.Constants;
using BussinessTier.Payload.ArtWork;
using BussinessTier.Payload;
using BussinessTier;
using Microsoft.AspNetCore.Mvc;

namespace ArtWorkWeb.Controllers
{
    public class SubController : BaseController<SubController>
    {
        private readonly ISubService _subService;

        public SubController(ILogger<SubController> logger, ISubService subService) : base(logger)
        {
            _subService = subService;
        }

        //[HttpPost(ApiEndPointConstant.ArtWork.ArtWorksEndPoint)]
        //[ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        //public async Task<IActionResult> CreateNewArtWork(CreateArtWorkRequest request)
        //{
        //    var response = await _artWorkService.CreateNewArtwork(request);
        //    return Ok(response);
        //}

        //[HttpGet(ApiEndPointConstant.ArtWork.ArtWorksEndPoint)]
        //[ProducesResponseType(typeof(GetArtWorkResponse), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllArtWorks([FromQuery] ArtWorkFilter filter, [FromQuery] PagingModel pagingModel)
        //{
        //    var response = await _artWorkService.GetAllArtWorks(filter, pagingModel);
        //    return Ok(response);
        //}

        //[HttpGet(ApiEndPointConstant.ArtWork.ArtWorkEndPoint)]
        //[ProducesResponseType(typeof(GetArtWorkResponse), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetArtWorkById(int id)
        //{
        //    var response = await _artWorkService.GetArtWrokById(id);
        //    return Ok(response);
        //}

        //[HttpPut(ApiEndPointConstant.ArtWork.ArtWorkEndPoint)]
        //[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        //public async Task<IActionResult> UpdateArtWorkInfo(int id, UpdateArtWorkRequest request)
        //{
        //    var isSuccessful = await _artWorkService.UpdateArtWorkInfo(id, request);
        //    if (!isSuccessful) return Ok(MessageConstant.ArtWork.UpdateStatusFailedMessage);
        //    return Ok(MessageConstant.ArtWork.UpdateStatusSuccessMessage);
        //}

        //[HttpDelete(ApiEndPointConstant.ArtWork.ArtWorkEndPoint)]
        //[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        //public async Task<IActionResult> DeleteArtWork(int id)
        //{
        //    var isSuccessful = await _artWorkService.DeleteArtWork(id);
        //    if (!isSuccessful) return Ok(MessageConstant.ArtWork.UpdateStatusFailedMessage);
        //    return Ok(MessageConstant.ArtWork.UpdateStatusSuccessMessage);
        //}
    }
}
