namespace MagShared;

public static class ErrorsMy
{
   
    public static class General
    {
        public static ErrorMy ValueIsInavalid(string? name = null)
        {
            var label = name ?? "value";
            return ErrorMy.Validation("value.is.invalid", $"{label} is invalid");
        }

        public static ErrorMy NotFound(Guid? id = null)
        {
            var forId = id == null ? "value" : $" for id '{id}'";
            return ErrorMy.NotFound("record.is.found", $"Record not found id:{forId}");
        }

        public static ErrorMy ValueIsRequired(string? name = null)
        {
            var label = name == null ? "" : " " + name + " ";
            return ErrorMy.Validation("lenght.is.invalid", $"Invalid{label}length");
        }

        public static ErrorMy AllReadyExist()
        {
            return ErrorMy.Conflict("record.already.exist", $"Volunteer already exist");
        }
    }

    public static class Users
    {
        public static ErrorMy NotFound(string Email)
        {
            var email = Email == null ? "user" : $" for email '{Email}'";
            return ErrorMy.NotFound("user.is.found", $"User not found email:{email}");
        }
        
        public static ErrorMy Conflict(string Email)
        {
            var email = Email == null ? "user" : $" for email '{Email}'";
            return ErrorMy.Conflict("user.is.alreadyExist", $"User already exist, email:{email}");
        }
    }
}

public   class ErrorMy
{
    public string Code { get; init; }
    public string Message { get; set; }
    public ErrorMyType Type { get; set; }

    public  ErrorMy(string code, string message, ErrorMyType type)
    {
        Message = message;
        Code = code;
    }

    public static ErrorMy NotFound(string code,string message)
    {
        return new ErrorMy( code,  message, ErrorMyType.NotFound);
    }
    
    public static ErrorMy Validation(string code,string message)
    {
        return new ErrorMy( code,  message, ErrorMyType.Validation);
    }
    
    public static ErrorMy Failure(string code,string message)
    {
        return new ErrorMy( code,  message, ErrorMyType.Failure);
    }
    
    public static ErrorMy Conflict(string code,string message)
    {
        return new ErrorMy( code,  message, ErrorMyType.Conflict);
    }
    
    public static ErrorMy None(string code,string message)
    {
        return new ErrorMy( code,  message, ErrorMyType.None);
    }
    
    

}