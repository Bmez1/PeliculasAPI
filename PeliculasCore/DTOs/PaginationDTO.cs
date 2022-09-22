namespace PeliculasCore.DTOs;

public class PaginationDTO
{
    private const int _maximunNumberRecordsPage = 50;
    private int _numberRecordsPage { get; set; } = 10;
    
    public int Page { get; set; } = 1;
    public int NumberRecordsPage
    {
        get => _numberRecordsPage;
        set => _numberRecordsPage = value > _maximunNumberRecordsPage ? _maximunNumberRecordsPage : value;
    }
}