using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelManagement.Application.Commands;
using TravelManagement.Application.DTO;
using TravelManagement.Application.Queries;
using TravelManagement.Shared.Abstractions.Commands;
using TravelManagement.Shared.Commands;

namespace TravelManagement.Api.Controllers
{
    public class TravelCheckListController : BaseController
    {
        #region Constructor

        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public TravelCheckListController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        #endregion


        #region Get

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TravelCheckListDto>> Get([FromRoute] GetTravelCheckList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelCheckListDto>>> Get([FromQuery] SearchTravelCheckList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTravelCheckListWithItems command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }


        #endregion

        #region Put

        [HttpPut("{TravelCheckListId}/items")]
        public async Task<IActionResult> Put([FromBody] AddTravelerItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("{TravelCheckListId:guid}/items/{name}/Take")]
        public async Task<IActionResult> Put([FromBody] TakeItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        #endregion

        #region Delete

        [HttpDelete("{TravelCheckListId:guid}/items/{name}")]
        public async Task<IActionResult> Delete([FromBody] RemoveTravelerItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromBody] RemoveTravelCheckList command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        #endregion

    }
}
