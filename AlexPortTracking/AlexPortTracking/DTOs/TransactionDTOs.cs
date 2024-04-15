namespace AlexPortTracking.DTOs
{
    public record TransactionDTO(int Id,
        string Tag,
        int ReaderId,
        int CarId,
        int Count,
        DateTime LogTime,
        DateTime LastLogTime, 
        CarDTO Car);


    public record TransactionLogDTO(int Id, string Tag);
}
