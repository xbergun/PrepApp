using System.Text.Json.Serialization;
using NTT.Core.Enum;

namespace NTT.Core.DTOs.Custom;


//Response olarak tek model dönmek istiyorum. Response success de olsa fail de olsa tek model döneceğim.
public class CustomResponseDto<T>
{
    public T Data { get; set; } = default!;

    [JsonIgnore]
    public int StatusCode { get; set; }

    public string Message { get; set; } = null!;
    
    public static CustomResponseDto<T> Success(int statusCode, T data)
    {
        return new CustomResponseDto<T>
        {
            Data = data,
            StatusCode = statusCode,
            Message = "Success"
        };
    }
    
    public static CustomResponseDto<T> Success(int statusCode)
    {
        return new CustomResponseDto<T>
        {
            StatusCode = statusCode,
            Message = "Success"
        };
    }
    
    public static CustomResponseDto<T> Error(int statusCode, string message)
    {
        return new CustomResponseDto<T>
        {
            StatusCode = statusCode,
            Message = message
        };
    }
    
    public static CustomResponseDto<T> NoContent(int statusCode)
    {
        return new CustomResponseDto<T>
        {
           
        };
    }
}