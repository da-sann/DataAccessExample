# DataAccessExample

Usage example
```c
private readonly ISampleEntityUnitOfWork _sampleEntityUnitOfWork;
        private readonly IMapper _mapper;

        public ExampleController(ISampleEntityUnitOfWork sampleEntityUnitOfWork, IMapper mapper, ILogger<ExampleController> logger)
        {
            _sampleEntityUnitOfWork = sampleEntityUnitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet, Route("{id:guid}")]
        public async Task<IActionResult> GetEntity(Guid id, CancellationToken token) 
        {
            return Ok(await _sampleEntityUnitOfWork.GetQueryById(id).SingleAsync<SampleEntity, SampleModel>(token));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(SampleCreateRequest createRequest, CancellationToken token)
        {
            var entity = _mapper.Map<SampleEntity>(createRequest);
     
            await _sampleEntityUnitOfWork.AddAsync(entity, token);
            await _sampleEntityUnitOfWork.SaveAsync(token);

            return Ok(entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntity(SampleUpdateRequest updateRequest, CancellationToken token)
        {
            var model = _sampleEntityUnitOfWork.Update(updateRequest.Id, e => _mapper.Map(updateRequest, e));

            await _sampleEntityUnitOfWork.SaveAsync(token);

            return Ok(await _sampleEntityUnitOfWork.GetQueryById(updateRequest.Id).SingleAsync<SampleEntity, SampleModel>(token));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEntity(Guid id, CancellationToken token)
        {
            _sampleEntityUnitOfWork.Delete(id);

            await _sampleEntityUnitOfWork.SaveAsync(token);

            return Ok();
        }

        [HttpGet]
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
```
