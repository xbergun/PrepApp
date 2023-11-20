using System.Text.Json.Serialization;
namespace NTT.Core.DTOs.Custom;

public class CustomResponseDto<T>
{
    public T Data { get; set; } = default!;

    [JsonIgnore]
    public int StatusCode { get; set; }

    public string Message { get; set; } = null!;
    
    public static CustomResponseDto<T> Success(int statusCode, T? data = default)
    {
        return new CustomResponseDto<T>
        {
            Data = data,
            StatusCode = statusCode,
            Message = "Success"
        };
    }
    
    public static CustomResponseDto<T> Error(int statusCode, T Data)
    {
        return new CustomResponseDto<T>
        {
            Data = Data,
            StatusCode = statusCode,
            Message = "Error"
        };
    }
    
    
    public static CustomResponseDto<T> NoContent(int statusCode)
    {
        return new CustomResponseDto<T>
        {
            
        };
    }
}