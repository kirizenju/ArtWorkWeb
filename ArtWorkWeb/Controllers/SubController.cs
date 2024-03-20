using ArtWorkWeb.Service.Interfaces;
using BussinessTier.Constants;
using BussinessTier.Payload.ArtWork;
using BussinessTier.Payload;
using BussinessTier;
using Microsoft.AspNetCore.Mvc;
using BussinessTier.Payload.Sub;

namespace ArtWorkWeb.Controllers
{
    public class SubController : BaseController<SubController>
    {
        private readonly ISubService _subService;

        public SubController(ILogger<SubController> logger, ISubService subService) : base(logger)
        {
            _subService = subService;
        }

        [HttpPost(ApiEndPointConstant.Sub.SubsEndPoint)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateNewSub(CreateSubRequest request)
        {
            var response = await _subService.CreateNewSub(request);
            return Ok(response);
        }

        //[HttpGet(ApiEndPointConstant.Sub.SubsEndPoint)]
        //[ProducesResponseType(typeof(GetSubscriptionResponse), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllSubs([FromQuery] SubFilter filter, [FromQuery] PagingModel pagingModel)
        //{
        //    var response = await _subService.GetAllSubs(filter, pagingModel);
        //   return Ok(response);
        //}

        [HttpGet(ApiEndPointConstant.Sub.SubEndPoint)]
        [ProducesResponseType(typeof(GetSubscriptionResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetArtWorkById(int id)
        {
            var response = await _subService.GetSubById(id);
            return Ok(response);
        }

        [HttpPut(ApiEndPointConstant.Sub.SubEndPoint)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateSubInfo(int id, UpdateSubscriptionRequest request)
        {
            var isSuccessful = await _subService.UpdateSubInfo(id, request);
            if (!isSuccessful) return Ok(MessageConstant.Sub.UpdateFailedMessage);
            return Ok(MessageConstant.Sub.UpdateSuccessMessage);
        }

        [HttpDelete(ApiEndPointConstant.Sub.SubEndPoint)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteSub(int id)
        {
            var isSuccessful = await _subService.DeleteSub(id);
            if (!isSuccessful) return Ok(MessageConstant.Sub.UpdateFailedMessage);
            return Ok(MessageConstant.Sub.UpdateSuccessMessage);
        }
    }
}
