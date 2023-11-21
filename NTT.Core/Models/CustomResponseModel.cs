using System.Text.Json.Serialization;
namespace NTT.Core.DTOs.Custom;

public class CustomResponseModel<T>
{
    public T Data { get; set; } = default!;

    [JsonIgnore]
    public int StatusCode { get; set; }

    public string Message { get; set; } = null!;
    
    public static CustomResponseModel<T> Success(int statusCode, T data)
    {
        return new CustomResponseModel<T>
        {
            Data = data,
            StatusCode = statusCode,
            Message = "Success"
        };
    }
    
    public static CustomResponseModel<T> Error(int statusCode, T Data)
    {
        return new CustomResponseModel<T>
        {
            Data = Data,
            StatusCode = statusCode,
            Message = "Error"
        };
    }
    
    
    public static CustomResponseModel<T> NoContent(int statusCode)
    {
        return new CustomResponseModel<T>
        {
            
        };
    }
}