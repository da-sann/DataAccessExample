using DataAccessExample.Entities;
using DataAccessExample.Interfaces.Uow;
using DataAccessExample.Models;
using DataAccessExample.Requests;
using Microsoft.AspNetCore.Mvc;
using DataAccessExample.Helpers;
using AutoMapper;
using DataAccessExample.Specifications;
using ApiExample.Validation;

namespace ApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
       
        private readonly ILogger<ExampleController> _logger;
        private readonly ISampleEntityRepository _sampleEntityUnitOfWork;
        private readonly IMapper _mapper;

        public ExampleController(ISampleEntityRepository sampleEntityUnitOfWork, IMapper mapper, ILogger<ExampleController> logger)
        {
            _sampleEntityUnitOfWork = sampleEntityUnitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet, Route("{id:guid}")]
		[ProducesResponseType(typeof(SampleModel), 200)]
		public async Task<IActionResult> GetEntity(Guid id, CancellationToken token) 
        {
            return Ok(await _sampleEntityUnitOfWork.GetQueryById(id).SingleAsync<SampleEntity, SampleModel>(token));
        }

        [HttpPost]
		[ProducesResponseType(typeof(SampleModel), 201)]
		[ProducesResponseType(typeof(ValidationResultModel), 400)]
		public async Task<IActionResult> CreateEntity(SampleCreateRequest createRequest, CancellationToken token)
        {
            var entity = _mapper.Map<SampleEntity>(createRequest);
     
            await _sampleEntityUnitOfWork.AddAsync(entity, token);
            await _sampleEntityUnitOfWork.SaveAsync(token);

            return Ok(entity.Id);
        }

		[HttpPut]
		[HttpPatch]
		[ProducesResponseType(typeof(SampleModel), 200)]
		[ProducesResponseType(typeof(ValidationResultModel), 400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> UpdateEntity(SampleUpdateRequest updateRequest, CancellationToken token)
        {
            var model = _sampleEntityUnitOfWork.Update(updateRequest.Id, e => _mapper.Map(updateRequest, e));

            await _sampleEntityUnitOfWork.SaveAsync(token);

            return Ok(await _sampleEntityUnitOfWork.GetQueryById(updateRequest.Id).SingleAsync<SampleEntity, SampleModel>(token));
        }

		[HttpDelete, Route("{id:guid}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> DeleteEntity(Guid id, CancellationToken token)
        {
            _sampleEntityUnitOfWork.Delete(id);

            await _sampleEntityUnitOfWork.SaveAsync(token);

            return Ok();
        }

        [HttpGet]
		[ProducesResponseType(typeof(PagedList<SampleModel>), 200)]
		public async Task<IActionResult> SearchEntities([FromQuery] SearchQuery query, CancellationToken token)
        {
            var search = new SampleSearch
            {
                Name = query.Name,
                DateProperty = query.Date,
                Page = query.Page,
                Size = query.Size,
                SortOrder = query.SortOrder,
                SortBy = query.SortBy
            };
            var result = await _sampleEntityUnitOfWork.Where(search.BuildCriteria()).ToLookupAsync<SampleEntity, SampleModel>(search, token);

            return Ok(result);
        }
    }
}