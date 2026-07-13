namespace LibraryMVC.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
    }


    public class BaseResponse<T> : BaseResponse
    {
        public T? Data { get; set; }
    }
    
}
