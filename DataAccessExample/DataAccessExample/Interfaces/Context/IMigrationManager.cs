namespace DataAccessExample.Interfaces.Context
{
	public interface IMigrationManager
	{
		Task MigrateAsync(CancellationToken cancellationToken);
		Task<IDictionary<string, string[]>> GetPendingMigrationsAsync(CancellationToken cancellationToken);
		bool IsCorrectKey(string key);
	}
}
