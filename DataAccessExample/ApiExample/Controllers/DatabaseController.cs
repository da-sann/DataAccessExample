using DataAccessExample.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;

namespace ApiExample.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DatabaseController : ControllerBase
	{
		public DatabaseController(IMigrationManager migrationManager)
		{
			_migrationManager = migrationManager;
		}
		private readonly IMigrationManager _migrationManager;

		[HttpGet]
		public async Task<IActionResult> Index([FromHeader(Name = "Password")] string password, CancellationToken cancellationToken)
		{
			if (!_migrationManager.IsCorrectKey(password))
				return Forbid();
			var result = await _migrationManager.GetPendingMigrationsAsync(cancellationToken);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromHeader(Name = "Password")] string password, CancellationToken cancellationToken)
		{
			if (!_migrationManager.IsCorrectKey(password))
				return Forbid();
			await _migrationManager.MigrateAsync(cancellationToken);
			return await Index(password, cancellationToken);
		}
	}
}
