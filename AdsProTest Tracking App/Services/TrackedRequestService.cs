using AdsProTest.Data;
using AdsProTest.Models;
using Dapper;

namespace AdsProTest.Services
{
    public class TrackedRequestService
    {
        private readonly DapperContext _context;
        public TrackedRequestService(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public async Task<bool> ContainsClientId(string clientId)
        {
            var query = $"SELECT  count(*)  FROM Requests  Where [ClientId] = '{clientId}'";
            using (var connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<int>(query)).ElementAt(0) > 0;
            }
        }
        public async Task<List<TrackedRequest>> GetRequests()
        {
            var query = "SELECT * FROM Requests";
            using (var connection = _context.CreateConnection())
            {
                var requests = await connection.QueryAsync<TrackedRequest>(query);
                return requests.ToList();
            }
        }
        public async Task<List<TrackedRequestGroupByCountry>> GetRequestsByCountry()
        {
            var query = "select ClientCountry, count(*) as [Requests] from dbo.Requests group by ClientCountry";
            using (var connection = _context.CreateConnection())
            {
                var requests = await connection.QueryAsync<TrackedRequestGroupByCountry>(query);
                return requests.ToList();
            }
        }

        public async Task InsertRequest(TrackedRequest request)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("INSERT INTO  [dbo].[Requests] ([ClientId],[SiteCountry],[ClientCountry],[ClientIp],[OS],[Domain]) " +
                    $"VALUES (@ClientId,@SiteCountry,@ClientCountry,@ClientIp,@OS,@Domain)", request);
            }
        }
    }
}
