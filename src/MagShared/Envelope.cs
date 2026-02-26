namespace MagShared;

public record Envelope
{
    public object? Result { get;  }
   
    public ErrorMy? ErrorMy { get; set; }
    public DateTime TimeGenerated { get;  }

    private Envelope(object? result, ErrorMy? errorMy)
    {
        Result =result;
        ErrorMy = errorMy;
        TimeGenerated=DateTime.Now;
    }
    
    public static Envelope Ok(object? result)
    {
        return new Envelope(result, null);
    }
    
    public static Envelope Error(ErrorMy? errorMy)
    {
        return new Envelope( null, errorMy);
    }
}

public enum ErrorMyType
{
    Validation,
    NotFound,
    Failure,
    Conflict,
    None
    
}