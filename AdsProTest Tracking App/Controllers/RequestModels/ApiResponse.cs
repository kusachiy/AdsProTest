namespace AdsProTest.Controllers.RequestModels
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool HasError { get; set; }
    }
}
