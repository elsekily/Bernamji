namespace Bernamji.DTOs.DTOs;

public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public ApiResponse()
    {

    }
    public ApiResponse(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
}