namespace Taller.Shared.DTOs;

public class PaginationDTO
{
    public int Id { get; set; }
    public int Page { get; set; } = 1;
    public int RecordNumber { get; set; } = 10;
}