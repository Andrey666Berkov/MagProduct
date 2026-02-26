using Microsoft.AspNetCore.Mvc;

namespace MagShared;

public  static class Result
{
    public static OkObjectResult Ok(this OkObjectResult result, object obj)
    {
        return new OkObjectResult(Envelope.Ok(obj));
    }
    
    public static ObjectResult Ok(this ObjectResult result, object obj)
    {
        return new ObjectResult(Envelope.Ok(obj));
    }
    public static ObjectResult Ok(this ObjectResult result, ErrorMy errorMy)
    {
        return new ObjectResult(Envelope.Error(errorMy));
    }
}